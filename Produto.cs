using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEstoque
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public Produto(int id, string nome, int quantidade, decimal precoUnitario)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public override string ToString()
        {
            return $"{Id,-5} | {Nome,-15} | {Quantidade,-12} | {PrecoUnitario,-15:C}";
        }
    }
}
