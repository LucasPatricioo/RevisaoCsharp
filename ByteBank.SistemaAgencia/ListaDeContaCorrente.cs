using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class ListaDeContaCorrente
    {
        private ContaCorrente[] _conta;
        private int _proximoIndice;

        public int Tamanho
        {
            get { return _proximoIndice; }
        }

        public ListaDeContaCorrente()
        {
            _conta = new ContaCorrente[5];
            _proximoIndice = 0;
        }

        public void Adicionar(ContaCorrente conta)
        {

            VerificarLista(_proximoIndice + 1);

            Console.WriteLine($"Adicionando novo item na lista no indice {_proximoIndice} ");

            _conta[_proximoIndice] = conta;
            _proximoIndice++;
        }
        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach(ContaCorrente item in itens)
            {
                Adicionar(item);
            }
        }
        private void VerificarLista(int tamanhoNecessario)
        {
            ContaCorrente[] contasAtualizadas;

            if (_conta.Length >= tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("Adicionando novo item");

            contasAtualizadas = new ContaCorrente[tamanhoNecessario];

            Array.Copy(sourceArray: _conta, destinationArray: contasAtualizadas, length: _conta.Length);

            _conta = contasAtualizadas;
        }

        public void Remover(ContaCorrente item)
        {
            int indiceItem = -1;

            for (int i = 0; i < _proximoIndice; i++)
            {
                if (_conta[i].Equals(item))
                {
                    indiceItem = i;
                }
            }

            for(int i = indiceItem; i < _proximoIndice-1; i++)
            {
                _conta[indiceItem] = _conta[indiceItem + 1];
            }

            _proximoIndice--;
            _conta[_proximoIndice] = null;
        }

        public ContaCorrente GetItemNoIndice(int indice) {
            if(indice < 0 && indice >= _proximoIndice)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _conta[indice];
        }

        public string RecuperarItem(int indice)
        {
            return $"Numero da conta : {_conta[indice].NumeroConta}, Numero da agencia: {_conta[indice].NumeroAgencia}";
        }
    
        public ContaCorrente this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
    
    }
}
