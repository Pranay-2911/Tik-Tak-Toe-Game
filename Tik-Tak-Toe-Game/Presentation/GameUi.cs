using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tik_Tak_Toe_Game.Controller;

namespace Tik_Tak_Toe_Game.Presentation
{
    internal class GameUi
    {
        private GameManager game;

        public GameUi(GameManager controller)
        {
            game = controller;
        }

        // Main game loop to handle user input and gameplay
        public void PlayGame()
        {
            Console.WriteLine("============= Welcome to Tik-Tak-Toe Game =============");
            bool gameEnded = false;
            PlayGameLoop(ref gameEnded);

            Console.WriteLine("Game over. Would you like to play again? (y/n)\n");
            string response = Console.ReadLine();
            if (response == "y" || response == "Y")
            {
                game.ResetBoard();
                PlayGame();
            }
        }

       
        // While Loop for the All operation
        public void PlayGameLoop(ref bool gameEnded)
        {
            while (!gameEnded)
            {
                Console.WriteLine();
                DisplayBoard();
                Console.WriteLine("Player " + game.GetCurrentPlayer() + "'s turn.");
                int position = 9;
                try
                {

                    Console.Write("Enter your move (position [0-8]): ");
                    position = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (position < 0 || position > 8)
                {
                    Console.WriteLine("Invalid input, Please enter a number between 0 and 8 \n");
                    continue;
                }

                if (game.PlaceMark(position))
                {
                    CheckGameCondition(ref gameEnded);
                    
                }
                else
                {
                    Console.WriteLine("This move is not valid. Try again \n");
                }
               
            }
        }

        // Funtion to check the all condition of the game
        public void CheckGameCondition(ref bool gameEnded)
        {
            if (game.CheckWinner())
            {
                DisplayBoard();
                Console.WriteLine("Player " + game.GetCurrentPlayer() + " wins! \n");
                gameEnded = true;
                return;
            }
            if (game.CheckDraw())
            {
                DisplayBoard();
                Console.WriteLine("The game is a draw!\n");
                gameEnded = true;
                return;
            }
            game.SwitchPlayer(); // Change turn
          
        }

        // Display the board with grid lines
        public void DisplayBoard()
        {
            char[] board = game.GetBoard();
            Console.WriteLine($"  0   1   2 \n" +
                $"0  {board[0]} |  {board[1]} |  {board[2]}\n" +
                $"  -----------\n" +
                $"1  {board[3]} |  {board[4]} |  {board[5]}\n" +
                $"  -----------\n" +
                $"2  {board[6]} |  {board[7]} |  {board[8]}\n");
        }
    }
}
