using System;
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

		private void listClientes_DoubleClick(object sender, EventArgs e)
		{
			EditarCliente(listClientes.SelectedIndex);
		}

		void BtnBuscar_Click(object sender, EventArgs e)
		{         
			Buscar(txtBuscar.Text);         
		}

		void btnExcluir_Click(object sender, EventArgs e)
		{
			ExcluirCliente();
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

		void Buscar(string cpf)
		{
			if (dao.cliente.Count == 0)
			{
				MessageBox.Show("Não ha clientes");
			}
			else if (!EditarCliente(new Cliente(cpf)))
			{
				MessageBox.Show("Cliente não encontrado!");
			}
		}

		private void AtualizarLista()
		{
			listClientes.Items.Clear();
			listClientes.Items.AddRange(this.dao.cliente.ToArray());
		}

		private void AdicionarNovo()
		{
			FormCliente popup = new FormCliente(dao, new Cliente());
			popup.ShowDialog();
			AtualizarLista();
		}

		bool EditarCliente(int posicao)
		{
			if( posicao > -1){
				FormCliente poup = new FormCliente(dao, dao.cliente[posicao]);            
                poup.ShowDialog();
                AtualizarLista();
				return true;
			}
			return false;
		}

		bool EditarCliente(Cliente cliente)
		{
			int posicao = dao.cliente.IndexOf(cliente);
			return EditarCliente(posicao);
		}

		void ExcluirCliente()
		{
			if (listClientes.SelectedIndex > -1)
            {
                dao.RemoverCliente(dao.cliente[listClientes.SelectedIndex]);
            }
            else
            {
                MessageBox.Show("Selecione um cliente antes!");
            }
		}
        // Fim da Classe
	}
}
