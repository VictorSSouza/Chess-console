using System.Collections.Generic;
using boardgame;

namespace chess 
{
    class ChessMatch 
    {
        // Classe 'Partida de Xadrez'
        public Board Bd { get; private set; } // tabuleiro
        public int Turn { get; private set; } // turno da partida
        public Color CurrentPlayer { get; private set; } // jogador atual e cor da peca
        public bool Finished { get; private set; } // fim da partida
        private HashSet<Piece> pieces; // conjunto de pecas em jogo
        private HashSet<Piece> captured; // conjunto de pecas capturadas
        public bool Check { get; private set; } // xeque 
        public Piece EnPassantVulnerable { get; private set; } // vuneravel a :)jogadaEspecial En Passant
        public ChessMatch() {
            Bd = new Board(8, 8); // xadrez e um array(matriz) com 8 linhas e 8 colunas
            Turn = 1; // primeiro turno para movimentar uma peca
            CurrentPlayer = Color.Branca; // inicia a partida pela peca branca
            Finished = false;
            pieces = new HashSet<Piece>(); // todas as pecas inicialmente estao no tabuleiro
            captured = new HashSet<Piece>(); // esse conjunto inicia vazio
            EnPassantVulnerable = null;
            Check = false;           
            PutPieces(); // colocar pecas no tabuleiro
        }

