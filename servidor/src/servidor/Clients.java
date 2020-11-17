package servidor;

public class Clients {
	
	private Thread[] clientes;
	private int[] idCli;
	private int id;
	
	public Clients(int cant) {
		this.setClientes(cant);
		this.setIdCli(cant);
		this.setId(9);
	}

	public Thread [] getClientes() {
		return this.clientes;
	}
	public void setClientes(int cant) {
		this.clientes= new Thread[cant];
	}
	public int[] getIdCli() {
		return this.idCli;
	}
	public void setIdCli(int cant) {
		this.idCli= new int[cant];
	}
	public int getId() {
		return this.id;
	}
	public void setId(int id) {
		this.id=id;
	}
	
	public int newId() {
		int x;
		x=this.getId();
		x++;
		this.setId(x);
		return x;
	}
	
	public void addCliente(Thread cliente) {
		int i=0;
		boolean band=true;
		do {
			if(this.clientes[i]==null) {
				this.clientes[i]= cliente;
				this.idCli[i]= this.newId();
				band=!band;
			}
			i++;
		}while (band);
		
	}
	
	public void deleteCliente(int x) {
		for(int j=0; j<this.idCli.length;j++) {
			if(this.idCli[j]==x) {
				this.clientes[j]=null;
				this.idCli[j]=0;
			}
		}
		
	}
	
	public void cleanClient() {
		
		for(int i=0; i<this.clientes.length; i++) {
			if(this.clientes[i]!=null) {
				if(this.clientes[i].isAlive()==false) {
				this.deleteCliente(i);
			}
			}
			
		}
	}
	
	public void orderClientes() {
		for(int i=0; i<this.clientes.length; i++) {
			for(int j=i+1; j<this.clientes.length; j++) {
	//			if((this.clientes[i]==null || !(this.clientes[i].isAlive()) )
		//		&& (this.clientes[j]!=null)) {
				
				if(this.idCli[i]==0
				&& this.idCli[j]!=0) {
					this.clientes[i]= this.clientes[j];
					this.idCli[i]= this.idCli[j];
					this.deleteCliente(j);
					i++;
				}
			}
		}
	}
	
	public boolean isLleno() {
		for(int i=0; i<this.idCli.length; i++) {
			if(this.idCli[i]==0) {
				return false;
			}
		}
		return true;
	}
	
	//programar funcion que devuelve todos los usuarios excepto el solicitante
	public String getUsers(String id) {
		String usuarios="";
		for(int i=0; i<this.idCli.length; i++) {
			if(this.idCli[i]!= Integer.parseInt(id)) {
				if(this.idCli[i]!=0) {
					usuarios+= this.idCli[i]+"";
				}
				
			}
		}
		return usuarios;
	}
}
