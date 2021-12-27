using System;

namespace AulaPratica
{
    class Program
    {
        static void Main(string[] args)
        {

            string opçaodoTorcedor = ObterOpçao();
           

            while (opçaodoTorcedor.ToUpper() != "X")
            {
                switch (opçaodoTorcedor)
                {
                    case "1":
                        
                        Console.WriteLine("talvez o vasco sobe");
                        Console.WriteLine();
                        break;

                    case "2":
                        
                        Console.WriteLine("provavel que o vasco suba");
                        Console.WriteLine();
                        break;

                    case "3":
                        
                        Console.WriteLine("certeza que o vasco sobe");
                        Console.WriteLine();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opçaodoTorcedor = ObterOpçao();
            }
        }

        private static string ObterOpçao()
        {
            Console.WriteLine("Informa uma opçao");
            Console.WriteLine("1- O passaro pede demissao");
            Console.WriteLine("2- O salgado demite o passaro");
            Console.WriteLine("3- O salgado pede demissao junto com o passaro");
            Console.WriteLine("X- sair");
            Console.WriteLine();

            string opçaodoTorcedor = Console.ReadLine();
            Console.WriteLine();

            return opçaodoTorcedor;
        }
    }
}
