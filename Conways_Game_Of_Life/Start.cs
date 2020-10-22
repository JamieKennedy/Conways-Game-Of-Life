using System;
using System.Threading;

namespace Conways_Game_Of_Life {
    class Start {
        static void Main(string[] args) {
            Game game = new Game(20, 20);

            game.SetRandom(50);

            while (!game.HasTermianted()) {
                Console.Clear();
                game.PrintBoard();
                game.Update();
                Thread.Sleep(300);
            }



        }
    }
}
