using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class CadastroProduto : Form
    {
        DAO dao;
        public CadastroProduto(DAO d)
        {
            InitializeComponent();
            dao = d;
        }

        void btnNovoProduto_Click(object sender, EventArgs e)
        {
            TelaAdicionar(new Produto());
        }

        void Atualizar()
        {
            
        }

        void TelaAdicionar(Produto produto)
        {
            var pop = new FormProduto(dao, produto);
            pop.ShowDialog();
            AtualizaGridView();
        }

        private void btnEditarProduto_Click(object sender, EventArgs e)
        {
            if (GridLinha() > -1)
                TelaEditar(dao.produto[dataGriProduto.CurrentCell.RowIndex]); // Se tiver algum item selecionado, chama a função
            else
                MessageBox.Show("Selecione um item antes");
        }

        bool TelaEditar(Produto produto)
        {
            if (dao.produto.Contains(produto))
            {
                var editPro = new FormProduto(dao, produto);
                editPro.ShowDialog();
                AtualizaGridView();
                return true;
            }
            return false;
        }

        int GridLinha()
        {  // Verifica se selecionou algum item na grid       
            try { return dataGriProduto.CurrentCell.RowIndex; }
            catch { return -1; }
        }

        void AtualizaGridView()
        {
            dataGriProduto.Rows.Clear();
            dataGriProduto.AllowUserToAddRows = false;
            dataGriProduto.AllowDrop = false;
            dataGriProduto.AllowUserToDeleteRows = false;
            dataGriProduto.AllowUserToResizeColumns = false;
            dataGriProduto.AllowUserToResizeRows = false;

            dataGriProduto.ColumnCount = 4;
            dataGriProduto.Columns[0].Width = 200;
            dataGriProduto.Columns[2].Width = 180;
            dataGriProduto.Columns[0].Name = "Nome";
            dataGriProduto.Columns[1].Name = "Preço";
            dataGriProduto.Columns[2].Name = "Marca";
            dataGriProduto.Columns[3].Name = "STATUS";

            foreach (Produto p in dao.produto)
            {
                string[] row = { p.nome, p.preco.ToString(), p.marca, p.status };
                dataGriProduto.Rows.Add(row);
            }
        }

        private void btnExcluirProduto_Click(object sender, EventArgs e)
        {
            if (GridLinha() > -1)
                if (dao.RemoverProduto(dao.produto[GridLinha()])) AtualizaGridView();
                else
                    MessageBox.Show("Selecione antes um cliente");
        }

        private void btnBuscarProduto_Click(object sender, EventArgs e)
        {
            string texto = txtBuscarProduto.Text;

            int i = dao.produto.FindIndex(p => p.nome == texto);

            if (i < 0)
                MessageBox.Show("Cliente não localizado");
            else
                TelaEditar(dao.produto[i]);
        }
    }
}
