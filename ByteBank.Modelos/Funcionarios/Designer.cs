using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public class Designer : Funcionario
    {
        public Designer(string cpf, double salario) : base(cpf, salario) { }
        internal protected override double GetBonificacao()
        {
            return Salario * 0.35;
        }
        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }
    }
}
