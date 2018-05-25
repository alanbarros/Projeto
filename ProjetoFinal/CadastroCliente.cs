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
			AtualizaGridView();
		}

		void BtnNovo_Click(object sender, EventArgs e)
		{
			TelaAdicionar(new Cliente());
		}

		void BtnBuscar_Click(object sender, EventArgs e)
		{
			if (!TelaEditar(new Cliente(txtBuscar.Text)))
				MessageBox.Show("Cliente não localizado");
			else 
				AtualizaGridView();
		}

		void BtnExcluir_Click(object sender, EventArgs e)
		{         
			if (GridLinha() > -1)
    			if(dao.RemoverCliente(dao.cliente[GridLinha()])) AtualizaGridView();
			else
				MessageBox.Show("Selecione antes um cliente");
		}

		void BtnEditar_Click(object sender, EventArgs e)
		{
			if (GridLinha() > -1)
				TelaEditar(dao.cliente[dgCliente.CurrentCell.RowIndex]); // Se tiver algum item selecionado, chama a função
			else
				MessageBox.Show("Selecione um item antes");   
		}

		// Controlers

		void AtualizaGridView()
        {
            dgCliente.Rows.Clear();
			dgCliente.AllowUserToAddRows = false;
			dgCliente.AllowDrop = false;
			dgCliente.AllowUserToDeleteRows = false;
			dgCliente.AllowUserToResizeColumns = false;
			dgCliente.AllowUserToResizeRows = false;

            dgCliente.ColumnCount = 4;
			dgCliente.Columns[0].Width = 200;         
            dgCliente.Columns[2].Width = 180;
            dgCliente.Columns[0].Name = "Nome";
            dgCliente.Columns[1].Name = "Idade";
            dgCliente.Columns[2].Name = "CPF";
            dgCliente.Columns[3].Name = "STATUS";

            foreach (Cliente c in dao.cliente)
            {
				string[] row = { c.Nome, c.Idade().ToString(), c.Cpf, c.Status };
                dgCliente.Rows.Add(row);
            }         
        }      

        int GridLinha()
        {  // Verifica se selecionou algum item na grid       
			try { return dgCliente.CurrentCell.RowIndex; }
			catch { return -1; }
        }

		void TelaAdicionar(Cliente cliente)
		{
			var popup = new FormCliente(dao, cliente);
			popup.ShowDialog();
			AtualizaGridView();
		}

		bool TelaEditar(Cliente cliente)
		{
			if(dao.cliente.Contains(cliente)){
				var editCli = new FormCliente(dao, cliente);
				editCli.ShowDialog();
				AtualizaGridView();
				return true;
			}
			return false;         
		}
    }
}
