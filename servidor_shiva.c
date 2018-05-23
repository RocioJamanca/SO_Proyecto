#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>             
#include <stdio.h>
#include <mysql.h>
#include <time.h>
#include <my_global.h> //SHIVA
#include <pthread.h>
#define max 200
#define NUM_THREADS 10

pthread_mutex_t mutexsum;

typedef struct 
{
	int id;   //El ide de la conexion
	char nombreUsuario [50];
}cliente;

typedef struct
{
	int num; //Numero de sockets
	cliente lista[max];
}listaClientes;
//Lista de usuarios conectados
listaClientes *cl,clientes;

//Lista de partidas 

typedef struct 
{
	int idPartida;
	int numeroPersonas;
	cliente listaJugador[max];
	
}partida;
typedef struct 
{
	int numPartidas;
	partida listaP[max];
	
}listaPartidas;

listaPartidas *lp,partidas;
int turno = 1;


//Escribe una funcion que anade a la lista de conectados un nuevo jugador (nombre y socket).
int nuevoUsuario(listaClientes *l,int idSocket,char nombre [max])
{
	if (l->num == max) //En cso de tener la lista llena
	{
		printf("Lista de conectados llena\n");
		return -1;
	}
	else
	{
		
		l->lista[l->num].id=idSocket;
		strcpy(l->lista[l->num].nombreUsuario,nombre);
		
		//anadimos a la lista el nuevo cliente
		l->num++;     
		printf("Usuario correctamente anadido\n");
		return 0;
	}
}

cliente encontrarCliente(listaClientes *cl, char nombre[100]) //Retorno cliente
{
	cliente c;
	printf("Funcion encontrar cliente\n");
	for(int i=0;i<cl->num;i++)
	{
		if(strcmp(nombre,cl->lista[i].nombreUsuario)==0)
		{
			c=cl->lista[i];
			printf("El usuario encontrado es: %s\n",cl->lista[i].nombreUsuario);
			printf("El usuario encontrado tiene socket: %d\n",cl->lista[i].id);
		}
		
	}
	return c;
}

//Escribe una funcion que elimina de la lista a uno de los jugadores, 
//a partir del nombre de ese jugador.

int eliminarUsuario(listaClientes *l, char nombre[100])
{
	int encont=0;
	for(int i=0; i<l->num;i++)
	{
		if(strcmp(l->lista[i].nombreUsuario,nombre)==0)
		{
			
			for(int j=i+1; j<l->num;j++)
			{
				l->lista[j-1]=l->lista[j];
			}
			
			l->num=l->num-1;
			printf("Persona %s eliminada de la lista\n",nombre);
			encont=1;
		}
	}
	if (encont=1)
	{
		printf("Usuario correctamente eliminado\n");
		return 0;
	}
	else 
	{
		printf("El usuario no se encuentra en la lista\n");
		return -1;
	}
}

//Escribe una funcion que devuelve el socket de un jugador determinado, a partir de su nombre.

int obtenerSocket(listaClientes *l, char nombre [max])
{
	int id;
	for(int i=0;i<l->num;i++)
	{
		if (strcmp(l->lista[i].nombreUsuario,nombre)==0)
		{
			
			id=l->lista[i].id;
		}
	}
	return id;
}

//Escribe una funcion que crea una cadena de caracteres que contiene el numero
//de jugadores que hay en la lista seguido del nombre de todos esos jugadores, 
//separados todos esos datos por una coma.
void crearCadena(listaClientes *l,char cadena [200])
{
	//strcpy(cadena,"");
	for (int i=0;i<l->num;i++)
	{
		strcat(cadena, l->lista[i].nombreUsuario); ////REVISAR/
		strcat(cadena, "*");
	}
	printf("Fucion crear cadena. Lista de usuarios :%s\n",cadena);
}

