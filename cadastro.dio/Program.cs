using System;

namespace cadastro.dio
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcao = ObterOpcaoUsuario();
            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
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
                        throw new ArgumentOutOfRangeException("Opção digitada inválida");
                }
                Console.WriteLine();
                opcao = ObterOpcaoUsuario();
            }
            Console.WriteLine("Certo, até mais !");
            Console.ReadKey();
        }

        private void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine($"#ID {serie.RetornaId()}: {serie.RetornaTitulo()}");
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série:");

            foreach (int i in Enum.GetValues(typeof(Genero))) //Verificar documentação GetValues
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i)); // Verificar documentaçao GetName
            }
            Console.Write("Digite o gênero entre as opções a cima: ");
            int entradaGen = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série:");
            string entradaTit = Console.ReadLine();

            Console.Write("Digite o ano de início da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série");
            string entradaDescr = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGen,
                                        titulo: entradaTit,
                                        ano: entradaAno,
                                        descricao: entradaDescr);

            repositorio.Insere(novaSerie);
        }
        private void AtualizarSerie()
        {
            Console.WriteLine("Atualizar série, digite o id:");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero))) //Verificar documentação GetValues
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i)); // Verificar documentaçao GetName
            }
            Console.Write("Digite o gênero entre as opções a cima: ");
            int entradaGen = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série:");
            string entradaTit = Console.ReadLine();

            Console.Write("Digite o ano de início da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série");
            string entradaDescr = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGen,
                                        titulo: entradaTit,
                                        ano: entradaAno,
                                        descricao: entradaDescr);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries - Seja Bem Vindo !");
            Console.WriteLine("Informe uma opção:");

            Console.WriteLine("1 - Listar séries.");
            Console.WriteLine("2 - Inserir nova série.");
            Console.WriteLine("3 - Atualizar série.");
            Console.WriteLine("4 - Excluir série.");
            Console.WriteLine("5 - Visualizar série.");
            Console.WriteLine("C - Limpar tela.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine("");
            return opcaoUsuario.ToUpper();


        }
    }
}

