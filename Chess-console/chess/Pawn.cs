using boardgame;

namespace chess
{
    internal class Pawn : Piece
    {
        public Pawn(Board bd, Color color) : base(bd, color) { }
        public override string ToString()
        {
            return "P";
        }
        private bool OpponentExist(Position pos)
        {
            Piece p = Bd.piece(pos);
            return p != null && p.color != this.color;
        }
        private bool Free(Position pos)
        {
            return Bd.piece(pos) == null; 
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Bd.rows, Bd.columns];

            Position pos = new Position(0, 0);

            if(color == Color.Branca)
            {
                // acima 1 casa
                pos.SetValues(position.row - 1, position.column);
                if(Bd.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                // acima 2 casas
                pos.SetValues(position.row - 2, position.column);
                Position p2 = new Position(position.row - 1, position.column);
                if (Bd.ValidPosition(p2) && Free(p2) && Bd.ValidPosition(pos) && Free(pos) && qtyMoviments == 0)
                {
                    mat[pos.row, pos.column] = true;
                }

                // diagonal superior para esquerda
                pos.SetValues(position.row - 1, position.column - 1);
                if(Bd.ValidPosition(pos) && OpponentExist(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                // diagonal superior para direita
                pos.SetValues(position.row - 1, position.column + 1);
                if(Bd.ValidPosition(pos) && OpponentExist(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }
            else
            {
                // abaixo 1 casa
                pos.SetValues(position.row + 1, position.column);
                if (Bd.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                // abaixo 2 casas
                pos.SetValues(position.row + 2, position.column);
                Position p2 = new Position(position.row + 1, position.column);
                if (Bd.ValidPosition(p2) && Free(p2) && Bd.ValidPosition(pos) && Free(pos) && qtyMoviments == 0)
                {
                    mat[pos.row, pos.column] = true;
                }

                // diagonal inferior para esquerda
                pos.SetValues(position.row + 1, position.column - 1);
                if (Bd.ValidPosition(pos) && OpponentExist(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                // diagonal inferior para direita
                pos.SetValues(position.row + 1, position.column + 1);
                if (Bd.ValidPosition(pos) && OpponentExist(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
            }

            return mat;
        }
    }
}
