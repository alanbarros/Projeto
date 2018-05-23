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
    public partial class FormCliente : Form
    {
        DAO dao;
        DateTime dataNasc;
        Cliente cliente;
        List<string> listaStatus;

		public FormCliente(DAO d, Cliente c){
			// Gerando Lista de strings para a Enum Status
            var s = Enum.GetValues(typeof(StatusEnum));
            listaStatus = new List<string>();
            foreach (var x in s)
            {
                listaStatus.Add(x.ToString());
            }

            InitializeComponent();

            this.dao = d;
			int pos = d.cliente.IndexOf(c);

			if(pos > -1){
				PreencheForm(d.cliente[pos]);
				cliente = d.cliente[pos];
			}
		}
        
        void BtnGravar_Click(object sender, EventArgs e)
        {
			if (cliente != null)
            {
                EditarCliente();
            }
            else
            {
                AdicionarCliente();
            }
        }

        void BtnCancelar_Click(object sender, EventArgs e){
            this.Close();
        }

        // Controladores

        void PreencheForm(Cliente c) // Preence o formulário
        {
            txtNome.Text = c.Nome;
            txtBairro.Text = c.EnderecoDeEntrega.Bairro;
            txtCep.Text = c.EnderecoDeEntrega.Cep;
            txtCidade.Text = c.EnderecoDeEntrega.Cidade;
            txtLougradouro.Text = c.EnderecoDeEntrega.Lougradouro;
            txtNumero.Text = c.EnderecoDeEntrega.Numero;
            cmbUf.Text = c.EnderecoDeEntrega.Uf;
            txtCPF.Text = c.Cpf;
            cmbStatus.Text = c.Status.ToString();
            mtxtDataNascimento.Text = c.DataNascimento.ToString("dd/MM/yyyy");
        }

        bool ConverterParaData(string texto) // Define a variavel dataNasc convertendo de string
        {
            DateTime dataConvertida;
            try
            {
                dataConvertida = Convert.ToDateTime(texto);
                dataNasc = dataConvertida;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        bool MontarCliente() // Atribui o valor da variavel cliente
        {
			Endereco e = new Endereco(txtLougradouro.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, txtCep.Text, cmbUf.Text);
				
            // Convertendo string do combobox para enum
            Enum.TryParse(cmbStatus.Text, out StatusEnum Status);
         
            if(ConverterParaData(mtxtDataNascimento.Text))
            {
				cliente = new Cliente(txtNome.Text, txtCPF.Text, dataNasc, e, Status);
                return true;
            } else
            {
                MessageBox.Show("Verifique a data");
                return false;
            }
        }

        void AdicionarCliente()
        {
			if (dao.cliente.Contains(new Cliente(txtCPF.Text)))
            {
				MessageBox.Show("Já existe um usuário com este CPF");
			} else if(MontarCliente()){ // Chama a função MontarCliente e verificar se retorna true            
                dao.AdicionarCliente(cliente); // Se der certo, adiciona um novo cliente
                this.Close();
            }
        }
        
        void EditarCliente()
        {         
            if (MontarCliente()) // Se conseguir montar a classe
            {            
				dao.EditarCliente(cliente); // Chama a função para editar o cliente atualizado
                this.Close();
            }
        }

        // Fim da classe
    }
}
