using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class CadastroProduto : Form
    {
        DAO dao;
        public CadastroProduto(DAO d)
        {
            InitializeComponent();
            dao = d;

        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            Adicionar();
        }

        void Atualizar()
        {
            
        }

        void Adicionar()
        {
            dao.produto.Add(new Produto("Teclado", 123.12, "Dell", "PC"));
            Atualizar();
        }
    }
}
