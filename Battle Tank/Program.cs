//shadiq widi putra 2207112581
using System;

namespace Battle_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            //variabel
            Console.WriteLine(" Selamat datang, hari ini kita akan bermain permainan Battle Tank");
            Console.WriteLine(" Hancurkan 3 buah tank untuk memenangkan pertandingan");
            Console.WriteLine(" Pilih kordinat X = 1-5 dan Y = 1-5");
            int DessertLength =5;
            char tank = 'T';
            char sand = '~';
            char hit = 'X';
            char miss = 'O';
            char destroyed = 'x';
            int jumlahTank = 3;

            //array 2D
            char[,] Dessert = createDessert(DessertLength, sand, tank, jumlahTank);

            //print array 2d to console
            printDessert(Dessert, sand, tank, destroyed);

            //Total Hidden Tank
            int unknownTankDetected = jumlahTank;

            //GamePlay
            while(unknownTankDetected > 0)
            {
                int[] guessCoordinates = getCoordinateUser(DessertLength);
                char locationViewUpdate = verifGuessAndTarget(guessCoordinates, Dessert, tank, sand, hit, miss, destroyed);

                if (locationViewUpdate == hit)
                {
                    unknownTankDetected--;   
                }
                Dessert = updateDessert(Dessert, guessCoordinates, locationViewUpdate);
                Console.WriteLine("Tank Left :"+unknownTankDetected);
                printDessert(Dessert, sand, tank, destroyed);
            }
            }
            catch(System.FormatException)
            {
                Console.WriteLine(" Tidak bisa memasukan selain angka, permainan berakhir! ");
            }
            
        }
        
        //print Array 2D to Console Screen
        private static void printDessert(char[,] Dessert, char sand, char tank, char destroyed)
        {
            Console.Write("  ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i + 1 + " ");
            }
            Console.WriteLine();
            for (int row = 0; row < 5; row++)
            {
                Console.Write(row + 1 + " ");
                for(int coloumn = 0; coloumn < 5; coloumn++)
                {
                    char position = Dessert[row, coloumn];
                    if(position == tank)
                    {
                        Console.Write(sand + " ");
                    }
                    else
                    {
                        Console.Write(position + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        // check validation user guess
        private static char verifGuessAndTarget(int[] guessCoordinates, char[,] Dessert, char tank, char sand, char hit, char miss, char destroyed)
        {
            string message;
            int row = guessCoordinates[0];
            int coloumn = guessCoordinates[1];
            char target = Dessert[row, coloumn];
            
            if(target == tank)
            {
                Console.WriteLine(" ");
                message = " Good Job You Hit the Tank Sir!";
                Console.WriteLine(" ");
                target = hit;
            }
            else if(target == sand)
            {
                Console.WriteLine(" ");
                message = " Very unfortunate sir, let's try again!";
                Console.WriteLine(" ");
                target = miss;
            }
            else if(target == hit)
            {
                Console.WriteLine(" ");
                message = " This Tank is Already Destroyed! ";
                target = destroyed;
            }
            else
            {
                Console.WriteLine(" ");
                message = " This Area is clear ";
                Console.WriteLine(" ");
            }
            Console.WriteLine(message);
            return target;
        }
        //update array2D view based on player guess result
        private static char[,] updateDessert(char[,] Dessert, int[] guessCoordinates, char locationViewUpdate)
        {
            int row = guessCoordinates[0];
            int coloumn = guessCoordinates[1];
            Dessert[row, coloumn] = locationViewUpdate;
            return Dessert;
        }
        // User Input
        private static int[] getCoordinateUser(int DessertLength)
        {
            int row;
            int coloumn;
            
            do
            {
                Console.WriteLine(" ");
                Console.Write("Coordinate X : ");
                row = Convert.ToInt32(Console.ReadLine());
            }
            while(row<0 || row > DessertLength + 1);

            do
            {
                Console.Write("Coordinate Y: ");
                coloumn = Convert.ToInt32(Console.ReadLine());
            }
            while(coloumn< 0 || coloumn > DessertLength + 1);
            return new[]{row -1, coloumn -1};
        }

        //Array 2D
        private static char[,] createDessert(int DessertLength,char sand, char tank, int jumlahTank)
        {
            char[,] Dessert = new char[DessertLength, DessertLength];
            for (int row = 0; row < DessertLength ; row++)
            {
                for (int coloumn = 0; coloumn < DessertLength ; coloumn++)
                {
                    Dessert[row, coloumn] = sand;
                }
            }
            return placeTanks(Dessert, jumlahTank, sand, tank);
        }
        //place 3 tank to Array 2D
        private static char[,] placeTanks(char[,] Dessert, int jumlahTank, char sand, char tank)
        {
            int tankPlaced = 0;
            int DessertLength = 5;

            while(tankPlaced < jumlahTank)
            {
                int[] tankLocation = generateTankCoordinate(DessertLength);
                char positionOK= Dessert[tankLocation[0], tankLocation[1]];

                if(positionOK == sand)
                {
                    Dessert[tankLocation[0], tankLocation[1]] = tank;
                    tankPlaced++;
                }
            }
            return Dessert;
        }
        // Random position in Array 2D
        private static int[] generateTankCoordinate(int DessertLength)
        {
            Random rnd = new Random();
            int[] coordinates = new int[2];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates [i] = rnd.Next(DessertLength);
            }
            return coordinates;
        }
    }
}
