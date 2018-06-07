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
    public partial class CadastroVenda : Form
    {
		DAO dao;
		public CadastroVenda(DAO d)
        {
			dao = d;
            InitializeComponent();
            AtualizarGridVenda();
        }

        void btnNovo_Click(object sender, EventArgs e)
        {
            FormVenda fv = new FormVenda(dao);
            fv.ShowDialog();
			AtualizarGridVenda();
        }

		void btnCancelar_Click(object sender, EventArgs e){         
			CancelarVenda(dao.venda[dgVenda.CurrentCell.RowIndex]);
			AtualizarGridVenda();
		}

		void btnEditar_Click(object sender, EventArgs e){
			if (!EditarVenda(dao.venda[dgVenda.CurrentCell.RowIndex]))
				MessageBox.Show("Só é permitido editar vendas pendentes");
			AtualizarGridVenda();
		}
        
		bool EditarVenda(Venda venda){
			if(venda.StatusVenda == Status.Pendente){
                FormVenda editarVenda = new FormVenda(dao, venda);
                editarVenda.ShowDialog();
                AtualizarGridVenda();
				return true;
			}

			return false;
		}

		bool CancelarVenda(Venda venda){
			if(venda.StatusVenda != Status.Cancelado){
				venda.StatusVenda = Status.Cancelado;
				return true;
			}
			return false;
		}

        void AtualizarGridVenda()
        {
            dgVenda.Rows.Clear();
            dgVenda.AllowUserToAddRows = false;
            dgVenda.AllowDrop = false;
            dgVenda.AllowUserToDeleteRows = false;
            dgVenda.AllowUserToResizeColumns = false;
            dgVenda.AllowUserToResizeRows = false;
            
            dgVenda.ColumnCount = 5;
            //dgVenda.Columns[0].Width = 75;
            //dgVenda.Columns[1].Width = 180;
            
			dgVenda.Columns[0].Name = "Id";
            dgVenda.Columns[1].Name = "Cliente";
            dgVenda.Columns[2].Name = "Data";
            dgVenda.Columns[3].Name = "Total";
            dgVenda.Columns[4].Name = "Status";

			foreach(Venda v in dao.venda){
				List<string> row = new List<string>();

				if(v.Cliente == null){
					row.Add(v.IdVenda.ToString());               
					row.Add("");               
					row.Add(v.Data.ToString("dd/MM/yyyy"));
					row.Add("R$ "+v.Total().ToString());
					row.Add(v.StatusVenda.ToString());
                } else {               
                    row.Add(v.IdVenda.ToString());
                    row.Add(v.Cliente.ToString());
                    row.Add(v.Data.ToString("dd/MM/yyyy"));
					row.Add("R$ "+v.Total().ToString());
                    row.Add(v.StatusVenda.ToString());
				}

				dgVenda.Rows.Add(row.ToArray());
			}
        }

        // Fim da classe
    }
}
