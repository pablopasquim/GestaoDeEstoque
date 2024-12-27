using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEstoque
{
    public class Estoque
    {
        private List<Produto> produtos;

        public Estoque()
        {
            produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
            Console.WriteLine($"Produto {produto.Nome} adicionado com sucesso!");
        }


        public void RemoverProduto(int id)
        {
            Produto produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                throw new Exception($"Erro: Produto com ID {id} não encontrado");
            }

            produtos.Remove(produto);
            Console.WriteLine($"Produto {produto.Nome} removido com sucesso!");
        }

        public void AlterarProduto(int id, string novoNome, int novaQuantidade, decimal novoPreco)
        {
            Produto produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                Console.WriteLine($"\nProduto com o ID {id} não encontrado!");
                return;
            }

            produto.Nome = novoNome;
            produto.Quantidade = novaQuantidade;
            produto.PrecoUnitario = novoPreco;

            Console.WriteLine($"\nProduto com o ID {produto.Id} alterado com sucesso!");
        }


        public void ExibirProdutos()
        {
            if (!produtos.Any())
            {
                Console.WriteLine("Estoque vazio.");
                return;
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"{"ID",-5} | {"Nome",-20} | {"Quantidade",-10} | {"Preço Unitário",-15}");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }

            Console.WriteLine("-------------------------------------------------------------");

        }

        public void FiltrarProdutoPorId(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);

            if(produto == null)
            {
                throw new Exception($"Erro: Produto com {id} não encontrado");
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"{"ID",-5} | {"Nome",-20} | {"Quantidade",-10} | {"Preço Unitário",-15}");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(produto);
            Console.WriteLine("-------------------------------------------------------------");
        }

        public decimal CalcularValorTotal()
        {
            return produtos.Sum(p => p.PrecoUnitario * p.Quantidade);
        }

        public bool ProdutoExiste(int id)
        {
            return produtos.Any(p => p.Id == id);
        }
    }
}
