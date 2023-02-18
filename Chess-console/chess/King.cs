using boardgame;

namespace chess {
    class King : Piece {

        private ChessMatch match;
        public King(Board Bd, Color color, ChessMatch match) : base(Bd, color) {
            this.match = match;
        }

        public override string ToString() {
            return "R";
        }

        private bool CanMove(Position pos) {
            Piece p = Bd.piece(pos);
            return p == null || p.color != this.color;
        }
        private bool TowerTestToCastling(Position pos)
        {
            Piece p = Bd.piece(pos);
            return p != null && p.color == this.color && p.qtyMoviments == 0 && p is Tower;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Bd.rows, Bd.columns];

            Position pos = new Position(0, 0);

            // acima
            pos.SetValues(position.row - 1, position.column);
            if (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // nordeste
            pos.SetValues(position.row - 1, position.column + 1);
            if (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // direita
            pos.SetValues(position.row, position.column + 1);
            if (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // sudeste
            pos.SetValues(position.row + 1, position.column + 1);
            if (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // abaixo
            pos.SetValues(position.row + 1, position.column);
            if (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // sudoeste
            pos.SetValues(position.row + 1, position.column - 1);
            if (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // esquerda
            pos.SetValues(position.row, position.column - 1);
            if (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // noroeste
            pos.SetValues(position.row - 1, position.column - 1);
            if (Bd.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            // :) jogada especial Roque
            if(qtyMoviments == 0 && !match.Check)
            {
                // :)jogadaEspecial Roque pequeno
                Position posK1 = new Position(position.row, position.column + 3);
                if (TowerTestToCastling(posK1))
                {
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);
                    if(Bd.piece(p1) == null && Bd.piece(p2) == null)
                    {
                        mat[position.row, position.column + 2] = true;
                    }
                }
                // :)jogadaEspecial Roque grande
                Position posK2 = new Position(position.row, position.column - 4);
                if (TowerTestToCastling(posK2))
                {
                    Position p1 = new Position(position.row, position.column - 1);
                    Position p2 = new Position(position.row, position.column - 2);
                    Position p3 = new Position(position.row, position.column - 3);
                    if (Bd.piece(p1) == null && Bd.piece(p2) == null && Bd.piece(p3) == null)
                    {
                        mat[position.row, position.column - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
