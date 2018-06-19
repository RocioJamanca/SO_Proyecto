using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MenuConsultas
{
    public partial class dialog_Logear : Form
    {
        public dialog_Logear()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtBox_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||Char.IsSymbol(e.KeyChar)||Char.IsSeparator(e.KeyChar);
        }
        private void txtBox_Contra_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsSeparator(e.KeyChar);
        }
        private void textBox_Contra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnviar_Click(this, new EventArgs());

            }
        }

        private void txtBox_Contra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
