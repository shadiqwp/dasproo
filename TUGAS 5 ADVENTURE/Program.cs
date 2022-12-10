//shadiq widi putra (2207112581)
using System;

namespace TUGAS_5_ADVENTURE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to My Advanture Game");
            Console.WriteLine("What is your Name?");
            Novice player = new Novice();
            player.Name = Console.ReadLine();
            Console.WriteLine("Hi " + player.Name + ", ready to begin the game?[y/n]");
            string bReady = Console.ReadLine();
            if (bReady == "y")
            {
                Console.WriteLine(player.Name + " is entering the world...");
                Enemy enemy1 = new Enemy("ButterFly");
                Console.WriteLine(player.Name + " is encountering " + enemy1.Name);
                Console.WriteLine("Choose Your Action : ");
                Console.WriteLine("1. Single Atteck");
                Console.WriteLine("2. Wsing Atteck");
                Console.WriteLine("3. Defend");
                Console.WriteLine("4. Run Away");

                while (!player.IsDead && !enemy1.IsDead)
                {
                    string playerAction = Console.ReadLine();
                    switch (playerAction)
                    {
                        case "1":
                            Console.WriteLine(player.Name + " is doing single attack");
                            enemy1.GetHit(player.AttackPower);
                            player.Experience += 0.3f;
                            enemy1.Attack(enemy1.AttackPower);
                            player.GetHit(enemy1.AttackPower);
                            Console.Write("Player Health : " + player.Health + " | Enemy Health : " + enemy1.Health + "\n");
                            break;
                        case "2":
                            player.Swing();
                            player.Experience += 0.9f;
                            enemy1.GetHit(player.AttackPower);
                            Console.Write("Player Health : " + player.Health + " | Enemy Health : " + enemy1.Health + "\n");
                            break;
                        case "3":
                            player.Rest();
                            Console.WriteLine("Enemy is being restored...");
                            enemy1.Attack(enemy1.AttackPower);
                            player.GetHit(enemy1.AttackPower);
                            break;
                        case "4":
                            Console.WriteLine(player.Name + " is running away...");
                            break;
                    }
                }
                Console.WriteLine(player.Name + " get " + player.Experience + " experience point.");
            }
            else
            {
                Console.WriteLine("Goodbye...");
                Console.Read();
            }
        }
    }
    class Novice
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public int Skillslot { get; set; }
        public bool IsDead { get; set; }
        public float Experience { get; set; }
        Random rng = new Random();

        public Novice()
        {
            Health = 100;
            Skillslot = 0;
            AttackPower = 1;
            IsDead = false;
            Experience = 0f;
            Name = "Newbie";
        }

        public void Swing()
        {
            if (Skillslot > 0)
            {
                Console.WriteLine("SWINGG!!!");
                AttackPower = AttackPower + rng.Next(3, 11);
                Skillslot--;
            }
            else
            {
                Console.WriteLine("You do not have energy!");
            }
        }

        public void GetHit(int hitValue)
        {
            Console.WriteLine(Name + " get hit by " + hitValue);
            Health = Health - hitValue;

            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }

        public void Rest()
        {
            Skillslot = 3;
            AttackPower = 1;
        }

        public void Die()
        {
            Console.WriteLine(Name + " You are dead. Game Over");
            IsDead = true;
        }
    }
    class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public int AttackPower { get; set; }
        public bool IsDead { get; set; }
        Random rng = new Random();

        public Enemy(string name)
        {
            Health = 50;
            Name = name;
        }

        public void Attack(int damage)
        {
            AttackPower = rng.Next(1, 10);
        }

        public void GetHit(int hitValue)
        {
            Console.WriteLine(Name + " get hit by " + hitValue);
            Health = Health - hitValue;

            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }

        public void Die()
        {
            Console.WriteLine(Name + " is dead");
            IsDead = true;
        }
    }
}