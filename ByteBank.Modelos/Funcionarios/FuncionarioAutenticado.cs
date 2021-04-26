using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public abstract class FuncionarioAutenticado : Funcionario, IAutenticavel
    {
        private AutenticacaoHelper _autenticacao = new AutenticacaoHelper();
        public string Senha { get; set; }
        public FuncionarioAutenticado(string cpf, double salario) : base(cpf, salario) { }

        public bool Autenticar(string senha)
        {
            return _autenticacao.CompararSenha(Senha, senha);
        }
    }
}
