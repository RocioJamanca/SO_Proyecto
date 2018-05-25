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

        //Formulario Partida necesita estos datos.
        String nombreAnfitrion; 
        String nombreJugadores;

        Thread atender;
        List<String> listaJugadores = new List<string>();
        // Lista Genérica de formularios
        List<Partida> formularios= new List<Partida>();
        List<String> idsPartidas = new List<string>();

<<<<<<< HEAD
        public String getNombreAnfitrion()
        {
            return this.nombreAnfitrion;
        }
        public String getNombresJugadores()
        {
            return this.nombreJugadores;
        }

=======
        List<string> turnos=new List<string>();
>>>>>>> Branch-Rocio
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
                byte[] msg = new byte[180];
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
                            //MessageBox.Show("Log in con exito.\n");                      
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
                            MessageBox.Show("Error\n");
                        }
                        else if (code2==1)
                        {
                           // MessageBox.Show("Registro con exito\n");
                        }
                        else if (code2 == 2)
                        {
                            MessageBox.Show("El usuario ya ha sido registrado\n");
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
                            //MessageBox.Show("El jugador: " + nombreINVITADO + " ha aceptado tu invitación");
                            DelegadoParaListaJugadores delegadoJugadores = new DelegadoParaListaJugadores(mostrarListaJugadores);
                            jugadores.Invoke(delegadoJugadores, new object[] { nombreINVITADO });
                        }

                        break;

<<<<<<< HEAD
                    case 10: //Recibo: 10/idPartida/nombreHost/nombreJugador1*nombreJugador2
                        string idPartida = trozos[1];
                        this.nombreAnfitrion = trozos[2];
                        this.nombreJugadores = trozos[3]; //Estos habrá que separarlos ya que estan en el formato nombre1*nombre2*nombre3*....
                        //MessageBox.Show("Se ha iniciado una Partida con id:  "+idPartida+" el anfitrión es:  "+nombreAnfitrion);
                    
                        //Enviar desde este form al nuevo -> nombre, nombreAnfitrion, id de la partida al nuevo form y las personas que estan jugando.
                        
                    
                        //pongo en marcha el thread  
                        ThreadStart ts = delegate { PonerMarchaFormulario(idPartida); };
                        Thread T = new Thread(ts);
                        T.Start();
                        break;

                    case 11: //chat
                        int numForm = idsPartidas.IndexOf(trozos[1]);  
                        string frase = trozos[2]; //Mensaje que aparecerá en la listBox
                        formularios[numForm].tomaFrase(frase);
                        break;
=======
                    case 10:
                    string idPartida = trozos[1];
                    string nombreAnfitrion = trozos[2];
                    string nombreJugadores = trozos[3]; //Estos habrá que separarlos ya que estan en el formato nombre1*nombre2*nombre3*....
                    ThreadStart ts = delegate { PonerMarchaFormulario(idPartida); };
                    Thread T = new Thread(ts);
                    T.Start();
                    break;
                    int numForm = idsPartidas.IndexOf(trozos[1]);
                    formularios[numForm].tomaAnfitrion(nombreAnfitrion);

                    case 11: //chat
                    numForm = idsPartidas.IndexOf(trozos[1]);  
                    string frase = trozos[2]; //Mensaje que aparecerá en la listBox
                    formularios[numForm].tomaFrase(frase);
                    break;
