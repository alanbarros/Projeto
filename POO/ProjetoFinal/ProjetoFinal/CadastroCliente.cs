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
    public partial class CadastroCliente : Form
    {
        DAO dao;
        public CadastroCliente()
        {
            InitializeComponent();
            dao = new DAO();
        }

		private void btnNovo_Click(object sender, EventArgs e)
		{
			AdicionarNovo();
		}

		private void listClientes_DoubleClick(object sender, EventArgs e){
			EditarCliente();
		}

		void BtnBuscar_Click(object sender, EventArgs e){
			MessageBox.Show("Clicado!");
			Buscar(txtBuscar.ToString());
		}

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            bool foi = ExcluirCliente();

            if (!foi)
            {
                MessageBox.Show("Selecione um cliente antes!");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool foi = EditarCliente();

            if (!foi)
            {
                MessageBox.Show("Selecione um cliente antes!");
            }
        }

        // Controlers
        
		void Buscar(string cpf){
			Cliente cliente;
			foreach(Cliente c in dao.cliente){
				if(c.Equals(cpf)){
					cliente = c;
					MessageBox.Show("Encontrado!");
					break;
				}
				MessageBox.Show("Não encontrado");
			}

		}

       private void AtualizarLista()
        {
            listClientes.Items.Clear();
            listClientes.Items.AddRange(this.dao.cliente.ToArray());
        }

        private void AdicionarNovo()
        {
            FormCliente popup = new FormCliente(dao);
            popup.ShowDialog();
            AtualizarLista();
        }

        private bool EditarCliente()
        {
            int posicao = listClientes.SelectedIndex;
            if(posicao > -1)
            {
                FormCliente popup = new FormCliente(dao, posicao);
                popup.ShowDialog();
                AtualizarLista();

                return true;
            } else
            {
                return false;
            }
        }

        private bool ExcluirCliente()
        {
            int posicao = listClientes.SelectedIndex;
            if (posicao > -1)
            {
                dao.RemoverCliente(dao.cliente[posicao]);
                AtualizarLista();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
