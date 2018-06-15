using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MenuConsultas.dialogs
{
    public partial class dialog_Registrar : Form
    {
        public dialog_Registrar()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dialog_Registrar_Load(object sender, EventArgs e)
        {

        }

       
    }
}
