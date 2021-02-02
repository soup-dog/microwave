using System;
using System.Threading;

namespace Microwave
{
    class Program
    {
        public const float MS_TO_S = 0.001f;

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("USAGE: microwave <time> [<filename>]\n" +
                    "\nPARAMETERS:\n" +
                    "\ttime (int) - time in form xx:xx or x\n" +
                    "\tfilename (string) - filename");
                Environment.Exit(0);
                return;
            }

            int mDelay = 10; // delay between ms in milliseconds

            string[] timeParts = args[0].Split(":");

            int time; // cook time in seconds

            switch (timeParts.Length)
            {
                case 1:
                    time = int.Parse(timeParts[0]);
                    break;
                case 2:
                    time = int.Parse(timeParts[0]) * 60 + int.Parse(timeParts[1]);
                    break;
                default:
                    Console.WriteLine("Too many elements in cooking time. Cooking time should be in the form xx:xx or x.");
                    Environment.Exit(0);
                    return;
            }

            Console.WriteLine(Properties.Resources.Microwave);

            Console.Write("microwave: ");

            for (int i = 0; i < time / (mDelay * MS_TO_S); i++)
            {
                Console.Write("m");
                Thread.Sleep(mDelay);
            }

            Console.Write("\n");

            Console.Write("microwave: ");

            while (!Console.KeyAvailable)
            {
                Console.Write("BEEP ");
                Console.Beep();
                Thread.Sleep(1000);
            }

            Console.Write("\n");
        }
    }
}
