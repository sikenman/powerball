using System;
using System.Threading;

namespace ConsolePowerBall
{
    /// <author>Siken Man Singh Dongol</author>
    /// <datecreated>3/20/2017</datecreated>
    /// <summary>Console application to generate 128 set of random PowerBall numbers</summary>
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            UInt16 NO_OF_DRAWS = 128;
            if (args.Length == 1)
            {
                NO_OF_DRAWS = UInt16.Parse(args[0]);
            }

            Console.BackgroundColor = ConsoleColor.Black;

            string startTime = "Start Time: " + DateTime.Now;

            for (int i = 1; i <= NO_OF_DRAWS; i++)
            {
                PowerBall p = new PowerBall();

                // Generate 5 unique white balls
                for (int j = 1; j <= 5;)
                {
                    int no = p.getWhiteNumber();
                    if (no != -1) j++;
                }

                // Generate 1 RED ball
                p.getPowerBall();

                //Console.SetCursorPosition(5, 5);
                // Sort Array
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(i.ToString().PadLeft(3) + " | ");

                p.sortWhiteBalls();
                p.showWhiteBalls();
                p.showRedBall();

                Thread.Sleep(12);
            }

            Console.WriteLine(startTime);
            Console.WriteLine("End Time: " + DateTime.Now);
            Console.WriteLine("Press any key to close the program.");
            Console.ReadKey();
        }
    }

    class PowerBall
    {
        private static int powerRed;
        private static int[] powerWhite = new int[5];

        private static int counter;

        public PowerBall()
        {
            counter = 0;
            powerRed = 0;
        }

        public int getWhiteNumber()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            int number = rnd.Next(1, 70);
            bool R = addWhiteNo(number);

            if (R)
                return number;
            else
                return -1;
        }

        private bool addWhiteNo(int number)
        {
            bool result = true;
            for (int i = 0; i < counter; i++)
            {
                if (number == powerWhite[i])
                {
                    result = false;
                    break;
                }
            }

            // No duplicate found
            if (result)
            {
                powerWhite[counter++] = number;
            }
            return result;
        }

        public int getPowerBall()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            int number = rnd.Next(1, 27);
            powerRed = number;

            return number;
        }

        internal void sortWhiteBalls()
        {
            Array.Sort(powerWhite);
        }

        internal void showWhiteBalls()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int n = 0; n < 5; n++)
            {
                Console.Write(powerWhite[n].ToString().PadLeft(2));
                Console.Write(" ");
            }
        }

        internal void showRedBall()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(powerRed.ToString().PadLeft(2));
        }
    }
}
