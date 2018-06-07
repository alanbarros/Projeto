using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
	public partial class DAO
	{
		public List<Cliente> cliente;
		public List<Produto> produto;
        public List<Venda> venda;

		public DAO()
		{
			cliente = new List<Cliente>();
			produto = new List<Produto>();
            venda = new List<Venda>();

			BaseTeste();
		}


		void BaseTeste(){
			DateTime data = new DateTime(2000, 01, 01);
			Endereco endereco = new Endereco("Rua 01", "12A", "Sao Joao", "São Paulo", "00000-000", "SP");
			Cliente cli = new Cliente("Fulano da Silva", "999.999.999-99", data, endereco, "Ativo");

			Produto prod = new Produto("Mouse", 12.90, "Jetline", "Computador", "Ativo", 3);

			cliente.Add(cli);
			produto.Add(prod);
		}


	}
}
