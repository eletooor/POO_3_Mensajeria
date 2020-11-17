using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    class Class3
    {
        int id;
        String mensaje;
        public Class3(int id)
        {
            this.id = id;
            this.mensaje = "";
        }

        //getters
        public int getId()
        {
            return this.id;
        }
        public String getMensaje()
        {
            return this.mensaje;
        }

        public void grabar(String mensaje)
        {
            this.mensaje += mensaje;
        }

        public String leer()
        {
            return this.mensaje;
        }

        public void matar(int id)
        {
            this.id = 0;
            this.mensaje = "";
        }
    }
}
