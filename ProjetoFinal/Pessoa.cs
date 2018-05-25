﻿using System;
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
		public string Status { get; private set; }

		public int Idade()
        {
			var birthdate = DataNascimento;
			var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;
			return age;
        }	

		protected Pessoa(string Nome, string Cpf, DateTime DataNascimento, string Status)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.DataNascimento = DataNascimento;
			this.Status = Status;
        }

		protected Pessoa(){}

		protected Pessoa(string Cpf){
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
