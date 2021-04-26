using ByteBank.Modelos.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class Estagiario : Funcionario
    {
        public Estagiario(string cpf, double salario) : base(cpf, salario) { }
        protected override double GetBonificacao() {
            return Salario * 0.05;
        }
        public override void AumentarSalario()
        {
            Salario *= 1.05;
        } 
    }
}
