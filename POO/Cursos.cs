using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

       
  
        public Curso(string nome, double preco,string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;

        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar Vagas no Curso {nome}");
            Console.WriteLine("Digite a Quantiade:");
            int vaga = int.Parse(Console.ReadLine());
            vagas += vaga;
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir Vagas no Curso {nome}");
            Console.WriteLine("Digite a Quantiade a ser Consumida:");
            int vaga = int.Parse(Console.ReadLine());
            vagas -= vaga;

        }

        public void Exibir()
        {
           Console.WriteLine($"Nome = {nome}");
           Console.WriteLine($"Autor = {autor}");
           Console.WriteLine($"Preço = {preco}");
            Console.WriteLine($"Vagas = {vagas}");
        }
    }
}
