using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    class Cliente : Pessoa
    {
        public string EnderecoDeEntrega { get; private set; }

        public Cliente(string Nome, string Cpf, string EnderecoDeEntrega) : base(Nome, Cpf)
        {
            this.EnderecoDeEntrega = EnderecoDeEntrega;
        }

        public string ImprimaEndereco()
        {
            return EnderecoDeEntrega;
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
