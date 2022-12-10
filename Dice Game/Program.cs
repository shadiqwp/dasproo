//Shadiq Widi Putra 2207112581
using System;

namespace Dice_Game
{
    class Program
    {
        static void Main(string[] args)
        {
                int playerRandomNum;
                int computernum;
                int playerpoint = 0;
                int compoint = 0;
            
                Random random = new Random();

                for (int i = 0; i < 10; i++)
                {
                Console.WriteLine("Tekan apa saja untuk melempar dadu.");
                Console.ReadKey();

                playerRandomNum = random.Next(1,7);
                Console.WriteLine("Angka dadu anda :" +playerRandomNum);

                computernum = random.Next(1,7);
                Console.WriteLine("Angka dadu komputer :" +computernum);

                if(playerRandomNum > computernum)
                {
                playerpoint++;
                Console.WriteLine("Anda menang di round ini");
                }
                else if(playerRandomNum < computernum)
                {
                compoint++;
                Console.WriteLine("Anda kalah di round ini") ;  
                }
                else
                {
                Console.WriteLine("Anda seri");
                }
                Console.WriteLine("Skor player : " + playerpoint + ". komputer : " + compoint + ".");
                Console.WriteLine();
                }
                if(playerpoint > compoint)
                {
                Console.WriteLine("Kamu Menang!");
                }
                else if(playerpoint < compoint)
                {
                Console.WriteLine("Kamu Kalah!");
                }
                Console.ReadKey();
        }
    }
}
