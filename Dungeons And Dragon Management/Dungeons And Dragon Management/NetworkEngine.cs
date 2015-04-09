using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace Dungeons_And_Dragon_Management
{
    class NetworkEngine
    {
        Socket socketConnection;
        SocketAsyncEventArgs SAEA;

        public NetworkEngine(string ipAdress, int port)
        {
            socketConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipInfo = new IPEndPoint(IPAddress.Parse(ipAdress), port) ;
            SAEA.RemoteEndPoint = ipInfo;
            SAEA = new SocketAsyncEventArgs();
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
