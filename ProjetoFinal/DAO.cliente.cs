namespace ProjetoFinal{
	partial class DAO{
		
		public void AdicionarCliente(Cliente cliente)
        {
            this.cliente.Add(cliente);
        }

        public bool RemoverCliente(Cliente cliente)
        {
            try
            {
                this.cliente.Remove(cliente);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RedefinirCliente(Cliente cliente)
        {
            this.cliente[this.cliente.IndexOf(cliente)] = cliente;
        }
	}
}