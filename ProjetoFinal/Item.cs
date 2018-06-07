using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    public class Item
    {
		public int Id { get; set; }
		public Produto Produto { get; private set; }
		public int Quantidade { get; private set; }

        public Item() { }

        public Item(Produto p, int qtd)
        {
            Produto = p;
            Quantidade = qtd;
            if (Quantidade > 0) Total(); // Fazer tratativa caso a quantidade for igual ou menor que zero.
		}
        
        public double Total()
        {
            return Produto.preco * Quantidade;
        }
    }
}
