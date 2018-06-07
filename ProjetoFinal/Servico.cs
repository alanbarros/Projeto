using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    class Servico : Produto
    {
        public double Taxa { get; private set; }

        public Servico (string Nome, double Preco, string Marca, string Tipo, string Status, int Garantia) : base(Nome, Preco, Marca, Tipo, Status, Garantia)
        {
            this.Taxa = Taxa;
        }
    }
}
