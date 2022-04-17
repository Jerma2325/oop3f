using System;
using System.IO;
using System.Text;

namespace ConsoleApp.Logger
{
	 public abstract class WriterLogger :ILogger
	 {
        protected TextWriter writer;


        public virtual void Log(params String[] messages)
        {
            DateTime time = DateTime.Now;

            FileStream stream = new FileStream("file.txt", FileMode.Append);
            
            writer.Write(time + " ");
            foreach (string message in messages)
            {
                writer.Write(message + " ");
            }
            writer.Write("\n");
            writer.Flush();
        }

        public abstract void Dispose();
        
     }
}

