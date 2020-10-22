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
            board = new bool[height, width];
            ClearBoard();
        }

        public void ClearBoard() {
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    board[i, j] = false;
                }
            }
        }

        public void PrintBoard() {
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (board[i, j]) {
                        Console.Write('#');
                    } else {
                        Console.Write('.');
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }

        public void SetCell(int i, int j) {
            if (IsInBounds(i, j)) {
                board[j, i] = true;
            } else {
                Console.WriteLine("Provided coordiantes are not within bounds");
            }
        }

        private bool IsInBounds(int i, int j) {
            if (i >= 0 && i < width) {
                if (j >= 0 && j < height) {
                    return true;
                }
            }

            return false;
        }
    }
}
