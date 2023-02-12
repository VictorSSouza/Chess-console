using boardgame;

namespace chess {
    class Tower : Piece {

        public Tower(Board Bd, Color color) : base(Bd, color) {
        }

        public override string ToString() {
            return "T";
        }

        private bool CanMove(Position pos) {
            Piece p = Bd.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Bd.rows, Bd.columns];

            Position pos = new Position(0, 0);

            // acima
            pos.SetValues(position.row - 1, position.column);
            while (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color) {
                    break;
                }
                pos.row = pos.row - 1;
            }

            // abaixo
            pos.SetValues(position.row + 1, position.column);
            while (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color) {
                    break;
                }
                pos.row = pos.row + 1;
            }

            // direita
            pos.SetValues(position.row, position.column + 1);
            while (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color) {
                    break;
                }
                pos.column = pos.column + 1;
            }

            // esquerda
            pos.SetValues(position.row, position.column - 1);
            while (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (Bd.piece(pos) != null && Bd.piece(pos).color != color) {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return mat;
        }
    }
}
