using System;
using DIO.Series.Classes;
using DIO.Series.Enum;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = ObterOpcaoUsuario();

            while (opcao != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        inserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":

                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            opcao = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por usar nosso aplicativo! ");
            Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Cadastro de series DIO!");
            Console.WriteLine("Informe a opcao desejada: ");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Series.");
            Console.WriteLine("2 - Inserir Nova Série.");
            Console.WriteLine("3 - Excluir Série.");
            Console.WriteLine("4 - Visualizar Série.");
            Console.WriteLine("C - Limpar tela.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Lista de séries:");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine($"#ID: {serie.RetornaId()} | Titulo: {serie.RetornaTitulo()} |||| {(serie.RetornExcluido() ? "**Excluido**" : "**Ativo**")}");
            }
        }

        private static void inserirSerie()
        {

            foreach (int index in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($" {index} - {System.Enum.GetName(typeof(Genero), index)}");
            }
            
            Console.WriteLine("Selecione o Genero: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescrição = Console.ReadLine();

            repositorio.Insere(new Classes.Series(repositorio.ProximoId(),
                                                  (Genero)entradaGenero,
                                                  entradaTitulo,
                                                  entradaDescrição,
                                                  entradaAno));

        }

        private static void AtualizarSerie()
        {

            Console.WriteLine("Digite o indice da série que deseja atualizar: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            foreach (int index in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($" {index} - {System.Enum.GetName(typeof(Genero), index)}");
            }

            Console.WriteLine("Selecione o Genero: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescrição = Console.ReadLine();

            Classes.Series serie = new Classes.Series(indiceSerie,
                                                  (Genero)entradaGenero,
                                                  entradaTitulo,
                                                  entradaDescrição,
                                                  entradaAno);

            repositorio.Atualiza(indiceSerie, serie);

        }


        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da serie a excluir: ");

            repositorio.Exclui(int.Parse(Console.ReadLine()));

            Console.WriteLine("Exclusão concluida.");

        }



        private static void VisualizarSerie()
        {

            Console.WriteLine("Digite o ID da serie para visualizar: ");

            Console.WriteLine(repositorio.RetornaPorId(int.Parse(Console.ReadLine())));

        }




    }
}
