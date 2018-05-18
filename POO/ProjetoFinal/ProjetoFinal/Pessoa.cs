using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    abstract class Pessoa
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }

        public Pessoa(string Nome, string Cpf)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
        }
    }
}
