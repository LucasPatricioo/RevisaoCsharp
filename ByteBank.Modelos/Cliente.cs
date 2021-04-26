using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public int Idade { get; private set; }

        public Cliente(string nome, string cpf, int idade)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
        }
    }
}
