using APIs.Classes;
using APIs.Enums;
using System;

namespace APIs
{
    class Program
    {
		static SerieRepositorio repositorioSerie = new SerieRepositorio();
		static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
		static void Main(string[] args)
		{
			string menu = EscolhaMenu();

			while (menu.ToUpper() != "0")
			{
				string subMenu = Escolha(menu);

					switch (subMenu)
					{
						case "1":
							if (menu.Equals("1"))
							{
								ListarFilmes();
							}
							else
							{
								ListarSeries();
							}
							break;
						case "2":
							if (menu.Equals("1"))
							{
								InserirFilme();
                            Console.WriteLine("Informações insediras com sucesso!");
							}
							else
							{
								InserirSerie();
							Console.WriteLine("Informações insediras com sucesso!");
						}
							break;
						case "3":
							if (menu.Equals("1"))
							{
								AtualizarFilme();
							Console.WriteLine("Informações atualizadas com sucesso!");
						}
							else
							{
								AtualizarSerie();
							Console.WriteLine("Informações atualizadas com sucesso!");
						}
							break;
						case "4":
							if (menu.Equals("1"))
							{
								ExcluirFilme();
							Console.WriteLine("Informações Excluidas com sucesso!");
						}
							else
							{
								ExcluirSerie();
							Console.WriteLine("Informações Excluidas com sucesso!");
						}
							break;
						case "5":
							if (menu.Equals("1"))
							{
								VisualizarFilme();
							Console.WriteLine("Informações Excluidas com sucesso!");
						}
							else
							{
								VisualizarSerie();
							}
							break;
						case "C":
							Console.Clear();
							break;

						default:
							throw new ArgumentOutOfRangeException();
					}

					menu = EscolhaMenu();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int id = int.Parse(Console.ReadLine());

			repositorioSerie.Exclui(id);
		}

		private static void ExcluirFilme()
		{
			Console.Write("Digite o id do filme: ");
			int id = int.Parse(Console.ReadLine());

			repositorioFilme.Exclui(id);
		}

		private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int id = int.Parse(Console.ReadLine());

			var serie = repositorioSerie.RetornaPorId(id);


			Console.WriteLine(serie);
		}
		private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int id = int.Parse(Console.ReadLine());

			var filme = repositorioFilme.RetornaPorId(id);

			Console.WriteLine(filme);
		}

		private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int id = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: id,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioSerie.Atualiza(id, atualizaSerie);
		}
		private static void AtualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int id = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: id,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioFilme.Atualiza(id, atualizaFilme);
		}
		private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorioSerie.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.RetornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorioFilme.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
				var excluido = filme.RetornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", filme.RetornaId(), filme.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}


		private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioSerie.Insere(novaSerie);
		}

		private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioFilme.Insere(novoFilme);
		}

		private static string EscolhaMenu()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Filmes");
			Console.WriteLine("2- Séries");

			Console.WriteLine("0- Sair");
			Console.WriteLine();

			string opcaoEscolhida = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoEscolhida;
		}

		private static string Escolha(string menu)
		{
			string tipo = menu.Equals("1") ? "Filmes" : "Séries";
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine($"1- Listar {tipo}");
			Console.WriteLine($"2- Inserir {tipo}");
			Console.WriteLine($"3- Atualizar {tipo}");
			Console.WriteLine($"4- Excluir {tipo}");
			Console.WriteLine($"5- Visualizar {tipo}");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("0- Sair");
			Console.WriteLine();

			string opcaoEscolhida = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoEscolhida;
		}
	}
}