>>>>>>> Branch-Rocio
                     
                        case 12:
                        string nombreAbandona=trozos[1];
                        numForm = idsPartidas.IndexOf(trozos[2]);
                        string nombresJugadores = trozos[3];
                        if (nombreAbandona == nombre)
                        { 
                            formularios[numForm].tomaNombreJugadores(nombresJugadores);
                        }
                        else
                        {
                            formularios[numForm].tomaNombreAbandona(nombreAbandona);
                        }
                        break;
                    
                    case 13:
                        string nombreResponde = trozos[1];
                        numForm = idsPartidas.IndexOf(trozos[2]);
                        int deacuerdo = Convert.ToInt32(trozos[3]);
                        nombresJugadores = trozos[4];
                        int numeroJugadores = Convert.ToInt32(trozos[5]);
                        formularios[numForm].tomaDatosAbandonar(nombreResponde,deacuerdo,nombresJugadores,numeroJugadores);
                        break;

                    case 14:
                        numForm = idsPartidas.IndexOf(trozos[1]);
                        formularios[numForm].cerrarForm();
                        break;
                    case 15:
                        //Recibo: 15/nombre/idPartida/palo/numero/numeroJugador
                        numForm = idsPartidas.IndexOf(trozos[2]);
                        int palo=Convert.ToInt32(trozos[3]);
                        int numero = Convert.ToInt32(trozos[4]);
                        //Tenemos que distinguir entre si somos el Jug1 o el Jug2
                        int aux_numJugador = Convert.ToInt32(trozos[5]);

                        if(aux_numJugador == 1)
                            formularios[numForm].tomaCartaJug1(palo,numero);
                        if(aux_numJugador == 2)
                            formularios[numForm].tomaCartaJug2(palo, numero);

                        break;
                    case 16:
                        //Recibo 16/idPatida/turno
                        numForm = idsPartidas.IndexOf(trozos[1]);
                        formularios[numForm].turno = Convert.ToInt32(trozos[2]);

                        if (formularios[numForm].numJugador == formularios[numForm].turno)
                        {
                            MessageBox.Show("Es tú turno");
                        }


                        if (formularios[numForm].turno == 3) //turno croupier
                        {
                            //El cliente del jugador 1 será el que ponga en marcha la logica del Croupier
                            //Sin esto todos los clientes lo pondrian en marcha
                            MessageBox.Show("Turno Croupier");
                            
                            if (formularios[numForm].numJugador == 1)
                            {
                                formularios[numForm].logicaCroupier();
                            }
                        }


                        if (formularios[numForm].turno == 4) //Turno para ver los ganadores
                        {
                            formularios[numForm].logicaGanadores();
                        }

                        break;
                    case 17: //Recibo 17/idPartida/paloCoupier/numCoupier/nombreAnfitrion*palo1*num1*palo2*num2/Jug2*palo1*num1*palo2*num2/...
                        //ejemplo 17/5/2/3/esteban*2*6*1*9*/rocio*4*7*2*8*/  
                        String cartasJug1 = trozos[4];
                        String cartasJug2 = trozos[5];

                        numForm = idsPartidas.IndexOf(trozos[1]);
                        int palo_coupier = Convert.ToInt32(trozos[2]);
                        int numero_coupier = Convert.ToInt32(trozos[3]);
                        formularios[numForm].tomaCartaCroupier(palo_coupier, numero_coupier);
                        
                        String[] array_cartasJug1 = cartasJug1.Split('*'); //nombreAnfitrion*palo1*num1*palo2*num2
                        int paloJug1 = Convert.ToInt32(array_cartasJug1[1]);
                        int numJug1 = Convert.ToInt32(array_cartasJug1[2]);
                        formularios[numForm].tomaCartaJug1(paloJug1, numJug1);
                        
                        paloJug1 = Convert.ToInt32(array_cartasJug1[3]);
                        numJug1 = Convert.ToInt32(array_cartasJug1[4]);
                        formularios[numForm].tomaCartaJug1(paloJug1, numJug1);

                        String[] array_cartasJug2 = cartasJug2.Split('*'); //Jug2*palo1*num1*palo2*num2
                        int paloJug2 = Convert.ToInt32(array_cartasJug2[1]);
                        int numJug2 = Convert.ToInt32(array_cartasJug2[2]);
                        formularios[numForm].tomaCartaJug2(paloJug2, numJug2);
                        
                        paloJug2 = Convert.ToInt32(array_cartasJug2[3]);
                        numJug2 = Convert.ToInt32(array_cartasJug2[4]);
                        formularios[numForm].tomaCartaJug2(paloJug2, numJug2);
                        break;

                    case 18: //Turno del croupier
                        //Recibo 18/idPartida/palo/num/
                        numForm = idsPartidas.IndexOf(trozos[1]);
                        palo = Convert.ToInt32(trozos[2]);
                        numero = Convert.ToInt32(trozos[3]);

                        int puntosCroupier = formularios[numForm].tomaCartaCroupier(palo, numero);

                        if (puntosCroupier < 16)
                            formularios[numForm].logicaCroupier();
                        else
                            formularios[numForm].pasarTurno();

                        break;
                    case 17:
                        numForm = idsPartidas.IndexOf(trozos[1]);
                        formularios[numForm].tomaNombreJugadores(trozos[2]);
                        break;
                    case 18:
                        string nombreJugadorAnterior = trozos[1];
                        numForm = idsPartidas.IndexOf(trozos[2]);
                        string nombreTocaJugar=trozos[3];
                        int turno = Convert.ToInt32(trozos[4]);
                        numeroJugadores=Convert.ToInt32(trozos[5]);
                        nombreJugadores=trozos[6];
                        int vez = Convert.ToInt32(trozos[7]);

                       // MessageBox.Show("La persona que acaba de jugar:" + nombreJugadorAnterior + " le toca jugar a " + nombreTocaJugar + " turno:" + turno);
                        //comprobar 
                        if (vez == 0)
                        {
                            palo = Convert.ToInt32(trozos[8]);
                            numero = Convert.ToInt32(trozos[9]);
                            formularios[numForm].tomaCarta(palo, numero);
                            turnos.Add(nombreJugadorAnterior); //el indice=0

                        }
                        int i=0;
                        if (i < numeroJugadores)
                            turnos.Add(nombreTocaJugar);
                        else
                        {
                            turnos.Clear();
                            turnos.Add(nombreJugadorAnterior);
                        }

                                formularios[numForm].tomaActualizacionMiTurno(nombreJugadorAnterior, nombreTocaJugar, turno,numeroJugadores,nombreJugadores);
                                formularios[numForm].tomaTurno(turno);

                        
                        //enviar quien esta jugando y el turno
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
            IPEndPoint ipep = new IPEndPoint(direc, 50023);
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
                //MessageBox.Show("Estas invitando a: " + persona);
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
            Partida formPartida = new Partida(idPartida,server,nombre, nombreAnfitrion, nombreJugadores); //idPartida(será el numForm y server es el socket)
            formularios.Add(formPartida);
            idsPartidas.Add(idPartida);
            formPartida.ShowDialog();
            //pongo en marcha el thread que atenderá los mensajes del servidor  
        }

    }
}
