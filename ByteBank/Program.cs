using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarregarContas();

            //try{Metodo();}
            //catch (Exception e){Console.WriteLine(e.Message);Console.WriteLine("Aconteceu um erro!");}

            Console.ReadLine();
        }

        private static void CarregarContas()
        {
            using (LeitorDeArquivo leitor = new LeitorDeArquivo("teste.txt"))
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }

            //////////////////////////////////////////////////////
            //LeitorDeArquivo leitor = null;
            //try
            //{
            //    new LeitorDeArquivo("contas5.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //}
            //catch (IOException) 
            //{
            //    Console.WriteLine("Exceção tipo IOException resolvida");
            //}
            //finally
            //{
            //    Console.WriteLine("Executando o finally");

            //    if(leitor != null)
            //        leitor.Fechar();
            //}

        }

        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(123, 4656789);
                ContaCorrente contaD = new ContaCorrente(123, 4656789);

                conta.Transferir(1000, contaD);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Operção da INNER EXCEPTION:");
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }

        }

        //Teste com a cadeia de chamada:
        //Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            //ContaCorrente conta = null;
            //Console.WriteLine(conta.Saldo);

            return numero / divisor;
        }
    }
}

