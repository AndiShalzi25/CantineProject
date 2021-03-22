using System;
using System.Collections.Generic;
using System.Text;

namespace ValueAndPercentage
{
    public class Pawn
    {
        public const char PAWN_SYMBOL = 'X';

        public const char SPACE = ' ';

        public static char[,] pawns;

        public Pawn()
        {
            pawns = new char[ChessBoard.DIMMENSION, ChessBoard.DIMMENSION];
        }
    }
}
