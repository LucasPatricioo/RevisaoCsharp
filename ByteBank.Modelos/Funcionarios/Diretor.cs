using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public class Diretor : FuncionarioAutenticado
    {
        public Diretor(string cpf, double salario) : base(cpf, salario) { }

        internal protected override double GetBonificacao()
        {
            return Salario * 1.15;
        }
        public override void AumentarSalario()
        {
            Salario *= 1.5;
        }
    }
}
