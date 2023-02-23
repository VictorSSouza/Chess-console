using boardgame;

namespace chess
{
    internal class Bishop : Piece
    {
        // Classe 'Bispo' que herda da classe 'Peca' o metodo 'PossibleMoves'
        public Bishop(Board Bd, Color color) : base(Bd, color) // construtor
        {
        }

        public override string ToString() // metodo para representar o Bispo no tabuleiro 
        {
            return "B";
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

            /* A peca do bispo e possivel mover nas diagonais ate o fim do tabuleiro ou ate existir uma peca na 
             * posicao */

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
