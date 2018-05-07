import jade.content.lang.sl.SLCodec;
import jade.core.Agent;
import jade.domain.DFService;
import jade.domain.FIPAException;
import jade.domain.FIPAAgentManagement.DFAgentDescription;
import jade.domain.FIPAAgentManagement.ServiceDescription;


public class Agente extends Agent {

	private static final long serialVersionUID = 1L;
	protected Parallel parallel;
	
	
	// Idiomas de los presidentes
	
	private String [] idiomasRajoy	=	{"Español"};
	private String [] idiomasMay	= 	{"Francés", "Portugués"};
	private String [] idiomasMerkel	= 	{"Alemán","Inglés"};
	private String [] idiomasMacron	= 	{"Español","Italiano"};
	private String [] idiomasSergio	= 	{"Francés","Italiano"};
	private String [] idiomasMarcelo= 	{"Alemán","Portugués"};
	
	//Comportamientos
	public void setup(){
		
		int i;
		String [] idiomas=null;
		
		//
		//Registrar servicios
		//
		String nombre=getLocalName();
		
		DFAgentDescription dfd = new DFAgentDescription();
		dfd.setName(getAID());
		ServiceDescription sd;
		
		
		switch(nombre) {
		
		case "Rajoy":
			idiomas= new String [idiomasRajoy.length];
			for(i=0;i<idiomasRajoy.length;i++)
				idiomas[i]=idiomasRajoy[i];
			break;
		case "Merkel":
			idiomas= new String [idiomasMerkel.length];
			for(i=0;i<idiomasMerkel.length;i++)
				idiomas[i]=idiomasMerkel[i];
			break;
		case "May":
			idiomas= new String [idiomasMay.length];
			for(i=0;i<idiomasMay.length;i++)
				idiomas[i]=idiomasMay[i];
			break;
		case "Sergio":
			idiomas= new String [idiomasSergio.length];
			for(i=0;i<idiomasSergio.length;i++)
				idiomas[i]=idiomasSergio[i];
			break;
		case "Macron":
			idiomas= new String [idiomasMacron.length];
			for(i=0;i<idiomasMacron.length;i++)
				idiomas[i]=idiomasMacron[i];
			break;
		case "Marcelo":
			idiomas= new String [idiomasMarcelo.length];
			for(i=0;i<idiomasMarcelo.length;i++)
				idiomas[i]=idiomasMarcelo[i];
			break;
			
		}
		
		// Bucle metiendo los idiomas del presidente
		
		for(i=0;i<idiomas.length;i++) {
			
			sd= new ServiceDescription();
			//El nombre sera el de cada presidente
			sd.setName(nombre);
			//El tipo sean los idiomas que habla cada presidente
			sd.setType(idiomas[i]);
			//La ontologia no se va a usar en este caso
			sd.addOntologies("Ontologia");
	
			sd.addLanguages(new SLCodec().getName());
			//añadimos el servicio al agente
			dfd.addServices(sd);
			//guardamos los servicios que da el agente
		}
		
		
		try{
			DFService.register(this,dfd);
			
		}catch(FIPAException e){
			System.err.println("Agente "+getLocalName()+": "+e.getMessage());
		}
		
		parallel = new Parallel();
		
		this.addBehaviour(parallel);
	}
	
}