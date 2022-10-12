using System;
using System.Reflection;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        private static string playerOneName;
        private static string playerTwoName;
        private static string[,] board;     // 2D_Game board
        private static int currentPlayer = 1;// 1 => player 1|| 2 => player 2
        private static int GamingMode = 2;  // 1 = single player || 2 = dual player
        private static int tryLeft = 9;


        static void Main(string[] args)
        {
            do 
            {
                string mode = GetMode();
                if (mode.Equals("Q") || mode.Equals("q"))
                {
                    ByeBye();
                    Environment.Exit(0);
                }
                else if ((Int32.TryParse(mode, out GamingMode)) && (GamingMode == 1 || GamingMode == 2))
                {
                    if (1 == GamingMode)
                    {
                        Console.WriteLine("\n\t[[ * Single Player mode will be available from next update! * ]]");
                        Console.Write("\n\nPress Enter...");
                        Console.ReadKey();
                    }
                    else if (2 == GamingMode)
                    {
                        if (GameIntroDual())
                        {
                            if (!PrintCurrentState())
                            {
                                Console.WriteLine("\n\t___________________\n");
                                Console.WriteLine("\t|   Match Draw!   | ");
                                Console.WriteLine("\t___________________\n");
                            }
                            Console.Write("\n\nPress Enter...");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n\t* Wrong Input! *\n");
                    Console.Write("\n\nPress Enter...");
                    Console.ReadKey();
                }
            } while (true);
        }
        public static string GetMode() 
        {
            Console.Clear();
            
            BoardReset();
            tryLeft = 9;
            currentPlayer = 1;
            PlayerOneName = " ";
            PlayerOneName = " ";
            
            Console.WriteLine("--------------- Tic-Tac-Toe ---------------");
            Console.WriteLine("\n");
            Console.WriteLine("\t<< Gaming Mode >>\n");
            Console.WriteLine("\t 1] Single Player");
            Console.WriteLine("\t 2] Double Player");
            Console.WriteLine("\n\t Q] Exit");
            Console.Write("\n\t>>_ ");
            return Console.ReadLine();
        }
        public static void Congratulate(int player) 
        {
            Console.Clear();
            Console.WriteLine("--------------- Tic-Tac-Toe ---------------");
            Console.WriteLine("\n\t_____________");
            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.WriteLine("\t|   |   |   |");
                Console.WriteLine("\t| {0} | {1} | {2} |", board[row, 0], board[row, 1], board[row, 2]);
                Console.WriteLine("\t|___|___|___|");
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("\t{0} => X", PlayerOneName);
            Console.WriteLine("\n\t{0} => O", PlayerTwoName);
            Console.WriteLine("\n");
            
            if (1 == player) 
            {
                Console.WriteLine("   [[ Congratulations! {0} is Winner ]]", PlayerOneName);  
            }
            else
            {
                Console.WriteLine("   [[ Congratulations! {0} is Winner ]]", PlayerTwoName);
            }
            
            Console.ReadKey();
        }
        public static void BoardReset()
        { 
            board = new string[,]
            {
                { "1", "2", "3"},
                { "4", "5", "6"},
                { "7", "8", "9"},
            };
        }
        public static bool IsOccupied(int row, int col)
        {
            if (board[row, col] == "X" || board[row, col] == "O") 
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
        public static bool IsWin(int player)
        {
            string symbol;
            if (1 == player)
                symbol = "X";
            else
                symbol = "O";
            //Win condition
            //Diagonally matching checking
            if (board[0, 0].Equals(symbol) && board[1, 1].Equals(symbol) && board[2, 2].Equals(symbol))
            {
                return true;
            }
            else if (board[0, 2].Equals(symbol) && board[1, 1].Equals(symbol) && board[2, 0].Equals(symbol))
            {
                return true;
            }
            //Row-wise
            else if (board[0, 0].Equals(symbol) && board[0, 1].Equals(symbol) && board[0, 2].Equals(symbol))
            {
                return true;
            }
            else if (board[1, 0].Equals(symbol) && board[1, 1].Equals(symbol) && board[1, 2].Equals(symbol))
            {
                return true;
            }
            else if (board[2, 0].Equals(symbol) && board[2, 1].Equals(symbol) && board[2, 2].Equals(symbol))
            {
                return true;
            }
            //Column wise
            else if (board[0, 0].Equals(symbol) && board[1, 0].Equals(symbol) && board[2, 0].Equals(symbol))
            {
                return true;
            }
            else if (board[0, 1].Equals(symbol) && board[1, 1].Equals(symbol) && board[2, 1].Equals(symbol))
            {
                return true;
            }
            else if (board[0, 2].Equals(symbol) && board[1, 2].Equals(symbol) && board[2, 2].Equals(symbol))
            {
                return true;
            }
            else
                return false;

        }
        public static bool UpdateBoard(int position, int player)
        {
            int row, column;

            if (position % 3 == 0)
            {
                row = (position / 3) - 1;
                column = 2;
            }
            else
            {
                row = (position / 3);
                column = (position % 3) - 1;
            }
            if (IsOccupied(row, column))
            {
                return false;
            }
            else
            {
                if (player == 1) 
                {
                    board[row, column] = "X";
                    tryLeft -= 1;
                }
                else if (player == 2)
                {
                    board[row, column] = "O";
                    tryLeft -= 1;
                }
                return true;
            }
        }
        public static string PlayerOneName 
        {
            get => playerOneName;
            set => playerOneName = value;  
        }
        public static string PlayerTwoName
        {
            get => playerTwoName;
            set => playerTwoName = value;
        }
        private static bool GameIntroDual()
        {
            Console.Clear();
            Console.WriteLine("--------------- Tic-Tac-Toe ---------------");
            Console.WriteLine("\n");
            
            Console.WriteLine("\tWelcome to the Game!");
            Console.WriteLine("\n\n");
            Console.WriteLine("\tEnter The Player Name(s)");
            Console.WriteLine("\n");
            
            Console.Write("\t>> Player - 1: ");
            PlayerOneName = Console.ReadLine();
            Console.Write("\n\t>> Player - 2: ");
            PlayerTwoName = Console.ReadLine();
            
            Console.WriteLine("\n\n");
            Console.WriteLine("\t{0} => X", PlayerOneName);
            Console.WriteLine("\n\t{0} => O", PlayerTwoName);
            
            Console.WriteLine("\n\n");
            Console.WriteLine("");
            return EnterGame();
        }
        public static void ByeBye()
        {
            Console.Clear();
            Console.WriteLine("--------------- Tic-Tac-Toe ---------------");
            Console.WriteLine("\n");
            Console.WriteLine("\n\tSee you again....... :( \n\n\n");
        }
        public static bool EnterGame() 
        {
            Console.Write("\tNext(y) | Back(n) | Exit(q) >>_ ");
            string choice = Console.ReadLine();
            if (choice == "y" || choice == "Y")
            {
                return true;
            }
            else if (choice == "n" || choice == "N")
            {
                return false;
            }
            else if (choice == "Q" || choice == "q")
            {
                ByeBye();
                Environment.Exit(0);
                return false;
            }
            else
            {
                Console.WriteLine("\n\t* Wrong Input! *\n");
                return EnterGame();
            }
        }
        public static bool TakeYesNo() 
        {
            string choice = Console.ReadLine();
            if (choice == "y" || choice == "Y")
            {
                return true;
            }
            else if (choice == "n" || choice == "N")
            {
                return false;
            }
            else
            {
                Console.WriteLine("\n\t* Wrong Input! *\n");
                return TakeYesNo();
            }
        }
        public static bool PrintCurrentState() 
        {
            Console.Clear();
            Console.WriteLine("--------------- Tic-Tac-Toe ---------------");
            Console.WriteLine("\n\t_____________");
            for (int row = 0; row < 3; row++) 
            {
                Console.WriteLine("\t|   |   |   |");
                Console.WriteLine("\t| {0} | {1} | {2} |", board[row, 0], board[row, 1], board[row, 2]);
                Console.WriteLine("\t|___|___|___|");
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("\t{0} => X", PlayerOneName);
            Console.WriteLine("\n\t{0} => O", PlayerTwoName);
            Console.WriteLine("\n");

            if (tryLeft == 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\t[[ Grab the Position(1-9) | Reset(r) | Exit(q) ]]");
                Console.Write("\n\t {0}'s Turn |>> ", currentPlayer == 1 ? PlayerOneName : PlayerTwoName);
                string choice = Console.ReadLine();
                if (choice == "R" || choice == "r")
                {
                    Console.Write("\t   Reset! Are You Sure?(y/n) >>_ ");
                    if (TakeYesNo())
                    {
                        // Perform board-reset
                        // Game start from the beginning but the players are same
                        BoardReset();
                        tryLeft = 9;
                        currentPlayer = 1;
                    }
                    return (PrintCurrentState());
                }
                else if (choice == "Q" || choice == "q")
                {
                    Console.Write("\t   Quit! Are You Sure?(y/n) >>_ ");
                    if (TakeYesNo())
                    {
                        ByeBye();
                        Environment.Exit(0);
                    }
                    return (PrintCurrentState());
                }
                else if (Int32.TryParse(choice, out int position))
                {
                    if (position >= 1 && position <= 9)
                    {
                        if (UpdateBoard(position, currentPlayer))
                        {
                            if (IsWin(currentPlayer))
                            {
                                Congratulate(currentPlayer);
                                return true;
                            }
                            else
                            {
                                if (currentPlayer == 1)
                                {
                                    currentPlayer = 2;
                                }
                                else if (currentPlayer == 2)
                                {
                                    currentPlayer = 1;
                                }
                                return (PrintCurrentState());
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\t* Position Occupied! *\n");
                            Console.Write("\n\nPress Enter...");
                            Console.ReadKey();
                            return (PrintCurrentState());
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\t* A Single Number Please! *\n");
                        Console.Write("\n\nPress Enter...");
                        Console.ReadKey();
                        return (PrintCurrentState());
                    }
                }
                else
                {
                    Console.WriteLine("\n\t* Wrong Input! *\n");
                    Console.Write("\n\nPress Enter...");
                    Console.ReadKey();
                    return (PrintCurrentState());
                }
            }
        }
    }
}