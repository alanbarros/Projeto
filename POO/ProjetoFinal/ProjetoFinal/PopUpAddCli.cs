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
    public partial class PopUpAddCli : Form
    {
        private DAO dao { get; set; }
        private int posicao;

        public PopUpAddCli(DAO d)
        {
            InitializeComponent();
            //mtxtDataNascimento.Mask = "00/00/0000";
            this.dao = d;
            this.posicao = -1;
        }

        public PopUpAddCli(DAO d, int posicao)
        {
            InitializeComponent();
            this.dao = d;
            this.posicao = posicao;
            PreencheForm(d.cliente[posicao]);
        }

        private void PreencheForm(Cliente c)
        {
            txtNome.Text = c.Nome.ToString();
            txtBairro.Text = c.EnderecoDeEntrega.Bairro.ToString();
            txtCep.Text = c.EnderecoDeEntrega.Cep.ToString();
            txtCidade.Text = c.EnderecoDeEntrega.Cidade.ToString();
            txtLougradouro.Text = c.EnderecoDeEntrega.Lougradouro.ToString();
            txtNumero.Text = c.EnderecoDeEntrega.Numero.ToString();
            cmbUf.Text = c.EnderecoDeEntrega.Uf.ToString();
            txtCPF.Text = c.Cpf.ToString();
            cmbStatus.Text = c.Status.ToString();
            mtxtDataNascimento.Text = c.DataNascimento.ToString();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (posicao > -1)
            {
                EditarCliente();
            }
            else
            {
                AdicionarCliente();
            }
        }

        // Controladores

        private void AdicionarCliente()
        {
            Endereco e = new Endereco(txtLougradouro.Text, int.Parse(txtNumero.Text), txtBairro.Text, txtCidade.Text, int.Parse(txtCep.Text), cmbUf.Text);
            DateTime d = new DateTime(long.Parse(mtxtDataNascimento.Text));
            Cliente c = new Cliente(txtNome.Text, txtCPF.Text, d, e, cmbStatus.Text);
            dao.AdicionarCliente(c);
            this.Close();
        }

        private void EditarCliente()
        {
            Endereco e = new Endereco(txtLougradouro.Text, int.Parse(txtNumero.Text), txtBairro.Text, txtCidade.Text, int.Parse(txtCep.Text), cmbUf.Text);
            DateTime d = new DateTime(long.Parse(mtxtDataNascimento.Text));
            Cliente c = new Cliente(txtNome.Text, txtCPF.Text, d, e, cmbStatus.Text);
            dao.cliente[posicao] = c;
            this.Close();
        }
    }
}
