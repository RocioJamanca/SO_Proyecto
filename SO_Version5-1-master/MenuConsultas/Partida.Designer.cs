namespace MenuConsultas
{
    partial class Partida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Partida));
            this.numero_partida = new System.Windows.Forms.Label();
            this.listBox_chat = new System.Windows.Forms.ListBox();
            this.btn_enviar = new System.Windows.Forms.Button();
            this.textBox_chat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_abandonar = new System.Windows.Forms.Panel();
            this.btn_no = new System.Windows.Forms.Button();
            this.btn_si = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_abandonar = new System.Windows.Forms.Button();
            this.panel_dejarPartida = new System.Windows.Forms.Panel();
            this.label_nombreAbandona = new System.Windows.Forms.Label();
            this.btn_abandonar_no = new System.Windows.Forms.Button();
            this.btn_abandonar_sI = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_ListaJugadores = new System.Windows.Forms.Panel();
            this.ocultarJugadores = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label_finPartida = new System.Windows.Forms.Label();
            this.btn_nuevaCarta = new System.Windows.Forms.Button();
            this.btn_plantarse = new System.Windows.Forms.Button();
            this.panel_abandonar.SuspendLayout();
            this.panel_dejarPartida.SuspendLayout();
            this.panel_ListaJugadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // numero_partida
            // 
            this.numero_partida.AutoSize = true;
            this.numero_partida.BackColor = System.Drawing.Color.Transparent;
            this.numero_partida.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numero_partida.Location = new System.Drawing.Point(179, 14);
            this.numero_partida.Name = "numero_partida";
            this.numero_partida.Size = new System.Drawing.Size(133, 28);
            this.numero_partida.TabIndex = 0;
            this.numero_partida.Text = "Numero_partida";
            // 
            // listBox_chat
            // 
            this.listBox_chat.BackColor = System.Drawing.Color.DarkSlateGray;
            this.listBox_chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_chat.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_chat.ForeColor = System.Drawing.Color.White;
            this.listBox_chat.FormattingEnabled = true;
            this.listBox_chat.ItemHeight = 19;
            this.listBox_chat.Location = new System.Drawing.Point(18, 96);
            this.listBox_chat.Name = "listBox_chat";
            this.listBox_chat.Size = new System.Drawing.Size(325, 247);
            this.listBox_chat.TabIndex = 13;
            // 
            // btn_enviar
            // 
            this.btn_enviar.BackColor = System.Drawing.Color.Gray;
            this.btn_enviar.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_enviar.ForeColor = System.Drawing.Color.White;
            this.btn_enviar.Location = new System.Drawing.Point(111, 381);
            this.btn_enviar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_enviar.Name = "btn_enviar";
            this.btn_enviar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btn_enviar.Size = new System.Drawing.Size(120, 52);
            this.btn_enviar.TabIndex = 12;
            this.btn_enviar.Text = "Enviar";
            this.btn_enviar.UseVisualStyleBackColor = false;
            this.btn_enviar.Click += new System.EventHandler(this.btn_enviar_Click);
            // 
            // textBox_chat
            // 
            this.textBox_chat.Font = new System.Drawing.Font("Arial", 10.2F);
            this.textBox_chat.Location = new System.Drawing.Point(18, 349);
            this.textBox_chat.Name = "textBox_chat";
            this.textBox_chat.Size = new System.Drawing.Size(325, 27);
            this.textBox_chat.TabIndex = 0;
            this.textBox_chat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Chat_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 28);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 33);
            this.label2.TabIndex = 15;
            this.label2.Text = "Id de la partida:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 33);
            this.label3.TabIndex = 16;
            this.label3.Text = "Jugador:";
            // 
            // panel_abandonar
            // 
            this.panel_abandonar.Controls.Add(this.btn_no);
            this.panel_abandonar.Controls.Add(this.btn_si);
            this.panel_abandonar.Controls.Add(this.label4);
            this.panel_abandonar.Location = new System.Drawing.Point(18, 456);
            this.panel_abandonar.Name = "panel_abandonar";
            this.panel_abandonar.Size = new System.Drawing.Size(307, 141);
            this.panel_abandonar.TabIndex = 18;
            this.panel_abandonar.Visible = false;
            // 
            // btn_no
            // 
            this.btn_no.BackColor = System.Drawing.Color.Gray;
            this.btn_no.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_no.ForeColor = System.Drawing.Color.White;
            this.btn_no.Location = new System.Drawing.Point(166, 82);
            this.btn_no.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_no.Name = "btn_no";
            this.btn_no.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btn_no.Size = new System.Drawing.Size(120, 52);
            this.btn_no.TabIndex = 21;
            this.btn_no.Text = "No";
            this.btn_no.UseVisualStyleBackColor = false;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_si
            // 
            this.btn_si.BackColor = System.Drawing.Color.Gray;
            this.btn_si.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_si.ForeColor = System.Drawing.Color.White;
            this.btn_si.Location = new System.Drawing.Point(31, 82);
            this.btn_si.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_si.Name = "btn_si";
            this.btn_si.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btn_si.Size = new System.Drawing.Size(120, 52);
            this.btn_si.TabIndex = 20;
            this.btn_si.Text = "Si";
            this.btn_si.UseVisualStyleBackColor = false;
            this.btn_si.Click += new System.EventHandler(this.btn_si_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 66);
            this.label4.TabIndex = 16;
            this.label4.Text = "¿Estas seguro de que quieres\r\n      abandonar la partida?";
            // 
            // btn_abandonar
            // 
            this.btn_abandonar.BackColor = System.Drawing.Color.Gray;
            this.btn_abandonar.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_abandonar.ForeColor = System.Drawing.Color.White;
            this.btn_abandonar.Location = new System.Drawing.Point(421, 655);
            this.btn_abandonar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_abandonar.Name = "btn_abandonar";
            this.btn_abandonar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btn_abandonar.Size = new System.Drawing.Size(120, 52);
            this.btn_abandonar.TabIndex = 19;
            this.btn_abandonar.Text = "Abandonar";
            this.btn_abandonar.UseVisualStyleBackColor = false;
            this.btn_abandonar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_dejarPartida
            // 
            this.panel_dejarPartida.Controls.Add(this.label_nombreAbandona);
            this.panel_dejarPartida.Controls.Add(this.btn_abandonar_no);
            this.panel_dejarPartida.Controls.Add(this.btn_abandonar_sI);
            this.panel_dejarPartida.Controls.Add(this.label5);
            this.panel_dejarPartida.Location = new System.Drawing.Point(6, 499);
            this.panel_dejarPartida.Name = "panel_dejarPartida";
            this.panel_dejarPartida.Size = new System.Drawing.Size(306, 184);
            this.panel_dejarPartida.TabIndex = 20;
            this.panel_dejarPartida.Visible = false;
            // 
            // label_nombreAbandona
            // 
            this.label_nombreAbandona.AutoSize = true;
            this.label_nombreAbandona.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nombreAbandona.Location = new System.Drawing.Point(103, 16);
            this.label_nombreAbandona.Name = "label_nombreAbandona";
            this.label_nombreAbandona.Size = new System.Drawing.Size(59, 31);
            this.label_nombreAbandona.TabIndex = 22;
            this.label_nombreAbandona.Text = "label6";
            // 
            // btn_abandonar_no
            // 
            this.btn_abandonar_no.BackColor = System.Drawing.Color.Gray;
            this.btn_abandonar_no.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_abandonar_no.ForeColor = System.Drawing.Color.White;
            this.btn_abandonar_no.Location = new System.Drawing.Point(173, 123);
            this.btn_abandonar_no.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_abandonar_no.Name = "btn_abandonar_no";
            this.btn_abandonar_no.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btn_abandonar_no.Size = new System.Drawing.Size(120, 52);
            this.btn_abandonar_no.TabIndex = 21;
            this.btn_abandonar_no.Text = "No";
            this.btn_abandonar_no.UseVisualStyleBackColor = false;
            this.btn_abandonar_no.Click += new System.EventHandler(this.btn_abandonar_no_Click);
            // 
            // btn_abandonar_sI
            // 
            this.btn_abandonar_sI.BackColor = System.Drawing.Color.Gray;
            this.btn_abandonar_sI.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_abandonar_sI.ForeColor = System.Drawing.Color.White;
            this.btn_abandonar_sI.Location = new System.Drawing.Point(31, 123);
            this.btn_abandonar_sI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_abandonar_sI.Name = "btn_abandonar_sI";
            this.btn_abandonar_sI.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btn_abandonar_sI.Size = new System.Drawing.Size(120, 52);
            this.btn_abandonar_sI.TabIndex = 20;
            this.btn_abandonar_sI.Text = "Si";
            this.btn_abandonar_sI.UseVisualStyleBackColor = false;
            this.btn_abandonar_sI.Click += new System.EventHandler(this.btn_abandonar_sI_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 66);
            this.label5.TabIndex = 16;
            this.label5.Text = "desea abandonar la partida.\r\n¿Estas de acuerdo?";
            // 
            // panel_ListaJugadores
            // 
            this.panel_ListaJugadores.Controls.Add(this.ocultarJugadores);
            this.panel_ListaJugadores.Controls.Add(this.dataGrid);
            this.panel_ListaJugadores.Controls.Add(this.label6);
            this.panel_ListaJugadores.Location = new System.Drawing.Point(28, 438);
            this.panel_ListaJugadores.Name = "panel_ListaJugadores";
            this.panel_ListaJugadores.Size = new System.Drawing.Size(315, 388);
            this.panel_ListaJugadores.TabIndex = 21;
            this.panel_ListaJugadores.Visible = false;
            // 
            // ocultarJugadores
            // 
            this.ocultarJugadores.BackColor = System.Drawing.Color.Gray;
            this.ocultarJugadores.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ocultarJugadores.ForeColor = System.Drawing.Color.White;
            this.ocultarJugadores.Location = new System.Drawing.Point(102, 323);
            this.ocultarJugadores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ocultarJugadores.Name = "ocultarJugadores";
            this.ocultarJugadores.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.ocultarJugadores.Size = new System.Drawing.Size(120, 52);
            this.ocultarJugadores.TabIndex = 22;
            this.ocultarJugadores.Text = "Ocultar";
            this.ocultarJugadores.UseVisualStyleBackColor = false;
            this.ocultarJugadores.Click += new System.EventHandler(this.ocultarJugadores_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGrid.GridColor = System.Drawing.Color.White;
            this.dataGrid.Location = new System.Drawing.Point(63, 43);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.Size = new System.Drawing.Size(176, 275);
            this.dataGrid.TabIndex = 18;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 150F;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(96, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 33);
            this.label6.TabIndex = 17;
            this.label6.Text = "Jugadores:";
            // 
            // label_finPartida
            // 
            this.label_finPartida.AutoSize = true;
            this.label_finPartida.BackColor = System.Drawing.Color.Transparent;
            this.label_finPartida.Font = new System.Drawing.Font("Bookman Old Style", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_finPartida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_finPartida.Location = new System.Drawing.Point(238, 388);
            this.label_finPartida.Name = "label_finPartida";
            this.label_finPartida.Size = new System.Drawing.Size(216, 70);
            this.label_finPartida.TabIndex = 22;
            this.label_finPartida.Text = "label7";
            this.label_finPartida.Visible = false;
            // 
            // btn_nuevaCarta
            // 
            this.btn_nuevaCarta.BackColor = System.Drawing.Color.Gray;
            this.btn_nuevaCarta.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevaCarta.ForeColor = System.Drawing.Color.White;
            this.btn_nuevaCarta.Location = new System.Drawing.Point(595, 369);
            this.btn_nuevaCarta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_nuevaCarta.Name = "btn_nuevaCarta";
            this.btn_nuevaCarta.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btn_nuevaCarta.Size = new System.Drawing.Size(120, 52);
            this.btn_nuevaCarta.TabIndex = 20;
            this.btn_nuevaCarta.Text = "Nueva Carta";
            this.btn_nuevaCarta.UseVisualStyleBackColor = false;
            this.btn_nuevaCarta.Click += new System.EventHandler(this.btn_nuevaCarta_Click);
            // 
            // btn_plantarse
            // 
            this.btn_plantarse.BackColor = System.Drawing.Color.Gray;
            this.btn_plantarse.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_plantarse.ForeColor = System.Drawing.Color.White;
            this.btn_plantarse.Location = new System.Drawing.Point(800, 381);
            this.btn_plantarse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_plantarse.Name = "btn_plantarse";
            this.btn_plantarse.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.btn_plantarse.Size = new System.Drawing.Size(120, 52);
            this.btn_plantarse.TabIndex = 21;
            this.btn_plantarse.Text = "Plantarse";
            this.btn_plantarse.UseVisualStyleBackColor = false;
            this.btn_plantarse.Click += new System.EventHandler(this.btn_plantarse_Click);
            // 
            // Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1130, 852);
            this.Controls.Add(this.btn_plantarse);
            this.Controls.Add(this.btn_abandonar);
            this.Controls.Add(this.btn_nuevaCarta);
            this.Controls.Add(this.label_finPartida);
            this.Controls.Add(this.panel_dejarPartida);
            this.Controls.Add(this.panel_abandonar);
            this.Controls.Add(this.panel_ListaJugadores);
            this.Controls.Add(this.textBox_chat);
            this.Controls.Add(this.btn_enviar);
            this.Controls.Add(this.listBox_chat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numero_partida);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Partida";
            this.Text = "Partida";
            this.Load += new System.EventHandler(this.Partida_Load);
            this.panel_abandonar.ResumeLayout(false);
            this.panel_abandonar.PerformLayout();
            this.panel_dejarPartida.ResumeLayout(false);
            this.panel_dejarPartida.PerformLayout();
            this.panel_ListaJugadores.ResumeLayout(false);
            this.panel_ListaJugadores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numero_partida;
        private System.Windows.Forms.ListBox listBox_chat;
        private System.Windows.Forms.Button btn_enviar;
        private System.Windows.Forms.TextBox textBox_chat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_abandonar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_abandonar;
        private System.Windows.Forms.Button btn_no;
        private System.Windows.Forms.Button btn_si;
        private System.Windows.Forms.Panel panel_dejarPartida;
        private System.Windows.Forms.Label label_nombreAbandona;
        private System.Windows.Forms.Button btn_abandonar_no;
        private System.Windows.Forms.Button btn_abandonar_sI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel_ListaJugadores;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button ocultarJugadores;
        private System.Windows.Forms.Label label_finPartida;
        private System.Windows.Forms.Button btn_plantarse;
        private System.Windows.Forms.Button btn_nuevaCarta;
    }
}