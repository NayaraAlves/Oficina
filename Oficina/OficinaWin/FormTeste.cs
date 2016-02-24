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
    public partial class FormTeste : Form
    {
        public FormTeste()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = new ClienteBll().Pesquisar(new Cliente());
        }
    }
}
