using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    class DAO
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

        public void RemoverCliente(Cliente cliente)
        {
            this.cliente.Remove(cliente);
        }

        public void EditarCliente(int posicao, Cliente cliente)
        {
            this.cliente[posicao] = cliente;
        }

    }
}
