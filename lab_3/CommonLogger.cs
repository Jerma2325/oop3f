using System;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ConsoleApp.Logger
{
	public class CommonLogger : ILogger
		
	{
		private ILogger[] loggers;

		public  CommonLogger(ILogger[] loggers)
		{
			this.loggers = loggers;
		}

		public void Dispose() { }
        

        public void Log(params String[] messages)
		{
            foreach (var logger in loggers)
            {
				logger.Log(messages);
            }
			
		}
		

	}
}

