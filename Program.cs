using System;

namespace cadastro_de_series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
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

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.WriteLine();

            static void ListarSeries()
            {
                Console.WriteLine("Listar Séries");
                var lista = repositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Sem séries cadastradas");
                    return;
                }

                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "***Excluído***" : ""));
                }
            }

             static void InserirSerie()
            {
                Console.WriteLine("Inserir nova série");

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("ID {0}: - {1}", i, Enum.GetName(typeof(Genero), i));
                }

                    Console.Write("Escolha o gênero da série:");
                    int entradaGenero = int.Parse(Console.ReadLine());

                    Console.Write("Digite o título da série: ");
                    string entradaTitulo = Console.ReadLine();

                    Console.Write("Digite o ano de início da série: ");
                     int entradaAno = int.Parse(Console.ReadLine());

                    Console.Write("Digite a descrição da série: ");
                     string entradaDescricao = Console.ReadLine();

                    Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                descricao: entradaDescricao
                    
                    );
                    repositorio.Insere(novaSerie);

                }
            }
            
            static void AtualizarSerie()
            {
                Console.Write("Digite o ID da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }

                Console.Write("Digite o genero da série: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o título da série: ");
                string entradaTitulo = (Console.ReadLine());

                Console.Write("Digite o ano da série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite o título da série: ");
                string entradaDescricao = (Console.ReadLine());

                Serie atualizaSerie = new Serie(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
                );

                repositorio.Atualiza(indiceSerie, atualizaSerie);
 }
        
            static void ExcluirSerie()
            {
                Console.Write("Digite o ID da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceSerie);
            }
            
            static void VisualizarSerie()
            {
                Console.Write("Digite o ID da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(indiceSerie);

                Console.WriteLine(serie);
            }

            static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("DIO Series a seu dispor!");
                Console.WriteLine("Escolha sua opção:");

                Console.WriteLine("1 - Listar séries");
                Console.WriteLine("2 - Adicionar série");
                Console.WriteLine("3 - Atualizar série");
                Console.WriteLine("4 - Excluir série");
                Console.WriteLine("5 - Visualizar série");
                Console.WriteLine("C - Limpar tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }
        }
    }
