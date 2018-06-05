#include <stdio.h>
#include "test.h"
#include "mpi.h"


void Obten_Nombre_Procesos(int id, int numprocs)
{
	char nombreproc [MPI_MAX_PROCESSOR_NAME];	
	int lnombreproc; 	
	int etiqueta=50;
	MPI_Status status;
	int origen;

	MPI_Get_processor_name(nombreproc,& lnombreproc);
	
	if (id==0)
	{
		fprintf(stdout,"Proceso %d en %s\n", id, nombreproc);
		
		for (origen=1; origen<numprocs;origen++)
		{
			MPI_Recv(nombreproc,MPI_MAX_PROCESSOR_NAME, MPI_CHAR, MPI_ANY_SOURCE, MPI_ANY_TAG, MPI_COMM_WORLD, &status);
			fprintf(stdout,"Proceso %d en %s\n", status.MPI_SOURCE, nombreproc);
		}
	}
	else
	{
		MPI_Send(nombreproc, MPI_MAX_PROCESSOR_NAME, MPI_CHAR, 0, etiqueta, MPI_COMM_WORLD);
	}
}

void clean_stdin() {
	int c;
	do {
		c=getchar();
	} while(c!='\n');
}

void run_test(int tipo, int iIteraciones, long * vSal, double * tiempos){

	unsigned long x=iIteraciones;
	long long *y=(long long *)vSal;
	double *z=(double *)vSal;
	long double *t=(long double *)vSal;

	switch(tipo){
		case 0:
			tiempos[0]=test_long_add_sub(x,vSal);
			tiempos[1]=test_long_mul_div(x,vSal);
			break;
		case 1:
			tiempos[0]=test_long_long_add_sub(x,y);
			tiempos[1]=test_long_long_mul_div(x,y);
			break;
		case 2:
			tiempos[0]=test_double_add_sub(x,z);
			tiempos[1]=test_double_mul_div(x,z);
			break;
		case 3:
			tiempos[0]=test_long_double_add_sub(x,t);
			tiempos[1]=test_long_double_mul_div(x,t);
			break;
	}

	tiempos[2] = (double) *vSal;
}


