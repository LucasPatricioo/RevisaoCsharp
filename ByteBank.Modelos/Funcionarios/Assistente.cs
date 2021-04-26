using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public class Assistente : Funcionario
    {
        public Assistente(string cpf, double salario) : base(cpf, salario) { }
        internal protected override double GetBonificacao()
        {
            return Salario * 0.15;
        }
        public override void AumentarSalario()
        {
            Salario *= 1.10; 
        }
    }
}
