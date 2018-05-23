using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    public class Endereco
    {
        public string Lougradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Cep { get; private set; }
        public string Uf { get; private set; }

        public Endereco (string lougradouro, string numero, string bairro, string cidade, string cep, string uf)
        {
            Lougradouro = lougradouro;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            Uf = uf;
            Numero = numero;
        }
    }
}
