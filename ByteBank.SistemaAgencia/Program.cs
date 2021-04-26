using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Extensoes;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {




            Console.ReadKey();
        }
        public static void ListasExpressoesLambda()
        {

            var lista = new List<ContaCorrente>() {
                new ContaCorrente(315,292837),
                new ContaCorrente(318,292835),
                null,
                new ContaCorrente(319,292836),
                new ContaCorrente(317,292834),
            };

            //lista.Sort(new ComparadorNumeroConta());
            //IOrderedEnumerable<ContaCorrente> contas = lista.OrderBy(conta =>
            //{
            //    if (conta == null)
            //    {
            //        return int.MaxValue;
            //    }
            //    return conta.NumeroConta;
            //}
            //                                                         );

            var contas = lista.Where(conta => conta != null)
                .OrderBy(conta => conta.NumeroConta);


            foreach (var conta in contas)
            {
                Console.WriteLine($"Agência {conta.NumeroAgencia} / Conta {conta.NumeroConta}");
            }



            //for (int i = 0; i < lista.Count; i++)
            //{
            //    Console.WriteLine($"Agência {lista[i].NumeroAgencia} / Conta {lista[i].NumeroConta}");
            //}    
        }
        public static int CalcularTotal(params int[] numeros)
        {
            int resultado = 0;
            foreach (int numero in numeros)
            {
                resultado += numero;
            }
            return resultado;
        }
        public static void ManipulandoString()
        {
            //[] -> definem o padrão que sera expresso na expressão regular, exemplo [0-9] tera variação do caracter 0 ao 9 com base na tabela ascii.
            //{} -> definem quantidade, exemplo [0-9]{4} tera quatro caracteres que variam de 0 a 9, se a variação for de 0 a 1 em quantidade pode se usar o -> ?.
            string expressaoRegular = "[0-9]{5}[-][0-9]{4}"; //indica um padrão de quatro caracteres que variam de 0 a 9 na tabela ascii não no numeral.

            string mensagem = "Olá meu nome é lucas me ligue em 97326-9271";

            Match numero = Regex.Match(mensagem, expressaoRegular);
            Console.WriteLine(numero.Value);

            //string url = "https://www.bytebank.com/cambios?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            //ExtratorValorDeArgumentos extrator = new ExtratorValorDeArgumentos(url);
            //Console.WriteLine("Moeda Origem = " + extrator.GetValor("moedaOrigem"));
            //Console.WriteLine("Moeda Destino = " + extrator.GetValor("moedaDestino"));
            //Console.WriteLine("Valor = " + extrator.GetValor("valOr"));
        }
    }
}
