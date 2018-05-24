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

		void btnNovo_Click(object sender, EventArgs e)
		{
			AdicionarNovo();
		}

		void listClientes_DoubleClick(object sender, EventArgs e)
		{
			bool result = listClientes.SelectedIndex > -1 ? true : false; // Verifica se selecionou algum item na lista
			if (result) EditarCliente(dao.cliente[listClientes.SelectedIndex]); // Se tiver algum item selecionado, chama a função
		}

		void BtnBuscar_Click(object sender, EventArgs e)
		{
			if (!EditarCliente(new Cliente(txtBuscar.Text))){
				MessageBox.Show("Cliente não localizado");
			}        
		}

		void btnExcluir_Click(object sender, EventArgs e)
		{
			if(!ExcluirCliente(dao.cliente[listClientes.SelectedIndex]))
				MessageBox.Show("Selecione antes um cliente");
		}

		void btnEditar_Click(object sender, EventArgs e)
		{         
			if (!EditarCliente(dao.cliente[listClientes.SelectedIndex]))
				MessageBox.Show("Selecione um cliente antes!");
		}

		// Controlers

		void AtualizarLista()
		{
			listClientes.Items.Clear();
			listClientes.Items.AddRange(this.dao.cliente.ToArray());
		}

		void AdicionarNovo()
		{
			FormCliente popup = new FormCliente(dao, new Cliente());
			popup.ShowDialog();
			AtualizarLista();
		}

		bool EditarCliente(Cliente cliente)
		{
			if(dao.cliente.Contains(cliente)){
				FormCliente editCli = new FormCliente(dao, cliente);
				editCli.ShowDialog();
				AtualizarLista();
				return true;
			}
			return false;         
		}

		bool ExcluirCliente(Cliente cliente)
		{
			if (dao.cliente.Contains(cliente)){
				dao.RemoverCliente(cliente);
				AtualizarLista();
				return true;
            }
			return false;
		}

        // Fim da Classe
	}
}
