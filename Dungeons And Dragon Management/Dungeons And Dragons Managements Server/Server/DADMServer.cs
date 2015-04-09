using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Dungeons_And_Dragons_Managements_Server
{
    class DADMServer
    {
        private Socket socketBucket;
        private List<Socket> lobby;
        private SocketAsyncEventArgs SAEA;

        public DADMServer()
        {

        }

        public void StartListening(int port)
        {
            socketBucket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint theIp = new IPEndPoint(IPAddress.Any, port);

            socketBucket.Bind(theIp);
            socketBucket.Listen(6);

            SAEA.Completed += SAEA_Completed;
        }

        private void SAEA_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                lobby.Add(e.AcceptSocket);
            }
        }
    }
}
