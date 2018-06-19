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
            if (txtBox_Contra.Text == textBox_Contra2.Text)
                this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                txtBox_Contra.Clear();
                textBox_Contra2.Clear();
                txtBox_Nombre.Clear();
            }
        }

        private void dialog_Registrar_Load(object sender, EventArgs e)
        {

        }

        private void txtBox_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsSeparator(e.KeyChar);
        }
        private void txtBox_Contra_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsSeparator(e.KeyChar);
        }
        private void txtBox_Contra2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsSeparator(e.KeyChar);
        }
        private void textBox_Contra2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnviar_Click(this, new EventArgs());

            }
        }
       
    }
}
