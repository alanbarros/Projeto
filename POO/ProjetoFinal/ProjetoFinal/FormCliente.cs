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
			int saida = cliente == null ? AdicionarCliente() : EditarCliente();
			switch(saida){
				case -1:
					MessageBox.Show("Data com formato inválido");
					break;
				case -2:
					MessageBox.Show("Nome não pode ser em branco");
					break;
				case -3:
					MessageBox.Show("CPF já cadastrado");
					break;
				case -4:
					MessageBox.Show("CPF não pode ser em branco");
					break;
			}

			// Debug // if (saida != 1) MessageBox.Show(saida.ToString());
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
			mtxtDataNascimento.Text = c.DataNascimento.Equals(new DateTime()) ? "" : c.DataNascimento.ToString("dd/MM/yyyy");
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
			if (txtNome.Text == "") return -2; // Se o nome for vazio
			if (ConfereCpf() == -1) return -3; // Se o CPF estiver vazio

			try{
				Endereco e = new Endereco(txtLougradouro.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, txtCep.Text, cmbUf.Text);
				Enum.TryParse(cmbStatus.Text, out StatusEnum Status); // Convertendo string do combobox para enum
				cliente = new Cliente(txtNome.Text, txtCPF.Text, dataNasc, e, Status);	
			} catch (FormatException) {
				return 0; // Erro desconhecido
			}
            
			return 1; // Se tudo der certo;
		}
        
		int ConfereCpf(){
			if(txtCPF.Text == "") return -1; // Se o campo CPF for nulo, retorna -1
			return dao.cliente.Contains(new Cliente(txtCPF.Text)) ? 0 : 1; // Se já exite cpf, retorna 0 se não retorna 1
		}

		int ConfereData(){
			if (mtxtDataNascimento.Text == "") return -1; // Se a data não for digitada, retorna -1
			return ConverterParaData(mtxtDataNascimento.Text) ? 1 : 0; // Se conseguir converter em data retorna 1, se não retorna 0;
		}
        
		int AdicionarCliente(){ // return 1,-1,-2 (Montagem cliente) return -4 cpf vazio e -3 ja existe
			int cpf = ConfereCpf();

			if (cpf == -1) return -4; // Se CPF não for digitado

			if (cpf == 0) return -3; // Se CPF já exista

			int criacao = MontarCliente();

			if(criacao == 1){
                dao.AdicionarCliente(cliente); // Adiciona um novo cliente
                Close();
			}

			return criacao;
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
