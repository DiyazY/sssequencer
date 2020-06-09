using sss;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class ConsoleTracer : ITracer
    {
        public void Error(string msg)
        {
            Console.WriteLine($"Error: {msg}");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"Info: {msg}");
        }

        public void Warn(string msg)
        {
            Console.WriteLine($"Warn: {msg}");
        }
    }
}
