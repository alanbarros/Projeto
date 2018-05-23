using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    public class DAO
    {
        public List<Cliente> cliente;

        public DAO()
        {
            cliente = new List<Cliente>();
        }

        public void AdicionarCliente(Cliente cliente)
        {
            this.cliente.Add(cliente);
        }

        public bool RemoverCliente(Cliente cliente)
        {
			try{
				this.cliente.Remove(cliente);
				return true;
			} catch{
				return false;
			}
        }

        public void EditarCliente(Cliente cliente)
        {
			this.cliente[this.cliente.IndexOf(cliente)] = cliente;
        }

    }
}
