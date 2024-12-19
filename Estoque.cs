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
            Console.WriteLine("Produto adicionado com sucesso!");
        }

        public void RemoverProduto(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                throw new Exception($"Erro: Produto com ID {id} não encontrado.");
            }

            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso!");
        }

        public void ExibirProdutos()
        {
            if (!produtos.Any())
            {
                Console.WriteLine("Estoque vazio.");
                return;
            }

            Console.WriteLine("Produtos em Estoque:");
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }
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
