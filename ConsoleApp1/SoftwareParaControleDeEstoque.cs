using System;
using System.Collections.Generic;

namespace SoftwareParaControleDeEstoque
{
    public class Livro
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int QuantidadeEmEstoque { get; private set; }
        public string Autor { get; set; }
        public string Genero { get; set; }

        public Livro(string nome, double preco, string autor, string genero)
        {
            Nome = nome;
            Preco = preco;
            QuantidadeEmEstoque = 0;
            Autor = autor;
            Genero = genero;
        }

        public void EntradaEstoque(int quantidade) => QuantidadeEmEstoque += quantidade;

        public bool SaidaEstoque(int quantidade)
        {
            if (quantidade <= QuantidadeEmEstoque)
            {
                QuantidadeEmEstoque -= quantidade;
                return true;
            }
            return false;
        }

        public override string ToString() => $"{Nome} ({Preco:C}) - {Autor} - {Genero} - {QuantidadeEmEstoque} no estoque";
    }

    class SoftwareParaControleDeEstoque
    {
        static readonly List<Livro> livros = new List<Livro>();

        static void Main(string[] _)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("[1] Novo\n[2] Listar Produtos\n[3] Remover Produtos\n[4] Entrada Estoque\n[5] Saída Estoque\n[0] Sair");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: AdicionarLivro(); break;
                    case 2: ListarProdutos(); break;
                    case 3: RemoverProduto(); break;
                    case 4: EntradaEstoque(); break;
                    case 5: SaidaEstoque(); break;
                    case 0: continuar = false; break;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        static void AdicionarLivro()
        {
            Console.Write("Informe o nome do Livro: ");
            string nome = Console.ReadLine();
            Console.Write("Informe o preço: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Informe o autor(a): ");
            string autor = Console.ReadLine();
            Console.Write("Informe o Gênero: ");
            string genero = Console.ReadLine();

            livros.Add(new Livro(nome, preco, autor, genero));
            Console.WriteLine("Livro adicionado!");
        }

        static void ListarProdutos()
        {
            int index = 1;
            foreach (var livro in livros)
            {
                Console.WriteLine($"{index}. {livro}");
                index++;
            }
        }

        static void RemoverProduto()
        {
            ListarProdutos();
            Console.Write("Informe a posição do livro a ser removido: ");
            int posicao = int.Parse(Console.ReadLine()) - 1;
            livros.RemoveAt(posicao);
            Console.WriteLine("Livro removido com sucesso.");
        }

        static void EntradaEstoque()
        {
            ListarProdutos();
            Console.Write("Informe a posição do livro: ");
            int posicao = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Informe a quantidade de Entrada: ");
            int quantidade = int.Parse(Console.ReadLine());
            livros[posicao].EntradaEstoque(quantidade);
            Console.WriteLine("Estoque atualizado.");
        }

        static void SaidaEstoque()
        {
            ListarProdutos();
            Console.Write("Informe a posição do livro: ");
            int posicao = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Informe a quantidade de Saída: ");
            int quantidade = int.Parse(Console.ReadLine());
            if (livros[posicao].SaidaEstoque(quantidade))
            {
                Console.WriteLine("Estoque atualizado.");
            }
            else
            {
                Console.WriteLine("Operação não realizada.");
            }
        }
    }
}
