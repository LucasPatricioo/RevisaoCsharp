using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentos
    {
        public string URL { get; }
        private readonly string _argumentos;
        public ExtratorValorDeArgumentos(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser nulo ou vazio.", nameof(url));
            }

            URL = url;
            int indice = url.IndexOf('?') + 1;
            _argumentos = url.Substring(indice);

        }

        public string GetValor(string parametros)
        {
            parametros = parametros.ToUpper();
            string argumentoCompararcao = _argumentos.ToUpper();

            string termo = parametros + "=";
            int indiceTermo = argumentoCompararcao.IndexOf(termo);
            
            string valor = _argumentos.Substring(indiceTermo + termo.Length);
            int indiceEComercial = valor.IndexOf('&');

            if (indiceEComercial == -1)
            {
                return valor;
            }

            return valor.Remove(indiceEComercial);
        }
    }
}
