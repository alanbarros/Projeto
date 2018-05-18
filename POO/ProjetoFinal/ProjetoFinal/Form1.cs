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
    public partial class Form1 : Form
    {
        private DAO dao;

        public Form1()
        {
            dao = new DAO();
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarCliente();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            RemoverCliente(listaClientes.SelectedIndex);
        }

        /// Controlers

        private void Atualizar()
        {
            listaClientes.Items.Clear();
            listaClientes.Items.AddRange(dao.cliente.ToArray());

            txtNome.Clear();
            txtCPF.Clear();
            txtEndereco.Clear();
        }

        private void AdicionarCliente()
        {
            Cliente c = new Cliente(txtNome.Text, txtCPF.Text, txtEndereco.Text);
            dao.AdicionarCliente(c);
            Atualizar();
        }

        private void RemoverCliente(int IndiceLista)
        {
            Cliente c = this.dao.cliente[IndiceLista];
            this.dao.RemoverCliente(c);
            Atualizar();
        }

        public void EditarCliente(int IndiceLista)
        {
            Cliente c = this.dao.cliente[IndiceLista];
            txtNome.Text = c.Nome;
            txtCPF.Text = c.Cpf;
            txtEndereco.Text = c.EnderecoDeEntrega;
        }
    }
}
