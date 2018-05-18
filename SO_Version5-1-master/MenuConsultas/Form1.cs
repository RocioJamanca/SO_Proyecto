﻿using System;
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
//Hola
//Para comentar:        Ctr K + Ctr C
//Para descomentar:     Ctr K + Ctr U
//Como he puesto todos ls dialogs dentro de una carpeta tengo que añadir esta linea.
using MenuConsultas.dialogs;

//Compilar en shiva: gcc -o server Version5-1.c -lpthread `mysql_config --cflags --libs`

namespace MenuConsultas
{
    public partial class Form1 : Form
    {
        Socket server;
        String Ip = "147.83.117.22"; //192.168.56.102 --- 147.83.117.22
        String nombre;
        String password;
        int idPartida;
        Thread atender;
        List<String> listaJugadores = new List<string>();
        // Lista Genérica de formularios
        List<Partida> formularios= new List<Partida>();
        List<String> idsPartidas = new List<string>();


        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser
            //accedidos desde threads diferentes a los que los crearon 
        }
        //Para la delegación:
        //  -Paso 1: crear la función de la operación que no puedo realizar
        //  -Paso 2: Invoke (en donde queremos mostrarlo)
        //  -Paso 3:Creamos objeto delegado, los parámetros de este han de ser los mismos que el de la función
        //  -Paso 4:Declaramos donde queremos escribir el delegado
        //  -Paso 5:"Rellenar" el invoke con el delegado que usamos y el objeto (new object[] {nombre})

        public void mostrarNombre(string nombre)
        {
            label1.Text = "Bienvenido: " + nombre;
            this.btnContraseña.Show();
            this.btnFecha.Show();
            this.btnGanador.Show();
            this.btnRegistrar.Hide();
            this.btnLogear.Hide();
            this.panel_conectados.Show();
        }
        delegate void DelegadoParaEscribirNombre(string nombre);

        public void mostrarConectados(string mensaje6)
        {
            String[] nombres = mensaje6.Split('*');
            List<String> lista = nombres.ToList<String>();
            lista.Remove(nombre);
            lista.RemoveAt(lista.Count - 1);
            matriz.ColumnCount = 1;
            matriz.RowCount = lista.Count;
            for (int j = 0; j < lista.Count; j++)
            {
                matriz.Rows[j].Cells[0].Value = lista[j];
            }
        }
        delegate void DelegadoParaListaConectados(string mensaje6);

        public void mostrarListaJugadores(string nombreINVITADO)
        {
            if (listaJugadores == null)
            {
                panelJugadores.Hide();
            }
            else
            {
                listaJugadores.Add(nombreINVITADO);
                jugadores.ColumnCount = 1;
                jugadores.RowCount = listaJugadores.Count;
                for (int h = 0; h < listaJugadores.Count; h++)
                {
                    jugadores.Rows[h].Cells[0].Value = listaJugadores[h];
                }
                panelJugadores.Show();
            }
        }
        delegate void DelegadoParaListaJugadores(string nombreINVITADO);

