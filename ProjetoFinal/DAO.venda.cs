namespace ProjetoFinal
{
    public partial class DAO
    {
        public void AdicionarVenda(Venda venda)
        {
            this.venda.Add(venda);
        }

        public bool RemoverVenda(Venda venda)
        {
            try
            {
                this.venda.Remove(venda);
            }
            catch
            {
                return false;
            }

			return true;
        }

        public void RedefinirVenda(Venda venda)
        {
            this.venda[this.venda.IndexOf(venda)] = venda;
        }
    }
}