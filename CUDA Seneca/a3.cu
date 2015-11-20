/*
//****************************************************************************80
//
//  Purpose:
//
//    MAIN is the main program for HEATED_PLATE.
//
//  Discussion:
//
//    This code solves the steady state heat equation on a rectangular region.
//
//    The sequential version of this program needs approximately
//    18/epsilon iterations to complete.
//
//
//    The physical region, and the boundary conditions, are suggested
//    by this diagram;
//
//                   W = 0
//             +------------------+
//             |                  |
//    W = 100  |                  | W = 100
//             |                  |
//             +------------------+
//                   W = 100
//
//    The region is covered with a grid of M by N nodes, and an N by N
//    array W is used to record the temperature.  The correspondence between
//    array indices and locations in the region is suggested by giving the
//    indices of the four corners:
//
//                  I = 0
//          [0][0]-------------[0][N-1]
//             |                  |
//      J = 0  |                  |  J = N-1
//             |                  |
//        [M-1][0]-----------[M-1][N-1]
//                  I = M-1
//
//    The steady state solution to the discrete heat equation satisfies the
//    following condition at an interior grid point:
//
//      W[Central] = (1/4) * ( W[North] + W[South] + W[East] + W[West] )
//
//    where "Central" is the index of the grid point, "North" is the index
//    of its immediate neighbor to the "north", and so on.
//
//    Given an approximate solution of the steady state heat equation, a
//    "better" solution is given by replacing each interior point by the
//    average of its 4 neighbors - in other words, by using the condition
//    as an ASSIGNMENT statement:
//
//      W[Central]  <=  (1/4) * ( W[North] + W[South] + W[East] + W[West] )
//
//    If this process is repeated often enough, the difference between successive
//    estimates of the solution will go to zero.
//
//    This program carries out such an iteration, using a tolerance specified by
//    the user, and writes the final estimate of the solution to a file that can
//    be used for graphic processing.
//
//  Licensing:
//
//    This code is distributed under the GNU LGPL license.
//
//  Modified:
//
//    22 July 2008
//
//  Author:
//
//    Original C version by Michael Quinn.
//    C++ version by John Burkardt.
//
//  Reference:
//
//    Michael Quinn,
//    Parallel Programming in C with MPI and OpenMP,
//    McGraw-Hill, 2004,
//    ISBN13: 978-0071232654,
//    LC: QA76.73.C15.Q55.
//
//  Parameters:
//
//    Commandline argument 1, float EPSILON, the error tolerance.
//
//    Commandline argument 2, char *OUTPUT_FILENAME, the name of the file into which
//    the steady state solution is written when the program has completed.
//
//  Local parameters:
//
//    Local, float DIFF, the norm of the change in the solution from one iteration
//    to the next.
//
//    Local, float MEAN, the average of the boundary values, used to initialize
//    the values of the solution in the interior.
//
//    Local, float U[M][N], the solution at the previous iteration.
//
//    Local, float W[M][N], the solution computed at the latest iteration.
//
//****************************************************************************80
*/
# include <cstdlib>
# include <iostream>
# include <iomanip>
# include <fstream>
# include <cmath>
# include <ctime>
# include <string>
# include <cuda_runtime.h>

using namespace std;
# define M 1000
# define N 1000


/*float ctime;
float ctime1;
float ctime2;*/


//__device__ float *h_Diff;

ofstream output;
char output_filename[80];
FILE *fp;

int i;
int iterations;
int iterations_print;
int j;
int success;

const int ntpb = 32;

float mean;
float diff;
float epsilon;
float u[M*N];
float w[M*N];

void setBoundaryValue();
void setAverageBoundary();
void writeToFile();
void getHeat();
int main(int argc, char *argv[]);
float cpu_time();

__global__ void copyMat(const float *w, float *u){
	int i = blockIdx.x * blockDim.x + threadIdx.x;
	int j = blockIdx.y * blockDim.y + threadIdx.y;
	if (i < M && j < N) {
		u[i * M + j] = w[i * M + j];
	}
	__syncthreads();
}
__global__ void calcHeat(float *w, float *u, float *d, int m, int n, float* d_array){
	int i = blockIdx.x * blockDim.x + threadIdx.x;
	int j = blockIdx.y * blockDim.y + threadIdx.y;
	int tx = threadIdx.x;
	int ty = threadIdx.y;

	__shared__ float s_u[ntpb][ntpb];
	__shared__ float s_w[ntpb][ntpb];
	__shared__ float s_dif[ntpb][ntpb];
	if (tx < ntpb && ty < ntpb) {
		s_w[ty][tx] = w[j * M + i];
		s_u[ty][tx] = w[j * M + i];
	}
	__syncthreads();

	if ( ( tx < (ntpb-1) && ty < (ntpb-1) ) && ( tx >0 && ty > 0 ) && ( i < M && j < N ) ) {
		s_w[ty][tx] = ( s_u[ty - 1][tx] + s_u[ty + 1][tx] + s_u[ty][tx - 1] + s_u[ty][tx + 1] ) / 4.0;

		s_dif[ty][tx] = fabsf(s_w[ty][tx] - s_u[ty][tx]);

		//if (s_dif[ty][tx] < 0){ s_dif[ty][tx] *= -1; }
	}
	__syncthreads();
	if (tx < ntpb && ty < ntpb) {
		w[j * M + i] = s_w[ty][tx];
		//u[j * M + i] = s_w[ty][tx];
		d_array[j * M + i] = s_dif[ty][tx];
	}
	__syncthreads();
}
__global__ void bigDiff(float* d_array, float* d, int m, int n){
	int i = blockIdx.x * blockDim.x + threadIdx.x;

	for (int x = 1; i + x < m*n; x *= 2) {
		if (d_array[i] > *d || d_array[i + x] > *d){
			if (d_array[i] > d_array[i + x])
				*d = d_array[i];
			else
				*d = d_array[i + x];
		}
		__syncthreads();
	}
}

