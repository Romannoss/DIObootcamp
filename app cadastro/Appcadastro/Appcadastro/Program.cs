using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appcadastro.interfaces;
using Appcadastro.Enum;
using Appcadastro.classes;

namespace Appcadastro
{
    class Program 
    {
        static SerieRepositorio repositorio = new();

        static void Main(string[] args)
        {
            string opcaoUser = ObterOpcaoUser();

            while (opcaoUser.ToUpper() != "X")
            {
                switch (opcaoUser)
                {

                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        Insere();
                        break;

                    case "3":
                        AtualizaSerie();
                        break;

                    case "4":
                     ExcluiSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUser = ObterOpcaoUser();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços. ");
            Console.ReadLine();
        }

        private static void AtualizaSerie()
        {
            Console.WriteLine("digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Genero.GetName(typeof(Genero), i));
                                
            }

            Console.WriteLine("digite o genero entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("digite a descriçao da serie: ");
            string entradaDescricao = Console.ReadLine();

            serie atualizaSerie = new serie(id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);


            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluiSerie()
        {
            Console.WriteLine("digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

            Console.WriteLine("Excluido com sucesso.");
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);

        }


        private static void ListarSeries()
        {

            Console.WriteLine("Listar series");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {

                Console.WriteLine("nenhuma serie cadastrada. ");
                return;
            }

            foreach( var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if (!excluido) { 
                Console.WriteLine("#ID {0}: - {1}", serie.retornaid(), serie.retornatitulo());
                }
            }

         /*   foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaid(), serie.retornatitulo(), (excluido ? "excluido" : ""));

            } */
        }

        private static void Insere()
        {

            Console.WriteLine("Inserir nova serie");

            foreach(int i in Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Genero.GetName(typeof(Genero), i));

            }

            Console.WriteLine("digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("digite o titulo da serie: ");
            string entradatitulo = Console.ReadLine();

            Console.WriteLine("digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("digite a descriçao da serie: ");
            string entradaDescricao = Console.ReadLine();

            serie novaSerie = new serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero,
                titulo: entradatitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }

        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!");
            Console.WriteLine("Informe a opçao desejada");
            
            
            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- visualizar serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- sair");
            Console.WriteLine();

            string opcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUser;
        }
    }
}
