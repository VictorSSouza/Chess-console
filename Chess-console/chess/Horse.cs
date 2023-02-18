using boardgame;

namespace chess
{
    internal class Horse : Piece
    {
        public Horse(Board bd, Color color) : base(bd, color){ }

        public override string ToString()
        {
            return "C";
        }
        private bool CanMove(Position pos)
        {
            Piece p = Bd.piece(pos);
            return p == null || p.color != this.color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Bd.rows, Bd.columns];

            Position pos = new Position(0,0);

            pos.SetValues(position.row - 1, position.column - 2);
            if(Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row - 2, position.column - 1);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row - 2, position.column + 1);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row - 1, position.column + 2);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row + 1, position.column + 2);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row + 2, position.column + 1);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row + 2, position.column - 1);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row + 1, position.column - 2);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            return mat;
        }
    }
}
