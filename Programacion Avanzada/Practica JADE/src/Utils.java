import jade.content.lang.sl.SLCodec;
import jade.core.AID;
import jade.core.Agent;
import jade.domain.DFService;
import jade.domain.FIPAException;
import jade.domain.FIPAAgentManagement.DFAgentDescription;
import jade.domain.FIPAAgentManagement.Envelope;
import jade.domain.FIPAAgentManagement.SearchConstraints;
import jade.domain.FIPAAgentManagement.ServiceDescription;
import jade.lang.acl.ACLMessage;

import java.io.IOException;
import java.io.Serializable;

public class Utils {
	
	/**
	 * Permite buscar a todos los agentes que implementa un servicio de un tipo dado
	 * @param agent Agente con el que se realiza la b�squeda
	 * @param tipo  Tipo de servidio buscado
	 * @return Listado de agentes que proporciona el servicio
	 */
    public static DFAgentDescription [] buscarAgentes(Agent agent, String tipo){
    	
        //indico las caracter�sticas el tipo de servicio que quiero encontrar
        DFAgentDescription template=new DFAgentDescription();
        ServiceDescription templateSd=new ServiceDescription();
        templateSd.setType(tipo); //como define el tipo el agente coordinador tambien podriamos buscar por nombre
        template.addServices(templateSd);
        
        SearchConstraints sc = new SearchConstraints();
        sc.setMaxResults(Long.MAX_VALUE);
        
        try{
            DFAgentDescription [] results = DFService.search(agent, template, sc);
            
            return results;
            
        }catch(FIPAException e){
        	
            //JOptionPane.showMessageDialog(null, "Agente "+getLocalName()+": "+e.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        	e.printStackTrace();
        }
        
        return null;
    }
    
    /**
	 * Permite buscar a todos los servicios de un agente
	 * @param agent Agente con el que se realiza la b�squeda
	 * @param presidente nombre del agente del que se quieren conocer sus idiomas
	 * @return idiomas Idiomas que habla ese agente
	 */
    
	public static String [] buscarServiciosDeAgente(Agent agent, String presidente){
		
		String [] idiomas= new String [6];
		DFAgentDescription [] espanol=buscarAgentes(agent,"Espa�ol");
		DFAgentDescription [] ingles=buscarAgentes(agent,"Ingl�s");
		DFAgentDescription [] aleman=buscarAgentes(agent,"Alem�n");
		DFAgentDescription [] italiano=buscarAgentes(agent,"Italiano");
		DFAgentDescription [] portugues=buscarAgentes(agent,"Portugu�s");
		DFAgentDescription [] frances=buscarAgentes(agent,"Franc�s");
		
		int i, j=0;
		
		for(i=0;i<idiomas.length;i++) {
			idiomas[i]="vacio";
		}
		
		for(i=0;i<espanol.length;i++) {
			if(espanol[i].getName().getLocalName().equals(presidente)) {
				idiomas[j]="Espa�ol";
				j++;
			}
		}
		for(i=0;i<ingles.length;i++) {
			if(ingles[i].getName().getLocalName().equals(presidente)) {
				idiomas[j]="Ingl�s";
				j++;
			}
		}
		for(i=0;i<aleman.length;i++) {
			if(aleman[i].getName().getLocalName().equals(presidente)) {
				idiomas[j]="Alem�n";
				j++;
			}
		}
		for(i=0;i<italiano.length;i++) {
			if(italiano[i].getName().getLocalName().equals(presidente)) {
				idiomas[j]="Italiano";
				j++;
			}
		}
		for(i=0;i<portugues.length;i++) {
			if(portugues[i].getName().getLocalName().equals(presidente)) {
				idiomas[j]="Portugu�s";
				j++;
			}
		}
		for(i=0;i<frances.length;i++) {
			if(frances[i].getName().getLocalName().equals(presidente)) {
				idiomas[j]="Franc�s";
				j++;
			}
		}
		String [] idiomas_retorno= new String [j];
		for(i=0;i<idiomas.length;i++) {
			if(idiomas[i].equals("vacio")) {
				continue;
			}else {
				idiomas_retorno[i]=idiomas[i];
			}
		}
		
		return idiomas_retorno;
        
    }
    

