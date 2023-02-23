using boardgame;

namespace chess
{
    internal class Pawn : Piece
    {
        // Classe 'Peao' que herda da classe 'Peca' o metodo 'PossibleMoves'
        private ChessMatch match; // variavel da Partida de xadrez
        public Pawn(Board bd, Color color, ChessMatch match) : base(bd, color) // construtor
        {
            this.match = match;
        }
        public override string ToString() // metodo para representar o Peao no tabuleiro
        {
            return "P";
        }
        private bool OpponentExist(Position pos) // verificar se existe um oponente 
        {
            Piece p = Bd.piece(pos);
            return p != null && p.color != this.color;
        }
        private bool Free(Position pos) // verifica se a posicao de movimento esta livre
        {
            return Bd.piece(pos) == null; 
        }
        public override bool[,] PossibleMoves() // metodo que retorna a matriz(array) com os movimentos possiveis
        {
            bool[,] mat = new bool[Bd.rows, Bd.columns];

            Position pos = new Position(0, 0); // iniciando a variavel

            /* A peca do peao se move sempre uma linha para frente, exceto no primeiro movimento, quando pode mover-se duas linhas, o peao e a unica peça que não pode retroceder e tambem ela so pode captura uma peca na diagonal para frente */

            if (color == Color.Branca) // pecas brancas
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

                /* :)jogadaEspecial EnPassant,ou 'de passagem' e uma regra especial do xadrez que permite ao peao capturar um outro peao que acabou de passar por ele.
                 * O peao de captura deve ter avançado exatamente tres fileiras para executar este lance.
                 * O peao capturado deve ter movido duas casas em um lance, aterrissando ao lado do peao que vai captura-lo.
                 * A captura en passant deve ser realizada no lance imediatamente apos o movimento do peao que esta prestes a ser capturado.
                 * Se o jogador nao fizer a captura en passant nesse turno, ele nao pode fazer isso depois. */

                if (position.row == 3) // linha 5
                {
                    // esquerda acima
                    Position left = new Position(position.row, position.column - 1);
                    if(Bd.ValidPosition(left) && OpponentExist(left) && Bd.piece(left) == match.EnPassantVulnerable)
                    {
                        mat[left.row - 1, left.column] = true;
                    }
                    // direita acima
                    Position right = new Position(position.row, position.column + 1);
                    if (Bd.ValidPosition(right) && OpponentExist(right) && Bd.piece(right) == match.EnPassantVulnerable)
                    {
                        mat[right.row - 1, right.column] = true;
                    }
                }
            }
            else // pecas pretas
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

                // :)jogadaEspecial EnPassant, ou 'de passagem' e uma regra especial do xadrez que permite ao peao capturar um outro peao que acabou de passar por ele.
                if (position.row == 4) // linha 4
                {
                    // esquerda abaixo
                    Position left = new Position(position.row, position.column - 1);
                    if (Bd.ValidPosition(left) && OpponentExist(left) && Bd.piece(left) == match.EnPassantVulnerable)
                    {
                        mat[left.row + 1, left.column] = true;
                    }
                    // direita abaixo
                    Position right = new Position(position.row, position.column + 1);
                    if (Bd.ValidPosition(right) && OpponentExist(right) && Bd.piece(right) == match.EnPassantVulnerable)
                    {
                        mat[right.row + 1, right.column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
