using System;
using System.Linq;

namespace TicTacToe
{
    class GameBoard
    {
        public string[] tiles;
        public int[] closedTiles;
        public string winner = "";
        public int playerTurn;
        public int turnCount = 0;

        public GameBoard()
        {
            Setup();
        }

        public void Setup()
        {
            winner = "";
            playerTurn = 0;
            closedTiles = SetTiles();
            tiles = CreateBoard();
        }

        public int[] SetTiles()
        {
            int[] closedTiles = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            return closedTiles;
        }

        public string[] CreateBoard()
        {
            string[] tiles = { "1","2","3","4","5","6","7","8","9" };
            return tiles;
        }

        public void Display()
        {
            for (int i = 0; i < 9; i += 3)
            {
                Console.WriteLine("-------------");
                Console.WriteLine($"| {tiles[i]} | {tiles[i + 1]} | {tiles[i + 2]} |");
            }
            Console.WriteLine("-------------\n\n");
        }

        public void ChangeTurn()
        {
            playerTurn += (playerTurn == 0) ? 1 : -1;
        }

        public bool TileIsOpen(string choice)
        {
            int tile = (int.TryParse(choice, out int number)) ? number : -1;
            if (tile != -1 && !closedTiles.Contains(tile))
            {
                return true;
            }
            return false;
        }

        public void UpdateBoard(int choice)
        {
            string playerToken = (playerTurn == 0) ? "X" : "O";
            tiles[choice] = playerToken;
            closedTiles[turnCount] = choice + 1;
            turnCount++;
        }

        public bool HasWinner(string target)
        {
            if ((tiles[0] == target && tiles[1] == target && tiles[2] == target)
                    || (tiles[3] == target && tiles[4] == target && tiles[5] == target)
                    || (tiles[6] == target && tiles[7] == target && tiles[8] == target)
                    || (tiles[0] == target && tiles[3] == target && tiles[6] == target)
                    || (tiles[1] == target && tiles[4] == target && tiles[7] == target)
                    || (tiles[2] == target && tiles[5] == target && tiles[8] == target)
                    || (tiles[0] == target && tiles[4] == target && tiles[8] == target)
                    || (tiles[2] == target && tiles[4] == target && tiles[6] == target))
            {
                winner = target;
                return true;
            }
            return false;
        }

        public bool IsDraw()
        {
            return turnCount == 9 && (!winner.Equals("X") || !winner.Equals("O"));
        }
    }
}
