using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public double Saldo { get; }
        public double Valor { get; }
        public SaldoInsuficienteException() { }
        public SaldoInsuficienteException(string mensagem) : base(mensagem) { }
        public SaldoInsuficienteException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna) { }
        public SaldoInsuficienteException(double valor, double saldo) : this("O saldo da conta é insuficiente para realizar esta operação, Saldo em conta: " + saldo + ", valor informado: " + valor)
        {
            Saldo = saldo;
            Valor = valor;
        }
    }
}
