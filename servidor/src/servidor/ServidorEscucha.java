package servidor;
import java.net.*;
import java.io.*;
public class ServidorEscucha  implements Runnable
{
Socket elCliente;
DataOutputStream salida;
BufferedReader entrada;
String leido;
Clients clientsList;
MessageBox messageList;
int myId;


 ServidorEscucha(Socket cliente)
	{elCliente=cliente;}


@SuppressWarnings("deprecation")
public void run (){
    System.out.println("\n Entro " + "puerto=" + elCliente.getPort() + " ip=" + elCliente.getRemoteSocketAddress()); 
		   try{
			   salida = new DataOutputStream(elCliente.getOutputStream());
			   salida.writeBytes("\n" +this.clientsList.getId()+"\n");
		   
			   while(true){
				  
				  
				   
				   entrada = new BufferedReader(new InputStreamReader(elCliente.getInputStream()));
				   System.out.print("\nEsperando\n");
				   leido=entrada.readLine();
//	
				
				   switch(leido.substring( 0, 2)) {
				   
				   case "00":	//Cerrar Sesion
					   System.out.println("Entró por 00");
					   System.out.println(this.leido);
					   salida.writeBytes("\nReinicie su sesion para seguir chateando\n");
					   this.clientsList.deleteCliente(myId);
					   elCliente.close();
					  Thread.currentThread().stop();				   
					   break;
					   
				   case "01":	//Enviar Mensaje
					   System.out.println("entró por 01");
					   System.out.println(this.leido);
					   salida.writeBytes("\nEnviado...\n");
					   this.messageList.addMessage(leido);
					  
					   break; 
					   
				   case "02":	//Pedir Usuarios en linea
					   System.out.println("entró por 02");
					   System.out.println(this.leido);
					   salida.writeBytes( "\n"+this.clientsList.getUsers(leido.substring(2))+"\n");
					  
					   
					   break; 
					   
				   case "03":	//Pedir Mensajes
					   System.out.println("entró por 03");
					   System.out.println(this.leido);
					   salida.writeBytes("\n"+this.messageList.getAllMyMessages(leido.substring(2))+"\n");
					   this.messageList.deleteAllMyMessages(leido.substring(2));
					   
					   break;
					   
				   default:
						System.out.println("mensaje no valido");
						 salida.writeBytes("\nError de mensaje\nIngrese el codigo:\n[00tuId] para salir\n[01tuIdsuIdMensaje] para enviar\n[02tuId] para obtener usuarios\n[03suId] para obtener mensajes\n***Por favor! no se desconecte sin cerrar sesion***");
					//	 this.clientsList.deleteCliente(myId);
	//					   elCliente.close();
//							  Thread.currentThread().stop();
					
				   }
			   
				   
			   }
		   }catch(Exception e){
			   System.out.println( e.getMessage() );
		   }
	   } 

public void addMessageList(MessageBox messages) {
	this.messageList= messages;
}

public void addClientsList(Clients list) {
	this.clientsList= list;
}

public void addId(int id) {
	this.myId= id;
}

}
