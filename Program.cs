using System;
using System.Collections.Generic;

namespace Filme.Infantil
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        private static Genero entradaGenero;

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }        
            Console.WriteLine("Obrigado por utilizar nossos serviços. Volte sempre!");
            Console.ReadLine();
        }
        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceFilme);
        }
        private static void VisualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorio.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }
        private static void AtualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do filme: ");
            string entradaDecricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                                    genero: (Genero)entradaGenero,
                                                    titulo: entradaTitulo,
                                                    ano: entradaAno,
                                                    descricao: entradaDecricao);
            
            repositorio.Atualiza(indiceFilme, atualizaFilme);
        }
        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes");
            
            var lista = repositorio.Lista();

            if (lista.Count == 0)            
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }
            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", filme.retonaId(), filme.retornaTitulo());
            }
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

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do filme: ");
            string entradaDescrição = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescrição);

            repositorio.Insere(novoFilme);            
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Seja bem-vindo a Filmes Infantis S/A!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir novo filme");
            Console.WriteLine("3- Atualizar filme ");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}