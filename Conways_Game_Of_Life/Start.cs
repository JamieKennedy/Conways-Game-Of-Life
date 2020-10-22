using System;
using System.Threading;

namespace Conways_Game_Of_Life {
    class Start {
        static void Main(string[] args) {
            Game game = new Game(30, 30);

            game.ReadBoardFromFile(@"D:\Google Drive\Programming\Conways_Game_Of_Life\Conways_Game_Of_Life\Board.txt", 'O');

            game.Start();



        }
    }
}