int nuevaPartida(listaPartidas *lp, int idPartida,int numeroPersonas,char nombreJugadores[max])
{
	printf("Funcion nueva partida\n");
	char jugadores[max];
	char *z;
	cliente c;
	strcpy(jugadores,nombreJugadores);
	
	
	if (lp->numPartidas == max) //En cso de tener la lista llena
	{
		printf("Lista de partidas llena\n");
		return -1;
	}
	else
	{
		
		lp->listaP[lp->numPartidas].idPartida=idPartida;
		lp->listaP[lp->numPartidas].numeroPersonas=numeroPersonas;
		printf("Funcion nuevaPartida. idPartida: %d, numeroPersonas: %d \n",idPartida,numeroPersonas);
		z=strtok(jugadores,"*");
		//comparar la lista de clientes con la z 
		//encontrarCliente(&cl,z,c);
		//lp->listaPartida[p->numPartidas]=c;
		int i = 0;
		for(; i<numeroPersonas && z != NULL;i++)
		{					
			c=encontrarCliente(cl,z);
			printf("Usuario, nombre: %s, id: %d \n",c.nombreUsuario,c.id);
			lp->listaP[lp->numPartidas].listaJugador[i]=c;
			printf("Id socket: %d - nombreSocket: %s \n",lp->listaP[lp->numPartidas].listaJugador[i].id,lp->listaP[lp->numPartidas].listaJugador[i].nombreUsuario);
			z = strtok( NULL, "*");
		}
		//Avisar si no concuerdan el numero de jugadores con la cantidad de jugadores
		if(i!=numeroPersonas)
		{
			printf("La cantidad de personas deber￯﾿ﾭa ser %d pero hay %d nombres.\n",numeroPersonas,i);
		}
		//anadimos a la lista el nuevo cliente
		
		lp->numPartidas++;     
		printf("Partida correctamente anadida\n");
		return idPartida;
		
	}
}





