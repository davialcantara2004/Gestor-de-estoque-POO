using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{

    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;
        public Ebook(string nome, double preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel adicionar entrada nesse tipo de produto");
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Quantiade de vendas no Ebook {nome}");
            Console.WriteLine("Digite a Quantiade:");
            int venda = int.Parse(Console.ReadLine());
            vendas += venda;

        }

        public void Exibir()
        {
            Console.WriteLine($"Nome = {nome}");
            Console.WriteLine($"Autor = {autor}");
            Console.WriteLine($"Preço = {preco}");
            Console.WriteLine($"Vendas = {vendas}");
            
        }
    }
}
