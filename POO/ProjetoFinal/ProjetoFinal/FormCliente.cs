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
				MessageBox.Show(EditarCliente().ToString());
            }
            else
            {
				MessageBox.Show(AdicionarCliente().ToString());
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

		int MontarCliente() // retorna 1 se montar cliente com sucesso.
		{         
			if (ConfereData() == 0) return -1; // Se não conseguir converter a data;
			if (txtNome.Text == null) return -2; // Se o nome for nulo
			if (ConfereCpf() == -1) return -3; // Se o CPF estiver vazio

			try{
				Endereco e = new Endereco(txtLougradouro.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, txtCep.Text, cmbUf.Text);
				Enum.TryParse(cmbStatus.Text, out StatusEnum Status); // Convertendo string do combobox para enum
				cliente = new Cliente(txtNome.Text, txtCPF.Text, dataNasc, e, Status);	
			} catch {
				return 0; // Erro desconhecido
			}
            
			return 1; // Se tudo der certo;
		}

		int ConfereCpf(){
			if(txtCPF == null) return -1; // Se o campo CPF for nulo, retorna -1
			return dao.cliente.Contains(new Cliente(txtCPF.Text)) ? 1 : 0; // Se já exite cpf, retorna 0 se não retorna 1
		}

		int ConfereData(){
			if (mtxtDataNascimento != null) return -1; // Se a data não for digitada, retorna -1
			return ConverterParaData(mtxtDataNascimento.Text) ? 1 : 0; // Se conseguir converter em data retorna 1, se não retorna 0;
		}
        
		int AdicionarCliente(){
			int criacaoCliente = MontarCliente();
			int cpfNovo = ConfereCpf();
			if(criacaoCliente == 1 && cpfNovo == 1){
                dao.AdicionarCliente(cliente); // Adiciona um novo cliente
                Close();
				return criacaoCliente;
			}
			return criacaoCliente == 1 ? 10 : criacaoCliente; // Retorna erro cpf caso cliente estiver ok, e retorna erro cliente caso contrario;
        }
        
        int EditarCliente(){
			int criacaoCliente = MontarCliente();

			if (criacaoCliente == 1) // Se conseguir montar a o objeto cliente
            {            
				dao.EditarCliente(cliente); // Chama a função para editar o cliente atualizado
                Close();
			}

			return criacaoCliente;
        }

        // Fim da classe
    }
}
