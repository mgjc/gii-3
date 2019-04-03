#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <time.h>
#include <mpi.h>
#define _XOPEN_SOURCE
#include <unistd.h>
#include <crypt.h>

int main (int argc, char **argv){

	int iId;
	int iNumProcs;
    char mensaje[30];
	double tiempoIni = 0, tiempoFin = 0;	
    int i, flag;
	MPI_Status status;
	system("clear");
	MPI_Init (&argc ,&argv);
	MPI_Comm_rank(MPI_COMM_WORLD,&iId);
	MPI_Comm_size(MPI_COMM_WORLD, &iNumProcs);

	if(iId==0){
        long intentos_Total=0;
        long intentos_Procesos[iNumProcs];
        int hashes=2;
        int flag_bucle;
        int clave_hallada;
        char claves[hashes][30];
        char soluciones[hashes][9];
        int claves_Estado[hashes];
        int claves_Procesos[iNumProcs];

        tiempoIni = MPI_Wtime();

        for(i=0;i<iNumProcs;i++){
            intentos_Procesos[i]=0;
        }
        // Generamos las soluciones y las claves
        srand(9999);
        for(i=0;i<hashes;i++){
            sprintf(soluciones[i],"%08d",rand()%100000000);
            strcpy(claves[i],crypt(soluciones[i],"aa"));
        }


        puts("  ---------------------------------");
        puts("  CLAVES GENERADAS CON SEMILLA 9999");
        puts("  ---------------------------------");

        
        for(i=0;i<hashes;i++){
            claves_Estado[i]=-1;
	        printf("%02d) %s - %s\n",i,soluciones[i],claves[i]);
	    }

        
        puts("  --------------------");
        puts("  COMIENZA LA BUSQUEDA");
        puts("  --------------------");


        // En claves_Estado es para claves, -1 si no se esta buscando, 0 si se esta buscando, >0 implica el proceso que lo ha encontrado.
        // En claves_Procesos es para procesos. El indice 0 es para el proceso 1
        
        // Necesitamos saber que proceso esta haciendo cada clave, se usa otro array, claves_Procesos, donde se almacena el indice de la clave
        // que se esta buscando actualmente, se necesita para saber que procesos estan haciendo cierta clave, en caso de que uno de ellos descubra
        // la solucion habria que informar al resto de los procesos que se ha encontrado la solucion a esa clave, logicamente han de ser informados
        // aquellos que estaban buscando esa misma clave, no todos los procesos

        // Tenemos dos casos
        // Hay mas hashes que procesos, por lo que hay que enviar a todos los procesos un unico hash

        if(iNumProcs==1){
            srand(100);
            int intentos=0;
            char contrasenia[9];
            i=0;
            while(i<hashes){
                sprintf(contrasenia,"%08d",rand()%100000000);
                intentos++;
                if(strcmp(crypt(contrasenia,"aa"),claves[i])==0){
                    intentos_Total+=intentos;
                    intentos=0;
                    i++;
                }
            }


        }else{

            if(hashes>=iNumProcs){
                    for(i=1;i<iNumProcs;i++){
                        claves_Estado[i-1]=0;
                        claves_Procesos[i-1]=i-1;
                        strcpy(mensaje,claves[i-1]);
                        MPI_Send(mensaje,30,MPI_CHAR,i,2,MPI_COMM_WORLD);
                    }
            }else{
            // Hay mas procesos que hashes, por lo que hay que enviar a todos los procesos un hash aunque sean hashes repetidos ya que no hay tantos y tienen que compartir hashes
                for (i=1;i<iNumProcs;i++){
                    if(i<=hashes){
                        strcpy(mensaje,claves[i-1]);
                        claves_Estado[i-1]=0;
                        claves_Procesos[i-1]=i-1;
                    }else{
                        strcpy(mensaje,claves[i-1-hashes]);
                        // Comento la siguiente linea ya que el array ha sido puesto todo a 0 en la parte de arriba
                        claves_Procesos[i-1]=i-1-hashes;
                    }
                    
                    MPI_Send(mensaje,30,MPI_CHAR,i,2,MPI_COMM_WORLD);
                }
            }
            for(i=1;i<iNumProcs;i++){
                printf("PROC %02d: %s (%d)\n",i,claves[claves_Procesos[i-1]],claves_Procesos[i-1]);
            }

            // Mientras queden hashes por solucionar vamos a estar recibiendo y enviando mensajes hasta que no quede ningun hash por resolver
            flag_bucle=1;
            while(flag_bucle){
                int indice_Nuevo=-1;
                int indice_Repetido=-1;

                // Recibir mensaje
                do {
                    //BUCLE DE SNIFFING
                    usleep(20);
                    MPI_Iprobe(MPI_ANY_SOURCE, MPI_ANY_TAG,MPI_COMM_WORLD, &flag, &status);

                }while (!flag);
                flag=0;
                MPI_Recv(mensaje,30, MPI_CHAR, MPI_ANY_SOURCE, MPI_ANY_TAG, MPI_COMM_WORLD, &status);
                //  Descomprimir mensaje
                system("clear");
                char *token;
                char id[3];
                char intent[12];
                char contra[8];
                token=strtok(mensaje,"-");
                strcpy(id,token);
                token=strtok(NULL,"-");
                strcpy(intent,token);
                token=strtok(NULL,"-");
                strcpy(contra,token);
                int id_proc= atoi(id);
                char *ptr;
                unsigned long long intentos=strtol(intent,&ptr,10);
                // Tenemos el array claves_Estado, donde aparecen las claves que no estan siendo buscadas, -1, siendo buscadas , 0
                // Halladas por algun proceso, >0
                // Tenemos el array claves_Procesos, que indica que procesos estan haciendo cada clave
                intentos_Procesos[id_proc]+=intentos;
                for(i=0;i<hashes;i++){
                    if(strcmp(contra,soluciones[i])==0){
                        claves_Estado[i]=id_proc;
                        clave_hallada=i;
                        break;
                    }
                } 
                // Compruebo si hay algun hash por hacer
                for(i=0;i<hashes;i++){
                    if(claves_Estado[i]<1){
                        flag_bucle=1;
                        break;
                    }
                    flag_bucle=0;
                }
                // Si no quedan hashes por hacer se sale del bucle
                if(flag_bucle==0){
                    break;
                }
                // Si quedan hashes por hacer busco primero si hay hashes que nadie este resolviendo
                int indice=-1;
                for(i=0;i<hashes;i++){
                    if(claves_Estado[i]==-1){
                        indice_Nuevo=i;
                        indice=i;
                        break;
                    }
                }

                if(indice==-1){
                    for(i=0;i<hashes;i++){
                        if(claves_Estado[i]==0){
                            indice_Repetido=i;
                            indice=i;
                            break;
                        }
                    }
                }
                
                // Se envia otro mensaje con otro hash a resolver en caso de que aun queden hashes al proceso que ha quedado libre
                strcpy(mensaje,claves[indice]);

                // Si la clave la estaba buscando alguien mas, se les envia un mensaje actualizando con la nueva clave
                for(i=1;i<iNumProcs;i++){
                    if(claves_Procesos[id_proc-1]==claves_Procesos[i-1]){
                        MPI_Send(mensaje,30,MPI_CHAR,i,2,MPI_COMM_WORLD);
                        claves_Procesos[i-1]=indice;
                    }
                }
                
                claves_Estado[indice]=0;

                // Mostrar todo de nuevo:
                char x[30];
                int y;
                for(i=0;i<hashes;i++){
                    if(claves_Estado[i]==0){
                        y=-1;
                    }else{
                        y=claves_Estado[i];
                    }
                    if(y<1){
                        strcpy(x,"");
                    }else{
                        strcpy(x,soluciones[i]);
                    }
                    printf("%02d) %s->%s (%d)\n",i,claves[i],x,y);
                }
                for(i=1;i<iNumProcs;i++){
                    printf("PROC %02d: %s (%d)\n",i,claves[claves_Procesos[i-1]],claves_Procesos[i-1]);
                }
                
            }
        }

        // Paramos el tiempo
        tiempoFin = MPI_Wtime();

        // Sacamos el numero de intentos totales
        if(iNumProcs!=1){
            for(i=0;i<iNumProcs;i++)
                intentos_Total+=intentos_Procesos[i];
        
            puts("");
            puts("CLAVES ENCONTRADAS POR PROCESO\n");
            for(i=1;i<iNumProcs;i++){
                int j;
                int x=0;
                for(j=0;j<hashes;j++){
                    if(i==claves_Estado[j])
                        x++;
                }
                printf("%2d) %d\n",i,x);
            }
        }
	    puts("");
        puts("LLAMADAS A RAND Y CRYPT\n");
        if(iNumProcs!=1){
            for(i=1;i<iNumProcs;i++){
                printf("%2d) %ld\n",i,intentos_Procesos[i]);
            }
        }else{
            printf("%2d) %ld\n",0,intentos_Total);
        }
	    puts("");
	    puts("");
        puts("ESTADISTICAS TOTALES");
	    puts("");
        printf("Intentos acumulados: %ld\n", intentos_Total);
        printf("Segundos por Clave: %lf\n", (tiempoFin-tiempoIni)/hashes);

        printf("Numero Procesos: %d\n", iNumProcs);
        printf("Tiempo procesamiento: %lf\n", tiempoFin-tiempoIni);

		// Acaba con todos los procesos tras el while
        for (i=1;i<iNumProcs;i++)
            MPI_Send(mensaje,30,MPI_CHAR,i,1,MPI_COMM_WORLD);

        MPI_Finalize();
        return 0;

	}else{

		while(1){
			do {
				//BUCLE DE SNIFFING
				usleep(20);
				MPI_Iprobe(MPI_ANY_SOURCE, MPI_ANY_TAG,MPI_COMM_WORLD, &flag, &status);

			}while (!flag);

			flag=0;
            
			MPI_Recv(mensaje,30, MPI_CHAR, MPI_ANY_SOURCE, MPI_ANY_TAG, MPI_COMM_WORLD, &status);

            char contrasenia[9];
            unsigned long long intentos=0;

			switch(status.MPI_TAG){
				case 1:
                    // Finaliza
					MPI_Finalize();
					return 0;
					break;
				case 2:
                    // Busca el codigo y carga informacion en mensaje
                    srand(100*iId);
                    do{
                        // Comprobamos si ha llegado algo por el canal 4, en ese caso dejamos de buscar una solucion para esa clave
                        // un hash compartido ha sido solucionado salimos del bucle, del switch y esperamos otro mensaje
				        MPI_Iprobe(MPI_ANY_SOURCE, MPI_ANY_TAG,MPI_COMM_WORLD, &flag, &status);

                        if(flag!=0){
			                MPI_Recv(mensaje,30, MPI_CHAR, MPI_ANY_SOURCE, MPI_ANY_TAG, MPI_COMM_WORLD, &status);
                            flag=0;
                            if(status.MPI_TAG==1){
                                MPI_Finalize();
					            return 0;
                            }
                        }
                        // Si no ha llegado nada, hacemos rand, crypt y enviamos mensaje cuando encontremos la solución                    
                        sprintf(contrasenia,"%08d",rand()%100000000);
                        intentos++;
                        if (strcmp(crypt(contrasenia,"aa"),mensaje)==0){
                            char buffer[33];
                            char buffer2[33];
                            sprintf(buffer, "%d", iId);
                            // Comprimir datos en cadena mensaje
                            strcpy(mensaje,buffer);
                            strcat(mensaje,"-");
                            sprintf(buffer2, "%lld", intentos);
                            strcat(mensaje,buffer2);
                            strcat(mensaje,"-");
                            strcat(mensaje,contrasenia);
                            MPI_Send(mensaje,30,MPI_CHAR,0,3,MPI_COMM_WORLD);
                            break;
                        }
                    }while (1);
					break;
			}
		}
	}
	return 0;
}
