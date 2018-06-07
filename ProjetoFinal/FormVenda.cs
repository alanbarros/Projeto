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
    public partial class FormVenda : Form
    {
        DAO dao;
        Venda venda;
		bool editar;

        public FormVenda(DAO d) // Contrutor para uma venda nova
        {
            InitializeComponent();
            dao = d;
            venda = new Venda();

            AtualizaGridFormItem();
        }

		public FormVenda(DAO d, Venda v){ // Contrutor para edição de uma venda
			InitializeComponent();
			venda = v;
			dao = d;
			editar = true;
			AtualizaGridFormItem();
			PreecheEdicao();
		}

        void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        
		void btnGravar_Click(object sender, EventArgs e){         
			MontarVenda();
			Close();
		}

        void btnAdicionar_Click(object sender, EventArgs e)
        {
            TelaAdicionarItem();
        }

        void TelaAdicionarItem()
        {         
            FormItem formItem = new FormItem(dao, venda);
            formItem.ShowDialog();
			AtualizaGridFormItem();
        }

		void MontarVenda(){

			if (!editar)
			{
				try
				{
					venda.DefinirCliente(dao.cliente[cmbCliente.SelectedIndex]); // Atribui cliente à venda
					venda = new Venda(venda.Cliente, venda.Itens); // Cria a venda definitiva com o ID   
				}
				catch
				{
					venda = new Venda(venda.Itens);
				}

				dao.venda.Add(venda); // Persiste a nova venda na base

			} else {
				dao.venda[dao.venda.IndexOf(venda)] = venda; // Persiste a venda alterada na base
			}
            
            switch (cmbStatus.Text)
            {
                case "Pago":
                    venda.StatusVenda = Status.Pago;
                    break;
                case "Cancelado":
                    venda.StatusVenda = Status.Cancelado;
                    break;
                case "Pendente":
                    venda.StatusVenda = Status.Pendente;
                    break;
                default:
                    venda.StatusVenda = Status.Pendente;
                    break;
            }
		}

		void PreecheEdicao(){
			cmbStatus.Text = venda.StatusVenda.ToString();
			if(venda.Cliente != null){
				cmbCliente.Text = venda.Cliente.ToString();
				cmbCliente.Enabled = false;
			}
		}

        void AtualizaGridFormItem() //Atualiza o DataGrid do FormVenda, o ID da venda, o ComboBox dos clientes
        {
            cmbCliente.Items.AddRange(dao.cliente.ToArray());
			lblCodigo.Text = !editar ? (dao.venda.Count + 1).ToString() : venda.IdVenda.ToString();

            dgFormVenda.Rows.Clear();
            dgFormVenda.AllowUserToAddRows = false;
            dgFormVenda.AllowDrop = false;
            dgFormVenda.AllowUserToDeleteRows = false;
            dgFormVenda.AllowUserToResizeColumns = false;
            dgFormVenda.AllowUserToResizeRows = false;
            
            dgFormVenda.ColumnCount = 5;
            //dgFormVenda.Columns[0].Width = 75;         

            dgFormVenda.Columns[0].Name = "Item";
            dgFormVenda.Columns[1].Name = "Produto";
            dgFormVenda.Columns[2].Name = "Qtd";
            dgFormVenda.Columns[3].Name = "Preço Unitário";
            dgFormVenda.Columns[4].Name = "Preço Total";
            
            
			foreach (Item i in venda.Itens)
            {
				string[] row = { i.Id.ToString(), i.Produto.nome, i.Quantidade.ToString(), i.Produto.preco.ToString(), i.Total().ToString()};
				dgFormVenda.Rows.Add(row);
            }  
        }

        // Fim da classe
    }
}
