using boardgame;

namespace chess
{
    class Tower : Piece 
    {
        // Classe 'Torre' que herda da classe 'Peca' o metodo 'PossibleMoves'
        public Tower(Board Bd, Color color) : base(Bd, color) // construtor
        {
        }

        public override string ToString() // metodo para representar a Torre no tabuleiro
        {
            return "T";
        }

        private bool CanMove(Position pos) // verificar se e possivel mover a peca dependendo da posicao
        {
            Piece p = Bd.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] PossibleMoves() // metodo que retorna a matriz(array) com os movimentos possiveis
        {
            bool[,] mat = new bool[Bd.rows, Bd.columns];

            Position pos = new Position(0, 0); // iniciando a variavel

            /*  A peca da torre pode se mover para cima/baixo e esquerda/direitaate o fim do tabuleiro ou ate existir 
             *  uma peca na posicao */

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
