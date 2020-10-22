using System;

namespace Conways_Game_Of_Life {
    class Start {
        static void Main(string[] args) {
            Game game = new Game(10, 20);

            game.SetCell(9, 0);
            game.PrintBoard();
        }
    }
}
