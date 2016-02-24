using OficinaCore.Business;
using OficinaCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OficinaWin
{
    public partial class PrincipalMDI : Form
    {
        public PrincipalMDI()
        {
            InitializeComponent();

            List<Cliente> lista = new ClienteBll().Pesquisar(new Cliente());
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTeste form = new FormTeste();
            form.MdiParent = this;
            form.Show();
        }
    }
}
