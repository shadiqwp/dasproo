//shadiq widi putra 2207112581
using System;
using System.Collections.Generic;

namespace Tebak
{
    class Program
    {
        static int kesempatan = 5;
        static String kataMisteri = "arsenal";
        static List<string> listTebakan = new List<String>{};

        static void Main(string[] args) 
        {
            Intro();
            PlayGame();
            EndGame();
        }

        static void Intro(){ 
             Console.WriteLine("Selamat datang, hari ini kita akan bermain tebak kata");
             Console.WriteLine($"kamu punya {kesempatan} kesempatan untuk menebak kata misteri hari ini");
             Console.WriteLine("Pentunjuknya adalah kata ini merupakan klub sepak bola liga inggris");
             Console.WriteLine($"Kata tersebut terdiri dari {kataMisteri.Length} huruf");
             Console.WriteLine("kata apa yang dimaksud?");
             Console.ReadKey();
             Console.WriteLine();   

        }
        static void PlayGame(){
            while(kesempatan>0){
                Console.Write("Apa huruf tebakanmu?(pilih a-z) : ");
                string input = Console.ReadLine();
                listTebakan.Add(input);
                if(CekJawaban(kataMisteri, listTebakan)){
                    Console.WriteLine("Selamat anda berhasil menebak katanya");
                    Console.WriteLine($"Kata misteri hari ini adalah {kataMisteri}");
                    break;
                }else if(kataMisteri.Contains(input)){
                    Console.WriteLine("Huruf itu ada di dalam kata ini");
                    Console.WriteLine("Silakan tebak huruf lainya...");
                    //menampilkan huruf yang sudah tertebak
                    Console.WriteLine(CekHuruf(kataMisteri, listTebakan));
                }else{
                    Console.WriteLine("Huruf itu tidak ada didalam kata ini");
                    kesempatan--;//kesempatan = kesempatan - 1;
                    Console.WriteLine($"Kesempatan anda tinggal {kesempatan}");
                }

                if (kesempatan == 0){
                    EndGame();
                    break;
                }
            }
        }

        static bool CekJawaban(string kataRahasia,List<string> list){
            bool status = false;
        
            for (int i = 0; i < kataRahasia.Length; i++)
            {
                string c = Convert.ToString(kataRahasia[i]);
                if(list.Contains(c)){
                    status = true;
                }else{
                    return status = false;
                }

            }
            
            return status;
        } 
        static string CekHuruf(string kataRahasia,List<string> list){
            string x = "";

            for (int i = 0; i < kataRahasia.Length; i++)
            {
                string c = Convert.ToString(kataRahasia[i]);
                if(list.Contains(c)){
                    x = x + c;
                }else{
                    x = x + "-";
                }
            }

            return x;
        }

        static void EndGame()
        {
            Console.WriteLine("Bye...");
        }
    }
}