void *atender_cliente(void *conectados) 
	//Queremos que nuestro programa cree un thread diferente para procesar cada uno de los conectados.
{
	int sock_conn;
	//int socket_conn = * (int *) socket;
	sock_conn=(int*)conectados; //Threads, id conectados        
	printf("Atender cliente sock conn :%d \n",sock_conn);
	
	//servei
	char peticion[512];
	char respuesta[512];
	int ret;
	//CONEXION MYSQL
	//Inicializamos la conexion MYSQL
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char username[20];
	char password[15];
	char consulta [200];
	
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) 
	{
		printf ("Error al crear la conexion a mysql: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//inicializar la conexion
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "multinivel",0, NULL, 0);
	if (conn==NULL) 
	{
		printf ("Error al inicializar la conexion a mysql: %u %s\n",mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	int fin=0;
	while(fin==0)
	{
		//DESPUES DE INICIALIZAR LA CONEXION CON EL CLIENTE
		ret=read(sock_conn,peticion,sizeof(peticion));
		peticion[ret]='\0';
		write(1,"Mensaje recibido de cliente: ",16);
		write(1,peticion,strlen(peticion));
		//Declaramos lo necesario para guardar  y separar los
		//elementos server-cliente
		char *p = strtok( peticion, "/"); //Extraemos el codigo
		int codigo =  atoi (p);
		char nombre[20];
		char contra[20];
		p = strtok( NULL, "/"); //Extraemos el nombre
		strcpy (nombre, p);
		
		printf ("\n Mensaje recibido del cliente separado: Codigo= %d , Nombre= %s\n", codigo, nombre);
		
		/* Codigo - Consulta
		1	- Login
		2	- Registrar
		3 	- Fecha partida
		4	- Contrasena
		5 	- Partida Ganador
		*/
		/* Codigo - Respuesta
		0	- Error
		*/
		//Pedimos usuario y contrasena y los comparamos
		
		if (codigo==1) //Login      Recibo: 1/nombre/contrasena
		{
			int encontrado=0;
			//   envio: 1/1 Todo correcto
			//   envio: 1/0 Error
			p = strtok( NULL, "/"); //Extraemos la contrasena
			strcpy (contra, p);
			//Consulta
			strcpy (consulta,"SELECT password FROM jugador WHERE nombre = '"); 
			strcat (consulta, nombre);
			strcat(consulta,"'");
			
			//hacemos la consulta 
			err=mysql_query (conn, consulta);
			if (err!=0) 
			{
				printf ("Error en la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			strcpy(respuesta,"1/");
			//recogemos el resultado de la consulta  
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row (resultado);
			
			if (row == NULL) //No hay datos en la consulta
			{
				printf("No existen datos en la consulta\n");
				strcat(respuesta,"0/");
			}
			else{
				
				printf("Codigo 1. El resultado de la consulta: %s\n",row[0]);
				printf("Codigo 1. Contrasena introducida por cliente: %s\n",contra);
				if (strcmp(contra,row[0])==0) //La contrasena coincide.
				{
					
					if(cl->num==0)
					{
						printf("Aun no hay nadie en la lista de conectados\n");
						strcat(respuesta,"1/");
						printf("Codigo 1. Respuesta: %s\n",respuesta);
						pthread_mutex_lock (&mutexsum); //Solo a￯﾿ﾯ￯ﾾ﾿￯ﾾﾱanadimos exclusion mutua si se edita la lista de clientas
						nuevoUsuario(cl,sock_conn,nombre);
						pthread_mutex_unlock (&mutexsum);
					}
					
					else
					{
						printf("La lista de conectados no est￡ vac￭a\n");
							   for (int i=0; i<cl->num && encontrado==0;i++)
							   {
								   if(strcmp(cl->lista[i].nombreUsuario,nombre)==0)
								   {
									   printf("El usuario ya esta dentro de la lista de conectados");
									   strcat(respuesta,"2/");
									   printf("Codigo 1. Respuesta: %s\n",respuesta);
								   }
								   else
								   {
									   printf("El usuario se acaba de conectar\n");
									   strcat(respuesta,"1/");
									   printf("Codigo 1. Respuesta: %s\n",respuesta);
									   pthread_mutex_lock (&mutexsum); //Solo a￯﾿ﾯ￯ﾾ﾿￯ﾾﾱanadimos exclusion mutua si se edita la lista de clientas
									   nuevoUsuario(cl,sock_conn,nombre);
									   pthread_mutex_unlock (&mutexsum);
									   encontrado=1;
								   }
							   }
					}

					// notificar a todos los clientes conectados
				}
				else //La constrasena no coincide con la que tenemos en la bd.
				{
					strcat(respuesta,"0/");
				}	
			}
			
			strcat(respuesta,"\n");
			printf("Codigo 1. Respuesta que envio: %s\n",respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
		}
		else if (codigo==2)		//Registar  recibo: 2/nombre/contrase￯﾿ﾯ￯ﾾ﾿￯ﾾﾃ￯﾿ﾯ￯ﾾﾾ￯ﾾﾱa
		{
			//  envio: 2/0  NO se ha realizado correctamente
			//  envio: 2/1  Todo correcto
			p = strtok( NULL, "/"); //Extraemos la contrasena
			strcpy (contra, p);
			
			
			
			int cont;
			err=mysql_query (conn, "SELECT MAX(idJugador) FROM jugador"); 
			if (err!=0) 
			{
				printf("ERROR al contar");
			}
			else
			{
				resultado = mysql_store_result (conn); 
				row=mysql_fetch_row(resultado);
				cont=atoi(row[0]);
			}
			printf("Codigo 2. ID ultimo jugador %d\n",cont);
			printf("Codigo 2. Contrase￯﾿ﾯ￯ﾾ﾿￯ﾾﾱa nuevo jugador %s\n",contra);
			int id = cont +1;
			char code[20];
			sprintf(code,"%d",id);
			
			///
			strcpy (consulta,"SELECT password FROM jugador WHERE nombre = '"); 
			strcat (consulta, nombre);
			strcat(consulta,"'");
			
			//hacemos la consulta 
			err=mysql_query (conn, consulta);
			if (err!=0) 
			{
				printf ("Error en la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			strcpy(respuesta,"2/"); //-----
			//recogemos el resultado de la consulta  
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row (resultado);
			
			if (row != NULL) //No hay datos en la consulta
			{
				printf("La persona ya ha sido registrada\n");
				strcat(respuesta,"2/");
			}
			else{
			
			//Consulta
			strcpy(consulta,"INSERT INTO jugador(idJugador,nombre,password) VALUES (");	
			strcat(consulta, "'");
			strcat(consulta,code);
			strcat(consulta,"',");
			strcat(consulta, "'");
			strcat(consulta,nombre);
			strcat(consulta, "','");
			strcat(consulta,contra);
			strcat(consulta, "');");
			printf("Codigo 2. Formulacion de consulta: %s\n",consulta);
			
			err=mysql_query (conn, consulta); 
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
				
				strcat(respuesta,"0/");
			}
			
			else
			{
				strcat(respuesta,"1/");
			}
			
			}
			write (sock_conn,respuesta, strlen(respuesta));
			
		}
		
		else if (codigo==3) 	//Fecha partida  recibo: 3/nombre/contrasena
		{		
			//    envio: 3/1/fecha1*fecha2*fecha3*....
			//    envio: 3/0   No hay datos						
			p = strtok( NULL, "/"); //Extraemos la contrasena
			strcpy (contra, p);
			//Consulta
			strcpy (consulta,"SELECT partida.fecha FROM jugador,partida,relacion WHERE jugador.nombre = '"); 
			strcat (consulta, nombre);
			strcat (consulta,"'AND relacion.idPartidaR= partida.idPartida AND relacion.idJugadorR = jugador.idJugador");
			
			//hacemos la consulta 
			err=mysql_query (conn, consulta); 
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			strcpy(respuesta,"3/"); 
			
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row (resultado);
			
			if (row == NULL)
			{
				printf ("No se han obtenido datos en la consulta\n");
				strcat(respuesta,"0\n");
			}
			else
			{
				strcat(respuesta,"1/");
				printf(" Codigo 3. Fechas jugadas: \n");
				
				while(row != NULL) // fecha*fecha2*fecha3
				{
					printf(" %s\n",row[0]);
					strcat(respuesta,row[0]);
					strcat(respuesta,"*");
					row = mysql_fetch_row(resultado);
				}
			}
			write (sock_conn,respuesta, strlen(respuesta));
		}
		
		
		else if (codigo==4)		//No recuerdo mi contrasena
		{ 
			//recibo: 4/nombre	
			//  envio: 4/1/contrasena  Todo Correcto
			//  envio: 4/0/            Error
			//Consulta
			strcpy (consulta,"SELECT password FROM jugador WHERE nombre = '"); 
			strcat (consulta, nombre);
			strcat(consulta,"'");
			
			//hacemos la consulta 
			err=mysql_query (conn, consulta);
			if (err!=0) 
			{
				printf ("Error en la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			strcpy(respuesta,"4/");//
			
			//recogemos el resultado de la consulta  
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row (resultado);
			
			if (row == NULL) //No hay datos en la consulta
			{
				printf("No data\n");
				strcat(respuesta,"0/");
			}
			
			else{
				strcat(respuesta,"1/");
				strcat(respuesta,row[0]);
				printf("Codigo 4. Respuesta: %s\n",respuesta);
				
			}
			
			strcat(respuesta,"\n");
			printf("Codigo 4. Respuesta que envio: %s\n",respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
		}
		
		else if (codigo==5)		//Consulta partidas ganadas
		{
			//Recibo: 5/nombre/contrasena
			//Envio: 5/1/idPartidas
			//Envio: 5/0 No se ha ganado ninguna partida
			p = strtok( NULL, "/"); //Extraemos la contrasena
			strcpy (contra, p);
			//Consulta
			strcpy (consulta,"SELECT partida.idPartida FROM partida WHERE partida.ganador = '");
			strcat (consulta, nombre);
			strcat	(consulta, "'");
			
			//hacemos la consulta 
			err=mysql_query (conn, consulta); 
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			strcpy(respuesta,"5/"); //
			
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row (resultado);
			if (row == NULL)
			{
				printf ("No se han obtenido datos en la consulta\n");
				strcat(respuesta,"0\n");
			}
			else
			{
				strcat(respuesta,"1/");
				printf(" Codigo 5. Partidas ganadas \n");
				
				while(row != NULL) // idPartida1*idPartida2....
				{
					printf(" %s\n",row[0]);
					strcat(respuesta,row[0]);
					strcat(respuesta,"*");
					row = mysql_fetch_row(resultado);
				}
			}
			
			write (sock_conn,respuesta, strlen(respuesta));
		}
		else if(codigo==6)		//Enviar lista conectados 
		{
			//Recibo: 6/nombreconectado
			//Envio: 6/nombre1*nombre2*....
			// notificar a todos los clientes conectados
			printf("Codigo 6. Entrada OK\n");
			char notificacion[20];
			strcpy (notificacion, "6/");
			crearCadena(cl,notificacion);
			printf("Codigo 6. Notificacion despues de crear cadena %s\n",notificacion);
			for (int i=0; i< cl->num; i++)
			{
				write (cl->lista[i].id,notificacion, strlen(notificacion));
				printf("Lista de conectados enviada a: %s codigo: %d\n",cl->lista[i].nombreUsuario,cl->lista[i].id);
			}
		}
		else if (codigo==7)		//Desconectar cliente
		{
			//Recibo: 7/nombredescontar
			//Envio: 6/nombre1*nombre2*...
			
			write (sock_conn,"7/", strlen("7/"));
			pthread_mutex_lock (&mutexsum); //Solo a￯﾿ﾯ￯ﾾ﾿￯ﾾﾱanadimos exclusion mutua si se edita la lista de clientas
			eliminarUsuario(cl,nombre);
			pthread_mutex_unlock (&mutexsum);
			char notificacion[20];
			strcpy (notificacion, "6/"); //Para que el cliente lea la lista
			crearCadena(cl,notificacion);
			printf("Codigo 7. Notificacion despues de crear cadena %s\n",notificacion);
			printf("Codigo 7. cl->num %d\n",cl->num);
			
			for (int i=0; i< cl->num; i++)
			{
				
				write (cl->lista[i].id,notificacion, strlen(notificacion));
				printf("Lista de conectados enviada a: %s codigo: %d\n",cl->lista[i].nombreUsuario,cl->lista[i].id);
				
			}
			fin=1;
		}
		else if (codigo==8)		//Recibo invitacion
		{
			//Recibo: 8/nombre/personaINVITAR
			//Envio: 8/nombreINVITADOR
			printf("Codigo 8. El nombre del invitador es: %s\n", nombre);
			p = strtok( NULL, "/"); //Extraemos la contrasena
			strcpy (contra, p);
			char persona [100];
			strcpy(persona,contra);
			printf("Codigo 8. El nombre del invitador es: %s\n", nombre);
			
			printf("El nombre de la persona a la que invitas %s\n",persona);
			for(int i=0; i<cl->num ; i++)
			{
				if(strcmp(cl->lista[i].nombreUsuario,persona)==0)
				{
					//int sock =obtenerSocket(&cl,persona);
					sprintf(respuesta,"8/%s",nombre);
					write (cl->lista[i].id,respuesta, strlen(respuesta));
					printf("Codigo 8.Envio a: %d, %s => %s\n",cl->lista[i].id,persona,respuesta);
				}
			}
		}
		else if(codigo==9)		//Aceptar o denegar invitacion
		{
			//Recibo: 9/nombre/1/personaINVITADOR (ACEPTO INVITACION)
			//Recibo: 9/nombre/0/personaINVITADOR (NO ACEPTO INVITACION)
			//Envio: 9/1/nombreINVITADO   ACEPTO
			//Envio: 9/0/nombreINVITADO	  NO ACEPTO			
			printf("Codigo 9. El nombre del invitado es: %s\n", nombre);
			p = strtok( NULL, "/"); //Extraemos el 1 o el 0;
			int aceptar=atoi(p);
			char persona [100];
			p = strtok( NULL, "/");
			strcpy(persona,p);
			if(aceptar==0)
			{
				for(int i=0; i<cl->num ; i++)
				{
					if(strcmp(cl->lista[i].nombreUsuario,persona)==0)
					{
						sprintf(respuesta,"9/0/%s",nombre);
						write (cl->lista[i].id,respuesta, strlen(respuesta));
						printf("Codigo 9.Envio a: %d, %s => %s\n",cl->lista[i].id,persona,respuesta);
					}
				}
			}
			else
			{
				for(int i=0; i<cl->num ; i++)
				{
					if(strcmp(cl->lista[i].nombreUsuario,persona)==0)
					{
						sprintf(respuesta,"9/1/%s",nombre);
						write (cl->lista[i].id,respuesta, strlen(respuesta));
						printf("Codigo 9.Envio a: %d, %s => %s\n",cl->lista[i].id,persona,respuesta);
					}
				}
			}
		}
		else if (codigo==10) //Empezar p￯﾿ﾠrtida
		{	printf("Codigo 10.\n");
		//Recibo: 10/nombre/numeroJugadores/jugador1*jugador2*.......7
		//Envio: 10/idPartida/nombreHost/nombreJugador1*nombreJugador2
		p = strtok( NULL, "/"); //Extraemos el numero de jugadores
		int numJugadores=atoi(p);
		char jugadores[max];
		p = strtok( NULL, "/"); //Extraemos jugadores
		strcpy(jugadores,p);
		printf("Codigo 10. Recibo-> nombre: %s / numeroJugadores: %d / jugadores: %s\n",nombre,numJugadores,jugadores);
		int idPartida;
		pthread_mutex_lock (&mutexsum); //Solo a￯﾿ﾯ￯ﾾ﾿￯ﾾﾱanadimos exclusion mutua si se edita la lista de clientas
		idPartida = nuevaPartida(lp,lp->numPartidas,numJugadores,jugadores);
		pthread_mutex_unlock (&mutexsum);
		
		
		printf("Codigo 10. lp->numPartidas: %d , idPartida: %d\n",lp->numPartidas,idPartida);
		sprintf(respuesta,"10/%d/%s/",idPartida,nombre);
		for(int i=0;i<numJugadores;i++)
		{
			
			printf("Codigo 10. lp->listaP[idPartida].listaJugador[i].id : %d\n",lp->listaP[idPartida].listaJugador[i].id);
			strcat(respuesta,lp->listaP[idPartida].listaJugador[i].nombreUsuario);
			strcat(respuesta,"*");
			write(lp->listaP[idPartida].listaJugador[i].id,respuesta, strlen(respuesta));
			
		}
		printf("Codigo 10.Envio: %s\n",respuesta);
		}
		
		
		
		else if (codigo==11)   //Chat
		{
			printf("Codigo 11.\n");
			//Recibo: 11/nombre/idPartida/mensaje
			//Envio: 11/idPartida,mensaje
			p = strtok( NULL, "/");
			int idPartida=atoi(p); //extraemos numeroFormulario (coincide con idPartida)
			p = strtok( NULL, "/"); 
			char mensaje [max];
			strcpy(mensaje,p);
			sprintf(respuesta,"11/%d/%s: %s/",idPartida,nombre,mensaje);
			for(int i=0;i<lp->listaP[idPartida].numeroPersonas;i++)
			{
				write(lp->listaP[idPartida].listaJugador[i].id,respuesta, strlen(respuesta));
			}
			printf("Codigo 11.Envio: %s\n",respuesta);
			
		}
		else if (codigo==12)   //Abandonar partida
		{
			//Recibo: 12/nombre/idPartida
			//Envio: 12/nombreAbandonar/idPartida/nom*nom*/   A todos
			printf("Codigo 12.\n");
			p = strtok( NULL, "/");
			int idPartida=atoi(p); //extraemos idPartida
			sprintf(respuesta,"12/%s/%d/",nombre,idPartida);
			for(int i=0;i<lp->listaP[idPartida].numeroPersonas;i++)
			{
				strcat(respuesta,lp->listaP[idPartida].listaJugador[i].nombreUsuario);
				strcat(respuesta,"*");
			}
			strcat(respuesta,"/");
			
			for(int i=0;i<lp->listaP[idPartida].numeroPersonas;i++)
			{
				write(lp->listaP[idPartida].listaJugador[i].id,respuesta, strlen(respuesta));
			}
			printf("Codigo 12. Envio: %s\n",respuesta);
			
		}
		else if (codigo==13)  //Se desea abandonar?
		{
			//Recibo: 13/nombre/idPartida/1 SI ABANDONAR
			//Recibo: 13/nombre/idPartida/0	NO ABANDONAR
			//Envio: 13/nombre/idPartida/1 o 0/nom*nom*/numJugadores/
			printf("Codigo 13.\n");
			p = strtok( NULL, "/");
			int idPartida=atoi(p); //extraemos idPartida
			p = strtok( NULL, "/");
			int deacuerdo=atoi(p); //1 o 0
			sprintf(respuesta,"13/%s/%d/%d/",nombre,idPartida,deacuerdo);
			for(int i=0;i<lp->listaP[idPartida].numeroPersonas;i++)
			{
				strcat(respuesta,lp->listaP[idPartida].listaJugador[i].nombreUsuario);
				strcat(respuesta,"*");
			}
			strcat(respuesta,"/");
			char numeroJugadores[512];
			sprintf(numeroJugadores,"%d",lp->listaP[idPartida].numeroPersonas);
			strcat(respuesta,numeroJugadores);
			strcat(respuesta,"/");
			
			for(int i=0;i<lp->listaP[idPartida].numeroPersonas;i++)
			{
				write(lp->listaP[idPartida].listaJugador[i].id,respuesta, strlen(respuesta));
			}
			printf("Codigo 13. Envio: %s\n",respuesta);
		}
		else if(codigo==14)  //Final de partida
		{
			printf("Codigo 14.\n");
			p = strtok( NULL, "/");
			int idPartida=atoi(p); //extraemos idPartida
			//Guardardatos de la partida en mysql
			sprintf(respuesta,"14/%d/",idPartida);
			write(sock_conn,respuesta,strlen(respuesta));
			printf("Codigo 14. Envio: %s\n",respuesta);
		}
		else if (codigo==15) // Nueva carta
		{
			//Recibimos 15/Nombre/idPartida/NumeroJugador(Jug1=1 Jug2=2)
			//Enviamos 15/nombre/idPartida/palo/numero/numeroJugador

			//Cuando un cliente pida una carta
			//	*Le mandaremos esa carta a todos para que lo vean en los clientes.
			printf("Codigo 15.\n");
			p = strtok( NULL, "/");
			int idPartida=atoi(p); //extraemos idPartida
			
			p = strtok( NULL, "/"); //extraemos NumeroJugador
			int numeroJugador = atoi(p);
			
			int cantidad=0; 
			int palo=0;
			int numero=0;
			
			palo=rand()%(3-0)+1;
			printf("%d/%d\n",palo,numero);
			numero=rand()%(12-0)+1;
			cantidad++;
			printf("%d/%d/%d\n",cantidad, palo,numero);
			
			sprintf(respuesta,"15/%s/%d/%d/%d/%d/",nombre,idPartida,palo,numero, numeroJugador);
			//Le enviamos a todos la respuesta
			for(int i=0;i<lp->listaP[idPartida].numeroPersonas;i++)
			{
				write(lp->listaP[idPartida].listaJugador[i].id,respuesta, strlen(respuesta));
			}
			
			printf("Codigo 15. Envio: %s\n",respuesta);
		}
		else if (codigo==16)
		{
			//Recibo: 16/nombre/idPartida/Turno ¡recibo el turno actual!
			//Envio: 16/idPartida/Turno
			printf("Codigo 16.\n");
			p = strtok( NULL, "/");
			int idPartida=atoi(p); //extraemos idPartida
			
			p=strtok(NULL, "/");
			turno = atoi(p) + 1;

			if(turno == 5)
				turno=1;
			
			sprintf(respuesta,"16/%d/%d/",idPartida, turno);
			
			//Le enviamos a todos la respuesta
			for(int i=0;i<lp->listaP[idPartida].numeroPersonas;i++)
			{
				write(lp->listaP[idPartida].listaJugador[i].id,respuesta, strlen(respuesta));
			}

			
			printf("Codigo 16. Envio: %s\n",respuesta);

		}
		else if(codigo == 17)//Turno 0, se reparten 2 cartas a cada jugador, y el croupier enseña 1 carta.
		{
			//Recibo: 17/nombre/idPartida
			//Envio: 17/idPartida/paloCoupier/numCoupier/nombreAnfitrion*palo1*num1*palo2*num2/Jug1*carta1*carta2/...
			printf("Codigo 17. \n");
			
			p = strtok( NULL, "/");
			int idPartida=atoi(p);
			
			int palo=0;
			int numero=0;
			
			palo=rand()%(3-0)+1;
			numero=rand()%(12-0)+1;
			sprintf(respuesta, "17/%d/%d/%d/",idPartida, palo, numero); //Ejemplo; respuesta=17/5/2/3/

			//Cartas de los jugadores
			for(int j=0; j<lp->listaP[idPartida].numeroPersonas; j++)
			{
				sprintf(respuesta, "%s%s*",respuesta, lp->listaP[idPartida].listaJugador[j].nombreUsuario); 
				//Ejemplo primera vuelta respuesta = 17/5/2/3/esteban*
				//Ejemplo segunda vuelta: 17/5/2/3/esteban*2*6*1*9*/rocio*
				
				for(int i=0; i<2; i++)
				{
					palo=rand()%(3-0)+1;
					numero=rand()%(12-0)+1;
					sprintf(respuesta, "%s%d*%d*",respuesta, palo, numero ); 
					//Ejemplo primera vuelta: respuesta 17/5/2/3/esteban*2*6*
					//Ejemplo segunda vuelta: 17/5/2/3/esteban*2*6*1*9*
				}
				strcat(respuesta, "/"); 
				//Ejemplo: 17/2/3/esteban*2*6*1*9*/
			}
			//Les envio a todos los de la partida 
			for(int i=0;i<lp->listaP[idPartida].numeroPersonas;i++)
			{
				printf("%s\n", respuesta);
				write(lp->listaP[idPartida].listaJugador[i].id,respuesta, strlen(respuesta));
			}
			

		}
		else if(codigo == 18) //turno croupier
		{
			//Recibo: 18/nombre/idPartida/puntosCroupier
			//Envio: 18/idPartida/palo/num/
			p = strtok( NULL, "/");
			int idPartida=atoi(p);

			int palo=0;
			int numero=0;
			
			palo=rand()%(3-0)+1;
			numero=rand()%(12-0)+1;
			sprintf(respuesta, "18/%d/%d/%d/",idPartida, palo, numero);
			//Les envio a todos los de la partida 
			for(int i=0;i<lp->listaP[idPartida].numeroPersonas;i++)
			{
				printf("%s\n", respuesta);
				write(lp->listaP[idPartida].listaJugador[i].id,respuesta, strlen(respuesta));
			}
		}

		
		
	}
	
	// Codigo para salir, recordar anadir el thread
	
	printf("Cerrando conexion mysql\n");
	mysql_close(conn);
	printf("Cerrando conexion socket\n");
	close(sock_conn); /* Necessari per a que el client detecti EOF */
	printf("Cerrando thread\n");
	pthread_exit(NULL); //Para cerrar el thread
	
}

int main(int argc, char *argv[])
{
	
	cl = &clientes;//Asignar un puntero hacia la estructura con la lista de conectados
	cl->num = 0;
	lp=&partidas;
	lp->numPartidas=0;
	
	//Inicializar conexion
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
	{
		printf("Error creant socket");
	}
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY); /* El fica IP local */
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(50024);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf("Error al bind");
	
	// Limitem el nombre de connexions pendents
	if (listen(sock_listen, 10) < 0)
		printf("listen");
	
	pthread_t threads[NUM_THREADS];
	
	for (;;)
	{
		
		for(int i=0;i<NUM_THREADS;i++)
		{
			printf("Escuchando\n");	
			//acceptem connexio d'un client 
			sock_conn = accept(sock_listen,NULL,NULL); 
			//cuando el cliente realmente se va a a conecctar hay que utilizar este sock_conn
			printf ("Nos hemos conectado\n");
			//clientes.lista[i].id=sock_conn;
			
			pthread_create(&threads[i],NULL,atender_cliente,(void*)sock_conn);	
			
		}
	}
}
