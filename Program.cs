using GestãoDeEstoque;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Estoque estoque = new Estoque();
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Bem-Vindo ao Controle de Estoque\n");
            Console.WriteLine("1- Cadastrar Produto");
            Console.WriteLine("2- Remover Produto");
            Console.WriteLine("3- Exibir Estoque");
            Console.WriteLine("4- Valor Total em Estoque");
            Console.WriteLine("5- Sair");
            Console.WriteLine("---------------------------------");

            Console.Write("Digite sua opção: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Digite os dados do produto:");

                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());

                        if (estoque.ProdutoExiste(id))
                        {
                            throw new Exception($"Erro: O ID {id} já está cadastrado no sistema.");
                        }

                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        Console.Write("Quantidade: ");
                        int quantidade = int.Parse(Console.ReadLine());

                        Console.Write("Preço Unitário: ");
                        decimal precoUnitario = decimal.Parse(Console.ReadLine());

                        Produto produto = new Produto(id, nome, quantidade, precoUnitario);
                        estoque.AdicionarProduto(produto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    break;

                case 2:
                    try
                    {
                        Console.Clear();
                        Console.Write("Digite o ID do produto a ser removido: ");
                        int id = int.Parse(Console.ReadLine());

                        estoque.RemoverProduto(id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    break;

                case 3:
                    Console.Clear();
                    estoque.ExibirProdutos();
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    break;

                case 4:
                    Console.Clear();
                    decimal valorTotal = estoque.CalcularValorTotal();
                    Console.WriteLine($"Valor total em estoque: {valorTotal:C}");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    break;

                case 5:
                    Console.WriteLine("Saindo...");
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}