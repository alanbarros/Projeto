using System;
using System.Windows.Forms;

namespace ProjetoFinal
{
	public partial class CadastroCliente : Form
	{
		DAO dao;
		public CadastroCliente(DAO d)
		{
			InitializeComponent();
            dao = d;
		}

		void btnNovo_Click(object sender, EventArgs e)
		{
			AdicionarNovo();
		}

		void listClientes_DoubleClick(object sender, EventArgs e)
		{
			bool result = dgCliente.CurrentCell.RowIndex > -1 ? true : false; // Verifica se selecionou algum item na lista
			if (result) EditarCliente(dao.cliente[dgCliente.CurrentCell.RowIndex]); // Se tiver algum item selecionado, chama a função
		}

		void BtnBuscar_Click(object sender, EventArgs e)
		{
			if (!EditarCliente(new Cliente(txtBuscar.Text))){
				MessageBox.Show("Cliente não localizado");
			}        
		}

		void btnExcluir_Click(object sender, EventArgs e)
		{
			if(!ExcluirCliente(dao.cliente[dgCliente.CurrentCell.RowIndex]))
				MessageBox.Show("Selecione antes um cliente");
		}

		void btnEditar_Click(object sender, EventArgs e)
		{
            bool result = dgCliente.CurrentCell.RowIndex > -1 ? true : false; // Verifica se selecionou algum item na lista
            if (result) EditarCliente(dao.cliente[dgCliente.CurrentCell.RowIndex]); // Se tiver algum item selecionado, chama a função
            else
            {
                MessageBox.Show("Selecione um cliente antes!"); 
            }
            
		}

		// Controlers

        void PreencheGrid()
        {
            dgCliente.Rows.Clear();

            dgCliente.ColumnCount = 4;
            dgCliente.Columns[0].Name = "Nome";
            dgCliente.Columns[1].Name = "Idade";
            dgCliente.Columns[2].Name = "CPF";
            dgCliente.Columns[3].Name = "STATUS";

            foreach (Cliente c in dao.cliente)
            {
                DateTime hoje = DateTime.Today;

                string[] row = new string[] { c.Nome, (hoje - c.DataNascimento).ToString(), c.Cpf, c.Status };
                dgCliente.Rows.Add(row);
            }

            

        }

        void AtualizarLista()
		{
            PreencheGrid();
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

        private void dgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Fim da Classe
    }
}
