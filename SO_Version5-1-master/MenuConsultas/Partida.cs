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
        List<string> listaAbandonar = new List<string>();


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

        public void mostrarPanelDejarPartida(string nombreAbandonador)
        {
            panel_dejarPartida.Visible = true;
            label_nombreAbandona.Text = nombreAbandonador;
        }
        delegate void DelegadoParaDejarPartida(string nombreAbandonador);

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
        public void tomaNombreAbandona(string nombreAbandona)
        {
            listaAbandonar.Add(nombreAbandona);
            DelegadoParaDejarPartida delegadoDejar= new DelegadoParaDejarPartida(mostrarPanelDejarPartida);
            panel_dejarPartida.Invoke(delegadoDejar, new object[] { nombreAbandona }); //Invoca al thread que crea el objeto(label1)
        }
        public void tomaNombreJugadores(string nombresJugadores)
        {
            MessageBox.Show(nombre + " los jugadores acaban de recibir el mensaje");
            MessageBox.Show("Los jugadores de la partida son: " + nombresJugadores);
        }
        public void tomaDatosAbandonar(string nombreResponde,int deacuerdo,string nombresJugadores, int numeroJugadores) 
        {
            
            if (deacuerdo == 1)
            {
                listaAbandonar.Add(nombreResponde);
                MessageBox.Show(listaAbandonar.Count+"   "+numeroJugadores);
                if (listaAbandonar.Count == numeroJugadores)
                {
                    MessageBox.Show(nombre+ " Todos los jugadores han aceptado abandonar");
                }
                else
                {
                    MessageBox.Show(nombre +"No todos los jugadores han aceptado abandonar");
                }
            }
            else
            {
                MessageBox.Show("El jugador" + nombreResponde + " no acepta abandonar la partida");
            }
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

        private void btn_si_Click(object sender, EventArgs e)
        {
            listaAbandonar.Add(nombre);
            string mensaje = "12/" + nombre + "/" + idPartida;
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            DelegadoParaOcultar delegadoOcultar = new DelegadoParaOcultar(ocultarPanelAbandonar);
            panel_abandonar.Invoke(delegadoOcultar, new object[] { nombre }); 
        }

        private void btn_abandonar_sI_Click(object sender, EventArgs e)
        {
            
            string mensaje = "13/" + nombre + "/" + idPartida+"/1";
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            
        }

        private void btn_abandonar_no_Click(object sender, EventArgs e)
        {
            string mensaje = "13/" + nombre + "/" + idPartida + "/0";
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
    }
}