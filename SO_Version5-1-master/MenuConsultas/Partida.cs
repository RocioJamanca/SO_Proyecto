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
        List<int> numCartas = new List<int>();
        List<int> puntos = new List<int>();
        List<int> cartaPalo = new List<int>();
        List<int> cartaNumero = new List<int>();
        List<string> jugadorFinalizar = new List<string>();
        Image[,] cartas = new Image[13, 4];
        int turnoCliente;//turno de la persona siguiente
        int puntosFinal;
        string paloss = "";
        string numeross = "";

        //Variable para saber si quiero recibir mas cartas. 0->Si, 1->No
        int quieroMasCartas = 0;

        private void timer1_Tick(object sender, System.EventArgs e) // TIMER FECHA
        {
            int segundos;
            segundos = Convert.ToInt32(label9.Text) + 1;
            label9.Text = Convert.ToString(segundos);
        }

        public void mostrarNombre(string nombre)
        {
            label1.Text = nombre;
            label8.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
        delegate void DelegadoParaEscribirNombre(string mensaje);

        public void mostrarChat(string frase)
        {
            listBox_chat.Items.Add(frase);
        }
        delegate void DelegadoParaMostrarChat(string frase);

        public void mostrarJugadores(string nombresJugadores)
        {
            panel_ListaJugadores.Visible = true;
            dataGrid.ColumnHeadersVisible = false;
            dataGrid.RowHeadersVisible = false;
            String[] nombres = nombresJugadores.Split('*');
            dataGrid.ColumnCount = 1;
            dataGrid.RowCount = nombresJugadores.Split('*').Count() - 1;
            for (int j = 0; j < dataGrid.RowCount; j++)
            {
                dataGrid.Rows[j].Cells[0].Value = nombres[j];
                dataGrid.Rows[j].Cells[0].Style.BackColor = System.Drawing.Color.White;
            }
            dataGrid.ClearSelection();
        }
        delegate void DelegadoParaMostrarJugadores(string nombresJugadores);

        public void colorearCelda(string nombreA, int acepta)
        {
            //si acepta==1 colorear verde, sino colorear de rojo
            int i = dataGrid.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                string valor = dataGrid.Rows[j].Cells[0].Value.ToString();
                if (valor == nombreA)
                {
                    if (acepta == 1)
                    {
                        dataGrid.Rows[j].Cells[0].Style.BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        dataGrid.Rows[j].Cells[0].Style.BackColor = System.Drawing.Color.Red;
                    }
                }
            }

            for (int h = 0; h < listaAbandonar.Count; h++)
            {
                for (int j = 0; j < i; j++)
                {
                    string valor = dataGrid.Rows[j].Cells[0].Value.ToString();
                    if (valor == listaAbandonar[h].ToString())
                    {
                        dataGrid.Rows[h].Cells[0].Style.BackColor = System.Drawing.Color.Green;
                    }
                }
            }
        }
        delegate void DelegadoParaColorear(string nombreA, int acepta);

        public void ocultarPanelJugadores(string nombre)
        {
            panel_ListaJugadores.Visible = false;
        }
        delegate void DelegadoParaOcultarJugadores(string nombre);

        public void mostrarFinPartida()
        {
            label_finPartida.Text = "Se ha finalizado la partida";
            label_finPartida.Visible = true;
            btn_emepezar.Visible = false;
            btn_nuevaCarta.Visible = false;
            btn_plantarse.Visible = false;
        }
        delegate void DelegadoParaFinPartida();

        public void cierreForm()
        {
            this.Close();
        }
        delegate void DelegadoParaCerrar();

        public void mostrarBtnAbandonar()
        {
            btn_abandonar.Visible = true;
        }
        delegate void DelegadoParaMostrarBtnAbandonar();

        public void mostrarCarta(int palo,int numero)
        {
            btn_emepezar.Visible = false;
            panel_tablero.Visible = true;
            if (numCartas.Count == 1)
            {
                pictureBox_carta1.Image = cartas[numero, palo];
                cartaPalo.Add(palo);
                cartaNumero.Add(numero);
                puntosFinal = puntos[0];
                textBox_puntos.Text = puntosFinal.ToString();
            }
            else if (numCartas.Count == 2)
            {
                pictureBox_carta2.Image = cartas[numero, palo];
                cartaPalo.Add(palo);
                cartaNumero.Add(numero);
                puntosFinal = puntos[0]+puntos[1];
                textBox_puntos.Text = puntosFinal.ToString();
            }
            else if (numCartas.Count == 3)
            {
                pictureBox_carta3.Image = cartas[numero, palo];
                cartaPalo.Add(palo);
                cartaNumero.Add(numero);
                puntosFinal = puntos[0] + puntos[1]+puntos[2];
                textBox_puntos.Text = puntosFinal.ToString();
            }
            else if (numCartas.Count == 4)
            {
                pictureBox_carta4.Image = cartas[numero, palo];
                cartaPalo.Add(palo);
                cartaNumero.Add(numero);
                puntosFinal = puntos[0] + puntos[1]+puntos[2]+puntos[3];
                textBox_puntos.Text = puntosFinal.ToString();
                textBox_puntosFinal.Visible = true;
                textBox_puntosFinal.Text = "Has llegado a 4 cartas: " + puntosFinal;
            }

            int num;
            string numeros="";
            int pal;
            string palos = "";
            if (puntosFinal == 21)
            {
                this.quieroMasCartas = 1;
                textBox_puntosFinal.Visible = true;
                textBox_puntosFinal.Text = "Has llegado a: " + puntosFinal;
            }
            else if (puntosFinal > 21)
            {
                this.quieroMasCartas = 1;
                textBox_puntosFinal.Visible = true;
                textBox_puntosFinal.Text = "Tus puntos superan los 21, puntos totales: " + puntosFinal;
            }
            if (numCartas.Count == 4 || puntosFinal == 21 || puntosFinal > 21)
            {
                for (int i = 0; i < cartaNumero.Count; i++)
                {
                    num = cartaNumero[i];
                    numeros = numeros + "*" + num;
                    pal = cartaPalo[i];
                    palos = palos + "*" + pal;
                }

                string mensaje = "16/" + nombre + "/" + idPartida + "/" + puntosFinal + "/" + palos + "/" + numeros + "/" + turnoCliente + "/" + 1 + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + label9.Text;
               // MessageBox.Show(mensaje);
                byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                pasarFinalizar(puntosFinal,palos,numeros);
            }
        }
        delegate void DelegadoParaMostrarCarta(int palo,int numero);

        delegate void DelegadoParaCartasFinal(string personaFinal, int puntos, string palos, string numeros, int torn);
        public Partida(string idPartida, Socket server, string nombre)
        {
            InitializeComponent();
            this.idPartida = idPartida;
            this.server = server;
            this.nombre = nombre;
        }

        public void MostrarGanador(string ganador)
        {
            label_ganador.Text = "El jugador " + ganador + " ha ganado esta partida.";
            label_ganador.Visible = true;
            btn_nuevaCarta.Visible = false;
            btn_emepezar.Visible = false;
            btn_plantarse.Visible = false;
            this.panel_tablero.BackColor = Color.Silver;
        }
        delegate void DelegadoParaMostrarGanador(string ganador);

        public void miTurno(string nombreJugadorAnterior, string nombreTocaJugar, int turno, int numeroJugadores, string nombreJugadores)
        {
            label_turno.Text = "Es el turno de: " + nombreTocaJugar;
            if (nombreTocaJugar == nombre)
            {
                btn_nuevaCarta.Visible = true;
                btn_plantarse.Visible = true;
            }
            else
            {
                btn_nuevaCarta.Visible = false;
                btn_plantarse.Visible = false;
            }

            string[] nombreSeparado = nombreJugadores.Split('*');
            if (numeroJugadores == 2)
            {
                jugador2.Text = "Jugador 2";
                jugador2.Visible = true;
            }

            if (numeroJugadores == 3)
            {
                jugador1.Text = nombre;
                jugador2.Text = "Jugador 2";
                jugador2.Visible = true;
                jugador3.Visible = true;
            }
            if (numeroJugadores == 4)
            {
                jugador1.Text = nombre;
                jugador2.Text = "Jugador 2";
                jugador3.Text = "Jugador 3";
                jugador4.Text = "Jugador 4";
                jugador2.Visible = true;
                jugador3.Visible = true;
                jugador4.Visible = true;
            }

            jugador1.Text = nombre;
        }
        delegate void DelegadoParaMiTurno(string nombreJugadorAnterior, string nombreTocaJugar, int turno, int numeroJugadores, string nombreJugadores);
       
        public void  tomaCartasFinalizado(string personaFinal,int puntos, string palos,string numeros,int torn)
       {
           DelegadoParaCartasFinal delegadoFinal = new DelegadoParaCartasFinal(mostrarCartasFinal);
           panel_tablero.Invoke(delegadoFinal, new object[] {personaFinal,puntos,palos, numeros,torn});
       }
        public void pasarFinalizar(int puntosFinal, string palos, string numeros)
        {
            this.puntosFinal = puntosFinal;
            this.paloss = palos;
            this.numeross = numeros;
        }
        private void btn_plantarse_Click(object sender, EventArgs e)
        {
            //Aqui habia un problema cuando me queria plantar con dos cartas, mandaba al servidor paloss = null y numeross = null
            int num;
            string numeros = "";
            int pal;
            string palos = "";
            for (int i = 0; i < cartaNumero.Count; i++)
            {
                num = cartaNumero[i];
                numeros = numeros + "*" + num;
                pal = cartaPalo[i];
                palos = palos + "*" + pal;
            }
            this.quieroMasCartas = 1; //No quiero mas cartas

            string mensaje = "16/" + nombre + "/" + idPartida + "/" + puntosFinal + "/" + paloss + "/" + numeross + "/" + turnoCliente + "/" + this.quieroMasCartas + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + label9.Text; 
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        public void mostrarCartasFinal(string personaFinal, int puntos, string palos, string numeros, int torn)
       {
           jugadorFinalizar.Add(personaFinal);
           int numCartas=1;
           string[] paloSeparado = palos.Split('*');
           string[] numeroSeparado = numeros.Split('*');
           while (numCartas < palos.Split('*').Count())
           {
               if (jugadorFinalizar.Count == 1)
               {
                   switch (numCartas)
                   {
                       case 1:
                           jugador2_carta1.Visible = true;
                           jugador2_carta1.Image = cartas[Convert.ToInt32(numeroSeparado[1]), Convert.ToInt32(paloSeparado[1])];
                           numCartas++;
                           break;
                       case 2:
                           jugador2_carta2.Visible = true;
                           jugador2_carta2.Image = cartas[Convert.ToInt32(numeroSeparado[2]), Convert.ToInt32(paloSeparado[2])];
                           numCartas++;
                           break;
                       case 3:
                           jugador2_carta3.Visible = true;
                           jugador2_carta3.Image = cartas[Convert.ToInt32(numeroSeparado[3]), Convert.ToInt32(paloSeparado[3])];
                           numCartas++;
                           break;
                       case 4:
                           jugador2_carta4.Visible = true;
                           jugador2_carta4.Image = cartas[Convert.ToInt32(numeroSeparado[4]), Convert.ToInt32(paloSeparado[4])];
                           numCartas++;
                           break;
                   }
               }
               if (jugadorFinalizar.Count == 2)
               {
                   switch (numCartas)
                   {
                       case 1:
                           jugador3_carta1.Visible = true;
                           jugador3_carta1.Image = cartas[Convert.ToInt32(numeroSeparado[1]), Convert.ToInt32(paloSeparado[1])];
                           numCartas++;
                           break;
                       case 2:
                           jugador3_carta2.Visible = true;
                           jugador3_carta2.Image = cartas[Convert.ToInt32(numeroSeparado[2]), Convert.ToInt32(paloSeparado[2])];
                           numCartas++;
                           break;
                       case 3:
                           jugador3_carta3.Visible = true;
                           jugador3_carta3.Image = cartas[Convert.ToInt32(numeroSeparado[3]), Convert.ToInt32(paloSeparado[3])];
                           numCartas++;
                           break;
                       case 4:
                           jugador3_carta4.Visible = true;
                           jugador3_carta4.Image = cartas[Convert.ToInt32(numeroSeparado[4]), Convert.ToInt32(paloSeparado[4])];
                           numCartas++;
                           break;
                   }
               }
               if (jugadorFinalizar.Count == 3)
               {
                   switch (numCartas)
                   {
                       case 1:
                           jugador4_carta1.Visible = true;
                           jugador4_carta1.Image = cartas[Convert.ToInt32(numeroSeparado[1]), Convert.ToInt32(paloSeparado[1])];
                           numCartas++;
                           break;
                       case 2:
                           jugador4_carta2.Visible = true;
                           jugador4_carta2.Image = cartas[Convert.ToInt32(numeroSeparado[2]), Convert.ToInt32(paloSeparado[2])];
                           numCartas++;
                           break;
                       case 3:
                           jugador4_carta3.Visible = true;
                           jugador4_carta3.Image = cartas[Convert.ToInt32(numeroSeparado[3]), Convert.ToInt32(paloSeparado[3])];
                           numCartas++;
                           break;
                       case 4:
                           jugador4_carta4.Visible = true;
                           jugador4_carta4.Image = cartas[Convert.ToInt32(numeroSeparado[4]), Convert.ToInt32(paloSeparado[4])];
                           numCartas++;
                           break;
                   }
               }
           }
           
       }
        private void Partida_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // Set time interval to 1 second
            timer1.Enabled = true; // Start launching tick events every 1 second
            numero_partida.Text = idPartida.ToString();
            DelegadoParaEscribirNombre delegado = new DelegadoParaEscribirNombre(mostrarNombre);
            label1.Invoke(delegado, new object[] { nombre }); //Invoca al thread que crea el objeto(label1)     

            //0 diamante; 1 picas; 2 corazones; 3 treboles ;
            //0 diamante; 1 picas; 2 corazones; 3 treboles ;
            cartas[0, 0] = MenuConsultas.Properties.Resources._01_diamonds;
            cartas[1, 0] = MenuConsultas.Properties.Resources._02_diamonds;
            cartas[2, 0] = MenuConsultas.Properties.Resources._03_diamonds;
            cartas[3, 0] = MenuConsultas.Properties.Resources._04_diamonds;
            cartas[4, 0] = MenuConsultas.Properties.Resources._05_diamonds;
            cartas[5, 0] = MenuConsultas.Properties.Resources._06_diamonds;
            cartas[6, 0] = MenuConsultas.Properties.Resources._07_diamonds;
            cartas[7, 0] = MenuConsultas.Properties.Resources._08_diamonds;
            cartas[8, 0] = MenuConsultas.Properties.Resources._09_diamonds;
            cartas[9, 0] = MenuConsultas.Properties.Resources._10_diamonds;
            cartas[10, 0] = MenuConsultas.Properties.Resources.J_diamonds;
            cartas[11, 0] = MenuConsultas.Properties.Resources.Q_diamonds;
            cartas[12, 0] = MenuConsultas.Properties.Resources.K_diamonds;

            cartas[0, 1] = MenuConsultas.Properties.Resources._01_spades;
            cartas[1, 1] = MenuConsultas.Properties.Resources._02_spades;
            cartas[2, 1] = MenuConsultas.Properties.Resources._03_spades;
            cartas[3, 1] = MenuConsultas.Properties.Resources._04_spades;
            cartas[4, 1] = MenuConsultas.Properties.Resources._05_spades;
            cartas[5, 1] = MenuConsultas.Properties.Resources._06_spades;
            cartas[6, 1] = MenuConsultas.Properties.Resources._07_spades;
            cartas[7, 1] = MenuConsultas.Properties.Resources._08_spades;
            cartas[8, 1] = MenuConsultas.Properties.Resources._09_spades;
            cartas[9, 1] = MenuConsultas.Properties.Resources._10_spades;
            cartas[10, 1] = MenuConsultas.Properties.Resources.J_spades;
            cartas[11, 1] = MenuConsultas.Properties.Resources.Q_spades;
            cartas[12, 1] = MenuConsultas.Properties.Resources.K_spades;

            cartas[0, 2] = MenuConsultas.Properties.Resources._01_hearts;
            cartas[1, 2] = MenuConsultas.Properties.Resources._02_hearts;
            cartas[2, 2] = MenuConsultas.Properties.Resources._03_hearts;
            cartas[3, 2] = MenuConsultas.Properties.Resources._04_hearts;
            cartas[4, 2] = MenuConsultas.Properties.Resources._05_hearts;
            cartas[5, 2] = MenuConsultas.Properties.Resources._06_hearts;
            cartas[6, 2] = MenuConsultas.Properties.Resources._07_hearts;
            cartas[7, 2] = MenuConsultas.Properties.Resources._08_hearts;
            cartas[8, 2] = MenuConsultas.Properties.Resources._09_hearts;
            cartas[9, 2] = MenuConsultas.Properties.Resources._10_hearts;
            cartas[10, 2] = MenuConsultas.Properties.Resources.J_hearts;
            cartas[11, 2] = MenuConsultas.Properties.Resources.Q_hearts;
            cartas[12, 2] = MenuConsultas.Properties.Resources.K_hearts;

            cartas[0, 3] = MenuConsultas.Properties.Resources._01_clubs;
            cartas[1, 3] = MenuConsultas.Properties.Resources._02_clubs;
            cartas[2, 3] = MenuConsultas.Properties.Resources._03_clubs;
            cartas[3, 3] = MenuConsultas.Properties.Resources._04_clubs;
            cartas[4, 3] = MenuConsultas.Properties.Resources._05_clubs;
            cartas[5, 3] = MenuConsultas.Properties.Resources._06_clubs;
            cartas[6, 3] = MenuConsultas.Properties.Resources._07_clubs;
            cartas[7, 3] = MenuConsultas.Properties.Resources._08_clubs;
            cartas[8, 3] = MenuConsultas.Properties.Resources._09_clubs;
            cartas[9, 3] = MenuConsultas.Properties.Resources._10_clubs;
            cartas[10, 3] = MenuConsultas.Properties.Resources.J_clubs;
            cartas[11, 3] = MenuConsultas.Properties.Resources.Q_clubs;
            cartas[12, 3] = MenuConsultas.Properties.Resources.K_clubs;
            
            string mensaje = "17/" + nombre + "/" + idPartida;
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

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
            string menssage = "El jugador "+nombreAbandona+" desea abanadonar la partida, ¿tu también?";
            const string caption = "Abandonando Partida";
            var result = MessageBox.Show(menssage, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string mensaje = "13/" + nombre + "/" + idPartida + "/1";
                byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                string mensaje = "13/" + nombre + "/" + idPartida + "/0";
                byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
           
            DelegadoParaColorear delegadoColorear = new DelegadoParaColorear(colorearCelda);
            panel_ListaJugadores.Invoke(delegadoColorear, new object[] { nombreAbandona, 1 });
        }
        public void tomaNombreJugadores(string nombresJugadores)
        {
            DelegadoParaMostrarJugadores delegadoMostrarJugadores = new DelegadoParaMostrarJugadores(mostrarJugadores);
            panel_ListaJugadores.Invoke(delegadoMostrarJugadores, new object[] { nombresJugadores });
        }     
        public void tomaDatosAbandonar(string nombreResponde,int deacuerdo,string nombresJugadores, int numeroJugadores) 
        {
            DelegadoParaMostrarJugadores delegadoMostrarJugadores = new DelegadoParaMostrarJugadores(mostrarJugadores);
            panel_ListaJugadores.Invoke(delegadoMostrarJugadores, new object[] { nombresJugadores });
            DelegadoParaColorear delegadoColorear = new DelegadoParaColorear(colorearCelda);
            panel_ListaJugadores.Invoke(delegadoColorear, new object[] { nombreResponde,deacuerdo});
            if (deacuerdo == 1)
            {
                listaAbandonar.Add(nombreResponde);
                if (listaAbandonar.Count == numeroJugadores)
                {
                    string mensaje = "14/" + nombre + "/" + idPartida + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + label9.Text;
                    byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    DelegadoParaFinPartida delegadoFin = new DelegadoParaFinPartida(mostrarFinPartida);
                    label_finPartida.Invoke(delegadoFin, new object[] { });
                }
                else
                {
                    MessageBox.Show("Aun no han respondido todos los jugadores");
                }
            }
            else
            {
                MessageBox.Show("El jugador" + nombreResponde + " no acepta abandonar la partida se continua jugando");
                listaAbandonar.Clear();
                DelegadoParaOcultarJugadores delegadoOcultarListaJugadores = new DelegadoParaOcultarJugadores(ocultarPanelJugadores);
                panel_ListaJugadores.Invoke(delegadoOcultarListaJugadores, new object[] { nombre });
                DelegadoParaMostrarBtnAbandonar delegadoMostrarBtnAbandonar = new DelegadoParaMostrarBtnAbandonar(mostrarBtnAbandonar);
                btn_abandonar.Invoke(delegadoMostrarBtnAbandonar, new object[] { });
            }
        }
        public void tomaCarta(int palo, int numero)
        {
            int puntos_aux;
            paloss = paloss + "*" + palo;
            numeross = numeross + "*" + numero;
            numCartas.Add(1);
            puntos_aux = numero;
            if (numero > 9)
                puntos_aux = 9;
            if (numero == 0)
                puntos_aux = 10;
            puntos.Add(puntos_aux+1);
            DelegadoParaMostrarCarta delegadoCarta = new DelegadoParaMostrarCarta(mostrarCarta);
            panel_tablero.Invoke(delegadoCarta, new object[] { palo,numero});
            if(numCartas.Count==4)
            {
                //envio los puntos
            }
        }
        public void tomaGanadorPartida(string ganador)
        {
            DelegadoParaFinPartida delegadoFin = new DelegadoParaFinPartida(mostrarFinPartida);
            label_finPartida.Invoke(delegadoFin, new object[] { });
        }
        public void tomaTurno(int turno)
        {
            this.turnoCliente = turno;
        }
        public void tomaActualizacionMiTurno(string nombreJugadorAnterior, string nombreTocaJugar, int turno, int numeroJugadores, string nombreJugadores)
        {
            DelegadoParaMiTurno miturno = new DelegadoParaMiTurno(miTurno);
            btn_plantarse.Invoke(miturno, new object[] { nombreJugadorAnterior, nombreTocaJugar, turno, numeroJugadores, nombreJugadores });
        }

        public void cerrarForm()
        {
            MessageBox.Show("Adiós");
            DelegadoParaCerrar delegadoCerrar = new DelegadoParaCerrar(cierreForm);
            label_finPartida.Invoke(delegadoCerrar, new object[] { });
        }
        private void textBox_Chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            btn_enviar_Click(this, new EventArgs());
            
            }
        }
        private void button1_Click(object sender, EventArgs e) //Btn_Abandonar
        {
           const string menssage = "¿Estas seguro de que quieres abandonar la partida?";
           const string caption = "Abandonando Partida";
            var result= MessageBox.Show(menssage,caption, MessageBoxButtons.YesNo);
           if (result == DialogResult.Yes)
           {
               listaAbandonar.Add(nombre);
               string mensaje = "12/" + nombre + "/" + idPartida;
               byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
               server.Send(msg);
           }
        }
        private void ocultarJugadores_Click(object sender, EventArgs e)
        {
            DelegadoParaOcultarJugadores delegadoOcultarListaJugadores = new DelegadoParaOcultarJugadores(ocultarPanelJugadores);
            panel_ListaJugadores.Invoke(delegadoOcultarListaJugadores, new object[] { nombre }); 
        }
        private void btn_nuevaCarta_Click(object sender, EventArgs e)
        {
            /*Cuando pido una carta paso el turno directamente.
             * Si me paso de 21 punto -> no quiero pedir mas cartas.
             * Si me planto -> no quiero pedir mas cartas.
            */
            string mensaje = "15/" + nombre + "/" + idPartida + "/" + turnoCliente + "/" + 2 + "/"+ this.quieroMasCartas + "/" + puntosFinal;
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        private void btn_emepezar_Click(object sender, EventArgs e)
        {
            string mensaje = "15/" + nombre + "/" + idPartida + "/" + 1 + "/" + 0 + "/" + this.quieroMasCartas + "/" + puntosFinal;
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
         }

    }
}