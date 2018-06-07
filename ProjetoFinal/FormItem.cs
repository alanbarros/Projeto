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
    public partial class FormItem : Form
    {
        DAO dao;
		Venda venda;
		Item item;

        public FormItem(DAO d, Venda v)
        {
            InitializeComponent();
            dao = d;
            venda = v;
			AtualizaGridView();
        }

        void AtualizaGridView()
        {
            dgFormItem.Rows.Clear();
            dgFormItem.AllowUserToAddRows = false;
            dgFormItem.AllowDrop = false;
            dgFormItem.AllowUserToDeleteRows = false;
            dgFormItem.AllowUserToResizeColumns = false;
            dgFormItem.AllowUserToResizeRows = false;

            dgFormItem.ColumnCount = 2;
            dgFormItem.Columns[0].Width = 350;
            dgFormItem.Columns[1].Width = 100;
            dgFormItem.Columns[0].Name = "Descrição";
            dgFormItem.Columns[1].Name = "Preço";

            foreach (Produto p in dao.produto)
            {
                string[] row = { p.nome, p.preco.ToString() }; // Refatorar tostring do produto para retornar R$.
                dgFormItem.Rows.Add(row);
            }
        }

        int GridLinha()
        {  // Verifica se selecionou algum item na grid       
            try { return dgFormItem.CurrentCell.RowIndex; }
            catch { return -1; }
        }
        
        void btnGravar_Click(object sender, EventArgs e)
		{
			int indice;

			if( GridLinha() > -1 ){            
                if (int.TryParse(txtQtd.Text, out indice))
                    {
                        if (MontarItem(dao.produto[GridLinha()], indice))
                        {
                            venda.AdicionarItem(item);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao montar item");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Digite a quantidade");
                    }				
			} else {
				MessageBox.Show("Nenhum item selecionado.");	
			}
        }

		bool MontarItem(Produto produto, int qtd){
			try{
				item = new Item(produto, qtd);
			} catch{
				return false;
			}

			return true;
		}

        void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
