namespace MenuConsultas.dialogs
{
    partial class dialog_Invitación
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_noModificar1 = new System.Windows.Forms.Label();
            this.lbl_nombreInvitador = new System.Windows.Forms.Label();
            this.btn_aceptar_invitacion = new System.Windows.Forms.Button();
            this.btn_DeclinarInv = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_noModificar1
            // 
            this.lbl_noModificar1.AutoSize = true;
            this.lbl_noModificar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.lbl_noModificar1.Font = new System.Drawing.Font("Agency FB", 24F);
            this.lbl_noModificar1.ForeColor = System.Drawing.Color.Snow;
            this.lbl_noModificar1.Location = new System.Drawing.Point(20, 33);
            this.lbl_noModificar1.Name = "lbl_noModificar1";
            this.lbl_noModificar1.Size = new System.Drawing.Size(198, 49);
            this.lbl_noModificar1.TabIndex = 0;
            this.lbl_noModificar1.Text = "Invitación de: ";
            // 
            // lbl_nombreInvitador
            // 
            this.lbl_nombreInvitador.AutoSize = true;
            this.lbl_nombreInvitador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.lbl_nombreInvitador.Font = new System.Drawing.Font("Agency FB", 24F);
            this.lbl_nombreInvitador.ForeColor = System.Drawing.Color.Snow;
            this.lbl_nombreInvitador.Location = new System.Drawing.Point(245, 33);
            this.lbl_nombreInvitador.Name = "lbl_nombreInvitador";
            this.lbl_nombreInvitador.Size = new System.Drawing.Size(93, 49);
            this.lbl_nombreInvitador.TabIndex = 1;
            this.lbl_nombreInvitador.Text = "Rocio";
            // 
            // btn_aceptar_invitacion
            // 
            this.btn_aceptar_invitacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.btn_aceptar_invitacion.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar_invitacion.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar_invitacion.Location = new System.Drawing.Point(29, 123);
            this.btn_aceptar_invitacion.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btn_aceptar_invitacion.Name = "btn_aceptar_invitacion";
            this.btn_aceptar_invitacion.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_aceptar_invitacion.Size = new System.Drawing.Size(138, 44);
            this.btn_aceptar_invitacion.TabIndex = 10;
            this.btn_aceptar_invitacion.Text = "Aceptar";
            this.btn_aceptar_invitacion.UseVisualStyleBackColor = false;
            this.btn_aceptar_invitacion.Click += new System.EventHandler(this.btn_aceptar_invitacion_Click);
            // 
            // btn_DeclinarInv
            // 
            this.btn_DeclinarInv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.btn_DeclinarInv.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeclinarInv.ForeColor = System.Drawing.Color.White;
            this.btn_DeclinarInv.Location = new System.Drawing.Point(212, 123);
            this.btn_DeclinarInv.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btn_DeclinarInv.Name = "btn_DeclinarInv";
            this.btn_DeclinarInv.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_DeclinarInv.Size = new System.Drawing.Size(138, 44);
            this.btn_DeclinarInv.TabIndex = 11;
            this.btn_DeclinarInv.Text = "Declinar";
            this.btn_DeclinarInv.UseVisualStyleBackColor = false;
            this.btn_DeclinarInv.Click += new System.EventHandler(this.btn_DeclinarInv_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(409, 81);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // dialog_Invitación
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(389, 187);
            this.Controls.Add(this.btn_DeclinarInv);
            this.Controls.Add(this.btn_aceptar_invitacion);
            this.Controls.Add(this.lbl_nombreInvitador);
            this.Controls.Add(this.lbl_noModificar1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "dialog_Invitación";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invitación";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_noModificar1;
        private System.Windows.Forms.Button btn_aceptar_invitacion;
        private System.Windows.Forms.Button btn_DeclinarInv;
        public System.Windows.Forms.Label lbl_nombreInvitador;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}