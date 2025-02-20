using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{

    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public double frete;
        private int estoque;

        public ProdutoFisico(string nome, double preco, double frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no Produto{nome}");
            Console.WriteLine("Digite a Quantiade:");
            int estoques = int.Parse(Console.ReadLine());
            estoque += estoques;
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar Saidas no Produto {nome}");
            Console.WriteLine("Digite a Quantiade:");
            int estoques = int.Parse(Console.ReadLine());
            estoque -= estoques;
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome = {nome}");
            Console.WriteLine($"Preço = {preco}");
            Console.WriteLine($"Frete = {frete}");
            Console.WriteLine($"Estoque = {estoque}");
        }
    }
}
