using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    class Produto : IProduto
    {
        public string Nome { get; private set; }
        public double Preco { get; private set; }
        public string Marca { get; private set; }
        public string Tipo { get; private set; }

        public Produto(string Nome, double Preco, string Marca, string Tipo)
        {
            this.Nome = Nome;
            this.Preco = Preco;
            this.Marca = Marca;
            this.Tipo = Tipo;
        }

        public void ImprimaDadosProduto()
        {
            
        }
    }
}
