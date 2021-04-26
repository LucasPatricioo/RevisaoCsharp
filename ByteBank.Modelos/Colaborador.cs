using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    class Colaborador : IAutenticavel
    {
        private AutenticacaoHelper _autenticacao = new AutenticacaoHelper();
        public string Senha { get; private set; }
        public bool Autenticar(string senha)
        {
            return _autenticacao.CompararSenha(senha, senha);
        }
    }
}
