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
            Console.WriteLine("5- Alterar Produto");
            Console.WriteLine("0- Sair");
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

                        if (quantidade <= 0)
                        {
                            throw new Exception("Erro: A quantidade deve ser maior que zero.");
                        }

                        Console.Write("Preço Unitário: ");
                        decimal precoUnitario = decimal.Parse(Console.ReadLine());

                        if (precoUnitario <= 0)
                        {
                            throw new Exception("Erro: O preço unitário deve ser maior que zero.");
                        }

                        Produto produto = new Produto(id, nome, quantidade, precoUnitario);
                        estoque.AdicionarProduto(produto);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case 2:
                    
                        Console.Clear();
                        Console.Write("Digite o ID do produto a ser removido: ");
                        int removeId = int.Parse(Console.ReadLine());

                        if (removeId == null)
                        {
                            Console.WriteLine("Erro: O ID deve ser um número válido.");
                            break;
                        }

                        estoque.RemoverProduto(removeId);
                   
                   
                    break;


                case 3:
                    Console.Clear();
                    Console.WriteLine("Escolha uma opção: ");
                    Console.WriteLine("1- Exibir todos os produtos");
                    Console.WriteLine("2- Exibir produto por ID");
                    Console.Write("Digite sua opção: ");

                    int exibirOpcao = int.Parse(Console.ReadLine());

                    if (exibirOpcao == 1)
                    {
                        estoque.ExibirProdutos();
                    }
                    else if (exibirOpcao == 2)
                    {
                        Console.Write("Digite o ID do produto: ");
                        int filtroId = int.Parse(Console.ReadLine());
                        estoque.FiltrarProdutoPorId(filtroId);
                    }

                    break;

                case 4:
                    Console.Clear();
                    decimal valorTotal = estoque.CalcularValorTotal();
                    Console.WriteLine($"Valor total em estoque: {valorTotal:C}");
                    break;

                case 5:

                    Console.WriteLine("Produtos disponíveis:");
                    estoque.ExibirProdutos();

                    Console.Write("\nDigite o ID do produto a ser alterado: ");
                    int alterarId = int.Parse(Console.ReadLine());

                    Console.Write("\nDigite o novo nome do produto: ");
                    string novoNome = Console.ReadLine();

                    Console.Write("Digite a nova quantidade do produto: ");
                    int novaQuantidade = int.Parse(Console.ReadLine());

                    Console.Write("Digite o novo preço do produto: ");
                    decimal novoPreco = decimal.Parse(Console.ReadLine());

                    estoque.AlterarProduto(alterarId, novoNome, novaQuantidade, novoPreco);

                    break;

                case 0:
                    Console.WriteLine("Saindo...");
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
        }
    }
}
