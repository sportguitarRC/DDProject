using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Dungeons_And_Dragons_Managements_Server
{
    class DDServer
    {
        private Socket socketBucket;
        private List<Socket> lobby;
        private SocketAsyncEventArgs SAEA;

        public DDServer()
        {

        }

        public void StartListening(int port)
        {
            socketBucket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint theIp = new IPEndPoint(IPAddress.Any, port);

            socketBucket.Bind(theIp);
            socketBucket.Listen(6);

            SAEA.Completed += AcceptConnection;
        }

        private void AcceptConnection(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                Socket socketClient = e.AcceptSocket;
                lobby.Add(socketClient);

                prepareReceive(socketClient);
            }
        }

        private void prepareReceive(Socket socketClient)
        {
            SocketAsyncEventArgs receiveSAEA = new SocketAsyncEventArgs();
            byte[] receivedData = new byte[1024];

            receiveSAEA.Completed += receive;
            receiveSAEA.SetBuffer(receivedData, 0, receivedData.Length);
        }

        private void receive(object sender, SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred != 0)
            {
                //TODO: faire les opérations lors de la réception des données.
            }
            else
            {
                Socket theSocket = (Socket)sender;
                theSocket.Disconnect(false);
                theSocket.Dispose();
            }

            prepareReceive((Socket)sender);
        }

        public void SendToClient(object toSend)
        {
            SocketAsyncEventArgs sendSAEA = new SocketAsyncEventArgs();
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, toSend);
            //A revoir
            //sendSAEA.SetBuffer(bf.ToArray(), 0, bf.ToArray().Length);
        }
    }
}