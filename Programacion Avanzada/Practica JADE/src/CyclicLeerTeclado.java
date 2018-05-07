import java.io.Serializable;
import java.util.Scanner;

import jade.core.AID;
import jade.core.behaviours.CyclicBehaviour;
import jade.domain.FIPAAgentManagement.DFAgentDescription;


public class CyclicLeerTeclado extends CyclicBehaviour  {

	private static final long serialVersionUID = 1L;

	@Override
	public void action(){
		
		@SuppressWarnings("resource")
		Scanner sc = new Scanner (System.in);
		
		String destinatario="";
		String idioma="";
		String palabra="";
		String idioma_Trad="";
		String palabra_Trad="";
		StringBuilder mensaje_M=new StringBuilder("");
		StringBuilder mensaje_A_Enviar=new StringBuilder("");
		String [] nodos= new String [6];
		AID siguiente_Presidente = null;
		String [] idiomas_Mi_Presidente= new String [6];
		String [] idiomas_Presidente_Interm1;
		String [] idiomas_Presidente_Interm2;
		String [] idiomas_Presidente_Interm3;
		String [] idiomas_Presidente_Interm4;
		String [] idiomas_Presidente_Final;
		String [] idiomas= new String [6];
		DFAgentDescription [] presidentes;
		DFAgentDescription [] presidentes2;
		DFAgentDescription [] presidentes3;
		DFAgentDescription [] presidentes4;
		int flag=0;
		

		System.out.println("En que idioma esta el mensaje?");
		
		idioma=sc.nextLine();
		
		System.out.println("Cual es el mensaje?");

		palabra=sc.nextLine();
		
		System.out.println("Quien recibe el mensaje?");

		destinatario=sc.nextLine();
		
		switch(idioma) {
			case "Español":
				break;
			case "Alemán":
				break;
			case "Portugués":
				break;
			case "Francés":
				break;
			case "Italiano":
				break;
			case "Inglés":
				break;
			default:
				flag=-3;
		}
		

		if(idioma.equals("Alemán"))
			palabra_Trad=Utils.traducir(idioma, palabra, "Español");
		else
			palabra_Trad=Utils.traducir(idioma, palabra, "Alemán");
			
		
		if(palabra_Trad.equals("NULL")) flag=-2;

		switch(destinatario) {
			case "Rajoy":
				if(destinatario.equals(myAgent.getLocalName())) flag=-1;
				break;
			case "Merkel":
				if(destinatario.equals(myAgent.getLocalName())) flag=-1;
				break;
			case "Macron":
				if(destinatario.equals(myAgent.getLocalName())) flag=-1;
				break;
			case "May":
				if(destinatario.equals(myAgent.getLocalName())) flag=-1;
				break;
			case "Sergio":
				if(destinatario.equals(myAgent.getLocalName())) flag=-1;
				break;
			case "Marcelo":
				if(destinatario.equals(myAgent.getLocalName())) flag=-1;
				break;
			default:
				flag=-1;
		}
		
		if(flag<0) {
			switch(flag) {
				case -3:
					System.out.println("Has introducido mal el idioma");
					break;
				case -2:
					System.out.println("Has introducido mal la palabra");
					break;
				case -1:
					System.out.println("Has introducido mal el destinatario o has introducido como destinatario al presidente que envia el mensaje");
					break;
			
			}
		}else {

			idiomas_Mi_Presidente=Utils.buscarServiciosDeAgente(myAgent, myAgent.getLocalName());

			idiomas_Presidente_Final=Utils.buscarServiciosDeAgente(myAgent, destinatario);

		
			if(idiomas_Mi_Presidente.length==0) {
				flag=-1;
				System.out.println("No se puede enviar informacion, el presidente que intenta enviar el mensaje no habla ningun idioma");
			}
			if(idiomas_Presidente_Final.length==0) {
				flag=-1;
				System.out.println("No se puede enviar informacion, el presidente al que se le quiere enviar el mensaje no habla ningun idioma");
			}

			for(int i=0;i<idiomas_Mi_Presidente.length;i++) {
				if(idioma.equals(idiomas_Mi_Presidente[i])) {
					flag=1;
				}
				if(i==idiomas_Mi_Presidente.length-1) {
					if(flag==0) {
						System.out.println("El presidente inicial no habla ese idioma");
						flag=-1;
					}
				}
			}
			
			if(flag!=-1) {
				
				flag=0;
				
				for(int i=0; i<idiomas_Mi_Presidente.length;i++) {
			
					for (int j=0; j<idiomas_Presidente_Final.length;j++) {
						if(idiomas_Mi_Presidente[i].equals(idiomas_Presidente_Final[j])) {
							// Envio directo
							if (idioma.equals(idiomas_Mi_Presidente[i])) {
								
								idioma_Trad=idioma;
								palabra_Trad=palabra;
												
							}else {
						
								idioma_Trad=idiomas_Mi_Presidente[i];
								palabra_Trad=Utils.traducir(idioma, palabra, idioma_Trad);
							}
							nodos[0]=destinatario;
							flag=1;
						}
						if(flag==1)break;
					}
					if(flag==1)break;
				}

				for(int i=0;i<idiomas_Mi_Presidente.length;i++) {
					
					presidentes=Utils.buscarAgentes(myAgent,idiomas_Mi_Presidente[i]);

					if(presidentes!=null) {
						for(int j=0;j<presidentes.length;j++) {
							if(presidentes[j].getName().getLocalName().equals(myAgent.getLocalName())) continue;

							idiomas_Presidente_Interm1=Utils.buscarServiciosDeAgente(myAgent, presidentes[j].getName().getLocalName());
						
							nodos[0]=presidentes[j].getName().getLocalName();
							idiomas[0]=idiomas_Mi_Presidente[i];

							idioma_Trad=idiomas_Mi_Presidente[i];
							palabra_Trad=palabra;
						
							for(int x=0;x<idiomas_Presidente_Interm1.length;x++) {
								for (int y=0;y<idiomas_Presidente_Final.length;y++) {
								
									if(idiomas_Presidente_Interm1[x].equals(idiomas_Presidente_Final[y])) {

										nodos[1]=destinatario;
										idiomas[1]=idiomas_Presidente_Interm1[x];
										flag=1;
									}
									if(flag!=0) break;
								}
								if(flag!=0) break;
							}
							if (flag!=0) break;

							for( int k=0; k<idiomas_Presidente_Interm1.length;k++) {
								presidentes2=Utils.buscarAgentes(myAgent, idiomas_Presidente_Interm1[k]);
							
								if( presidentes2 != null) {
									for (int l=0; l<presidentes2.length;l++) {

										if(presidentes2[l].getName().getLocalName().equals(myAgent.getLocalName())) continue;
										if(presidentes2[l].getName().getLocalName().equals(presidentes[j].getName().getLocalName())) continue;
										idiomas_Presidente_Interm2=Utils.buscarServiciosDeAgente(myAgent, presidentes2[l].getName().getLocalName());
									
										nodos[1]=presidentes2[l].getName().getLocalName();
										idiomas[1]=idiomas_Presidente_Interm1[k];
									
										for (int x=0;x<idiomas_Presidente_Interm2.length;x++) {
											for (int y=0; y<idiomas_Presidente_Final.length;y++) {
												if (idiomas_Presidente_Final[y].equals(idiomas_Presidente_Interm2[x])) {
													nodos[2]=destinatario;
													idiomas[2]=idiomas_Presidente_Interm2[x];
													flag=2;
												}
												if(flag!=0) break;
											}
											if(flag!=0)break;
										}
										if (flag!=0)break;
								
										for(int m =0; m<idiomas_Presidente_Interm2.length;m++) {
											presidentes3=Utils.buscarAgentes(myAgent, idiomas_Presidente_Interm2[m]);
									
											if(presidentes3 != null) {

												for (int n=0; n<presidentes3.length;n++) {
													if(presidentes3[n].getName().getLocalName().equals(myAgent.getLocalName())) continue;
													if(presidentes3[n].getName().getLocalName().equals(presidentes[j].getName().getLocalName())) continue;
													if(presidentes3[n].getName().getLocalName().equals(presidentes2[l].getName().getLocalName())) continue;
											
													idiomas_Presidente_Interm3=Utils.buscarServiciosDeAgente(myAgent, presidentes3[n].getName().getLocalName());
													nodos[2]=presidentes3[n].getName().getLocalName();
													idiomas[2]=idiomas_Presidente_Interm2[m];
											
													for (int x=0;x<idiomas_Presidente_Interm3.length;x++) {
														for (int y=0; y<idiomas_Presidente_Final.length;y++) {
															if (idiomas_Presidente_Final[y].equals(idiomas_Presidente_Interm3[x])) {
																nodos[3]=destinatario;
																idiomas[3]=idiomas_Presidente_Interm3[x];
																flag=3;
															}
															if(flag!=0) break;
														}
														if(flag!=0)break;
													}
													if (flag!=0)break;
																						
													for(int p =0; p<idiomas_Presidente_Interm3.length;p++) {
														presidentes4=Utils.buscarAgentes(myAgent, idiomas_Presidente_Interm3[p]);
											
														if(presidentes4 != null) {

															for (int q=0; q<presidentes3.length;q++) {
																if(presidentes4[q].getName().getLocalName().equals(myAgent.getLocalName())) continue;
																if(presidentes4[q].getName().getLocalName().equals(presidentes[j].getName().getLocalName())) continue;
																if(presidentes4[q].getName().getLocalName().equals(presidentes2[l].getName().getLocalName())) continue;
																if(presidentes4[q].getName().getLocalName().equals(presidentes3[n].getName().getLocalName())) continue;
														
																idiomas_Presidente_Interm4=Utils.buscarServiciosDeAgente(myAgent, presidentes4[q].getName().getLocalName());
																nodos[3]=presidentes4[q].getName().getLocalName();
																idiomas[3]=idiomas_Presidente_Interm3[p];
														
																for (int x=0;x<idiomas_Presidente_Interm4.length;x++) {
																	for (int y=0; y<idiomas_Presidente_Final.length;y++) {
																		if (idiomas_Presidente_Final[y].equals(idiomas_Presidente_Interm4[x])) {
																			nodos[4]=destinatario;
																			idiomas[4]=idiomas_Presidente_Interm4[x];
																			flag=4;
																		}
																		if(flag!=0) break;
																	}
																	if(flag!=0)break;
																}
																if (flag!=0)break;
															}
															if (flag!=0)break;
														}
														if (flag!=0)break;
													}
													if (flag!=0)break;
												}
												if (flag!=0)break;
											}
											if (flag!=0)break;
										}
										if (flag!=0)break;
									}
									if (flag!=0) break;
								}
								if (flag!=0)break;
							}
							if (flag!=0)break;
						}
						if (flag!=0)break;
					}
					if (flag!=0) break;
				}
			
				if(flag!=0) {
					mensaje_M.append(myAgent.getLocalName());
					mensaje_M.append(":");
					mensaje_M.append(idioma);
					mensaje_M.append(":");
					mensaje_M.append(palabra);
					mensaje_M.append(":");
					mensaje_M.append(idioma_Trad);
					mensaje_M.append(":");
					mensaje_M.append(palabra_Trad);
					mensaje_M.append(":");
					mensaje_M.append(destinatario);
		
					System.out.println("E "+ myAgent.getLocalName() + " "+mensaje_M.toString());
		
					mensaje_A_Enviar.append(myAgent.getLocalName());
					mensaje_A_Enviar.append(":");
					mensaje_A_Enviar.append(myAgent.getLocalName());
					mensaje_A_Enviar.append(":");
					mensaje_A_Enviar.append(idioma_Trad);
					mensaje_A_Enviar.append(":");
					mensaje_A_Enviar.append(palabra_Trad);
					mensaje_A_Enviar.append(":");
					mensaje_A_Enviar.append(destinatario);
					mensaje_A_Enviar.append(":");
					for(int i=0;i<flag+1;i++) {
						mensaje_A_Enviar.append(nodos[i]);
						mensaje_A_Enviar.append(":");
						mensaje_A_Enviar.append(idiomas[i]);
						if(i==flag) continue;
						mensaje_A_Enviar.append(":");
					}	
		
					siguiente_Presidente=new AID(nodos[0], AID.ISLOCALNAME);
		
					Utils.enviarMensaje(myAgent, siguiente_Presidente, (Serializable)mensaje_A_Enviar.toString());
				}else {
					System.out.println("No se ha encontrado un camino para enviar el mensaje");
				}
			}
		}
	}
}
