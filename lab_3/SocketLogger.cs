using System;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;

namespace ConsoleApp.Logger
{
	public class SocketLogger : ILogger
	{
		private ClientSocket clientSocket;

        public SocketLogger(string host, int port) 
        {
            this.clientSocket =  new ClientSocket(host, port);
            
        }

        ~SocketLogger()
        {
            this.Dispose(false);
        }

        public void Log<TState>(params String[] messages)
        {
            throw new NotImplementedException();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.clientSocket.Dispose();
            }
        }
        
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Log(params string[] messages)
        {
            DateTime time = DateTime.Now;
            String logg = time.ToString() + " ";

            foreach (var message in messages)
            {
                logg += message + " ";

                using (clientSocket)
                {
                    byte[] request = Encoding.UTF8.GetBytes(logg);
                    clientSocket.Send(request);
                    byte[] responceBuffer = new byte[1024];
                    int responceSize = clientSocket.Recive(responceBuffer);
                    String responceText = Encoding.UTF8.GetString(responceBuffer, 0, responceSize);

                    Console.WriteLine(responceText);
                    Console.WriteLine(time + " " + logg+ " socket");
                    clientSocket.Close();
                }
            }
        }
    }
}

