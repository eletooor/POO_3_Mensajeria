using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class miFormulario : Form
    {
        String id;
        String[] users;
        Class1 clase;
        Class2 pdm;
       
        public miFormulario()
        {
            InitializeComponent();
          
        }

        Singleton singletonConeccion = Singleton.obtenerInstancia();


        //BOTON INICIAR
        //conecta con el servidor
        //activa y desactiva botones y timers
        //recibe lista de usuarios
        private void button1_Click(object sender, EventArgs e)
        {
          
            this.clase = new Class1(Singleton.obtenerHost(), Singleton.obtenerPuerto());
            this.pdm=new Class2();
            this.label2.Text = "Conectado..." ;
            this.id = this.clase.Recibir();
            this.textBox1.Text = "Su ID es: " + this.id;
            button_iniciar.Enabled = false;
            button_salir.Enabled = true;
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
        }

        
    

      
        //BOTON ENVIAR
        //verifica destinatario seleccionado
            //recupera destinatario seleccionado
            //envia mensaje al servidor

        private void Button2_Click(object sender, EventArgs e)
        {
            if (this.isCheked())
            {
                String idDestino = this.getIdRadioButton();
                this.clase.Enviar("01" + this.id + idDestino+ this.textBox2.Text);
           
                this.label5.Text = this.clase.Recibir();
                this.pdm.enviarMio(int.Parse(idDestino), this.textBox2.Text);
                this.textBox2.Text = "";
            }
            else
            {
                this.label5.Text = "Seleccione un destinatario";   
            }
        }


        //BOTON SALIR
        //envia informa al servidor
        //activa y desactiva botones y timers
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.offRAdioButton();
            this.clase.Enviar("00");
                this.textBox1.Text = "sesion expirada";
                this.label2.Text = this.clase.Recibir();
            button_iniciar.Enabled = true;
            button_enviar.Enabled = false;
            button_salir.Enabled = false;
            timer1.Enabled = false;
           
            

        }

        //FUNCION QUE LIMPIA EL CHEK DE LOS RADIOBUTTONS
        private void offRAdioButton()
        {
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;
            this.radioButton4.Checked = false;
            this.radioButton5.Checked = false;
            this.radioButton6.Checked = false;
            this.radioButton7.Checked = false;
            this.radioButton8.Checked = false;
            this.radioButton9.Checked = false;
        }

     
        //TEXBOX DEL MENSAJE
        //mensaje escrito
            //activa boton enviar
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                this.label5.Text = "";
                this.button_enviar.Enabled = true;
            }
            else
            {
                this.button_enviar.Enabled = false;
            }
        }

       
        //FUNCION QUE SOLICITA USUARIOS 
        //envia peticion al servidor
        //->devuelve String de usuarios
        public String getausers()
        {
            this.clase.Enviar("02" + this.id);
            return this.clase.Recibir();
        }

        //FUNCION QUE SOLICITA MENSAJES
        //envia peticion al servidor
        //->devuelve String de mensajes
        public String getMessages()
        {
            this.clase.Enviar("03" + this.id);
            return this.clase.Recibir();
        }

        //FUNCION QUE SEPARA USUARIOS DE UN STRING
        //recorre y extrae IDs 
        //->devuelve Vector de IDs (String[])
        public String[] separeUsers(String users)
        {
            String[] usuarios = new string[users.Length / 2];
            int i_us = -1;
            int cont = 0;
            String memory = "";
            for(int i=0; i < users.Length; i++)
            {
                memory += users[i];
                cont++;
                if (cont == 2)
                {
                    i_us++;
                    usuarios[i_us] = memory;
                    memory = "";
                    cont = 0;
                }
            }
            return usuarios;
        }

     
        //FUNCION QUE LISTA USUARIOS CONECTADOS
        //llamada por timer
        //solicita usuarios al servidor
        //verifica estado de radiobuttons
        //cambia propiedades segun corresponda (true/false)
        public void listarUsuarios()
        {
            if (button_salir.Enabled)
            {
                this.radioButton1.Visible = false;
                this.radioButton2.Visible = false;
                this.radioButton3.Visible = false;
                this.radioButton4.Visible = false;
                this.radioButton5.Visible = false;
                this.radioButton6.Visible = false;
                this.radioButton7.Visible = false;
                this.radioButton8.Visible = false;
                this.radioButton9.Visible = false;

               

                switch (this.users.Length)
                {
                    case 9:
                        this.radioButton9.Visible = true;
                        this.radioButton9.Text = "user id: " + this.users[8];
                        goto case 8;
                    case 8:
                        this.radioButton8.Visible = true;
                        this.radioButton8.Text = "user id: " + this.users[7];
                        goto case 7;
                    case 7:
                        this.radioButton7.Visible = true;
                        this.radioButton7.Text = "user id: " + this.users[6];
                        goto case 6;
                    case 6:
                        this.radioButton6.Visible = true;
                        this.radioButton6.Text = "user id: " + this.users[5];
                        goto case 5;
                    case 5:
                        this.radioButton5.Visible = true;
                        this.radioButton5.Text = "user id: " + this.users[4];
                        goto case 4;
                    case 4:
                        this.radioButton4.Visible = true;
                        this.radioButton4.Text = "user id: " + this.users[3];
                        goto case 3;
                    case 3:
                        this.radioButton3.Visible = true;
                        this.radioButton3.Text = "user id: " + this.users[2];
                        goto case 2;
                    case 2:
                        this.radioButton2.Visible = true;
                        this.radioButton2.Text = "user id: "+this.users[1];
                        goto case 1;
                    case 1:
                        this.radioButton1.Visible = true;
                        this.radioButton1.Text = "user id: " + this.users[0];
                        this.label3.Text = "";
                        
                        break;
                    default:
                        this.label3.Text = "No hay usuarios conectados";
                        this.radioButton1.Checked = false;
                        this.radioButton2.Checked = false;
                        this.radioButton3.Checked = false;
                        this.radioButton4.Checked = false;
                        this.radioButton5.Checked = false;
                        this.radioButton6.Checked = false;
                        this.radioButton7.Checked = false;
                        this.radioButton8.Checked = false;
                        this.radioButton9.Checked = false;

                        break;
                }
            }
        }

        //FUNCION QUE OBTIENE EL ID DEL DESTINATARIO SELECCIONADO
        public String getIdRadioButton()
        {
            if (radioButton1.Checked == true)
            {
                return radioButton1.Text.Substring(9);
            }else if (radioButton2.Checked == true)
            {
                return radioButton2.Text.Substring(9);
            }else if (radioButton3.Checked==true)
            {
                return radioButton3.Text.Substring(9);
            }else if (radioButton4.Checked == true)
            {
                return radioButton4.Text.Substring(9);
            }else if (radioButton5.Checked == true)
            {
                return radioButton5.Text.Substring(9);
            }else if (radioButton6.Checked == true)
            {
                return radioButton6.Text.Substring(9);
            }else if (radioButton7.Checked == true)
            {
                return radioButton7.Text.Substring(9);
            }else if (radioButton8.Checked == true)
            {
                return radioButton8.Text.Substring(9);
            }else if (radioButton9.Checked == true)
            {
                return radioButton9.Text.Substring(9);
            }else
            {
                return "%%%%%";
                this.label5.Text = "Mensaje perdido...";
            }
           
        }

        //FUNCION QUE INFORMA SI EXISTE DESTINATARIO SELECCIONADO
        public Boolean isCheked()
        {
            return radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked || radioButton6.Checked || radioButton7.Checked || radioButton8.Checked || radioButton9.Checked;
        }

        
        //TIMER CONTROLA LISTA DE  USUARIOS CONECTADOS
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            String[] userCompare= this.separeUsers(this.getausers());
            if (this.users != null)
            {  
                 for(int i=0; i<this.users.Length; i++)
                {
                    Boolean v = true;
                    for (int j=0; j<userCompare.Length; j++)
                    {
                        if (this.users[i] == userCompare[j])
                        {
                            v = false;
                        }
                    }
                    if (v)
                    {
                        this.pdm.matar(int.Parse(this.users[i]));
                    }
                }
            }



            this.users = userCompare;


            for(int i=0; i<this.users.Length; i++)
            {
                  this.pdm.nacer(int.Parse(this.users[i]));
            }
          
            this.listarUsuarios();
        }

      
        //TIMER CONTROLA BASE DE DATOS DE MENSAJES
        private void timer2_Tick(object sender, EventArgs e)
        {
            String mensajes = this.getMessages();
            this.pdm.enviar(mensajes);
        }

        //TIMER CONTROLA MENSAJE VISUALIZADO
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isCheked())
            {
                int idM = int.Parse(this.getIdRadioButton());
                String mensaje = this.pdm.pedir(idM);
                this.label4.Text = mensaje;
            }

        }

        //DESDE ACA SOLO DECLARACIONES DE COMPONENTES...
        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void miFormulario_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {


        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

   
    }
}

