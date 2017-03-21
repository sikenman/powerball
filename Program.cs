using System;
using System.Threading;

namespace ConsolePowerBall
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NO_OF_DRAWS = 128;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

            for (int i = 1; i <= NO_OF_DRAWS; i++)
            {
                PowerBall p = new PowerBall();

                // Generate 5 unique white balls
                for (int j = 1; j < 6;)
                {
                    int no = p.getWhiteNumber();
                    if (no != -1) j++;
                }

                // Generate 1 RED ball
                p.getPowerBall();

                // Sort Array
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(i.ToString().PadLeft(3) + " | ");

                p.sortWhiteBalls();
                p.showWhiteBalls();
                p.showRedBall();

            }
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
            Thread.Sleep(7);

            int number = rnd.Next(1, 69);
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
            Thread.Sleep(55);

            int number = rnd.Next(1, 26);
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
