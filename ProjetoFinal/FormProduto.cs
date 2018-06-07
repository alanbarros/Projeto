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
    public partial class FormProduto : Form
    {
        DAO dao;
        Produto produto;
        public FormProduto(DAO d, Produto p)
        {
            InitializeComponent();

            dao = d;
            var pos = d.produto.IndexOf(p);

            if (pos > -1)
            {
                PreencheForm(d.produto[pos]);
                produto = d.produto[pos];
            }
        }

        void btnGravarProduto_Click(object sender, EventArgs e)
        {
            if (produto == null)
            {
                if (AdicionarProduto() == 0) MessageBox.Show("Preencha todos os campos!");
            } else
            {
                if (EditarProduto() == 0) MessageBox.Show("Preencha todos os campos!");
            }
        }

        private void btnCancelarProduto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void PreencheForm(Produto p) // Preence o formulário
        {
            txtDescricaoProduto.Text = p.nome;
            txtPrecoProduto.Text = p.preco.ToString();
            txtMarcaProduto.Text = p.marca;
            cmbTipoProduto.Text = p.tipo;
            cmbStatusProduto.Text = p.status;
            txtGarantiaProduto.Text = p.garantia.ToString();
            txtId.Text = p.idProduto.ToString();
        }

        int MontarProduto(Montagem m) // retorna 1 se montar cliente com sucesso.
        {
            try
            {
                if(m == Montagem.Adicionar)
                {
                    produto = new Produto(txtDescricaoProduto.Text, double.Parse(txtPrecoProduto.Text), txtMarcaProduto.Text, cmbTipoProduto.Text, cmbStatusProduto.Text, int.Parse(txtGarantiaProduto.Text));
                }
                else
                {
                    produto = new Produto(txtDescricaoProduto.Text, double.Parse(txtPrecoProduto.Text), txtMarcaProduto.Text, cmbTipoProduto.Text, cmbStatusProduto.Text, int.Parse(txtGarantiaProduto.Text), this.produto.idProduto);
                }
            }
            catch (FormatException)
            {
                return 0; // Erro desconhecido
            }

            return 1; // Se tudo der certo;
        }

        int AdicionarProduto()
        {

            var criacao = MontarProduto(Montagem.Adicionar);

            if (criacao == 1)
            {
                dao.AdicionarProduto(produto);
                Close();
            }

            return criacao;
        }

        int EditarProduto()
        {
            var criacaoProduto = MontarProduto(Montagem.Editar);

            if (criacaoProduto == 1) // Se conseguir montar a o objeto cliente
            {
                dao.RedefinirProduto(produto);
                Close();
            }

            return criacaoProduto;
        }

        
    }

    enum Montagem
    {
        Editar, Adicionar
    }
}
