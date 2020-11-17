using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    class Class1
    {
        TcpClient tcpClient;
        NetworkStream ss;
        StreamReader clientStreamReader;

        public Class1(String host, int port)
        {
           
            tcpClient = new TcpClient();
            tcpClient.Connect(host, port);

            ss = tcpClient.GetStream();
            clientStreamReader = new StreamReader(ss);

        }

        public void Enviar(string S)
        {
            string aEnviar = S + "\n";
            byte[] ss2 = Encoding.ASCII.GetBytes(aEnviar);
            ss.Write(ss2, 0, ss2.Length);

        }

        public string Recibir()
        {
            string recibido = "";
            clientStreamReader.BaseStream.ReadTimeout = 20000;
            recibido = clientStreamReader.ReadLine();
            recibido = clientStreamReader.ReadLine();
            return recibido;
        }


        public void probar()
        {
            string recibido;

            string aEnviar = "abcdefgh\n";
            byte[] ss2 = Encoding.ASCII.GetBytes(aEnviar);

            ss.Write(ss2, 0, ss2.Length);
            recibido = clientStreamReader.ReadLine();
            recibido = clientStreamReader.ReadLine();
            //}
        }


    }
}




   