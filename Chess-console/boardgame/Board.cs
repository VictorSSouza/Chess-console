using System;
namespace boardgame
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
        public Piece piece(Position pos)
        {
            return _pieces[pos.Row, pos.Column];
        }
        public bool ValidPosition(Position pos)
        {
            if(pos.Row < 0|| pos.Row >= rows || pos.Column < 0 || pos.Column >= columns) return false;
            
            return true;
        }
        public void ValidatePosition(Position pos)
        {
            if(!ValidPosition(pos)) throw new BoardException("Invalid position!");
        }
        public bool PieceExists(Position pos)
        {
            ValidatePosition(pos);
            return piece(pos) != null;
        }
        public void PutPiece(Piece p, Position pos)
        {
            if (PieceExists(pos)) throw new BoardException("This piece already exists!");
            _pieces[pos.Row, pos.Column] = p;
            p.position = pos;
        }
    }
}
