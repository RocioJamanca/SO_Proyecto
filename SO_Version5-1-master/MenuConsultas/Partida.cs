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
using System.Threading;

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
        List<int> puntosJug1 = new List<int>();
        
        public List<int> puntosCroupier = new List<int>();
        List<int> numCartasCroupier = new List<int>();

        List<int> puntosJug2 = new List<int>();
        List<int> numCartasJug2 = new List<int>();


        Image[,] cartas = new Image[13, 4];
        public int turno = 1; //turno 1 jug1, turno2 jug2...
        public int numJugador;
        
        String nombreAnfitrion;
        String nombreJugadores;

        int dinero = 1000;
        int apuesta;

        public Partida(string idPartida, Socket server, string nombre, string nombreAnfitrion, string nombreJugadores)
        {
            InitializeComponent();
            this.idPartida = idPartida;
            this.server = server;
            this.nombre = nombre;
            this.nombreAnfitrion = nombreAnfitrion;
            this.nombreJugadores = nombreJugadores;
            //Llamo al metodo para que me diga el num de jugador que soy.
            if (this.nombreAnfitrion == this.nombre)
            {
                this.numJugador = queNumJugadorSoy(nombre, nombreJugadores); 
            }
            
        }
        private void Partida_Load(object sender, EventArgs e)
        {
            String[] nombres = nombreJugadores.Split('*');

            numero_partida.Text = idPartida.ToString();
            DelegadoParaEscribirNombre delegado = new DelegadoParaEscribirNombre(mostrarNombre);
            label1.Invoke(delegado, new object[] { nombre }); //Invoca al thread que crea el objeto(label1)     
            
            DelegadoParaModificarLblNombreJug1 delegadoLblNombreJug1 = new DelegadoParaModificarLblNombreJug1(modificarLblNombreJug1);
            lblNombreJug1.Invoke(delegadoLblNombreJug1, new object[] { nombreAnfitrion });

            DelegadoParaModificarLblNombreJug2 delegadoLblNombreJug2 = new DelegadoParaModificarLblNombreJug2(modificarLblNombreJug2);
            lblNombreJug2.Invoke(delegadoLblNombreJug2, new object[] { nombres[0] });

            //El Jugador1 sera el que tenga el primer turno y el que le dará al botón repartir cartas
            if (this.nombreAnfitrion == this.nombre)
            {
                this.numJugador = 1;
                
                DelegadoParaMostrarBtnTurno0 delegadoParaMostrarBtnTurno0 = new DelegadoParaMostrarBtnTurno0(mostrarBtnTurno0);
                btnTurno0.Invoke(delegadoParaMostrarBtnTurno0, new object[] { });
            }
            else
            {
                this.numJugador = 2;
            }
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


        }

        //Metodo que se usa para ver que jugador somos, ejemplo esteban*rocio*, esteban=1 rocio=2
        private int queNumJugadorSoy(string nombre, string nombreJugadores)
        {
            String[] nombres = nombreJugadores.Split('*');
            List<String> lista = nombres.ToList<String>();
            
            return lista.IndexOf(nombre) + 1;
        }

        public void modificarLblDinero (int dinero)
        {
            this.lblDinero_Jug1.Text = dinero.ToString();
        }
        delegate void DelegadoParaModificaDinero(int dinero);

        public void mostrarNombre(string nombre)
        {
            label1.Text = nombre;
            
        }
        delegate void DelegadoParaEscribirNombre(string mensaje);

        public void modificarLblNombreJug1(string nombre)
        {
            this.lblNombreJug1.Text = nombre;
        }
        delegate void DelegadoParaModificarLblNombreJug1(string nombre);

        public void modificarLblNombreJug2(string nombre)
        {
            this.lblNombreJug2.Text = nombre;
        }
        delegate void DelegadoParaModificarLblNombreJug2(string nombre);

        public void mostrarPerdido()
        {
            lblPasadoJug1.Show();

        }
        delegate void DelegadoParaMostrarPerdido();

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

        public void mostrarPanelAbandonar(string nombre)
        {
            panel_abandonar.Visible=true;
            btn_abandonar.Visible = false;
        }
        delegate void DelegadoParaAbandonar(string nombre);

        public void mostrarPanelDejarPartida(string nombreAbandonador)
        {
            panel_dejarPartida.Visible = true;
            label_nombreAbandona.Text = nombreAbandonador;
            panel_abandonar.Visible = false;
        }
        delegate void DelegadoParaDejarPartida(string nombreAbandonador);

        public void ocultarPanelAbandonar(string nombre)
        {
            panel_abandonar.Visible = false;
        }
        delegate void DelegadoParaOcultar(string nombre);

        public void ocultarPanelDejar(string nombre)
        {
            panel_dejarPartida.Visible = false;
        }
        delegate void DelegadoParaOcultarDejar(string nombre);

        public void ocultarPanelJugadores(string nombre)
        {
            panel_ListaJugadores.Visible = false;
        }
        delegate void DelegadoParaOcultarJugadores(string nombre);

        public void mostrarFinPartida()
        {
            label_finPartida.Text = "Se ha finalizado la partida";
            label_finPartida.Visible = true;
        }
        delegate void DelegadoParaFinPartida();

        public void cierreForm()
        {
            this.Close();
        }
        delegate void DelegadoParaCerrar();

        public void mostrarBtnTurno0()
        {
            btnTurno0.Show();
        }
        delegate void DelegadoParaMostrarBtnTurno0();

        public void ocultarBtnTurno0()
        {
            btnTurno0.Visible = false;
        }
        delegate void DelegadoParaOcultarBtnTurno0();

        public void mostrarBtnAbandonar()
        {
            btn_abandonar.Visible = true;
        }
        delegate void DelegadoParaMostrarBtnAbandonar();

        public void mostrarCartaCroupier(int palo, int numero)
        {
            if (numCartasCroupier.Count == 1)
            {
                pictureBox_croupier1.Visible = true;
                pictureBox_croupier1.Image = cartas[numero, palo];
                int puntosFinal = puntosCroupier[0];
                textBox_puntosCroupier.Text = puntosFinal.ToString();
            }
            else if (numCartasCroupier.Count == 2)
            {
                pictureBox_croupier2.Visible = true;
                pictureBox_croupier2.BringToFront();
                pictureBox_croupier2.Image = cartas[numero, palo];
                int puntosFinal = puntosCroupier[0] + puntosCroupier[1];
                textBox_puntosCroupier.Text = puntosFinal.ToString();
            }
            else if (numCartasCroupier.Count == 3)
            {
                pictureBox_croupier3.Visible = true;
                pictureBox_croupier3.BringToFront();
                pictureBox_croupier3.Image = cartas[numero, palo];
                int puntosFinal = puntosCroupier[0] + puntosCroupier[1] + puntosCroupier[2];
                textBox_puntosCroupier.Text = puntosFinal.ToString();
            }
            else if (numCartasCroupier.Count == 4)
            {
                pictureBox_croupier4.Visible = true;
                pictureBox_croupier4.BringToFront();
                pictureBox_croupier4.Image = cartas[numero, palo];
                int puntosFinal = puntosCroupier[0] + puntosCroupier[1] + puntosCroupier[2] + puntosCroupier[3];
                textBox_puntosCroupier.Text = puntosFinal.ToString();
            }
        }
        delegate void DelegadoParaMostrarCartaCroupier(int palo, int numero);

        public void mostrarLblPasadoJug1()
        {
            this.lblPasadoJug1.Show();
        }
        delegate void DelegadoParaMostrarPasadoJug1();

        public void mostrarLblPasadoJug2()
        {
            this.lblPasadoJug2.Show();
        }
        delegate void DelegadoParaMostrarPasadoJug2();

        public void mostrarCartaJug1(int palo,int numero)
        {
            int puntosFinal=0;
            if (numCartas.Count == 1)
            {
                pictureBox_carta1.Visible = true;
                pictureBox_carta1.Image = cartas[numero, palo];
                puntosFinal = puntosJug1[0];
                textBox_puntos.Text = puntosFinal.ToString();
            }
            else if (numCartas.Count == 2)
            {
                pictureBox_carta2.Visible = true;
                pictureBox_carta2.BringToFront(); 
                pictureBox_carta2.Image = cartas[numero, palo];
                puntosFinal = puntosJug1[0]+puntosJug1[1];
                textBox_puntos.Text = puntosFinal.ToString();
            }
            else if (numCartas.Count == 3)
            {
                pictureBox_carta3.Visible = true;
                pictureBox_carta3.BringToFront();
                pictureBox_carta3.Image = cartas[numero, palo];
                puntosFinal = puntosJug1[0] + puntosJug1[1]+puntosJug1[2];
                textBox_puntos.Text = puntosFinal.ToString();
            }
            else if (numCartas.Count == 4)
            {
                pictureBox_carta4.Visible = true;
                pictureBox_carta4.BringToFront();
                pictureBox_carta4.Image = cartas[numero, palo];
                puntosFinal = puntosJug1[0] + puntosJug1[1]+puntosJug1[2]+puntosJug1[3];
                textBox_puntos.Text = puntosFinal.ToString();
            }
            
        }
        delegate void DelegadoParaMostrarCartaJug1(int palo,int numero);

        public void mostrarCartaJug2(int palo, int numero)
        {
            int puntosFinal = 0;
            if (numCartasJug2.Count == 1)
            {
                pictureBox_jug2_carta1.Visible = true;
                pictureBox_jug2_carta1.Image = cartas[numero, palo];
                puntosFinal = puntosJug2[0];
                textBox_puntosJug2.Text = puntosFinal.ToString();
            }
            else if (numCartasJug2.Count == 2)
            {
                pictureBox_jug2_carta2.Visible = true;
                pictureBox_jug2_carta2.BringToFront();
                pictureBox_jug2_carta2.Image = cartas[numero, palo];
                puntosFinal = puntosJug2[0] + puntosJug2[1];
                textBox_puntosJug2.Text = puntosFinal.ToString();
            }
            else if (numCartasJug2.Count == 3)
            {
                pictureBox_jug2_carta3.Visible = true;
                pictureBox_jug2_carta3.BringToFront();
                pictureBox_jug2_carta3.Image = cartas[numero, palo];
                puntosFinal = puntosJug2[0] + puntosJug2[1] + puntosJug2[2];
                textBox_puntosJug2.Text = puntosFinal.ToString();
            }
            else if (numCartasJug2.Count == 4)
            {
                pictureBox_jug2_carta4.Visible = true;
                pictureBox_jug2_carta4.BringToFront();
                pictureBox_jug2_carta4.Image = cartas[numero, palo];
                puntosFinal = puntosJug2[0] + puntosJug2[1] + puntosJug2[2] + puntosJug2[3];
                textBox_puntosJug2.Text = puntosFinal.ToString();
            }
            


        }
        delegate void DelegadoParaMostrarCartaJug2(int palo, int numero);

        //public void ocultarlblGanadoJug1() { this.lblGanadoJug1.Hide(); }
        //delegate void DelegadoOcultarLblGanadoJug1();

        //public void ocultarlblGanadoJug2() { this.lblGanadoJug2.Hide(); }
        //delegate void DelegadoOcultarLblGanadoJug2();

        //public void ocultarlblPasadoJug1(){ this.lblPasadoJug1.Hide(); }
        //delegate void DelegadoOcultarLblPasadoJug1();

        //public void ocultarlblPasadoJug2() { this.lblPasadoJug2.Hide(); }
        //delegate void DelegadoOcultarLblPasadoJug1();


        
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
            DelegadoParaColorear delegadoColorear = new DelegadoParaColorear(colorearCelda);
            panel_ListaJugadores.Invoke(delegadoColorear, new object[] { nombreAbandona, 1 });
        }
       
        public void tomaNombreJugadores(string nombresJugadores)
        {
            //MessageBox.Show(nombre + " los jugadores acaban de recibir el mensaje");
            //MessageBox.Show("Los jugadores de la partida son: " + nombresJugadores);
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
                //MessageBox.Show(listaAbandonar.Count+"   "+numeroJugadores);
                if (listaAbandonar.Count == numeroJugadores)
                {
                    //MessageBox.Show(" Todos los jugadores han aceptado abandonar");
                    string mensaje = "14/" + nombre + "/" + idPartida;
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
       
        public void cerrarForm()
        {
            MessageBox.Show("Adiós");
            DelegadoParaCerrar delegadoCerrar=new DelegadoParaCerrar(cierreForm);
            label_finPartida.Invoke(delegadoCerrar, new object[] { });
        }

        public void tomaCartaJug1(int palo, int numero)
        {
            numCartas.Add(1);
            //En el blackjack J,Q y K valen 10 puntos.
            //En nuestro caso la carta 10 tiene asignado el numero 9 por lo tanto
            //Si el numero es mayor o igual que 9, añadiremos 10 puntos
            //Si es menor que 9 añadiremos el numero + 1.
            //En el blackjack la A puede valer 1 o 11 por simplicidad haremos que valga siempre 11.
            if (numero >= 9)
                puntosJug1.Add(10);
            if (numero < 9)
            {
                if (numero == 0) //la carta es un As
                {
                    puntosJug1.Add(11);
                }
                else //La carta es 2,3,4,5,6,7,8,9
                {
                    puntosJug1.Add(numero+1);
                }
            }
                
            DelegadoParaMostrarCartaJug1 delegadoCarta = new DelegadoParaMostrarCartaJug1(mostrarCartaJug1);
            panel_tablero.Invoke(delegadoCarta, new object[] { palo,numero});
            
            //Compruebo los puntos:
            //Comprobamos que no se ha pasado de 21 puntos
            if (puntosJug1.Sum() > 21)
            {
                DelegadoParaMostrarPasadoJug1 delegadolblPasadoJug1 = new DelegadoParaMostrarPasadoJug1(mostrarLblPasadoJug1);
                lblPasadoJug1.Invoke(delegadolblPasadoJug1, new object[] {});
            }
        }

        public void tomaCartaJug2(int palo, int numero)
        {
            numCartasJug2.Add(1);
            //En el blackjack J,Q y K valen 10 puntos.
            //En nuestro caso la carta 10 tiene asignado el numero 9 por lo tanto
            //Si el numero es mayor o igual que 9, añadiremos 10 puntos
            //Si es menor que 9 añadiremos el numero + 1.
            //En el blackjack la A puede valer 1 o 11 por simplicidad haremos que valga siempre 11.
            if (numero >= 9)
                puntosJug2.Add(10);
            if (numero < 9)
            {
                if (numero == 0) //la carta es un As
                {
                    puntosJug2.Add(11);
                }
                else //La carta es 2,3,4,5,6,7,8,9
                {
                    puntosJug2.Add(numero + 1);
                }
            }

            DelegadoParaMostrarCartaJug2 delegadoCartaJug2 = new DelegadoParaMostrarCartaJug2(mostrarCartaJug2);
            panel_tablero.Invoke(delegadoCartaJug2, new object[] { palo, numero });
            
            //Comprobamos que no se ha pasado de 21 puntos
            if (puntosJug2.Sum() > 21)
            {
                DelegadoParaMostrarPasadoJug2 delegadolblPasadoJug2 = new DelegadoParaMostrarPasadoJug2(mostrarLblPasadoJug2);
                lblPasadoJug2.Invoke(delegadolblPasadoJug2, new object[] { });
            }
        }

        //Devuelve la suma de los puntos actuales
        public int tomaCartaCroupier(int palo, int numero)
        {
            numCartasCroupier.Add(1);
            //En el blackjack J,Q y K valen 10 puntos.
            //En nuestro caso la carta 10 tiene asignado el numero 9 por lo tanto
            //Si el numero es mayor o igual que 9, añadiremos 10 puntos
            //Si es menor que 9 añadiremos el numero + 1.
            //En el blackjack la A puede valer 1 o 11 por simplicidad haremos que valga siempre 11.
            if (numero >= 9)
                puntosCroupier.Add(10);
            if (numero < 9)
            {
                if (numero == 0) //la carta es un As
                {
                    puntosCroupier.Add(11);
                }
                else //La carta es 2,3,4,5,6,7,8,9
                {
                    puntosCroupier.Add(numero + 1);
                }
            }

            DelegadoParaMostrarCartaCroupier delegadoCartaCroupier = new DelegadoParaMostrarCartaCroupier(mostrarCartaCroupier);
            panel_tablero.Invoke(delegadoCartaCroupier, new object[] { palo, numero });
            

            return puntosCroupier.Sum();
            
        }

        private void textBox_Chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            btn_enviar_Click(this, new EventArgs());
            
            }
        }

        private void btn_abandonar_Click_1(object sender, EventArgs e)
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

        //Se desea abandonar? 1-> Si, 0-> No
        private void btn_abandonar_Si_Click(object sender, EventArgs e)
        {
            string mensaje = "13/" + nombre + "/" + idPartida+"/1";
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            DelegadoParaOcultarDejar delegadoOcultar = new DelegadoParaOcultarDejar(ocultarPanelDejar);
            panel_abandonar.Invoke(delegadoOcultar, new object[] { nombre }); 
            
        }
        
        private void btn_abandonar_no_Click(object sender, EventArgs e)
        {
            string mensaje = "13/" + nombre + "/" + idPartida + "/0";
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            DelegadoParaOcultarDejar delegadoOcultar = new DelegadoParaOcultarDejar(ocultarPanelDejar);
            panel_abandonar.Invoke(delegadoOcultar, new object[] { nombre }); 
        }
       
        private void ocultarJugadores_Click(object sender, EventArgs e)
        {
            DelegadoParaOcultarJugadores delegadoOcultarListaJugadores = new DelegadoParaOcultarJugadores(ocultarPanelJugadores);
            panel_ListaJugadores.Invoke(delegadoOcultarListaJugadores, new object[] { nombre }); 
           
        }

        //Nueva carta
        private void btn_nuevaCarta_Click(object sender, EventArgs e)
        {
            if (turno != this.numJugador)
            {
                MessageBox.Show("Espera a tu turno");
            }
            else
            {
                string mensaje = "15/" + nombre + "/" + idPartida + "/" + this.numJugador;
                byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            
        }

        //Cuando el jugador le de a plantarse su turno se acaba
        //El turno tambien se acaba si las cartas del jugador suman mas de 21
        private void btn_plantarse_Click(object sender, EventArgs e)
        {
                /*Pasamos el turno al siguiente jugador
                 *En esta version hay 3 turnos: 
                 *Turno 1 => Jug1
                 *Turno 2 => Jug2
                 *Turno 3 => Croupier
                */
            if (turno != this.numJugador)
            {
                MessageBox.Show("Espera a tu turno");
            }
            else 
            { 
                //Enviamos nuestro turno, el servidor se encarga del siguiente turno.
                pasarTurno();
            }
            
        }

        //Codigo 17: Pone en marcha el turno0 (reparticion de las cartas)
        private void btnTurno0_Click(object sender, EventArgs e)
        {
            string mensaje = "17/" + nombre + "/" + idPartida;
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            DelegadoParaOcultarBtnTurno0 delegadoParaOcultarBtnTurno0 = new DelegadoParaOcultarBtnTurno0(ocultarBtnTurno0);
            btnTurno0.Invoke(delegadoParaOcultarBtnTurno0, new object[] { });
        }

        public void logicaCroupier()
        {
            
            string mensaje = "18/" + nombre + "/" + idPartida + "/" +puntosCroupier.Sum();
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        public void logicaGanadores()
        {
            //Gana el que supere el numero de puntos del croupier o si el croupier se pasa de 21.
            apuesta = Convert.ToInt32(this.textBox_apuesta_Jug1.Text);
            if (puntosCroupier.Sum() <= 21)
            {
                if (puntosJug1.Sum() <= 21 && puntosJug1.Sum() > puntosCroupier.Sum())
                {
                    dinero = dinero + apuesta;
                }
                if (puntosJug1.Sum() <= 21 && puntosJug1.Sum() < puntosCroupier.Sum()) //Ha perdido
                {
                    dinero = dinero - apuesta;
                }
                
                if (puntosJug2.Sum() <= 21 && puntosJug2.Sum() > puntosCroupier.Sum())
                    MessageBox.Show("El Jug2 ha ganado");
            }
            else
            {
                if (puntosJug1.Sum() <= 21)
                    dinero = dinero + apuesta;
                else
                    dinero = dinero - apuesta;
            }

            DelegadoParaModificaDinero delegadoParaModificarDinero = new DelegadoParaModificaDinero(modificarLblDinero);
            lblDinero_Jug1.Invoke(delegadoParaModificarDinero, new object[] { dinero });

        }
        
        public void pasarTurno()
        {
            string mensaje = "16/" + nombre + "/" + idPartida + "/" + turno;
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        


    }
}