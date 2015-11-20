#include <iostream>
#include <ctime>
#include <chrono>
#include <cstdlib>
using namespace std::chrono;

void init(float* a, int n) {
    const float randf = 1.0f / (float) RAND_MAX;
    for (int i = 0; i < n; i++)
        a[i] = std::rand() * randf;
}

void reportTime(const char* msg, steady_clock::duration span) {
    double nsecs = double(span.count()) *
            steady_clock::period::num / steady_clock::period::den;
    std::cout << std::fixed;
    std::cout << msg << " - took - " <<
            nsecs << " secs" << std::endl;
}

float sdot(int n, float* a, float* b) {

    // insert your custom code here
    double s = 0;
    for (int i = 0; i < n; i++)
        s += a[i] * b[i];

}

void sgemv(float* a, int n, float* v, float* w) {
    double s;
    // insert your custom code here
    for (int i = 0; i < n; i++) {
        s = 0;
        for (int j = 0; j < n; j++)
            s += a[i * n + j] * v[j];
        w[i] = s;
    }

}

void sgemm(float* a, float* b, int n, float* c) {
    double s;
    // insert your custom code here
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            s = 0;
            for (int k = 0; k < n; k++) {
                s += a[i * n + k] * b[k * n + j];
            }
            c[i * n + j] = s;
        }
    }
}

int main(int argc, char** argv) {
    if (argc != 2) {
        std::cerr << "***Incorrect number of arguments***\n";
        return 1;
    }
    int n = std::atoi(argv[1]);
    steady_clock::time_point ts, te;
    float* v = new float[n];
    float* w = new float[n];
    float* a = new float[n * n];
    float* b = new float[n * n];
    float* c = new float[n * n];

    // initialization
    std::srand(std::time(nullptr));
    ts = steady_clock::now();
    init(a, n * n);
    init(b, n * n);
    init(v, n);
    init(w, n);
    te = steady_clock::now();
    reportTime("initialization         ", te - ts);

    // vector-vector - dot product of v and w
    ts = steady_clock::now();
    sdot(n, v, w);
    te = steady_clock::now();
    reportTime("vector-vector operation", te - ts);

    // matrix-vector - product of a and v
    ts = steady_clock::now();
    sgemv(a, n, v, w);
    te = steady_clock::now();
    reportTime("matrix-vector operation", te - ts);

    // matrix-matrix - product of a and b
    ts = steady_clock::now();
    sgemm(a, b, n, c);
    te = steady_clock::now();
    reportTime("matrix-matrix operation", te - ts);
}
