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
        //Calls GenerateRoshambo upon initialization in main.
        public Human()
        {
            Name = "Player1";
            RoshamboValue = 0;
        }
        public override Outcomes GenerateRoshambo() 
        {
            Console.WriteLine("Choose a play!");
            Console.WriteLine("1. Rock");
            Console.WriteLine("2. Paper");
            Console.WriteLine("3. Scissors");

            bool isValid = int.TryParse(Console.ReadLine(), out int next);
            while (!isValid || next < 1 || next > 3) { Console.WriteLine("Please enter a valid choice. (1-3)"); isValid = int.TryParse(Console.ReadLine(), out next); }
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
                Console.Clear();
                Console.WriteLine("Welcome to ROSHAMBO!");
                Console.WriteLine("Select your opponent:");
                Console.WriteLine("1. School of Hard Rocks");
                Console.WriteLine("2. Lucky Justice");
                Console.WriteLine("0. to quit.");

                bool isValid = int.TryParse(Console.ReadLine(), out int answer);
                while (!isValid || answer < 0 || answer > 2)
                {
                    Console.WriteLine("That is not a valid opponent. (Type 1 or 2)");
                    isValid = int.TryParse(Console.ReadLine(), out answer);
                }

                bool isRunning = true;
                if(answer == 1)
                {
                    while (isRunning)
                    {
                        Console.Clear();
                        PlayerRock cpu = new PlayerRock();
                        Console.WriteLine($"You are facing {cpu.Name}");
                        Console.WriteLine("");
                        Human player1 = new Human();
                        player1.GenerateRoshambo();
                        Console.Clear();
                        Console.WriteLine($"You played {player1.RoshamboValue}");
                        Console.WriteLine($"They played {cpu.GenerateRoshambo()}");
                        GetWinner(cpu.RoshamboValue, player1.RoshamboValue);
                        PlayAgain(out isRunning);
                    }
                }
                if(answer == 2)
                {
                    while (isRunning)
                    {
                        Console.Clear();
                        PlayerCPU cpu = new PlayerCPU();
                        Console.WriteLine($"You are facing {cpu.Name}!");
                        Console.WriteLine("");
                        Human player1 = new Human();
                        player1.GenerateRoshambo();
                        Console.Clear();
                        Console.WriteLine($"You played {player1.RoshamboValue}");
                        Console.WriteLine($"They played {cpu.GenerateRoshambo()}");
                        GetWinner(cpu.RoshamboValue, player1.RoshamboValue);
                        PlayAgain(out isRunning);
                    }
                }
                if(answer == 0)
                {
                    Environment.Exit(1);
                }
            }
        }

        public static void PlayAgain(out bool proceed)
        {
            proceed = true;
            bool running = true;
            while (running)
            {
                Console.WriteLine("Want to play this team again? (Y/N)");
                string entry = Console.ReadLine().ToLower();
                if (entry == "y")
                {
                    proceed = true;
                    break;
                }
                else if (entry == "n")
                {
                    proceed = false;
                    break;
                }
                else
                {
                    proceed = true;
                    continue;
                }
            }
        }

        public static void GetWinner(Outcomes CPU, Outcomes Player)
        {
            if (Player == 0 && CPU == 0)
            {
                Console.WriteLine("You tied!");
                Console.WriteLine("");
            }
            if (Player == 0 && CPU == (Outcomes)1)
            {
                Console.WriteLine("You lost!");
                Console.WriteLine("");
            }
            if (Player == 0 && CPU == (Outcomes)2)
            {
                Console.WriteLine("You won!!");
                Console.WriteLine("");
            }
            if (Player == (Outcomes)1 && CPU == 0) //
            {
                Console.WriteLine("You won!!");
                Console.WriteLine("");
            }
            if (Player == (Outcomes)1 && CPU == (Outcomes)1)
            {
                Console.WriteLine("You tied!");
                Console.WriteLine("");
            }
            if (Player == (Outcomes)1 && CPU == (Outcomes)2)
            {
                Console.WriteLine("You lost!");
                Console.WriteLine("");
            }
            if (Player == (Outcomes)2 && CPU == 0) //
            {
                Console.WriteLine("You lost!");
                Console.WriteLine("");
            }
            if (Player == (Outcomes)2 && CPU == (Outcomes)1)
            {
                Console.WriteLine("You won!!");
                Console.WriteLine("");
            }
            if (Player == (Outcomes)2 && CPU == (Outcomes)2)
            {
                Console.WriteLine("You tied!");
                Console.WriteLine("");
            }
        }
    }
    }

