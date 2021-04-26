using ByteBank.Modelos.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class GerenciadorDeBonificacao
    {
        private double _bonificacao = 0;
        public void Registrar(Funcionario funcionario)
        {
            _bonificacao += funcionario.GetBonificacao();
        }
        public double GetTotalBonificacao()
        {
            return _bonificacao;
        }
    }
}
