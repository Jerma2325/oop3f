using System;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;

namespace ConsoleApp.Logger;

public class Program
{
    public static void Main()
    {
        ILogger[] loggers = new ILogger[]
        {
            new ConsoleLogger(),
            new FileLogger("log.txt"),
            new SocketLogger("google.com", 80)
        };

        using (ILogger logger = new CommonLogger(loggers))
        {
            logger.Log("Example message 1 ...");
            logger.Log("Example message 2 ...");
            logger.Log("Example message 3 ...", "value 1", "value 2", "value 3");
        }
    }
}
