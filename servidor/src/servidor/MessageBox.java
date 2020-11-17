package servidor;

public class MessageBox {
	String [] messages;
	
	public MessageBox(int cantidad) {
		this.messages= new String[cantidad];
	}
	
	public String[] getMessages() {
		return this.messages;
	}
	
	public void addMessage(String message) {
		int i=-1;
		do {
			i++;
		}while(this.getMessages()[i]!=null);
		this.messages[i]= message.substring(2);
	}
	
	public void deleteMessage(int messageD) {
		this.messages[messageD]=null;
	}

	public void orderMessages() {
		int last=this.lastPosition()+1;
		for(int i=0; i<last; i++) {
			for(int j=i+1; j<last; j++) {
				
				if(this.getMessages()[i]==null) {
					if(this.getMessages()[j]!=null) {
						this.getMessages()[i]=this.getMessages()[j];
						this.deleteMessage(j);
						i++;
					}					
				}else {i++;}
			}
		}
	}
	
	public int lastPosition() {
		int position=0;
		for(int i=0;i<this.getMessages().length; i++) {
			if(this.getMessages()[i]!=null) {
				position=i;
			}
		}
		return position;
	}
	
	public String getMessageById(int id) {
		String message;
		String myId=id + "";
		for(int i=0; i<this.getMessages().length; i++) {
			String substring=this.getMessages()[i].substring(0,2 );
			if(Integer.parseInt(substring)==Integer.parseInt(myId)) {
				message= this.getMessages()[i].substring(2);
				return message;
			}
		}
		return "";
	}
	
	public String getAllMyMessages(String id) {
		String mensaje="";
		String aux="";
		for(int i=0; i<this.messages.length;i++) {
			if(this.messages[i]!=null) {
					aux=this.messages[i].substring(2, 4);
					if(Integer.parseInt(aux)==Integer.parseInt(id)){
						mensaje+=this.messages[i].substring(0, 2);
						mensaje+=this.messages[i].substring(4)+":/:";
					}
			}
		
		}
		return mensaje;
	}
	
	public void deleteAllMyMessages(String id) {
		String aux="";
		for(int i=0; i<this.messages.length;i++) {
			if(this.messages[i]!=null) {
				aux=this.messages[i].substring(2, 4);
				if(Integer.parseInt(aux)==Integer.parseInt(id)) {
				this.deleteMessage(i);
				}
			}
			
		}
		this.orderMessages();
	}
	
	public static void main(String[] args) {
		MessageBox f1= new MessageBox(50);
		f1.addMessage("10hola wey1");
		f1.addMessage("20hola wey2");
		f1.addMessage("03hola wey3");
		System.out.println(f1.messages[0]);
		System.out.println(f1.messages[1]);
		System.out.println(f1.messages[2]);
		System.out.println(f1.messages[3]);
		f1.deleteMessage(0);
		System.out.println(f1.messages[0]);
		System.out.println(f1.messages[1]);
		System.out.println(f1.messages[2]);
		System.out.println(f1.messages[3]);
		f1.orderMessages();
		System.out.println(f1.messages[0]);
		System.out.println(f1.messages[1]);
		System.out.println(f1.messages[2]);
		System.out.println(f1.messages[3]);
		String m1=f1.getMessageById(20);
		System.out.println(m1);
		System.out.println(f1.messages[0]);
		System.out.println(f1.messages[1]);
		System.out.println(f1.messages[2]);
		System.out.println(f1.messages[3]);
	}
}
