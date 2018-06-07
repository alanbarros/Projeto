using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    class Computador : Produto
    {
        public double Garantia { get; private set; }

        public Computador (string Nome, double Preco, string Marca, string Tipo, string Status, int Garantia) : base(Nome, Preco, Marca, Tipo, Status, Garantia)
        {
            this.Garantia = Garantia;
        }
    }
}
