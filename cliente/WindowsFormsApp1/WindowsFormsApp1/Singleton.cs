using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    class Singleton
    {
        private int port;
        private String host;
        private static Singleton instancia = null;


        private Singleton()
        {
            this.setPort(60001);
            this.setHost("localhost");
        }

        private void setPort(int port)
        {
            this.port = port;
        }

        private void setHost(String host)
        {
            this.host = host;
        }

        private static void crearInstancia()
        {
            if (instancia == null)
            {
                instancia = new Singleton();
            }
        }

        public static Singleton obtenerInstancia()
        {
            if (instancia == null) crearInstancia();
            return instancia;
        }
        public static int obtenerPuerto()
        {
            return instancia.port;
        }
        public static String obtenerHost()
        {
            return instancia.host;
        }

    }
}
