using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    class Class2
    {
        Class3[] usuarios;
        public Class2()
        {
            this.usuarios = new Class3[10];
        }

        public void enviar(String mensajes)
        {
            int length = userLength();
            String[] msjs = this.separeMessages(mensajes);
            for (int i = 0; i < msjs.Length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (int.Parse(msjs[i].Substring(8, 2)) == this.usuarios[j].getId())
                    {
                        this.usuarios[j].grabar(msjs[i]);
                    }
                }
            }
        }

        public void enviarMio(int id, String mensaje)
        {
            int length = this.userLength();
            for (int i = 0; i < length; i++)
            {
                if (this.usuarios[i].getId() == id)
                {
                    this.usuarios[i].grabar("YO:\n"+mensaje+"\n");
                }
            }
        }
        public String pedir(int id)
        {
            for(int i=0; i<usuarios.Length; i++)
            {
                if (usuarios[i].getId() == id)
                {
                    return usuarios[i].getMensaje();
                }
            }
            return "No hay mensajes de éste usuario...";
        }

        public void nacer(int id)
        {
            Boolean v = true;
            for (int i = 0; i < this.usuarios.Length; i++)
            {
                if (this.usuarios[i]!=null && this.usuarios[i].getId()==id)
                {
                    v = false;
                }
            }

            if (v)
            {

                //////////deberia usar un while
                for (int i = 0; i < this.usuarios.Length; i++)
                {
                     if (this.usuarios[i] == null)
                     {
                          this.usuarios[i] = new Class3(id);
                        break;
                     }
                }
            }

          
        }
        public void matar(int id)
        {
            int length = this.userLength();
            for(int i=0; i<length; i++)
            {
                if (usuarios[i].getId() == id)
                {
                    usuarios[i] = null;
                    this.ordenar();
                }
            }
        }

        private void ordenar()
        { 
            for(int i=0; i<usuarios.Length; i++)
            {
                for(int j=i; j < usuarios.Length; j++)
                {
                    if(usuarios[i]==null && usuarios[j] != null)
                    {
                        usuarios[i] = usuarios[j];
                        usuarios[j] = null;
                    }
                }
            }
        }

        private int userLength()
        {
            int count = 0;
            while (this.usuarios[count] != null)
            {
                count++;
            }
            return count;
        }

        //////////////////////////////////////////
        private String[] separeMessages(String messageImput)
        {
            String[] salida = new string[messageImput.Length];
            String unMensaje = "";
            int i_salida = 0;
            for (int i = 0; i < messageImput.Length; i++)
            {
                if (messageImput[i] == ':')
                {
                    if (messageImput[i + 1] == '/')
                    {
                        if (messageImput[i + 2] == ':')
                        {
                            salida[i_salida] = "User ID ";
                            salida[i_salida] += unMensaje.Substring(0,2)+":\n";
                            salida[i_salida] += unMensaje.Substring(2)+"\n";
                            unMensaje = "";

                            if (i + 3 <= messageImput.Length)
                            {
                                i = i + 2;
                                i_salida++;
                            }
                            else
                            {
                                salida = this.truncateListMessages(salida);
                                return salida;
                            }

                        }
                        else
                        {
                            unMensaje += messageImput[i];
                        }
                    }
                    else
                    {
                        unMensaje += messageImput[i];
                    }
                }
                else
                {
                    unMensaje += messageImput[i];
                }
            }
            salida = this.truncateListMessages(salida);
            return salida;
        }

        private String[] truncateListMessages(String[] imput)
        {
            int cont = 0;
            String[] salida;
            for (int i = 0; i < imput.Length; i++)
            {
                if (imput[i] != null)
                {
                    cont++;
                }
            }
            salida = new String[cont];

            for (int i = 0; i < salida.Length; i++)
            {
                salida[i] = imput[i];
            }
            return salida;
        }
    }
}
