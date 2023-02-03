using System;
namespace Entities
{
    internal class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] _pieces;
        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            _pieces = new Piece[rows, columns];
        }
        public Piece piece(int row, int column)
        {
            return _pieces[row, column];
        }
    }
}
