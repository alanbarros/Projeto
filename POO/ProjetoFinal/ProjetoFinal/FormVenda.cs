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

            this.dao = d;
            Montar(dao);
        }

        public void Montar(DAO d)
        {
            cmbCliente.Items.AddRange(dao.cliente.ToArray());
        }
    }
}
