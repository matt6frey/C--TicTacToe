using System;

namespace TicTacToe
{
    class Game
    {
        public string player1Name;
        public int player1Wins = 0;
        public string player1Token = "X";
        public string player2Name;
        public string player2Token = "O";
        public int player2Wins = 0;
        public Game()
        {
            player1Name = GetName(1);
            player2Name = GetName(2);
        }

        public void Play()
        {
            GameBoard Board = new GameBoard();
            string[] players = { player1Name, player2Name };
            string[] tokens = { player1Token, player2Token };

            while (Board.winner.Equals(""))
            {
                Board.Display();
                Console.WriteLine($"It's your turn, Player {players[Board.playerTurn]}");
                Board.UpdateBoard(GetInput(Board));
                Console.Clear();

                foreach (var token in tokens)
                {
                    Board.HasWinner(token);
                }
                Board.ChangeTurn();
                if (Board.IsDraw()) { 
                    Board.winner = "DRAW";
                    Console.WriteLine("It's a draw!");
                }
            }
            if (!Board.IsDraw())
            {
                string winner = (Board.winner.Equals(player1Token)) ? player1Name : player2Name;
                player1Wins += (Board.winner.Equals(player1Token)) ? 1 : 0;
                player2Wins += (Board.winner.Equals(player2Token)) ? 1 : 0;
                AnnounceWinner(winner);
            }
            Board.Setup();
            PlayAgain();
        }

        public int GetInput(GameBoard Board)
        {
            string input = "";
            int number = 0;
            while (input.Equals(""))
            {
                input = Console.ReadLine();
                bool isAcceptable = int.TryParse(input, out number);

                if (number > 9 || !isAcceptable || !Board.TileIsOpen(input))
                {
                    Console.WriteLine((!Board.TileIsOpen(input)) ? "Choose a different number, that tile is chosen.: " : "Please enter a digit from 1 - 9: ");
                    input = "";
                }
            }
            return number - 1;
        }

        public string GetName(int player)
        {
            Console.WriteLine($"Enter Name for Player {player}: ");
            return Console.ReadLine();
        }

        public void AnnounceWinner(string player)
        {
            Console.WriteLine($"\n{player} wins!\n");
        }
        
        public void PlayAgain()
        {
            Console.WriteLine("How about another round? (Y/N)");
            string input = Console.ReadLine().ToUpper();
            if (input.Contains("YES") || input.Equals("Y"))
            {
                Console.Clear();
                Play();
            }
            else
            {
                Console.WriteLine("Thanks for playing!\n");
                Console.WriteLine($"Player {player1Name} wins: {player1Wins}");
                Console.WriteLine($"Player {player2Name} wins: {player2Wins}");
                Console.ReadKey();
            }
        }
    }
}
