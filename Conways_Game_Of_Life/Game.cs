using System;
using System.Collections.Generic;
using System.Text;

namespace Conways_Game_Of_Life {
    class Game {
        public int width { get; set; }
        public int height { get; set; }

        private bool[,] board;

        public Game(int width, int height) {
            this.width = width;
            this.height = height;

            Init();
        }

        private void Init() {
            board = new bool[width, height];
            ClearBoard();
        }

        public void ClearBoard() {
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    board[i, j] = false;
                }
            }
        }

        public void PrintBoard() {
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    if (board[i, j]) {
                        Console.Write('#');
                    } else {
                        Console.Write('.');
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
