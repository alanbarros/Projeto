using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    public class Cliente : Pessoa
    {
        public Endereco EnderecoDeEntrega { get; private set; }
        public string Status { get; private set; }

        public Cliente(string Nome, string Cpf, DateTime DataNascimento, Endereco EnderecoDeEntrega, string Status) : base(Nome, Cpf, DataNascimento)
        {
            this.EnderecoDeEntrega = EnderecoDeEntrega;
            this.Status = Status;
        }

        public string ImprimaEndereco()
        {
            return EnderecoDeEntrega.ToString();
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
