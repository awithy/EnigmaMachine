using System;

namespace Enigma
{
    public class Logger
    {
        private const bool DebugEnabled = false;

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Debug(string message)
        {
            if(DebugEnabled)
                Log(message);
        }
    }
}