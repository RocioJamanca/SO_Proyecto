namespace MenuConsultas
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnFecha = new System.Windows.Forms.Button();
            this.btnContraseña = new System.Windows.Forms.Button();
            this.btnGanador = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbQueCambiaAlConectar = new System.Windows.Forms.PictureBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnLogear = new System.Windows.Forms.Button();
            this.panel_conectados = new System.Windows.Forms.Panel();
            this.matriz = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_desconectar = new System.Windows.Forms.Button();
            this.panelJugadores = new System.Windows.Forms.Panel();
            this.jugadores = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_empezar_partida = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQueCambiaAlConectar)).BeginInit();
            this.panel_conectados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matriz)).BeginInit();
            this.panelJugadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.label1.Font = new System.Drawing.Font("Agency FB", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(139, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(576, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultas a la base de datos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnFecha
            // 
            this.btnFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.btnFecha.Font = new System.Drawing.Font("Agency FB", 11.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecha.ForeColor = System.Drawing.Color.White;
            this.btnFecha.Location = new System.Drawing.Point(331, 278);
            this.btnFecha.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Padding = new System.Windows.Forms.Padding(4);
            this.btnFecha.Size = new System.Drawing.Size(184, 78);
            this.btnFecha.TabIndex = 1;
            this.btnFecha.Text = "Obtener fecha de la partida que jugó un jugador";
            this.btnFecha.UseVisualStyleBackColor = false;
            this.btnFecha.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnContraseña
            // 
            this.btnContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.btnContraseña.Font = new System.Drawing.Font("Agency FB", 11.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContraseña.ForeColor = System.Drawing.Color.White;
            this.btnContraseña.Location = new System.Drawing.Point(331, 367);
            this.btnContraseña.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnContraseña.Name = "btnContraseña";
            this.btnContraseña.Padding = new System.Windows.Forms.Padding(4);
            this.btnContraseña.Size = new System.Drawing.Size(184, 71);
            this.btnContraseña.TabIndex = 2;
            this.btnContraseña.Text = "Obtener la contraseña del jugador";
            this.btnContraseña.UseVisualStyleBackColor = false;
            this.btnContraseña.Click += new System.EventHandler(this.btnContraseña_Click);
            // 
            // btnGanador
            // 
            this.btnGanador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.btnGanador.Font = new System.Drawing.Font("Agency FB", 11.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGanador.ForeColor = System.Drawing.Color.White;
            this.btnGanador.Location = new System.Drawing.Point(331, 450);
            this.btnGanador.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btnGanador.Name = "btnGanador";
            this.btnGanador.Padding = new System.Windows.Forms.Padding(4);
            this.btnGanador.Size = new System.Drawing.Size(184, 73);
            this.btnGanador.TabIndex = 3;
            this.btnGanador.Text = "Obtener número de partidas ganadas";
            this.btnGanador.UseVisualStyleBackColor = false;
            this.btnGanador.Click += new System.EventHandler(this.btnGanador_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.pictureBox1.Location = new System.Drawing.Point(-3, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(875, 105);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pbQueCambiaAlConectar
            // 
            this.pbQueCambiaAlConectar.BackColor = System.Drawing.Color.DarkGray;
            this.pbQueCambiaAlConectar.Location = new System.Drawing.Point(104, 37);
            this.pbQueCambiaAlConectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbQueCambiaAlConectar.Name = "pbQueCambiaAlConectar";
            this.pbQueCambiaAlConectar.Size = new System.Drawing.Size(32, 33);
            this.pbQueCambiaAlConectar.TabIndex = 5;
            this.pbQueCambiaAlConectar.TabStop = false;
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.Gray;
            this.btnConectar.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.ForeColor = System.Drawing.Color.White;
            this.btnConectar.Location = new System.Drawing.Point(16, 544);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btnConectar.Size = new System.Drawing.Size(120, 52);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.btnRegistrar.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(331, 130);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Padding = new System.Windows.Forms.Padding(4);
            this.btnRegistrar.Size = new System.Drawing.Size(184, 63);
            this.btnRegistrar.TabIndex = 7;
            this.btnRegistrar.Text = "Registrarse";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnLogear
            // 
            this.btnLogear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(154)))), ((int)(((byte)(148)))));
            this.btnLogear.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogear.ForeColor = System.Drawing.Color.White;
            this.btnLogear.Location = new System.Drawing.Point(331, 203);
            this.btnLogear.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btnLogear.Name = "btnLogear";
            this.btnLogear.Padding = new System.Windows.Forms.Padding(4);
            this.btnLogear.Size = new System.Drawing.Size(184, 63);
            this.btnLogear.TabIndex = 8;
            this.btnLogear.Text = "Entrar";
            this.btnLogear.UseVisualStyleBackColor = false;
            this.btnLogear.Click += new System.EventHandler(this.btnLogear_Click);
            // 
            // panel_conectados
            // 
            this.panel_conectados.Controls.Add(this.matriz);
            this.panel_conectados.Controls.Add(this.label2);
            this.panel_conectados.Location = new System.Drawing.Point(543, 122);
            this.panel_conectados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_conectados.Name = "panel_conectados";
            this.panel_conectados.Size = new System.Drawing.Size(275, 391);
            this.panel_conectados.TabIndex = 10;
            // 
            // matriz
            // 
            this.matriz.AllowUserToAddRows = false;
            this.matriz.AllowUserToDeleteRows = false;
            this.matriz.AllowUserToResizeColumns = false;
            this.matriz.AllowUserToResizeRows = false;
            this.matriz.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.matriz.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matriz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matriz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.matriz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.matriz.GridColor = System.Drawing.Color.White;
            this.matriz.Location = new System.Drawing.Point(23, 34);
            this.matriz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.matriz.Name = "matriz";
            this.matriz.ReadOnly = true;
            this.matriz.RowHeadersVisible = false;
            this.matriz.RowTemplate.Height = 24;
            this.matriz.Size = new System.Drawing.Size(205, 303);
            this.matriz.TabIndex = 11;
            this.matriz.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.matriz_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 150F;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lista de conectados:";
            // 
            // btn_desconectar
            // 
            this.btn_desconectar.BackColor = System.Drawing.Color.Gray;
            this.btn_desconectar.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_desconectar.ForeColor = System.Drawing.Color.White;
            this.btn_desconectar.Location = new System.Drawing.Point(736, 518);
            this.btn_desconectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_desconectar.Name = "btn_desconectar";
            this.btn_desconectar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btn_desconectar.Size = new System.Drawing.Size(120, 52);
            this.btn_desconectar.TabIndex = 11;
            this.btn_desconectar.Text = "Desconectar";
            this.btn_desconectar.UseVisualStyleBackColor = false;
            this.btn_desconectar.Click += new System.EventHandler(this.btn_desconectar_Click);
            // 
            // panelJugadores
            // 
            this.panelJugadores.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelJugadores.Controls.Add(this.jugadores);
            this.panelJugadores.Controls.Add(this.btn_empezar_partida);
            this.panelJugadores.Controls.Add(this.label3);
            this.panelJugadores.ForeColor = System.Drawing.Color.Black;
            this.panelJugadores.Location = new System.Drawing.Point(29, 122);
            this.panelJugadores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelJugadores.Name = "panelJugadores";
            this.panelJugadores.Size = new System.Drawing.Size(275, 391);
            this.panelJugadores.TabIndex = 12;
            // 
            // jugadores
            // 
            this.jugadores.AllowUserToAddRows = false;
            this.jugadores.AllowUserToDeleteRows = false;
            this.jugadores.AllowUserToResizeColumns = false;
            this.jugadores.AllowUserToResizeRows = false;
            this.jugadores.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.jugadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jugadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1});
            this.jugadores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jugadores.GridColor = System.Drawing.Color.White;
            this.jugadores.Location = new System.Drawing.Point(23, 35);
            this.jugadores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jugadores.Name = "jugadores";
            this.jugadores.ReadOnly = true;
            this.jugadores.RowHeadersVisible = false;
            this.jugadores.RowTemplate.Height = 24;
            this.jugadores.Size = new System.Drawing.Size(205, 155);
            this.jugadores.TabIndex = 13;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.FillWeight = 150F;
            this.dataGridViewButtonColumn1.HeaderText = "Column1";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Width = 150;
            // 
            // btn_empezar_partida
            // 
            this.btn_empezar_partida.BackColor = System.Drawing.Color.Gray;
            this.btn_empezar_partida.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_empezar_partida.ForeColor = System.Drawing.Color.White;
            this.btn_empezar_partida.Location = new System.Drawing.Point(23, 328);
            this.btn_empezar_partida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_empezar_partida.Name = "btn_empezar_partida";
            this.btn_empezar_partida.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btn_empezar_partida.Size = new System.Drawing.Size(197, 52);
            this.btn_empezar_partida.TabIndex = 12;
            this.btn_empezar_partida.Text = "Empezar partida";
            this.btn_empezar_partida.UseVisualStyleBackColor = false;
            this.btn_empezar_partida.Click += new System.EventHandler(this.btn_empezar_partida_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lista de jugadores:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(867, 551);
            this.Controls.Add(this.panelJugadores);
            this.Controls.Add(this.btn_desconectar);
            this.Controls.Add(this.panel_conectados);
            this.Controls.Add(this.btnLogear);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.pbQueCambiaAlConectar);
            this.Controls.Add(this.btnGanador);
            this.Controls.Add(this.btnContraseña);
            this.Controls.Add(this.btnFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQueCambiaAlConectar)).EndInit();
            this.panel_conectados.ResumeLayout(false);
            this.panel_conectados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matriz)).EndInit();
            this.panelJugadores.ResumeLayout(false);
            this.panelJugadores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Button btnContraseña;
        private System.Windows.Forms.Button btnGanador;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbQueCambiaAlConectar;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnLogear;
        private System.Windows.Forms.Panel panel_conectados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView matriz;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.Button btn_desconectar;
        private System.Windows.Forms.Panel panelJugadores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_empezar_partida;
        private System.Windows.Forms.DataGridView jugadores;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}

