using Tik_Tak_Toe_Game.Controller;
using Tik_Tak_Toe_Game.Presentation;

namespace Tik_Tak_Toe_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager controller = new GameManager(); // Controller for game logic
            GameUi ui = new GameUi(controller);         // UI to handle user interaction

            ui.PlayGame();
        }
    }
}
