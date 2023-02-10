using boardgame;

namespace chess {
    class Tower : Piece {

        public Tower(Board bd, Color color) : base(bd, color) {
        }

        public override string ToString() {
            return "T";
        }

        private bool CanMove(Position pos) {
            Piece p = bd.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[bd.rows, bd.columns];

            Position pos = new Position(0, 0);

            // acima
            pos.SetValues(position.row - 1, position.column);
            while (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color) {
                    break;
                }
                pos.row = pos.row - 1;
            }

            // abaixo
            pos.SetValues(position.row + 1, position.column);
            while (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color) {
                    break;
                }
                pos.row = pos.row + 1;
            }

            // direita
            pos.SetValues(position.row, position.column + 1);
            while (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color) {
                    break;
                }
                pos.column = pos.column + 1;
            }

            // esquerda
            pos.SetValues(position.row, position.column - 1);
            while (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color) {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return mat;
        }
    }
}
