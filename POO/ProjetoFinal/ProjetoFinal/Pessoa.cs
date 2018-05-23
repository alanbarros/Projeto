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
		public StatusEnum Status { get; private set; }

		public Pessoa(string Nome, string Cpf, DateTime DataNascimento, StatusEnum Status)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.DataNascimento = DataNascimento;
			this.Status = Status;
        }

		public Pessoa(string Cpf){
			this.Cpf = Cpf;
		}

		public override bool Equals(object obj)
		{
			var idCli = obj as Cliente;

			if (idCli == null){
				return false;
			}

			return Cpf.Equals(idCli.Cpf);
		}

		public override int GetHashCode()
		{
			return Cpf.GetHashCode();
		}
	}

	public enum StatusEnum{
		Inativo = 0,
        Ativo = 1,
		Bloqueado = 2
	}
}