        public Piece PerformMovement(Position origin, Position destiny) {
            Piece p = Bd.removePiece(origin); // remover peca da posicao de origem
            p.addQtyMoviments(); // incrementar movimentos de p
            Piece capturedPiece = Bd.removePiece(destiny); // variavel local recebe peca ou vazio da posicao destino
            Bd.PutPiece(p, destiny); // colocar p na posicao destino
            if(capturedPiece != null ) // se a peca tiver valor diferente de vazio
            {
                captured.Add(capturedPiece); // adiciona ao conjuntos de pecas capturadas
            }

            // :)jogadaEspecial roque pequeno
            if(p is King && destiny.column == origin.column + 2) // onde o rei vai ficar é origin.column + 2
            {
                Position originT = new Position(origin.row, origin.column + 3); // posicao de origem da peca torre na coluna h
                Position destinyT = new Position(origin.row, origin.column + 1); // posicao de destino da peca torre na coluna f
                Piece T = Bd.removePiece(originT); // remove da origem
                T.addQtyMoviments(); // incrementa o movimento
                Bd.PutPiece(T, destinyT); // coloca no destino
            }
            // :)jogadaEspecial roque grande
            if (p is King && destiny.column == origin.column - 2) // onde o rei vai ficar é origin.column + 2
            {
                Position originT = new Position(origin.row, origin.column - 4); // posicao de origem da peca torre na coluna a
                Position destinyT = new Position(origin.row, origin.column - 1); // posicao de destino da peca torre na coluna c
                Piece T = Bd.removePiece(originT); // remove da origem
                T.addQtyMoviments(); // incrementa o movimento
                Bd.PutPiece(T, destinyT); // coloca no destino
            }

            // :)jogadaEspecial EnPassant
            if(p is Pawn)
            {
                if(origin.column != destiny.column && capturedPiece == null) // Aqui é para colocar na posicao linha adequada da jogadaEspecial
                {
                    Position posP;
                    if(p.color == Color.Branca)
                    {
                        posP = new Position(destiny.row + 1, destiny.column); // fica acima do oponente
                    }
                    else
                    {
                        posP = new Position(destiny.row - 1, destiny.column); // fica abaixo do oponente
                    }
                    capturedPiece = Bd.removePiece(posP);
                    captured.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destiny, Piece capturedPiece) // metodo que desfaz movimento
        {
            Piece p = Bd.removePiece(destiny); // remove a peca do destino
            p.removeQtyMoviments(); // retira o movimento
            if(capturedPiece != null)
            {
                Bd.PutPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece); // retirar do conjunto das pecas capturadas
            }
            Bd.PutPiece(p, origin); // colocar p na posicao de origem

            // :)jogadaEspecial roque pequeno
            if (p is King && destiny.column == origin.column + 2)
            {
                Position originT = new Position(origin.row, origin.column + 3);
                Position destinyT = new Position(origin.row, origin.column + 1);
                Piece T = Bd.removePiece(destinyT); // remove a peca da torre da posicao destino
                T.removeQtyMoviments(); // decrementa a quantidade de movimentos
                Bd.PutPiece(T, originT); // coloca na origem
            }
            // :)jogadaEspecial roque grande
            if (p is King && destiny.column == origin.column - 2)
            {
                Position originT = new Position(origin.row, origin.column - 4);
                Position destinyT = new Position(origin.row, origin.column - 1);
                Piece T = Bd.removePiece(destinyT);
                T.removeQtyMoviments();
                Bd.PutPiece(T, originT);
            }

            // :)jogadaEspecial EnPassant
            if(p is Pawn)
            {
                if(origin.column != destiny.column && capturedPiece == EnPassantVulnerable) // retorna a peca as suas devidas posicoes antes da jogadaEspecial
                {
                    Piece pawn = Bd.removePiece(destiny);
                    Position posP;
                    if(p.color == Color.Branca)
                    {
                        posP = new Position(3, destiny.column);
                    }
                    else
                    {
                        posP = new Position(4, destiny.column);
                    }
                    Bd.PutPiece(pawn,posP);
                }
            }
        }
        public void MakeMove(Position origin, Position destiny) // realiza a jogada
        {
            Piece capturedPiece = PerformMovement(origin, destiny); // executa o movimento
            if (IsInCheck(CurrentPlayer)) // se o jogador atual esta em xeque
            {
                UndoMovement(origin, destiny, capturedPiece); // desfaz movimento
                throw new BoardException("Você não pode se colocar em XEQUE!");
            }

            Piece p = Bd.piece(destiny);
            // :)jogadaEspecial promocao/promotion
            if(p is Pawn)
            {
                if((p.color == Color.Branca && destiny.row == 0) || (p.color == Color.Preta && destiny.row == 7)) // se o peao chega a ultima linha possivel
                {
                    p = Bd.removePiece(destiny);
                    pieces.Remove(p); // remove o peao

                    Piece promotion = new Queen(Bd, p.color);
                    Bd.PutPiece(promotion, destiny); // coloca a dama no lugar do peao
                    pieces.Add(promotion); // adiciona ao conjunto de pecas em jogo
                }
            }

            if (IsInCheck(Opponent(CurrentPlayer))) // se o oponente esta em xeque
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (CheckmateTest(Opponent(CurrentPlayer))) // se o teste de xeque-mate do oponente e verdade
            {
                Finished = true;
            }
            else // senao continua o turno
            {
                Turn++;
                ChangePlayer();// troca o jogador
            }
          
            // :)jogadaEspecial EnPassant
            if(p is Pawn && (destiny.row == origin.row - 2 || destiny.row == origin.row + 2)) // verifica se a peca esta em vuneravel ao enPassant
            {
                EnPassantVulnerable = p;
            }
            else
            {
                EnPassantVulnerable = null;
            }
        }
        private void ChangePlayer() // trocar jogador
        {
            if(CurrentPlayer == Color.Branca)
            {
                CurrentPlayer = Color.Preta;
            }
            else
            {
                CurrentPlayer = Color.Branca;
            }
        }
        public void ValidateOriginPosition(Position pos) // metodo que valida posicao de origem escolhida
        {
            if (Bd.piece(pos) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida!");
            }
            if(CurrentPlayer != Bd.piece(pos).color)
            {
                throw new BoardException("A peça de origem escolhida é do adversário!");
            }
            if (!Bd.piece(pos).PossibleMovesExists())
            {
                throw new BoardException("Não existe movimentos possiveis para a peça de origem escolhida!");
            }
        }
        public void ValidateDestinyPosition(Position origin, Position destiny) // metodo que valida posicao de destino escolhida
        {
            if (!Bd.piece(origin).PossibleMove(destiny))
            {
                throw new BoardException("A posição de destino escolhida é inválida!");
            }
        }

        public HashSet<Piece> CapturedPieces(Color color) // metodo para armazenar conjunto de pecas capturadas
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured)
            {
                if (x.color == color)
                    aux.Add(x);
            }
            return aux;
        }
        public HashSet<Piece> InGamePieces(Color color) // metodo para armazenar conjunto de pecas em jogo
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                    aux.Add(x);
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }
        private Color Opponent(Color color) // metodo para definir o oponente dos dois jogadores
        {
            if(color == Color.Branca)
            {
                return Color.Preta;
            }
            else
            {
                return Color.Branca;
            }
        }
        private Piece king(Color color) // metodo para contar o numero de reis em jogo
        {
            foreach(Piece x in InGamePieces(color))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color) // metodo para verificar se o rei esta em xeque
        {
            Piece k = king(color);
            if(k == null)
            {
                throw new BoardException($"Não tem Rei da cor {color} no tabuleiro!");
            }
            foreach(Piece x in InGamePieces(Opponent(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[k.position.row, k.position.column])
                    return true;
            }
            return false;
        }
        public bool CheckmateTest(Color color) // metodo para testar o xeque-mate 
        {
            if (!IsInCheck(color)) return false;
            foreach(Piece x in InGamePieces(color))
            {
                bool[,] mat = x.PossibleMoves(); // movimentos possiveis de x
                for(int i = 0; i < Bd.rows; i++)
                {
                    for(int j = 0; j < Bd.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = PerformMovement(origin, destiny);
                            bool checkmateTest = IsInCheck(color);
                            UndoMovement(origin, destiny, capturedPiece);
                            if (!checkmateTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void PutNewPieces(char column, int row, Piece piece) // metodo que auxilia na hora de colocar novas pecas
        {
            Bd.PutPiece(piece,new ChessPosition(column, row).toPosition());
            pieces.Add(piece); // adicionar a peca no tabuleiro
        }
        private void PutPieces() // colocar todas as pecas de xadrez no tabuleiro
        {
            // Primeira Fileira Branca
            PutNewPieces('a', 1, new Tower(Bd, Color.Branca));
            PutNewPieces('b', 1, new Horse(Bd, Color.Branca));
            PutNewPieces('c', 1, new Bishop(Bd, Color.Branca));
            PutNewPieces('d', 1, new Queen(Bd, Color.Branca));
            PutNewPieces('e', 1, new King(Bd, Color.Branca, this));
            PutNewPieces('f', 1, new Bishop(Bd, Color.Branca));
            PutNewPieces('g', 1, new Horse(Bd, Color.Branca));
            PutNewPieces('h', 1, new Tower(Bd, Color.Branca));
            // Segunda Fileira Branca
            PutNewPieces('a', 2, new Pawn(Bd, Color.Branca, this));
            PutNewPieces('b', 2, new Pawn(Bd, Color.Branca, this));
            PutNewPieces('c', 2, new Pawn(Bd, Color.Branca, this));
            PutNewPieces('d', 2, new Pawn(Bd, Color.Branca, this));
            PutNewPieces('e', 2, new Pawn(Bd, Color.Branca, this));
            PutNewPieces('f', 2, new Pawn(Bd, Color.Branca, this));
            PutNewPieces('g', 2, new Pawn(Bd, Color.Branca, this));
            PutNewPieces('h', 2, new Pawn(Bd, Color.Branca, this));
            // Primeira Fileira Preta
            PutNewPieces('a', 8, new Tower(Bd, Color.Preta));
            PutNewPieces('b', 8, new Horse(Bd, Color.Preta));
            PutNewPieces('c', 8, new Bishop(Bd, Color.Preta));
            PutNewPieces('d', 8, new Queen(Bd, Color.Preta));
            PutNewPieces('e', 8, new King(Bd, Color.Preta, this));
            PutNewPieces('f', 8, new Bishop(Bd, Color.Preta));
            PutNewPieces('g', 8, new Horse(Bd, Color.Preta));
            PutNewPieces('h', 8, new Tower(Bd, Color.Preta));
            // Segunda Fileira Preta
            PutNewPieces('a', 7, new Pawn(Bd, Color.Preta, this));
            PutNewPieces('b', 7, new Pawn(Bd, Color.Preta, this));
            PutNewPieces('c', 7, new Pawn(Bd, Color.Preta, this));
            PutNewPieces('d', 7, new Pawn(Bd, Color.Preta, this));
            PutNewPieces('e', 7, new Pawn(Bd, Color.Preta, this));
            PutNewPieces('f', 7, new Pawn(Bd, Color.Preta, this));
            PutNewPieces('g', 7, new Pawn(Bd, Color.Preta, this));
            PutNewPieces('h', 7, new Pawn(Bd, Color.Preta, this));
        }
    }
}
