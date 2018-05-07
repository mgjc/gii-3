import java.io.Serializable;
import jade.core.AID;
import jade.core.behaviours.Behaviour;
import jade.lang.acl.ACLMessage;
import jade.lang.acl.MessageTemplate;
import jade.lang.acl.UnreadableException;

public class BehaviourRecibir extends Behaviour {

	private static final long serialVersionUID = 1L;

	@Override
	public void action() {
		
		
		String mensaje_R="";
		String remitente_Men_R="";
		String remitente_Inicial;
		String idioma;
		String palabra;
		String destinatario;
		String idioma_Trad;
		String palabra_Trad="";
		StringBuilder mensaje_A_Enviar=new StringBuilder("");
		StringBuilder mensaje_E=new StringBuilder("");
		AID siguiente_Presidente = null;
		int i;
		//
		//Recibir mensajes
		//
		ACLMessage msg=myAgent.blockingReceive(MessageTemplate.and(MessageTemplate.MatchPerformative(ACLMessage.REQUEST), MessageTemplate.MatchOntology("ontologia")));

		
		// Obtener el mensaje que le ha llegado y su remitente
		try{
			
			mensaje_R=(String)msg.getContentObject();
			remitente_Men_R=msg.getSender().getLocalName();
			
		}catch (UnreadableException e){
			e.printStackTrace();
		}
		
		String [] campos = mensaje_R.split(":");
		// Tendra los siguientes campos: Remitente inicial, el remitente, idioma, palabra, destinatario, nodos por los que pasa el mensaje
		remitente_Inicial=campos[0];
		idioma=campos[2];
		palabra=campos[3];
		destinatario=campos[4];
		
		// Comprobar si se es el destinatario final
		if (destinatario.equals(myAgent.getLocalName())) {
			// Si se es el presidente final muestro el ultimo mensaje
			System.out.println("R "+ myAgent.getLocalName() +" "+ remitente_Inicial + ":"+ remitente_Men_R + ":"+ idioma+":"+palabra+":"+destinatario);
		}else {
			// Se muestra el mensaje de que se ha recibido
			
			System.out.println("R "+ myAgent.getLocalName() +" "+ remitente_Inicial + ":"+ remitente_Men_R + ":"+ idioma+":"+palabra+":"+destinatario);
			
			idioma_Trad=campos[8];
			palabra_Trad=Utils.traducir(idioma, palabra, idioma_Trad);
			
			// Generar datos de envio
			mensaje_E.append(remitente_Inicial);
			mensaje_E.append(":");
			mensaje_E.append(remitente_Men_R);
			mensaje_E.append(":");
			mensaje_E.append(idioma);
			mensaje_E.append(":");
			mensaje_E.append(palabra);
			mensaje_E.append(":");
			mensaje_E.append(idioma_Trad);
			mensaje_E.append(":");
			mensaje_E.append(palabra_Trad);
			mensaje_E.append(":");
			mensaje_E.append(destinatario);
		
			// Mostrar la cadena de envio
			System.out.println("E "+ myAgent.getLocalName() + " "+mensaje_E.toString());

			mensaje_A_Enviar.append(remitente_Inicial);
			mensaje_A_Enviar.append(":");
			mensaje_A_Enviar.append(remitente_Men_R);
			mensaje_A_Enviar.append(":");
			mensaje_A_Enviar.append(idioma_Trad);
			mensaje_A_Enviar.append(":");
			mensaje_A_Enviar.append(palabra_Trad);
			mensaje_A_Enviar.append(":");
			mensaje_A_Enviar.append(destinatario);
			mensaje_A_Enviar.append(":");
		
			i=7;
			
			if(campos.length>i) {
				mensaje_A_Enviar.append(campos[7]);
				mensaje_A_Enviar.append(":");
				mensaje_A_Enviar.append(campos[8]);
				i++;
				i++;
			}
			if(campos.length>i) {
				mensaje_A_Enviar.append(":");
				mensaje_A_Enviar.append(campos[9]);
				mensaje_A_Enviar.append(":");
				mensaje_A_Enviar.append(campos[10]);
				i++;
				i++;
			}
			if(campos.length>i) {
				mensaje_A_Enviar.append(":");
				mensaje_A_Enviar.append(campos[11]);
				mensaje_A_Enviar.append(":");
				mensaje_A_Enviar.append(campos[12]);
				i++;
				i++;
			}
			if(campos.length>i) {
				mensaje_A_Enviar.append(":");
				mensaje_A_Enviar.append(campos[13]);
				mensaje_A_Enviar.append(":");
				mensaje_A_Enviar.append(campos[14]);
				i++;
				i++;
			}
			if(campos.length>i) {
				mensaje_A_Enviar.append(":");
				mensaje_A_Enviar.append(campos[15]);
				mensaje_A_Enviar.append(":");
				mensaje_A_Enviar.append(campos[16]);
				i++;
				i++;
			}
			//
			// Fin de los problemas
			//
			
			siguiente_Presidente=new AID(campos[7], AID.ISLOCALNAME);
			
			// Enviar el mensaje
			Utils.enviarMensaje(myAgent, siguiente_Presidente, (Serializable)mensaje_A_Enviar.toString());
		}
	}

	@Override
	public boolean done() {
		// TODO Auto-generated method stub
		return false;
	}


}
