using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public double Saldo { get; }
        public double ValorPahSacar { get; }

        public SaldoInsuficienteException() { }

        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this("Tentativa de saque do valor de " + valorSaque + " em uma conta com saldo de " + saldo)
        {
            Saldo = saldo;
            ValorPahSacar = valorSaque;
        }
        public SaldoInsuficienteException(string message) : base(message) { }

        public SaldoInsuficienteException(string message, Exception excecaoInterna) : base(message, excecaoInterna) { }


    }
}
