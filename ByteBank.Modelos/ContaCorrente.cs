using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Define uma conta corrente no banco ByteBank.
    /// </summary>
    public class ContaCorrente : IComparable
    {
        public Cliente Titular { get; private set; }
        public int NumeroConta { get; }
        public int NumeroAgencia { get; }
        public static int ContasCriadas { get; private set; }
        public static double TaxaOperacional { get; private set; }

        private double _saldo = 100;
        public double Saldo { get { return _saldo; } }

        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="numeroAgencia">Representa o valor da propriedade <see cref="numeroAgencia"/> e deve possuir um valor maior que zero.</param>
        /// <param name="numeroConta">Representa o valor da propriedade <see cref="numeroConta"/> e deve possuir um valor maior que zero.</param>
        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            if (numeroAgencia <= 0)
                throw new ArgumentException("O argumento numero agencia é menor ou igual a 0.", nameof(numeroAgencia));

            if (numeroConta <= 0)
                throw new ArgumentException("O argumento numero conta é menor ou igual a 0.", nameof(numeroConta));


            NumeroAgencia = numeroAgencia;
            NumeroConta = numeroConta;

            ContasCriadas++;
            TaxaOperacional = 30 / ContasCriadas;
        }

        public void Depositar(double valorDeposito)
        {
            if (valorDeposito < 0)
                throw new ArgumentException("Valor informado invalido para deposito.", nameof(valorDeposito));

            _saldo += valorDeposito;
        }

        /// <summary>
        /// Realiza o saque e atualiza o saldo da propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valorSaque"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de <paramref name="valorSaque"/> é maior que o valor da propriedade <see cref="Saldo"/>.</exception>
        /// <param name="valorSaque">representa o valor do saque, deve ser maior que 0 e menor que <see cref="Saldo"/>.</param>
        public void Sacar(double valorSaque)
        {
            if (valorSaque < 0)
                throw new ArgumentException("Valor informado: " + valorSaque, nameof(valorSaque));
            
            if (valorSaque > _saldo)
                throw new SaldoInsuficienteException(valorSaque, Saldo);
            
            _saldo -= valorSaque;
        }
        public void Transferir(ContaCorrente contaDestino, double valorTransferencia)
        {
            if (valorTransferencia < 0)
                throw new ArgumentException("Valor informado: " + valorTransferencia, nameof(valorTransferencia));
            
            try
            {
                Sacar(valorTransferencia);
            }
            catch (SaldoInsuficienteException e)
            {
                throw new OperacaoFinanceiraException("Operação não realizada", e);
            }
            contaDestino._saldo += valorTransferencia;
        }

        public override bool Equals(object obj)
        {
            ContaCorrente contaAtual = obj as ContaCorrente;

            if(contaAtual == null)
            {
                return false;
            }

            return (contaAtual.NumeroAgencia == NumeroAgencia) && (contaAtual.NumeroConta == NumeroConta);
        }

        public int CompareTo(object obj)
        {
            var conta = obj as ContaCorrente;

            if(conta == null)
            {
                return -1;
            }
            
            if(NumeroAgencia < conta.NumeroAgencia)
            {
                return -1;
            }
            
            if(NumeroAgencia == conta.NumeroAgencia)
            {
                return 0;
            }
            
            return 1;
        }
    }
}
