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
            this.listBox_chat.Size = new System.Drawing.Size(547, 247);
            this.listBox_chat.TabIndex = 13;
            // 
            // btn_enviar
            // 
            this.btn_enviar.BackColor = System.Drawing.Color.Gray;
            this.btn_enviar.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_enviar.ForeColor = System.Drawing.Color.White;
            this.btn_enviar.Location = new System.Drawing.Point(242, 381);
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
            this.textBox_chat.Size = new System.Drawing.Size(547, 27);
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
            // Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(619, 454);
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
    }
}