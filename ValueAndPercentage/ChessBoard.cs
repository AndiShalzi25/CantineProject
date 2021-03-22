using System;
using System.Collections.Generic;
using System.Text;

namespace ValueAndPercentage
{
    public class ChessBoard
    {
        private string[,] chessBoard;

        public const int DIMMENSION = 8;

        private Pawn pawn;

        private Move move;


        public ChessBoard()
        {
           
            move = new Move();

            chessBoard = new string[DIMMENSION, DIMMENSION];

            ChessBoardHorizontalSymbol = "+---";
            ChessBoardVerticalSymbol = "| "; 

        }

        public string ChessBoardHorizontalSymbol { get; set; }
        public string ChessBoardVerticalSymbol { get; set; }

        public void displayChessBoard()
        {
            //while (!move.Exit)
            //{
                Console.Clear();
                Console.WriteLine("    0   1   2   3   4   5   6   7");

                for(int rows = 0; rows < DIMMENSION; rows++)
                {
                    Console.Write("  ");//left spacing - 2 spaces

                    for(int column = 0; column < DIMMENSION; column++)
                    {
                        Console.WriteLine(ChessBoardHorizontalSymbol);//Write horizontal pattern

                    }
                    Console.Write("+\n");

                    for(int column = 0; column < DIMMENSION; column++)
                    {
                        Console.Write(rows + " ");//y axis header
                        Console.Write(ChessBoardVerticalSymbol + Pawn.pawns[rows,column] + " ");


                    }

                    Console.Write("|\n");
                }
            }
        }
    }
}
