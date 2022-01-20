using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public int Agencia { get; }

        public int Numero { get; }

        /// <summary>
        /// /////////////////////////////////////////////////////
        /// </summary>

        private double _saldo = 100;

        public static int TotalContas { get; private set; }

        public static double TaxaOperacao { get; private set; }

        public int ContadorSaquesInvalidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            if (numeroAgencia <= 0)
            {
                throw new ArgumentException("Agencia tem de ser maior que 0!!!!!!", nameof(numeroAgencia));
            }
            if (numeroConta <= 0)
            {
                throw new ArgumentException("Numero tem de ser maior que 0!!!!!!", nameof(numeroConta));
            }

            Agencia = numeroAgencia;
            Numero = numeroConta;


            TotalContas++;
            TaxaOperacao = 30 / TotalContas;
        }

        public void Sacar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor invalido para o saque.", nameof(valor));
            }
            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor <= 0)
            {
                ContadorSaquesInvalidos++;
                throw new ArgumentException("Valor invalido para a transferencia.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação inválida.", ex);
            }

            contaDestino.Depositar(valor);

        }
    }
}