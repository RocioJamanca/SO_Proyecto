using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace MenuConsultas
{
    public partial class Partida : Form
    {
        string idPartida;
        Socket server;
        string nombre;
        List<string> listaChat = new List<string>();

        public void mostrarNombre(string nombre)
        {
            label1.Text = nombre;
        }
        delegate void DelegadoParaEscribirNombre(string mensaje);

        public void mostrarChat(string frase)
        {
            listBox_chat.Items.Add(frase);
        }
        delegate void DelegadoParaMostrarChat(string frase);

        public Partida(string idPartida, Socket server, string nombre)
        {
            InitializeComponent();
            this.idPartida = idPartida;
            this.server = server;
            this.nombre = nombre;
        }

        private void Partida_Load(object sender, EventArgs e)
        {
            numero_partida.Text = idPartida.ToString();
            DelegadoParaEscribirNombre delegado = new DelegadoParaEscribirNombre(mostrarNombre);
            label1.Invoke(delegado, new object[] { nombre }); //Invoca al thread que crea el objeto(label1)     
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            string frase = textBox_chat.Text;
            if (frase == "")
            {
                MessageBox.Show("No hay nada escrito");
            }
            else
            {
                string mensaje = "11/" + nombre + "/" + idPartida + "/" + frase;
                byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                textBox_chat.Clear();
            }
        }
        public void tomaFrase(string frase)
        {
            listaChat.Add(frase);
            DelegadoParaMostrarChat delegadoMostrarChat = new DelegadoParaMostrarChat(mostrarChat);
            label1.Invoke(delegadoMostrarChat, new object[] { frase }); //Invoca al thread que crea el objeto(label1)
        }



        private void textBox_Chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            btn_enviar_Click(this, new EventArgs());
            }
        }
    }
}