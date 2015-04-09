using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace Dungeons_And_Dragon_Management
{
    class DDClient
    {
        Socket socketConnection;
        SocketAsyncEventArgs SAEA;

        public DDClient(string ipAdress, int port)
        {
            socketConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipInfo = new IPEndPoint(IPAddress.Parse(ipAdress), port) ;
            SAEA = new SocketAsyncEventArgs();
            SAEA.RemoteEndPoint = ipInfo;
            SAEA.Completed+=new EventHandler<SocketAsyncEventArgs>(SAEA_Completed);
            socketConnection.ConnectAsync(SAEA);
        }

        private void SAEA_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.LastOperation == SocketAsyncOperation.Connect)
            {
                MessageBox.Show("Yééé!");
            }

            if (e.LastOperation == SocketAsyncOperation.Receive)
            {
            }

            if (e.LastOperation == SocketAsyncOperation.Send)
            {
            }
        }

        private void sendToServer(byte[] messageToSend)
        {

        }
    }
}
