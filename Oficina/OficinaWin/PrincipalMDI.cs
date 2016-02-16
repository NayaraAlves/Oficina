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
    }

    private void sairToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
