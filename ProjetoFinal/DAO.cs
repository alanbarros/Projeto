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

		public DAO()
		{
			cliente = new List<Cliente>();
			produto = new List<Produto>();

		}



	}
}