    /**
     * Env�a un objeto desde el agente indicado a un agente que proporciona un servicio del tipo dado
     * @param agent Agente desde el que se va a enviar el servicio
     * @param agente_E Agente al que se le va a enviar el mensaje
     * @param objeto Mensaje a Enviar
     */
    public static void enviarMensaje(Agent agent, AID agente_E, Object objeto){
    	
      
        try{
            	
            ACLMessage aclMessage = new ACLMessage(ACLMessage.REQUEST);
            	
	        aclMessage.addReceiver(agente_E);
            	
            aclMessage.setOntology("ontologia");
            //el lenguaje que se define para el servicio
            aclMessage.setLanguage(new SLCodec().getName());
            //el mensaje se transmita en XML
            aclMessage.setEnvelope(new Envelope());
			//cambio la codificacion de la carta
			aclMessage.getEnvelope().setPayloadEncoding("ISO8859_1");
            //aclMessage.getEnvelope().setAclRepresentation(FIPANames.ACLCodec.XML); 
        	aclMessage.setContentObject((Serializable)objeto);
        	agent.send(aclMessage);
        		
        }catch(IOException e){
        	
            //JOptionPane.showMessageDialog(null, "Agente "+getLocalName()+": "+e.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
            e.printStackTrace();
        }
    }
    
    /**
     * Traduce una palabra a un idioma
     * @param idioma idioma en el que esta la palabra
     * @param palabra palabra que se quiere traducir
     * @param idioma_Trad idioma al que se desea traducir la palabra
     */
    