int main (int argc, char **argv){

	int iId;
	int iNumProcs;

	long iIteraciones=2000000000,ipp, iteracionesAcumuladas;
	double sumaRestaAcumulado=0, mulDivAcumulado=0; 
	double tiempoIni = 0, tiempoFin = 0;	
	int opc, flag, errn;
	int i;
	long vSal;
	double resultadoTiempos[3];

	MPI_Status status;

	int iEtiqueta=0;
	int dato=0;


	char menu[]="\n\n1) Cambiar iteraciones\n2) Seleccionar test\n3) Salir\nOpción:\n";
	char submenu[] = "\n\n0) Test long\n1) Test long long\n2) Test double\n3) Test long double\nOpción:\n\n";

	
	MPI_Init (&argc ,&argv); 						
	MPI_Comm_rank(MPI_COMM_WORLD,&iId ); 			
	MPI_Comm_size(MPI_COMM_WORLD, & iNumProcs );
	
	Obten_Nombre_Procesos(iId, iNumProcs);

	if(iId==0){	

		printf("\n\nIteraciones por defecto: %d\n\n", iIteraciones);

		// Mandamos las iteraciones
		ipp=iIteraciones/iNumProcs;
		for (i=1;i<iNumProcs;i++)
		{
			MPI_Send(&ipp,1,MPI_LONG,i,0,MPI_COMM_WORLD);	
		}

		while(1){

			do {
				printf("%s", menu);
				scanf("%d",&opc);

				if(opc>3 || opc<0){
					fprintf(stdout,"\nSeleccione una opción válida...\n");
				}
			} while(opc>3 || opc<0);

			switch(opc){
				case 1:
					fprintf(stdout,"\nIntroduzca el número de iteraciones:\n");
					clean_stdin();
					scanf("%d",&iIteraciones);
					ipp=iIteraciones/iNumProcs;	
					for (i=1;i<iNumProcs;i++)
					{
						MPI_Send(&ipp,1,MPI_LONG,i,0,MPI_COMM_WORLD);	
					}

					break;
				case 2:

					do {
						fprintf(stdout,"%s\n",submenu);
						fflush(stdin);
						scanf("%d",&opc);

						if(opc>3 || opc<0){
							fprintf(stdout,"\nSeleccione una opción válida...\n");						
						}
					} while(opc>3 || opc<0);

					tiempoIni = mygettime();
					
					printf("\n\nCALCULANDO.......................\n\n");

					for (i=1;i<iNumProcs;i++)
					{
						MPI_Send(&opc,1,MPI_LONG,i,2,MPI_COMM_WORLD);				
					}

					run_test(dato, ipp, &vSal, resultadoTiempos);
					printf("\nProceso: %d) Iteraciones: %ld, Result: %ld, Tipo +-: %lf, Tipo */: %lf\n", iId, ipp, vSal, resultadoTiempos[0], resultadoTiempos[1]);
					sumaRestaAcumulado += resultadoTiempos[0];
					mulDivAcumulado += resultadoTiempos[1];
					iteracionesAcumuladas += vSal;

					for (i=1;i<iNumProcs;i++)
					{

						do {
							//BUCLE DE SNIFFING
							usleep(20);
							errn=MPI_Iprobe(MPI_ANY_SOURCE, MPI_ANY_TAG,MPI_COMM_WORLD, &flag, &status);

						}while (!flag);

						flag=0;

						MPI_Recv(resultadoTiempos,3, MPI_DOUBLE, i, 3, MPI_COMM_WORLD, &status);
						printf("Proceso: %d) Iteraciones: %ld, Result: %ld, Tipo +-: %lf, Tipo */: %lf\n", i, ipp, vSal, resultadoTiempos[0], resultadoTiempos[1]);
						sumaRestaAcumulado += resultadoTiempos[0];
						mulDivAcumulado += resultadoTiempos[1];
						iteracionesAcumuladas += resultadoTiempos[2];
					}

					tiempoFin = mygettime();

					switch(opc){
						case 0:
							printf("\n\n<-----------------TEST LONG--------------->\n");
							break;
						case 1:
							printf("\n\n<-----------------TEST LONG LONG--------------->\n");
							break;
						case 2:
							printf("\n\n<-----------------TEST DOUBLE--------------->\n");
							break;
						case 3:
							printf("\n\n<-----------------TEST LONG DOUBLE--------------->\n");
							break;
					}

					printf("\nRESULTADO TOTAL\n");
					printf("Iteraciones totales: %ld\n", iIteraciones);
					printf("Resultados totales: %ld\n", iIteraciones + iNumProcs);
					printf("Tiempo Total + y - acumulado: %lf\n", sumaRestaAcumulado);
					printf("Tiempo Total * y / acumulado: %lf\n", mulDivAcumulado);
					printf("Tiempo total: %lf\n", tiempoFin-tiempoIni);
					printf("Iteraciones por segundo: %lf\n", iIteraciones/(tiempoFin-tiempoIni));
					break;
				case 3:
					for (i=1;i<iNumProcs;i++)
					{
						MPI_Send(&ipp,1,MPI_LONG,i,1,MPI_COMM_WORLD);				
					}
					MPI_Finalize();
					return 0;
					break;
				default:
					printf("error\n");
					break;
			}

		}
		
	}else{
		while(1){

			do {
				//BUCLE DE SNIFFING
				usleep(20);
				errn=MPI_Iprobe(MPI_ANY_SOURCE, MPI_ANY_TAG,MPI_COMM_WORLD, &flag, &status);

			}while (!flag);

			flag=0;

			MPI_Recv(&dato,1, MPI_LONG, MPI_ANY_SOURCE, MPI_ANY_TAG, MPI_COMM_WORLD, &status);

			switch(status.MPI_TAG){
				case 0:
					iIteraciones=dato;
					break;
				case 1:
					MPI_Finalize();
					return 0;
					break;					
				case 2:			
					run_test(dato, iIteraciones, &vSal, resultadoTiempos);
					MPI_Send(resultadoTiempos,3,MPI_DOUBLE,0,3,MPI_COMM_WORLD);
					break;

			}
		}
	}

	return 0;
}
