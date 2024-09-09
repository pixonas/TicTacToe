namespace TicTacToe
{
    internal class Program
    {
        class TicTacToe
        {
            static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };
            static char currentPlayer = 'X';

            static void Main()
            {
                int moves = 0;
                bool gameWon = false;

                while (moves < 9 && !gameWon)
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine($"Player {currentPlayer}, enter your move (1-9): ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int move) && move >= 1 && move <= 9)
                    {
                        if (MakeMove(move))
                        {
                            moves++;
                            gameWon = CheckWin();

                            if (!gameWon)
                            {
                                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move! The cell is already taken.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a number between 1 and 9.");
                        Console.ReadKey();
                    }
                }

                Console.Clear();
                PrintBoard();

                if (gameWon)
                {
                    Console.WriteLine($"Player {currentPlayer} wins!");
                }
                else
                {
                    Console.WriteLine("It's a draw!");
                }
                Console.ReadKey();
            }
            

            static void PrintBoard()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($" {board[i, j]} ");
                        if (j < 2) Console.Write("|");
                    }
                    if (i < 2)
                    {
                        Console.WriteLine("\n---+---+---");
                    }
                }
                Console.WriteLine();
            }

            static bool MakeMove(int move)
            {
                int row = (move - 1) / 3;
                int col = (move - 1) % 3;

                if (board[row, col] != 'X' && board[row, col] != 'O')
                {
                    board[row, col] = currentPlayer;
                    return true;
                }
                return false;
            }

            static bool CheckWin()
            {
                // Check rows and columns
                for (int i = 0; i < 3; i++)
                {
                    if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                        (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                    {
                        return true;
                    }
                }

                // Check diagonals
                if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                    (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
                {
                    return true;
                }

                return false;
            }
           
        }
        

    }
   
}
