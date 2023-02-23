using boardgame;

namespace chess
{
    internal class Queen : Piece
    {
        // Classe 'Rainha' ou 'Dama' que herda da classe 'Peca' o metodo 'PossibleMoves'
        public Queen(Board bd, Color color) : base(bd, color) // construtor
        { }

        public override string ToString() // metodo para representar a Dama no tabuleiro
        {
            return "D";
        }
        private bool CanMove(Position pos) // verificar se e possivel mover a peca dependendo da posicao
        {
            Piece p = Bd.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] PossibleMoves() // metodo que retorna a matriz(array) com os movimentos possiveis
        {
            bool[,] mat = new bool[Bd.rows, Bd.columns];

            Position pos = new Position(0,0); // iniciando a variavel

            /* A peca da dama e considerada a peca mais poderosa, pode mover quantas casas quiser na horizontal e na vertical (como a torre) e dama também pode mover quantas casas quiser na diagonal (como o bispo). 
             * */

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
