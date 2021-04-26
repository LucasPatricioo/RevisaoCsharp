using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Lista<T>
    {
        private T[] _item;
        private int _proximoIndice;

        public int Tamanho
        {
            get { return _proximoIndice; }
        }

        public Lista(int tamanhoDoArray = 5)
        {
            _item = new T[tamanhoDoArray];
            _proximoIndice = 0;
        }

        public void Adicionar(T item)
        {

            VerificarLista(_proximoIndice + 1);

            Console.WriteLine($"Adicionando novo item na lista no indice {_proximoIndice} ");

            _item[_proximoIndice] = item;
            _proximoIndice++;
        }
        public void AdicionarVarios(params T[] itens)
        {
            foreach (T item in itens)
            {
                Adicionar(item);
            }
        }
        private void VerificarLista(int tamanhoNecessario)
        {
            T[] itensAtualizados;

            if (_item.Length >= tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("Adicionando novo item");

            itensAtualizados = new T[tamanhoNecessario];

            Array.Copy(sourceArray: _item, 
                destinationArray: itensAtualizados, 
                length: _item.Length);

            _item = itensAtualizados;
        }

        public void Remover(T item)
        {
            int indiceItem = -1;

            for (int i = 0; i < _proximoIndice; i++)
            {
                if (_item[i].Equals(item))
                {
                    indiceItem = i;
                }
            }

            for (int i = indiceItem; i < _proximoIndice - 1; i++)
            {
                _item[indiceItem] = _item[indiceItem + 1];
            }

            _proximoIndice--;
            //_item[_proximoIndice] = null;
        }

        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 && indice >= _proximoIndice)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _item[indice];
        }

        public T this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

    }
}