    public static String traducir(String idioma, String palabra, String idioma_Trad) {
    	
    	int i;
    	
    	String [] espa�ol= {"Hola","Pa�s","Uni�n","Pol�tico", "Robo","Dinero","Sobres con dinero","Para�so fiscal","Tr�fico de influencias","Indulto", "C�rcerl", "Terrorismo","Bomba","Vacaciones","Financiaci�n ilegal","Hostilidad","Ataque","Armas qu�micas","�Por qu� no te callas?","Pasapalabra","Caf� con leche"};
    	String [] aleman={"Hallo","Land","Einigkeit","Politiker","Raub","Geld","Umschl�ge mit Geld","Steuerparadies","Vetternwirtschaft","Begnadigung","Kerker","Schreckensherrschaft","Pumpe","Urlaub","Illegale Finanzierung","Feindseligkeit","Angriff","Chemische Waffen","Warum verschweigst du nicht?","ASFD","Cafe con leche"};
    	String [] frances={"Salut","Pays","Union","Politique","Vol","Argent","Enveloppe avec de l'argent","Paradis fiscal","Trafic d'influence","Gr�ce","Prison","Terrorisme","Pompe","Vacances","Financement ill�gal","Hostilit�","Attaque","Armes chimiques","Pourquoi ne te tais pas?","ASFD","Cafe con leche"};
    	String [] italiano={"Ciao","Paese","Unione","Politico","Furto","Soldi","Buste con i soldi","Paradiso fiscale","Traffico di influenza","Perdono","Carcere","Terrorismo","Bomba","Vacanze","Finanziamento illegale","Ostilit�","Attacca","Armi chimiche","Perch� non stai zitto?","ASFD","Cafe con leche"};
    	String [] ingles={"Hello","Country","Union","Politician","Robbery","Money","Envelopes with money","Tax haven","Influence peddling","Amnesty","Jail","Terrorism","Bomb","Holidays","Illegal Funding","Hostility","Attack","Chemical weapons","Why don�t you shut up?","ASFD","Cafe con leche"};
    	String [] portugues={"Ol�","Pa�s","Uni�o","Pol�tico","Roubo","Dinheiro","Envelopes com dinheiro","Para�so fiscal","Tr�fico de influ�ncia","Indulto","Indulto","Terrorismo","Bomba","F�rias","Financiamento ilegal","Hostilidade","Ataque","Armas qu�micas","Por que n�o te calas?","ASFD","Cafe con leche"};
    	
    	switch(idioma) {
    	
    		case "Espa�ol":
    			switch(idioma_Trad) {
    	    	
        			case "Ingl�s":
        				for(i=0;i<ingles.length;i++) {
        					if(palabra.equals(espa�ol[i]))
        						return ingles[i];
        				}
        				break;
        			case "Italiano":
        				for(i=0;i<italiano.length;i++) {
        					if(palabra.equals(espa�ol[i]))
        						return italiano[i];
        				}
        				break;
        			case "Franc�s":
        				for(i=0;i<frances.length;i++) {
        					if(palabra.equals(espa�ol[i]))
        						return frances[i];
        				}
        				break;
        			case "Portugu�s":
        				for(i=0;i<portugues.length;i++) {
        					if(palabra.equals(espa�ol[i]))
        						return portugues[i];
        				}
        				break;
        			case "Alem�n":
        				for(i=0;i<aleman.length;i++) {
        					if(palabra.equals(espa�ol[i]))
        						return aleman[i];
        				}
        				break;
    				}
    			break;
    		case "Ingl�s":
    			switch(idioma_Trad) {
    	    	
        			case "Espa�ol":
        				for(i=0;i<espa�ol.length;i++) {
        					if(palabra.equals(ingles[i]))
        						return espa�ol[i];
        				}
        				break;
        			case "Italiano":
        				for(i=0;i<italiano.length;i++) {
        					if(palabra.equals(ingles[i]))
        						return italiano[i];
        				}
        				break;
        			case "Franc�s":
        				for(i=0;i<frances.length;i++) {
        					if(palabra.equals(ingles[i]))
        						return frances[i];
        				}
        				break;
        			case "Portugu�s":
        				for(i=0;i<portugues.length;i++) {
        					if(palabra.equals(ingles[i]))
        						return portugues[i];
        				}
        				break;
        			case "Alem�n":
        				for(i=0;i<aleman.length;i++) {
        					if(palabra.equals(ingles[i]))
        						return aleman[i];
        				}
        				break;
    				}
    			break;
    		case "Italiano":
    			switch(idioma_Trad) {
    	    	
        			case "Espa�ol":
        				for(i=0;i<espa�ol.length;i++) {
        					if(palabra.equals(italiano[i]))
        						return espa�ol[i];
        				}
        				break;
        			case "Ingl�s":
        				for(i=0;i<ingles.length;i++) {
        					if(palabra.equals(italiano[i]))
        						return ingles[i];
        				}
        				break;
        			case "Franc�s":
        				for(i=0;i<frances.length;i++) {
        					if(palabra.equals(italiano[i]))
        						return frances[i];
        				}
        				break;
        			case "Portugu�s":
        				for(i=0;i<portugues.length;i++) {
        					if(palabra.equals(italiano[i]))
        						return portugues[i];
        				}
        				break;
        			case "Alem�n":
        				for(i=0;i<aleman.length;i++) {
        					if(palabra.equals(italiano[i]))
        						return aleman[i];
        				}
        				break;
    				}
    			break;
    		case "Franc�s":
    			switch(idioma_Trad) {
    	    	
        			case "Espa�ol":
        				for(i=0;i<espa�ol.length;i++) {
        					if(palabra.equals(frances[i]))
        						return espa�ol[i];
        				}
        				break;
        			case "Ingl�s":
        				for(i=0;i<ingles.length;i++) {
        					if(palabra.equals(frances[i]))
        						return ingles[i];
        				}
        				break;
        			case "Italiano":
        				for(i=0;i<italiano.length;i++) {
        					if(palabra.equals(frances[i]))
        						return italiano[i];
        				}
        				break;
        			case "Portugu�s":
        				for(i=0;i<portugues.length;i++) {
        					if(palabra.equals(frances[i]))
        						return portugues[i];
        				}
        				break;
        			case "Alem�n":
        				for(i=0;i<aleman.length;i++) {
        					if(palabra.equals(frances[i]))
        						return aleman[i];
        				}
        				break;
    				}
    			break;
    		case "Portugu�s":
    			switch(idioma_Trad) {
    	    	
        			case "Espa�ol":
        				for(i=0;i<espa�ol.length;i++) {
        					if(palabra.equals(portugues[i]))
        						return espa�ol[i];
        				}
        				break;
        			case "Ingl�s":
        				for(i=0;i<ingles.length;i++) {
        					if(palabra.equals(portugues[i]))
        						return ingles[i];
        				}
        				break;
        			case "Italiano":
        				for(i=0;i<italiano.length;i++) {
        					if(palabra.equals(portugues[i]))
        						return italiano[i];
        				}
        				break;
        			case "Franc�s":
        				for(i=0;i<frances.length;i++) {
        					if(palabra.equals(portugues[i]))
        						return frances[i];
        				}
        				break;
        			case "Alem�n":
        				for(i=0;i<aleman.length;i++) {
        					if(palabra.equals(portugues[i]))
        						return aleman[i];
        				}
        				break;
    				}
    			break;
    		case "Alem�n":
    			switch(idioma_Trad) {
    	    	
        			case "Espa�ol":
        				for(i=0;i<espa�ol.length;i++) {
        					if(palabra.equals(aleman[i]))
        						return espa�ol[i];
        				}
        				break;
        			case "Ingl�s":
        				for(i=0;i<ingles.length;i++) {
        					if(palabra.equals(aleman[i]))
        						return ingles[i];
        				}
        				break;
        			case "Italiano":
        				for(i=0;i<italiano.length;i++) {
        					if(palabra.equals(aleman[i]))
        						return italiano[i];
        				}
        				break;
        			case "Franc�s":
        				for(i=0;i<frances.length;i++) {
        					if(palabra.equals(aleman[i]))
        						return frances[i];
        				}
        				break;
        			case "Portugu�s":
        				for(i=0;i<portugues.length;i++) {
        					if(palabra.equals(aleman[i]))
        						return portugues[i];
        				}
        				break;
    			}
    			break;
    			}

    	return "NULL";
    }
    
}