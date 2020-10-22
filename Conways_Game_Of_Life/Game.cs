using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Conways_Game_Of_Life {
    class Game {
        public int width { get; set; }
        public int height { get; set; }

        private bool[,] board;
        private bool[,] tmpBoard;

        private Dictionary<string, int> states;

        int iterations;

        public Game(int width, int height) {
            this.width = width;
            this.height = height;

            states = new Dictionary<string, int>();
            Init();
        }

        private void Init() {
            board = new bool[height, width];
            ClearBoard();
        }

        public void Start() {
            iterations = 0;

            while (!HasTermianted()) {
                Console.Clear();
                PrintBoard();
                Update();
                Thread.Sleep(250);
                iterations++;
            }
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

        public void SetRandom(int num) {
            int x, y;
            Random rnd = new Random();
            int set = 0;

            while (set < num) {
                x = rnd.Next(0, width);
                y = rnd.Next(0, height);

                if (!board[y, x]) {
                    SetCell(x, y);
                    set++;
                }
            }
        }

        public void Update() {
            int liveCells;
            tmpBoard = new bool[height, width];

            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    liveCells = GetNumberOfLiveNeighbours(j, i);

                    if (board[i, j]) {
                        if (liveCells == 2 || liveCells == 3) {
                            tmpBoard[i, j] = true;
                        }
                    } else {
                        if (liveCells == 3) {
                            tmpBoard[i, j] = true;
                        }
                    }
                }
            }

            board = tmpBoard;
        }

        public int GetNumberOfLiveNeighbours(int i, int j) {
            int liveNeigbours = 0;

            // Up
            if (IsInBounds(i, j - 1)) {
                if (board[j - 1, i]) {
                    liveNeigbours++;
                }
            }

            // Down
            if (IsInBounds(i, j + 1)) {
                if (board[j + 1, i]) {
                    liveNeigbours++;
                }
            }

            // Left
            if (IsInBounds(i - 1, j)) {
                if (board[j, i - 1]) {
                    liveNeigbours++;
                }
            }

            // Right
            if (IsInBounds(i + 1, j)) {
                if (board[j, i + 1]) {
                    liveNeigbours++;
                }
            }

            // Diagonal Up Right
            if (IsInBounds(i + 1, j - 1)) {
                if (board[j - 1, i + 1]) {
                    liveNeigbours++;
                }
            }

            // Diagonal Up left
            if (IsInBounds(i - 1, j - 1)) {
                if (board[j - 1, i - 1]) {
                    liveNeigbours++;
                }
            }

            // Diagonal Deown Left
            if (IsInBounds(i - 1, j + 1)) {
                if (board[j + 1, i - 1]) {
                    liveNeigbours++;
                }
            }

            // Diagonal Down Right
            if (IsInBounds(i + 1, j + 1)) {
                if (board[j + 1, i + 1]) {
                    liveNeigbours++;
                }
            }

            return liveNeigbours;
        }

        public bool HasTermianted() {
            if (states.ContainsKey(string.Join(",", board.Cast<bool>()))) {
                Console.WriteLine($"Terminated becuase duplicate state found on iteration {iterations}, the system is stable");
                return true;
            } else {
                states.Add(string.Join(",", board.Cast<bool>()), iterations);
                return false;
            }
        }
    }
}
