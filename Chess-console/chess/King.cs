using boardgame;

namespace chess {
    class King : Piece {

        public King(Board bd, Color color) : base(bd, color) {
        }

        public override string ToString() {
            return "R";
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
            if (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // ne
            pos.SetValues(position.row - 1, position.column + 1);
            if (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // direita
            pos.SetValues(position.row, position.column + 1);
            if (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // se
            pos.SetValues(position.row + 1, position.column + 1);
            if (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // abaixo
            pos.SetValues(position.row + 1, position.column);
            if (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // so
            pos.SetValues(position.row + 1, position.column - 1);
            if (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // esquerda
            pos.SetValues(position.row, position.column - 1);
            if (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // no
            pos.SetValues(position.row - 1, position.column - 1);
            if (bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            return mat;
        }
    }
}
