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

        public void mostrarPanelAbandonar(string nombre)
        {
            panel_abandonar.Visible=true;
        }
        delegate void DelegadoParaAbandonar(string nombre);
        public void ocultarPanelAbandonar(string nombre)
        {
            panel_abandonar.Visible = false;
        }
        delegate void DelegadoParaOcultar(string nombre);

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
                listBox_chat.TopIndex = listBox_chat.Items.Count - 1;
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

        private void btn_abandonar_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DelegadoParaAbandonar delegadoAbandonar = new DelegadoParaAbandonar(mostrarPanelAbandonar);
            panel_abandonar.Invoke(delegadoAbandonar, new object[] { nombre }); 
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            DelegadoParaOcultar delegadoOcultar = new DelegadoParaOcultar(ocultarPanelAbandonar);
            panel_abandonar.Invoke(delegadoOcultar, new object[] { nombre }); 
        }
    }
}