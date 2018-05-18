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
    public partial class dialog_Invitación : Form
    {
        public dialog_Invitación()
        {
            InitializeComponent();
        }

        private void btn_aceptar_invitacion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_DeclinarInv_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
