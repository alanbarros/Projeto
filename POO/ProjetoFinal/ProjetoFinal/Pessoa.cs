using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    public abstract class Pessoa
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Pessoa(string Nome, string Cpf, DateTime DataNascimento)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.DataNascimento = DataNascimento;
        }

		public override bool Equals(object obj)
		{
			var cpf = obj as String;

			if (cpf == null){
				return false;
			}

			return Cpf.Equals(cpf);
		}

		public override int GetHashCode()
		{
			return Cpf.GetHashCode();
		}
	}
}
