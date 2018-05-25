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
    public partial class FormVenda : Form
    {
        DAO dao;
        public FormVenda(DAO d)
        {
            InitializeComponent();

            dao = d;
            Montar();
        }

        public void Montar()
        {
            cmbCliente.Items.AddRange(dao.cliente.ToArray());
        }
    }
}
