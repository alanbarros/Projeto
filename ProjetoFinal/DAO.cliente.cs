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

        public bool RedefinirCliente(Cliente cliente)
        {
            int posicao = this.cliente.IndexOf(cliente);

            try
            {
                this.cliente[posicao] = cliente;
            } catch {
                return false;
            }

            return true;
        }
	}
}