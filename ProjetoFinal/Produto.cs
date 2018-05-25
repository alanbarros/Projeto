using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    public class Produto : IProduto
    {
        public string nome;
        public double preco;
        public string marca;
        public string tipo;

        public Produto(string nome, double preco, string marca, string tipo)
        {
            this.nome = nome;
            this.preco = preco;
            this.marca = marca;
            this.tipo = tipo;
        }

        public Produto ImprimaDadosProduto()
        {
            return this;
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
