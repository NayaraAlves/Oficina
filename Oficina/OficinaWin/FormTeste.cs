using OficinaCore.Business;
using OficinaCore.Entities;
using OficinaCore.Exceptions;
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
    public partial class FormTeste : Form
    {
        public FormTeste()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = new ClienteBll().Pesquisar(new Cliente());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new ClienteBll().TesteException();
            }
            catch (OficinaCoreException oce)
            {
                MessageBox.Show(oce.Message);
            }
        }
    }
}
