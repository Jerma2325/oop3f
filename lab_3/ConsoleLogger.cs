using System;
namespace ConsoleApp.Logger
{
	public class ConsoleLogger : WriterLogger, ILogger
	{
		public ConsoleLogger()
		{
			writer = Console.Out;
		}

        public override void Dispose()
        {
        }
    }
}

