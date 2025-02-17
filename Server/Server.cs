﻿using ApplicationLogic;
using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public class Server
    {
        private Socket serverSoket;
        private List<ClientHandler> klijenti;

        public Server()
        {
            serverSoket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            klijenti = new List<ClientHandler>();
        }

        public void Start()
        {
            try
            {
                serverSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
                serverSoket.Listen(5);
                MessageBox.Show("Server je pokrenut!");
            } catch(SocketException)
            {
                throw;
            }
        }

        public void Listen()
        {
            try
            {
                while(true)
                {
                    Socket soket = serverSoket.Accept();

                    ClientHandler handler = new ClientHandler(soket);
                    klijenti.Add(handler);
                    Thread nitKlijent = new Thread(handler.ObradiZahteve);
                    nitKlijent.IsBackground = true;
                    nitKlijent.Start();
                }
                
            } catch(SocketException se)
            {
                Debug.WriteLine(">>>>> " + se.Message);
            }
        }

        public void Stop()
        {
            serverSoket.Dispose();
            Debug.WriteLine("Server je zaustavljen!");

            foreach(ClientHandler c in klijenti)
            {
                c.Stop();
            }
        }

    }
}