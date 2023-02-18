using boardgame;

namespace chess
{
    internal class Queen : Piece
    {
        public Queen(Board bd, Color color) : base(bd, color){ }

        public override string ToString()
        {
            return "D";
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

            // esquerda
            pos.SetValues(position.row, position.column - 1);
            while(Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if(Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row, pos.column - 1);
            }
            // direita
            pos.SetValues(position.row, position.column + 1);
            while (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row, pos.column + 1);
            }
            // acima
            pos.SetValues(position.row - 1, position.column);
            while (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row - 1, pos.column);
            }
            // abaixo
            pos.SetValues(position.row +1, position.column);
            while (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row + 1, pos.column);
            }
            // noroeste
            pos.SetValues(position.row - 1, position.column - 1);
            while (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row - 1, pos.column - 1);
            }
            // nordeste
            pos.SetValues(position.row - 1, position.column + 1);
            while (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row - 1, pos.column + 1);
            }
            // sudeste
            pos.SetValues(position.row + 1, position.column + 1);
            while (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row + 1, pos.column + 1);
            }
            // sudoeste
            pos.SetValues(position.row + 1, position.column - 1);
            while (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.row + 1, pos.column - 1);
            }
            return mat;
        }
    }
}
