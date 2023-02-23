using boardgame;

namespace chess
{
    internal class Horse : Piece
    {
        // Classe 'Cavalo' que herda da classe 'Peca' o metodo 'PossibleMoves'
        public Horse(Board bd, Color color) : base(bd, color) // construtor
        { }

        public override string ToString() // metodo para representar o Cavalo no tabuleiro 
        {
            return "C";
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

            /* A peca do cavalo e possivel mover apenas em formato de 'L', e a unica peca que pode pular sobre outras pecas no tabuleiro sendo aliadas ou não
             * Por exemplo, o cavalo esta na posicao 'd5' e seu destino e 'b6', para conseguir mover a peca a peca anda na coluna duas vezes (c5, e depois b5), independentemente se nessas duas colunas estiver alguma peca, e deve subir uma linha chegando a 'b6' 
             * */

            pos.SetValues(position.row - 1, position.column - 2);
            if(Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row - 2, position.column - 1);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row - 2, position.column + 1);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row - 1, position.column + 2);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row + 1, position.column + 2);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row + 2, position.column + 1);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row + 2, position.column - 1);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            pos.SetValues(position.row + 1, position.column - 2);
            if (Bd.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            return mat;
        }
    }
}
