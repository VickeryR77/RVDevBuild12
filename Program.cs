using System;

namespace Roshambo
{
    enum Outcomes
    {
        Rock,
        Paper,
        Scissors
    }

    abstract class Player
    {
        public Random rand = new Random();

        public string Name { get; set; }
        public Outcomes RoshamboValue { get; set; }

        public abstract Outcomes GenerateRoshambo();

        public override string ToString() 
        {

            return base.ToString();

        }
        
    }

    class PlayerRock : Player 
    {
        //Always plays Rock

        public PlayerRock()
        {
            Name = "School of Hard Rocks";
            RoshamboValue = GenerateRoshambo();
        }

        public override Outcomes GenerateRoshambo() 
        {
            return RoshamboValue = (Outcomes)0;
        }

        public override string ToString()
        {
            return $"{Name} played {RoshamboValue}!";
        }
    }
    class PlayerCPU : Player 
    {

        public PlayerCPU()
        {
            Name = "Lucky Justice";
            RoshamboValue = GenerateRoshambo();
        }
        //Plays random choice, Rock, Paper, Scissors.
        public override Outcomes GenerateRoshambo() 
        {
            int next = rand.Next(3);
            return RoshamboValue = (Outcomes)next;
        }

        public override string ToString()
        {
            return $"{Name} played {RoshamboValue}!";
        }

    }

    class Human : Player
    {
        //Takes input and assigns a value.
        public Human()
        {
            Name = "Player1";
            RoshamboValue = GenerateRoshambo();
        }
        public override Outcomes GenerateRoshambo() 
        {
            Console.WriteLine("Choose a play!");
            Console.WriteLine("1. Rock");
            Console.WriteLine("2. Paper");
            Console.WriteLine("3. Scissors");

            bool isValid = int.TryParse(Console.ReadLine(), out int next);
            while (!isValid) { Console.WriteLine("Please enter a valid choice. (1-3)"); isValid = int.TryParse(Console.ReadLine(), out next); }
            return RoshamboValue = (Outcomes) next-1;
        }
        public override string ToString()
        {
            return $"{Name} played {RoshamboValue}!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Build();
        }

        public static void Build()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome to ROSHAMBO!");
                Console.WriteLine("Select your opponent:");
                Console.WriteLine("1. School of Hard Rocks");
                Console.WriteLine("2. Lucky Justice");

                bool isValid = int.TryParse(Console.ReadLine(), out int answer);
                while (!isValid || answer < 1 || answer > 2)
                {
                    Console.WriteLine("That is not a valid opponent. (Type 1 or 2)");
                    isValid = int.TryParse(Console.ReadLine(), out answer);
                }

                if(answer == 1)
                {
                    Console.Clear();
                    PlayerRock player = new PlayerRock();
                    Console.WriteLine($"You are facing {player.Name}");
                    Console.WriteLine("");
                    Human player1 = new Human();
                    Console.Clear();
                    Console.WriteLine($"You played {player1.RoshamboValue}");
                    Console.WriteLine($"They played {player.GenerateRoshambo()}");
                    GetWinner(player.RoshamboValue,player1.RoshamboValue);
                }
                if(answer == 2)
                {
                    Console.Clear();
                    PlayerCPU player = new PlayerCPU();
                    Console.WriteLine($"You are facing {player.Name}!");
                    Console.WriteLine("");
                    Human player1 = new Human();
                    Console.Clear();
                    Console.WriteLine($"You played {player1.RoshamboValue}");
                    Console.WriteLine($"They played {player.GenerateRoshambo()}");
                    GetWinner(player.RoshamboValue, player1.RoshamboValue);
                }
            }
        }

        public static void GetWinner(Outcomes CPU, Outcomes Player)
        {
            if (Player == 0 && CPU == 0)
            {
                Console.WriteLine("You tied!");
                Console.WriteLine("Press enter to play again.");
                Console.ReadLine();
                Console.Clear();
            }
            if (Player == 0 && CPU == (Outcomes)1)
            {
                Console.WriteLine("You lost!");
                Console.WriteLine("Press enter to play again.");
                Console.ReadLine();
                Console.Clear();
            }
            if (Player == 0 && CPU == (Outcomes)2)
            {
                Console.WriteLine("You won!!");
                Console.WriteLine("Press enter to play again.");
                Console.ReadLine();
                Console.Clear();
            }
            if (Player == (Outcomes)1 && CPU == 0) //
            {
                Console.WriteLine("You won!!");
                Console.WriteLine("Press enter to play again.");
                Console.ReadLine();
                Console.Clear();
            }
            if (Player == (Outcomes)1 && CPU == (Outcomes)1)
            {
                Console.WriteLine("You tied!");
                Console.WriteLine("Press enter to play again.");
                Console.ReadLine();
                Console.Clear();
            }
            if (Player == (Outcomes)1 && CPU == (Outcomes)2)
            {
                Console.WriteLine("You lost!");
                Console.WriteLine("Press enter to play again.");
                Console.ReadLine();
                Console.Clear();
            }
            if (Player == (Outcomes)2 && CPU == 0) //
            {
                Console.WriteLine("You lost!");
                Console.WriteLine("Press enter to play again.");
                Console.ReadLine();
                Console.Clear();
            }
            if (Player == (Outcomes)2 && CPU == (Outcomes)1)
            {
                Console.WriteLine("You won!!");
                Console.WriteLine("Press enter to play again.");
                Console.ReadLine();
                Console.Clear();
            }
            if (Player == (Outcomes)2 && CPU == (Outcomes)2)
            {
                Console.WriteLine("You tied!");
                Console.WriteLine("Press enter to play again.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
    }

