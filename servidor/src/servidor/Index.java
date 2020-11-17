package servidor;
import java.net.*;

public class Index {
	
	public static void main(String [ ] args)
	{
	int PUERTO=60001; 
	int cantidadUsuarios=10;
	Clients cliOnLine= new Clients(cantidadUsuarios);
	MessageBox messages= new MessageBox(cantidadUsuarios*10);
	
	System.out.println("\n Arranca Servidor");
	ServerSocket socketServidor=null;
	try{
		socketServidor = new ServerSocket(PUERTO);
		}catch(Exception e){
			System.out.println( e.getMessage() );
		}
    while (true){
    	Socket cliente=null;
    	
//    	cliOnLine.cleanClient();
    	cliOnLine.orderClientes();
    	
    	//
    		for(int i=0; i<cliOnLine.getClientes().length; i++) {
    			System.out.println(cliOnLine.getClientes()[i]);
    		}
    	//
    		//
    		for(int i=0; i<cliOnLine.getIdCli().length; i++) {
    			System.out.println(cliOnLine.getIdCli()[i]);
    		}
    	//
    	
    	if(cliOnLine.isLleno()) {
    		System.out.println("\nNo hay vacantes disponibles");
    		
    	}else {
    		
    	try    {
    	 cliente = socketServidor.accept();
    	 }catch(Exception e){
    		 System.out.println( e.getMessage() );
    		 }
    		  
    		  ServidorEscucha nuevoCliente=new ServidorEscucha( cliente);
    		  nuevoCliente.addClientsList(cliOnLine);
    		  Thread hilo = new Thread(nuevoCliente);
    		  
    		  cliOnLine.addCliente(hilo);
    		  nuevoCliente.addId(cliOnLine.getId());
    		  nuevoCliente.addMessageList(messages);
    		  hilo.start(); 
    		  	  
    	}
    	
	} 	
    //socketServidor.close();

	}
}
