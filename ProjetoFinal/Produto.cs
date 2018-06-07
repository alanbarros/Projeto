using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    public class Produto : IProduto
    {
        static int sequencia = 0;
        public string nome { get; private set; }
        public double preco { get; private set; }
        public string marca { get; private set; }
        public string tipo { get; private set; }
        public string status { get; private set; }
        public int garantia { get; private set; }
        public int idProduto { get; private set; }

        public Produto(string nome, double preco, string marca, string tipo, string status, int garantia)
        {
            idProduto = ++sequencia;
            this.nome = nome;
            this.preco = preco;
            this.marca = marca;
            this.tipo = tipo;
            this.status = status;
            this.garantia = garantia;
        }

        public Produto(string nome, double preco, string marca, string tipo, string status, int garantia, int id)
        {
            idProduto = id;
            this.nome = nome;
            this.preco = preco;
            this.marca = marca;
            this.tipo = tipo;
            this.status = status;
            this.garantia = garantia;
        }

        public Produto(string Nome) { }

        public Produto() { }

        public Produto ImprimaDadosProduto()
        {
            return this;
        }

        public override string ToString()
        {
            return nome;
        }

        public override bool Equals(object obj)
        {
            var idProd = obj as Produto;

            if(idProd == null)
            {
                return false;
            }

            return idProduto.Equals(idProd.idProduto);
        }

        public override int GetHashCode()
        {
            return idProduto.GetHashCode();
        }
    }
}
