using boardgame;

namespace chess 
{
    class King : Piece 
    {
        // Classe 'Rei' que herda da classe 'Peca' o metodo 'PossibleMoves'
        private ChessMatch match; // variavel da Partida de xadrez
        public King(Board Bd, Color color, ChessMatch match) : base(Bd, color) {
            this.match = match;
        }

        public override string ToString() // metodo para representar o Rei no tabuleiro 
        {
            return "R";
        }

        private bool CanMove(Position pos) // verificar se e possivel mover a peca dependendo da posicao
        {
            Piece p = Bd.piece(pos);
            return p == null || p.color != this.color;
        }
        private bool TowerTestToCastling(Position pos) // metodo que faz um teste para verificar a possibilidade de roque grande ou pequeno
        {
            Piece p = Bd.piece(pos);
            return p != null && p.color == this.color && p.qtyMoviments == 0 && p is Tower;
        }

        public override bool[,] PossibleMoves() // metodo que retorna a matriz(array) com os movimentos possiveis
        {
            bool[,] mat = new bool[Bd.rows, Bd.columns];

            Position pos = new Position(0, 0); // iniciando a variavel

            // A peca do rei pode se mover apenas uma posicao em todas as direcoes do tabuleiro
             

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

            /* :)jogadaEspecial Roque
             * No roque, o rei anda duas posicoes nas colunas em direcao a torre e a torre pula o rei ficando ao seu lado */
            if (qtyMoviments == 0 && !match.Check) // O rei  e a torre nao podem ter se movido e o rei nao pode estar em xeque
            {
                // :)jogadaEspecial Roque pequeno e aquele em que o rei anda em direcao a torre mais proxima
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
                // :)jogadaEspecial Roque grande e aquele que o rei anda em direcao a torre mais distante
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
