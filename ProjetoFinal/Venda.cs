using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
	public class Venda
	{
		public List<Item> Itens { get; private set; }
		public Cliente Cliente { get; private set; }
		static int sequencia = 0;
		public int IdVenda { get; private set; }
		public DateTime Data { get; private set; }
		public int IdItem { get; private set; }
		public Status StatusVenda { get; set; }

		public Venda() // Molde para venda
		{
			Itens = new List<Item>();
        }

		public Venda (List<Item> itens){ // Criando uma venda sem cliente declarado         
            IdVenda = ++sequencia;
            Data = DateTime.Today;
            Itens = itens;
		}

		public Venda(Cliente cliente, List<Item> itens) // Criando uma venda com cliente declarado
        {
			IdVenda = ++sequencia;
			Data = DateTime.Today;
            Itens = itens;
            Cliente = cliente;
        }
        
		public Venda(Venda venda){ // Construtor para editar um avenda pendente
			IdVenda = venda.IdVenda;
			Itens = venda.Itens;
			StatusVenda = venda.StatusVenda;
		}

		public void AdicionarItem(Item item){
			item.Id = Itens.Count + 1;
			Itens.Add(item);
		}

		public bool DefinirCliente(Cliente cliente){
			try{
				Cliente = cliente;	
			} catch{
				return false;
			}
			return true;
		}

        public double Total()
        {
            double total = 0;

            foreach (var i in Itens)
            {
                total += i.Total();
            }
            return total;
        }

		public override bool Equals(object obj)
		{
			Venda venda = obj as Venda;

			if(venda == null){
				return false;
			}

			return IdVenda.Equals(venda.IdVenda);
		}

		public override int GetHashCode()
		{
			return IdVenda.GetHashCode();
		}

		// Fim da classe
	}   
    public enum Status
    {
        Pago, Cancelado, Pendente
    }
}
