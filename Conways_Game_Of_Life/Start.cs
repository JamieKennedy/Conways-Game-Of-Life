using System;
using System.Threading;

namespace Conways_Game_Of_Life {
    class Start {
        static void Main(string[] args) {
            Game game = new Game(30, 30);

            game.SetRandom(100);

            game.Start();



        }
    }
}
