using boardgame;

namespace chess
{
    internal class Bishop : Piece
    {
        public Bishop(Board Bd, Color color) : base(Bd, color) { }

        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Bd.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Bd.rows, Bd.columns];
            
            Position pos = new Position(0, 0);
            // noroeste
            pos.SetValues(position.row - 1, position.column - 1);
            while (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if(Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row - 1, pos.column - 1);
            }
            // nordeste
            pos.SetValues(position.row - 1, position.column + 1);
            while(Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if(Bd.piece(pos) != null && Bd.piece(pos).color != color){
                    break;
                }
                pos.SetValues(pos.row - 1, pos.column + 1);
            }
            // sudoeste
            pos.SetValues(position.row + 1, position.column - 1);
            while(Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if(Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row + 1, pos.column - 1);
            }
            // sudeste
            pos.SetValues(position.row + 1, position.column + 1);
            while(Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if(Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row + 1, pos.column + 1);
            }
            return mat;
        }
    }
}