        public void cerrar(bool fin)
        {
            this.Close();
            server.Shutdown(SocketShutdown.Both);
            //fin = true;
            Application.Exit();
        }
        delegate void DelegadoParaCerrar(bool fin);

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnContraseña.Hide();
            this.btnFecha.Hide();
            this.btnGanador.Hide();
            this.panel_conectados.Hide();
            this.btnRegistrar.Hide();
            this.btnLogear.Hide();
            this.panelJugadores.Hide();
            //declaración de la matriz
            matriz.ColumnHeadersVisible = false;
            matriz.RowHeadersVisible = false;
            jugadores.ColumnHeadersVisible = false;
            jugadores.RowHeadersVisible = false;      
        }

        private void atender_mensajes_servidor()
        {
            /* Comprobamos los mensajes que nos envia el servidor
             * 
             * 0: Hubo un error o queremos salir
             * 1: Indica si nos hemos logeado con éxito
             * 2: Registro con exito
             * 3: Fecha partida
             * 4: Contraseña
             * 5: Partida ganador
             * 6: Lista conectados
             * 7: Cerrar conexion
             */
            bool fin = false;
            //cuando queramos desconectar, solo hará falta poner atender.Abort()
            while (!fin)
            {
                int codigo;
                byte[] msg = new byte[80];
                // recibo mensaje del servidor
                server.Receive(msg);
                string mensaje = Encoding.ASCII.GetString(msg);
                string[] trozos = mensaje.Split('/');
                codigo = Convert.ToInt32(trozos[0]);
                // Averiguo el tipo de mensaje
                
                switch (codigo)
                { 
                        //cambiar el salir, en vez del 7 el 0.
                    case 0: //Recibo 0/ si el cliente ya esta en la lista de conectados
                        MessageBox.Show("El cliente ya está conectado");
                    
                        break;

                    case 1: //Log in con exito
                        int code1 = Convert.ToInt32(trozos[1]);
                        if (code1 == 0)
                        {
                            MessageBox.Show("No estás registrado.\n");
                        }
                        else if (code1 == 2)
                        {
                            MessageBox.Show("El usuario ya ha sido conectado.\n");
                        }
                        else if (code1 == 1)
                        {
                            MessageBox.Show("Log in con exito.\n");                      
                            //Creamos el mensaje que enviaremos al servidor
                            string mensaje0 = "6/" + nombre;
                            byte[] msg0 = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje0);
                            server.Send(msg0);
                            DelegadoParaEscribirNombre delegado = new DelegadoParaEscribirNombre(mostrarNombre);
                            label1.Invoke(delegado, new object[] {nombre}); //Invoca al thread que crea el objeto(label1)
                        }
                        break;

                    case 2: //Registro con exito

                        int code2 = Convert.ToInt32(trozos[1]);
                        if (code2 == 0)
                        {
                            MessageBox.Show("Registro sin exito\n");
                        }
                        else
                        {
                            MessageBox.Show("Registro con exito\n");
                        }

                        break;

                    case 3: //Fecha partida
                        int code3 = Convert.ToInt32(trozos[1]);
                        if (code3 == 0)
                        {
                            MessageBox.Show("No existen fechas");
                        }
                        else
                        {
                            string[] separar = trozos[2].Split('*');
                            int a = trozos[2].Split('*').Length - 1;
                            //Juntamos toda la array de separar en una sola string.
                            //Environment.NewLine es para separar las strings en una linea nueva
                            string fechas = string.Join(Environment.NewLine, separar);
                            MessageBox.Show("Fechas jugadas\n" + fechas);
                        }
                        break;

                    case 4: //Contraseña
                        string contras;
                        int code4 = Convert.ToInt32(trozos[1]);
                        if (code4 == 0)
                        {
                            MessageBox.Show("No se han hallado resultados");
                        }
                        else
                        {
                            contras = trozos[2];
                            MessageBox.Show("La contraseña de: " + nombre.ToString() + " es: " + contras.ToString());
                        }
                        break;

                    case 5: //Partida Ganador
                        int code5 = Convert.ToInt32(trozos[1]);
                        if (code5 == 0)
                        {
                            MessageBox.Show("No se han hallado resultados");
                        }
                        else
                        {
                            string[] separar = trozos[2].Split('*');
                            int a = trozos[2].Split('*').Length - 1;
                            MessageBox.Show(nombre.ToString() + " ha ganado " + a + " partidas.");
                        }
                        break;

                    case 6: //Lista Conectados
                        
                        string mensaje6 = trozos[1];
                        DelegadoParaListaConectados delegadoListaConectados = new DelegadoParaListaConectados(mostrarConectados);
                        matriz.Invoke(delegadoListaConectados,new object [] {mensaje6});
                        break;
                    //solo le informamos al servidor que nos desconectamos,
                    //el servidor no enviará nada.

                   case 7:
                        DelegadoParaCerrar delegadoCerrar =new DelegadoParaCerrar(cerrar);
                        this.Invoke(delegadoCerrar, new object[] { fin });
                        fin = true;
                    break;

                   case 8:
                    string nombreINVITADOR = trozos[1];
                    AbrirInvitación(nombreINVITADOR);
                    break;

                    case 9:
                    //Recibo: 9/1/nombreINVITADO      ACEPTO
                    //Recibo: 9/0/nombreINVITADO	  NO ACEPTO			
                    int aceptar = Convert.ToInt32(trozos[1]);
                    string nombreINVITADO = trozos[2].Split('\0')[0];
                    if (aceptar == 0) //Denegado
                    {
                        MessageBox.Show("El jugador: " + nombreINVITADO + " ha declinado tu invitación" );
                    }
                    else  //Aceptado
                    {
                        MessageBox.Show("El jugador: " + nombreINVITADO + " ha aceptado tu invitación");
                        DelegadoParaListaJugadores delegadoJugadores = new DelegadoParaListaJugadores(mostrarListaJugadores);
                        jugadores.Invoke(delegadoJugadores, new object[] { nombreINVITADO });
                    }

                    break;

                    case 10:
                    string idPartida = trozos[1];
                    string nombreAnfitrion = trozos[2];
                    string nombreJugadores = trozos[3]; //Estos habrá que separarlos ya que estan en el formato nombre1*nombre2*nombre3*....
                    MessageBox.Show("Se ha iniciado una Partida con id:  "+idPartida+" el anfitrión es:  "+nombreAnfitrion);
                    //Enviar desde este form al nuevo -> nombre, nombreAnfitrion, id de la partida al nuevo form y las personas que estan jugando.
                    //pongo en marcha el thread  
                    ThreadStart ts = delegate { PonerMarchaFormulario(idPartida); };
                    Thread T = new Thread(ts);
                    T.Start();
                    break;

                    case 11: //chat
                    int numForm = idsPartidas.IndexOf(trozos[1]);
                        //Convert.ToInt32(trozos[1]); //Es el mismo que id Partida 
                        
                    string frase = trozos[2]; //Mensaje que aparecerá en la listBox
                    //formularios.Find(x=> x.Equals(numForm));
                    //formularios.IndexOf(numForm).tomaFrase();
                    formularios[numForm].tomaFrase(frase);
                    break;
                }
            }
        }

        //Para ocultar selección ctrl+M, ctrl+H
        //Funciones de Inicio de sesión y consultas. 
        //Boton Registrar
        private void button4_Click(object sender, EventArgs e)
        {
            //Creamos un dialog_Registrar
            dialog_Registrar dialog_registrar = new dialog_Registrar();
            if (dialog_registrar.ShowDialog() == DialogResult.OK)
            {
                if (dialog_registrar.txtBox_Nombre.Text == "" || dialog_registrar.txtBox_Contra.Text == "")
                {
                    MessageBox.Show("Los datos no se han introducido correctamente");
                }
                else
                {
                    //Creamos el mensaje que enviaremos al servidor
                    string mensaje = "2/" + dialog_registrar.txtBox_Nombre.Text + "/" + dialog_registrar.txtBox_Contra.Text;
                    byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    this.nombre = dialog_registrar.txtBox_Nombre.Text;
                    this.password = dialog_registrar.txtBox_Contra.Text;
                }
            }
        }

        //Boton Entrar
        private void btnLogear_Click(object sender, EventArgs e)
        {
            //Esta ventana se abrirá cuando clickeemos el boton Logear
            dialog_Logear dialog_logear = new dialog_Logear();
            if (dialog_logear.ShowDialog() == DialogResult.OK)
            {
                if (dialog_logear.txtBox_Nombre.Text == "" || dialog_logear.txtBox_Contra.Text=="")
                {
                    MessageBox.Show("Los datos no se han introducido correctamente");
                }
                else
                {
                    //Creamos el mensaje que enviaremos al servidor
                    string mensaje = "1/" + dialog_logear.txtBox_Nombre.Text + "/" + dialog_logear.txtBox_Contra.Text;
                    this.nombre = dialog_logear.txtBox_Nombre.Text;
                    this.password = dialog_logear.txtBox_Contra.Text;
                    byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
        }
        
        //Boton Obtener fecha
        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos el mensaje que enviaremos al servidor
            string mensaje = "3/" + nombre.ToString() + "/" + password.ToString();
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        
        //Boton obtener contraseña
        private void btnContraseña_Click(object sender, EventArgs e)
        {
            //Creamos el mensaje que enviaremos al servidor
            string mensaje = "4/" +nombre;
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
         
        //Boton obtener ganador
        private void btnGanador_Click(object sender, EventArgs e)
        {
            //Creamos el mensaje que enviaremos al servidor
            string mensaje = "5/" + nombre + "/" + password;
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg); 
        }

        //Funciones de conexión-desconexión
        //Funcion para conectarnos al servidor
        private void ConectarServidor()
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse(Ip);
            IPEndPoint ipep = new IPEndPoint(direc, 50025);
            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.pbQueCambiaAlConectar.BackColor = Color.Green;
                this.btnConectar.BackColor = Color.Green;
                this.btnRegistrar.Show();
                this.btnLogear.Show();
                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { atender_mensajes_servidor(); };
                atender = new Thread(ts);
                atender.Start();
            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }
        //Boton que usamos para conectarnos al servidor.
        private void btnConectar_Click(object sender, EventArgs e)
        {
            ConectarServidor();
        }
        //Funcion para desconectarnos del servidor con el boton
        private void btn_desconectar_Click(object sender, EventArgs e)
        {
         //Creamos el mensaje que enviaremos al servidor
            string mensaje = "7/" + nombre;
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        //Funcion para desconectarnos del servidor con la X.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Creamos el mensaje que enviaremos al servidor
            string mensaje = "7/" + nombre;
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);    
        }

        private void matriz_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i, j;
            i = e.RowIndex;
            j = e.ColumnIndex;
            //Persona invitada
            string persona;
            persona = matriz.Rows[i].Cells[0].Value.ToString();
            if (listaJugadores.Find(x => x.Equals(persona)) != null)
            {
                MessageBox.Show("El jugador: " + persona + " ya ha sido invitado");
            }
            else
            {
                MessageBox.Show("Estas invitando a: " + persona);
                //Creamos el mensaje que enviaremos al servidor
                string mensaje = "8/" + nombre + "/" + persona;
                byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }  
        }

        //Metodo que abre la ventana de invitación.
        //Envia al servidor si aceptamos o declinamos.
        private void AbrirInvitación(string nombreInvitador)
        {
            dialog_Invitación dialog_invitacion = new dialog_Invitación();
            dialog_invitacion.lbl_nombreInvitador.Text = nombreInvitador;
            dialog_invitacion.Text = nombre;
            //Si le damos a aceptar en el ventana de invitacion el Dialog_result será OK
            //Si le damos a declinar en la ventana de invitacion el Dialog_resulta será Cancel
            if (dialog_invitacion.ShowDialog() == DialogResult.OK)
            {
                //Creamos el mensaje que enviaremos al servidor
                // dialog_invitacion.lbl_nombreInvitador.Text nombreINVITADOR
                string mensaje = "9/" + nombre + "/1" + "/" + dialog_invitacion.lbl_nombreInvitador.Text;
                byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                // label_invitacion.Text nombreINVITADOR
                //Creamos el mensaje que enviaremos al servidor
                string mensaje = "9/" + nombre + "/0" + "/" + dialog_invitacion.lbl_nombreInvitador.Text;
                byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void btn_empezar_partida_Click(object sender, EventArgs e)
        {
            
            string nombreJugadores = "";
            for (int i = 0; i < listaJugadores.Count; i++)
            {
                nombreJugadores =nombreJugadores+"*"+listaJugadores[i] ;
            }
            nombreJugadores = nombreJugadores + "*"+nombre+"*";
            string mensaje = "10/" + nombre + "/" + (listaJugadores.Count+1) + "/" + nombreJugadores; 
            byte[] msg = System.Text.ASCIIEncoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            listaJugadores.Clear();
            jugadores.Columns.Clear();
            jugadores.Rows.Clear();
            if (listaJugadores.Count == 0)
            {
                panelJugadores.Hide();
            }
        }

        private void PonerMarchaFormulario(string idPartida)
        {
            //int n = formularios.Count();
            Partida formPartida = new Partida(idPartida,server,nombre); //idPartida(será el numForm y server es el socket)
            formularios.Add(formPartida);
            idsPartidas.Add(idPartida);
            formPartida.ShowDialog();
            //pongo en marcha el thread que atenderá los mensajes del servidor  
        }

    }
}
