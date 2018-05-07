import jade.core.behaviours.ParallelBehaviour;
import jade.core.behaviours.ThreadedBehaviourFactory;


public class Parallel extends ParallelBehaviour {
	
	private static final long serialVersionUID = 1L;

	public Parallel(){
		// Crear los subcomportamientos
		
		super();
		
		
		// Aqui se van a hacer los comportamientos que sean paralelos
		// Recibir datos ha de ejecutarse y ser bloqueante
		// Solicitar algo por teclado ha de ser bloqueante
		
		
		ThreadedBehaviourFactory tbf = new ThreadedBehaviourFactory();
		//creo un comportamiento para recibir mensajes
		BehaviourRecibir comportamientoRecibir = new BehaviourRecibir();
		//lo añado a mis comportamientos
		this.addSubBehaviour(tbf.wrap(comportamientoRecibir));
		
		CyclicLeerTeclado comportamientoLeer = new CyclicLeerTeclado();
		this.addSubBehaviour(tbf.wrap(comportamientoLeer));
		
	}
}
