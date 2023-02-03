using System;
using boardgame;
namespace chess
{
    internal class King : Piece
    {
        public King(Board bd, Color color) : base(bd, color) 
        {
        }
        public override string ToString()
        {
            return "K";
        }
    }
}
