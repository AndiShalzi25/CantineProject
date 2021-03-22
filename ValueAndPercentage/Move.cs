using System;
using System.Collections.Generic;
using System.Text;

namespace ValueAndPercentage
{
    public class Move : Pawn //Inheritance
    {
        private int targetX;
        private int targetY;

        private int destinationX;
        private int destinationY;

        public Move()
        {
            targetX = 0;
            targetY = 0;
            destinationX = 0;
            destinationY = 0;
            Exit = false;
        }

        public bool Exit { get; set; }
    }
}
