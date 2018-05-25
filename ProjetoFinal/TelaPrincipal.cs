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
    public partial class TelaPrincipal : Form
    {
        DAO dao;
        public TelaPrincipal()
        {
            InitializeComponent();
            dao = new DAO();
        }

        void btnCliente_Click(object sender, EventArgs e)
        {
            var cadCli = new CadastroCliente(dao);
            cadCli.ShowDialog();
        }

        void btnProduto_Click(object sender, EventArgs e)
        {
            var cadProd = new CadastroProduto(dao);
            cadProd.ShowDialog();
        }
    }
}
