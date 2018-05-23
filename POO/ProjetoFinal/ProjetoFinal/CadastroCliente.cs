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
			EditarCliente(listClientes.SelectedIndex);
		}

		void BtnBuscar_Click(object sender, EventArgs e){
			Buscar(txtBuscar.Text);
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
			bool foi = EditarCliente(listClientes.SelectedIndex);

            if (!foi)
            {
                MessageBox.Show("Selecione um cliente antes!");
            }
        }

        // Controlers
        
		void Buscar(string cpf){

			if (dao.cliente.Count == 0)
			{
				MessageBox.Show("Não ha clientes");
			}
			else
			{
				if (!EditarCliente(new Cliente(cpf)))
				{
					MessageBox.Show("Cliente não encontrado!");
				}
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

        private bool EditarCliente(int posicao)
        {
            if(posicao > -1)
            {
                FormCliente popup = new FormCliente(dao, posicao);
                popup.ShowDialog();
                AtualizarLista();

                return true;
            } 
			return false;
        }

		bool EditarCliente(Cliente cliente){
			int posicao = dao.cliente.IndexOf(cliente);
			if(posicao > -1){
				return EditarCliente(posicao);
			}          
			return false;         
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
