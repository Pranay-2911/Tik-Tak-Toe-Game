using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tik_Tak_Toe_Game.Controller
{
    internal class GameManager
    {
        private char[] board; // Array representing the 3x3 grid (9 cells)
        private char currentPlayer;

        public GameManager()
        {
            board = new char[9]; // Initialize the 1D board with 9 cells
            currentPlayer = 'X'; // Player 1 starts as 'X'
            ResetBoard();
        }

        // Resets the game board
        public void ResetBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = ' '; // Empty cells 
            }
        }

        // Places the player's mark on the board
        public bool PlaceMark(int position)
        {
            if (position < 0 || position >= 9 || board[position] != ' ')
            {
                return false;
            }

            board[position] = currentPlayer;
            return true;
        }

        // Check if there's a winner
        public bool CheckWinner()
        {
            return (CheckRows() || CheckColumns() || CheckDiagonals());
        }

        // Check for a draw 
        public bool CheckDraw()
        {
            foreach (var cell in board)
            {
                if (cell == ' ') return false; // Still empty cells, not a draw
            }
            return true; // All cells are filled therefore it a Draw
        }

        // Switch players to X -> O or O -> X
        public void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        // Returns the current player mark X or O
        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public char[] GetBoard()
        {
            return board;
        }

        // To check winning conditions
        public bool CheckRows()
        {
            // Checking rows in the array Which is (0,1,2), (3,4,5), (6,7,8)
            for (int i = 0; i < 9; i += 3)
            {
                if (board[i] == currentPlayer && board[i + 1] == currentPlayer && board[i + 2] == currentPlayer)
                    return true;
            }
            return false;
        }

        public bool CheckColumns()
        {
            // Checking columns in the array which is (0,3,6), (1,4,7), (2,5,8)
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == currentPlayer && board[i + 3] == currentPlayer && board[i + 6] == currentPlayer)
                    return true;
            }
            return false;
        }

        public bool CheckDiagonals()
        {
            // Checking diagonals in the array which is (0,4,8) and (2,4,6)
            if ((board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) ||
                (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer))
                return true;
            return false;
        }
    }
}
