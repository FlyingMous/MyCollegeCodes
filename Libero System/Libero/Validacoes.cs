using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Libero
{
    public static class Validacoes
    {

        public static Boolean VerificaCnpj(String cnpj)
        {

            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {

                return validaCnpj(cnpj);

            }

            else
            {

                return false;

            }

        }


////////////////////////////////////////////////////////////////////////////////////


        public static Boolean validaCnpj(String cnpj)
        {

            Int32[] digitos, soma, resultado;

            Int32 nrDig;

            String ftmt;

            Boolean[] cnpjOk;

            cnpj = cnpj.Replace("/", "");

            cnpj = cnpj.Replace(".", "");

            cnpj = cnpj.Replace("-", "");

            if (cnpj == "00000000000000")
            {

                return false;

            }

            ftmt = "6543298765432";

            digitos = new Int32[14];

            soma = new Int32[2];

            soma[0] = 0;

            soma[1] = 0;

            resultado = new Int32[2];

            resultado[0] = 0;

            resultado[1] = 0;

            cnpjOk = new Boolean[2];

            cnpjOk[0] = false;

            cnpjOk[1] = false;

            try
            {

                for (nrDig = 0; nrDig < 14; nrDig++)
                {

                    digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));

                    if (nrDig <= 11)

                        soma[0] += (digitos[nrDig] *

                        int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)

                        soma[1] += (digitos[nrDig] *

                        int.Parse(ftmt.Substring(nrDig, 1)));

                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {

                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))

                        cnpjOk[nrDig] = (digitos[12 + nrDig] == 0);

                    else

                        cnpjOk[nrDig] = (digitos[12 + nrDig] == (

                        11 - resultado[nrDig]));

                }

                return (cnpjOk[0] && cnpjOk[1]);

            }

            catch
            {

                return false;

            }

        }

        
///////////////////////////////////////////////////////////////////////////////////
        

        public static bool CpfValido(string cpf)
        {
            // Se vazio
            if (cpf.Length == 0)
                return false;
            //Expressao regular que valida cpf
            Regex rgx = new Regex(@"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$");
            if (rgx.IsMatch(cpf))
            {
                return true;
            }
            else
            {
                return false;
            }
            // Limpa caracteres especiais pontos e espaços
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            cpf = cpf.Replace("+", "").Replace("*", "").Replace(",", "").Replace("?", "");
            cpf = cpf.Replace("!", "").Replace("@", "").Replace("#", "").Replace("$", "");
            cpf = cpf.Replace("%", "").Replace("¨", "").Replace("&", "").Replace("(", "");
            cpf = cpf.Replace("=", "").Replace("[", "").Replace("]", "").Replace(")", "");
            cpf = cpf.Replace("{", "").Replace("}", "").Replace(":", "").Replace(";", "");
            cpf = cpf.Replace("<", "").Replace(">", "").Replace("ç", "").Replace("Ç", "");

            // Se o tamanho for < 11 entao retorna como inválido
            if (cpf.Length != 11)
                return false;
            // Caso coloque todos os numeros iguais
            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }
            // Calcula Validade do CPF
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(
            ".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma +=
                int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma +=
                int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

//////////////////////////////////////////////////////////////////////////////////


        
    }
}
