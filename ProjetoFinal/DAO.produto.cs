using System;
using System.Windows.Forms;

namespace ProjetoFinal
{
    partial class DAO
    {

        public void AdicionarProduto(Produto produto)
        {
            this.produto.Add(produto);
        }

        public bool RemoverProduto(Produto produto)
        {
            try
            {
                this.produto.Remove(produto);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RedefinirProduto(Produto produto)
        {

            int posicao = this.produto.IndexOf(produto);

            try
            {
                this.produto[posicao] = produto;
            } catch
            {
                return false;
            }

            return true;
        }
    }
}
