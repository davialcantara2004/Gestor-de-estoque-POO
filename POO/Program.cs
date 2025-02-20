using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

namespace POO
{
    internal class Program
    {


        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        enum CadastroProduto { Curso = 1, Ebook, ProdutoFisico }


        static void Main(string[] args)
        {
            Carregar();
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("Bem vindo ao sistema de controle de estoque");
                Console.WriteLine("1 - Listar\n2 - Adicionar\n3 - Remover\n4 - Entrada\n5 - Saida\n6 - Sair");

                Menu opcao = (Menu)int.Parse(Console.ReadLine());

                if (opcao >= (Menu)1 || opcao <= (Menu)6)
                {
                    switch (opcao)
                    {
                        case Menu.Listar:
                            Listar();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            AdicionarEntrada();
                            break;
                        case Menu.Saida:
                            AdicionarSaida();
                            break;
                        case Menu.Sair:
                            sair = true;
                            break;
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Opção inválida, digite novamente");
                }
            }
        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produtos");
            Console.WriteLine("1 - Curso\n2 - Ebook\n3 - Produto Físico");
            CadastroProduto Cp = (CadastroProduto)int.Parse(Console.ReadLine());

            switch (Cp)
            {
                case CadastroProduto.Curso:
                    CadastroCurso();
                    break;
                case CadastroProduto.Ebook:
                    CadastroEbook();
                    break;
                case CadastroProduto.ProdutoFisico:
                    CadastroPf();
                    break;
            }
        }
        static void CadastroPf()
        {
            Console.WriteLine("Cadastrando Produto Físico");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Frete: ");
            double frete = double.Parse(Console.ReadLine());
            ProdutoFisico Pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(Pf);
            Salvar();
        }
        static void CadastroCurso()
        {
            Console.WriteLine("Cadastrando Curso");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();
        }
        static void CadastroEbook()
        {
            Console.WriteLine("Cadastrando Ebook");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();

        }
        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();


            if (stream.Length == 0)
            {
                produtos = new List<IEstoque>();
            }
            else
            {
                try
                {
                    produtos = (List<IEstoque>)encoder.Deserialize(stream);
                }
                catch (Exception)
                {
                    produtos = new List<IEstoque>();
                }
            }
            stream.Close();
        }
        static void Listar()
        {
            Console.WriteLine("Listagem de Produtos");
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum item foi adicionado!");
                Console.ReadLine();
            }
            else
            {
                int i = 0;
                Console.WriteLine("Produtos disponíveis: ");
                foreach (IEstoque produto in produtos)
                {

                    Console.WriteLine("ID: " + i);
                    produto.Exibir();
                    i++;
                    Console.WriteLine("=====================");
                }
             }
            Console.ReadLine();
        }
        static void Listar2()
        {
            Console.WriteLine("Listagem de Produtos");
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum item foi adicionado!");
                Console.ReadLine();
            }
            else
            {
                int i = 0;
                Console.WriteLine("Produtos disponíveis: ");
                foreach (IEstoque produto in produtos)
                {

                    Console.WriteLine("ID: " + i);
                    produto.Exibir();
                    i++;
                    Console.WriteLine("=====================");
                }
            }
        }
        static void Remover()
        {
            Listar2();
            Console.WriteLine("Digite o ID do produto que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 || id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }
        static void AdicionarEntrada()
        {
            Listar2();
            Console.WriteLine("Seleciona o ID do produto que deseja adicionar entrada");
            int id = int.Parse(Console.ReadLine()); 
            if (id >= 0 || id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
                Console.ReadLine();
            }
        }
        static void AdicionarSaida()
        {
            Listar2();
            Console.WriteLine("Seleciona o ID do produto que deseja adicionar saida");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 || id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
                Console.ReadLine();
            }
        }
    }
}
