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

       private void AtualizarLista()
        {
            listClientes.Items.Clear();
            listClientes.Items.AddRange(this.dao.cliente.ToArray());
        }

        private void AdicionarNovo()
        {
            PopUpAddCli popup = new PopUpAddCli(dao);
            popup.ShowDialog();
            AtualizarLista();
        }

        private bool EditarCliente()
        {
            int posicao = listClientes.SelectedIndex;
            if(posicao > -1)
            {
                PopUpAddCli popup = new PopUpAddCli(dao, posicao);
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
