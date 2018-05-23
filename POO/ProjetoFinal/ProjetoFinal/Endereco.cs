using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Testando é nois!!

namespace ProjetoFinal
{
    public class Endereco
    {
        public string Lougradouro { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public int Cep { get; private set; }
        public string Uf { get; private set; }

        public Endereco (string lougradouro, int numero, string bairro, string cidade, int cep, string uf)
        {
            this.Lougradouro = lougradouro;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Cep = cep;
            this.Uf = uf;
            this.Numero = numero;
        }
    }
}