void setBoundaryValue(){
	for (i = 1; i < M - 1; i++)
	{
		w[i*M] = 100.0;
	}
	for (i = 0; i < M - 1; i++)
	{
		w[i * M + N - 1] = 100.0;
	}
	for (j = 0; j < N; j++)
	{
		w[M - 1 + j] = 100.0;
	}
	for (j = 0; j < N; j++)
	{
		w[j] = 0.0;
	}
}
void setAverageBoundary(){
	mean = 0.0;
	for (i = 1; i < M - 1; i++)
	{
		mean = mean + w[i*M];
	}
	for (i = 1; i < M - 1; i++)
	{
		mean = mean + w[i * M + N - 1];
	}
	for (j = 0; j < N; j++)
	{
		mean = mean + w[M - 1 + j];
	}
	for (j = 0; j < N; j++)
	{
		mean = mean + w[j];
	}
	mean = mean / (float)(2 * M + 2 * N - 4);
	// 
	//  Initialize the interior solution to the mean value.
	//
	for (i = 1; i < M - 1; i++)
	{
		for (j = 1; j < N - 1; j++)
		{
			w[i * M + j] = mean;
		}
	}
}
void writeToFile(){
	/*
	output.open(output_filename);

	output << M << "\n";
	output << N << "\n";

	for (i = 0; i < M; i++)
	{
	for (j = 0; j < N; j++)
	{
	output << "  " << w[i * M + j];
	}
	output << "\n";
	}
	output.close();

	cout << "\n";
	cout << "  Solution written to the output file \"" << output_filename << "?\"?\n";
	*/
}

void getHeat(){
	float* d_u; // old device matrix
	float* d_w; // new device matrix
	float* d_d; // device difference matrix
	float* d_Diff; // device difference value

	cudaMalloc((void**)&d_u, M * N * sizeof(float));
	cudaMalloc((void**)&d_w, M * N * sizeof(float));
	cudaMalloc((void**)&d_d, M * N * sizeof(float));
	cudaMalloc((void**)&d_Diff, sizeof(float));

	cudaMemcpy(d_w, w, M * N * sizeof(float), cudaMemcpyHostToDevice);

	int nbx = (M + ntpb - 1) / ntpb;
	int nby = (N + ntpb - 1) / ntpb;
	dim3 dGrid(nbx, nby);
	dim3 dBlock(ntpb, ntpb);

	iterations = 0;
	iterations_print = 1;
	cout << "\n";
	cout << " Iteration  Change\n";
	cout << "\n";

	while (epsilon <= diff)
	{
		//
		//  Save the old solution in U.
		//
		//  Determine the new estimate of the solution at the interior points.
		//  The new solution W is the average of north, south, east and west neighbors.
		//

		calcHeat << <dGrid, dBlock >> >(d_w, d_u, d_Diff, M, N, d_d);
		bigDiff << <1, dBlock >> >(d_d, d_Diff, M, N);
		cudaMemcpy(&diff, d_Diff, sizeof(float), cudaMemcpyDeviceToHost);

		iterations++;
		if (iterations == iterations_print)
		{
			cout << "  " << setw(8) << iterations
				<< "  " << diff << "\n";
			iterations_print = 2 * iterations_print;
		}
	}
	cudaMemcpy(w, d_w, M * N * sizeof(float), cudaMemcpyDeviceToHost);

	cudaFree(d_w);
	cudaFree(d_u);
	cudaFree(d_d);
	cudaFree(d_Diff);
	cudaDeviceReset();
}


int main(int argc, char *argv[]){
	epsilon = 0.001f;
	diff = epsilon;
	// 
	//  Set the boundary values, which don't change. 
	//
	setBoundaryValue();
	//
	//  Average the boundary values, to come up with a reasonable
	//  initial value for the interior.
	// 
	setAverageBoundary();
	//
	//  iterate until the  new solution W differs from the old solution U
	//  by no more than EPSILON.
	//
	//ctime1 = cpu_time();

	getHeat();

	//ctime2 = cpu_time();
	//ctime = ctime2 - ctime1;

	cout << "\n";
	cout << "  " << setw(8) << iterations
		<< "  " << diff << "\n";
	cout << "\n";
	cout << "  Error tolerance achieved.\n";
	//	cout << "  CPU time = " << ctime << "\n";
	// 
	//  Write the solution to the output file.
	//
	//writeToFile();
	// 
	//  Terminate.
	//
	cout << "\n";
	cout << "HEATED_PLATE:\n";
	cout << "  Normal end of execution.\n";

	return 0;

# undef M
# undef N
}
//****************************************************************************80

float cpu_time()

//****************************************************************************80
//
//  Purpose:
//
//    CPU_TIME returns the current reading on the CPU clock.
//
//  Licensing:
//
//    This code is distributed under the GNU LGPL license. 
//
//  Modified:
//
//    06 June 2005
//
//  Author:
//
//    John Burkardt
//
//  Parameters:
//
//    Output, float CPU_TIME, the current reading of the CPU clock, in seconds.
//
{
	float value;

	value = (float)clock() / (float)CLOCKS_PER_SEC;

	return value;
}