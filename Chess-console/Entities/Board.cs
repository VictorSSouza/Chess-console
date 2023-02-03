using System;
namespace Entities
{
    internal class Board
    {
        public int row { get; set; }
        public int columns { get; set; }
        private Piece[,] _pieces;
        public Board(int row, int columns)
        {
            this.row = row;
            this.columns = columns;
            _pieces = new Piece[row, columns];
        }
    }
}
