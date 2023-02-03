using System;
using boardgame;
namespace chess
{
    internal class Tower : Piece 
    {
        public Tower(Board bd, Color color) : base(bd, color)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
