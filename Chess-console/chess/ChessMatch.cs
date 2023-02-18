using System.Collections.Generic;
using boardgame;

namespace chess {
    class ChessMatch {

        public Board Bd { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool Xeque { get; private set; }
        public ChessMatch() {
            Bd = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.Branca;
            Finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            Xeque = false;
            PutPieces();
        }

        public Piece PerformMovement(Position origin, Position destiny) {
            Piece p = Bd.removePiece(origin);
            p.addQtyMoviments();
            Piece capturedPiece = Bd.removePiece(destiny);
            Bd.PutPiece(p, destiny);
            if(capturedPiece != null )
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = Bd.removePiece(destiny);
            p.removeQtyMoviments();
            if(capturedPiece != null)
            {
                Bd.PutPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            Bd.PutPiece(p, origin);

        }
        public void MakeMove(Position origin, Position destiny)
        {
            Piece capturedPiece = PerformMovement(origin, destiny);
            if (IsInCheck(CurrentPlayer))
            {
                UndoMovement(origin, destiny, capturedPiece);
                throw new BoardException("Você não pode se colocar em XEQUE!");
            }
            if (IsInCheck(Opponent(CurrentPlayer)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (CheckmateTest(Opponent(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
        }
        private void ChangePlayer()
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
        public void ValidateOriginPosition(Position pos)
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
        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!Bd.piece(origin).PossibleMove(destiny))
            {
                throw new BoardException("A posição de destino escolhida é inválida!");
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured)
            {
                if (x.color == color)
                    aux.Add(x);
            }
            return aux;
        }
        public HashSet<Piece> InGamePieces(Color color)
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
        private Color Opponent(Color color)
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
        private Piece king(Color color)
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

        public bool IsInCheck(Color color)
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
        public bool CheckmateTest(Color color)
        {
            if (!IsInCheck(color)) return false;
            foreach(Piece x in InGamePieces(color))
            {
                bool[,] mat = x.PossibleMoves();
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
        public void PutNewPieces(char column, int row, Piece piece)
        {
            Bd.PutPiece(piece,new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }
        private void PutPieces() {
            // Primeira Fileira Branca
            PutNewPieces('a', 1, new Tower(Bd, Color.Branca));
            PutNewPieces('b', 1, new Horse(Bd, Color.Branca));
            PutNewPieces('c', 1, new Bishop(Bd, Color.Branca));
            PutNewPieces('d', 1, new Queen(Bd, Color.Branca));
            PutNewPieces('e', 1, new King(Bd, Color.Branca));
            PutNewPieces('f', 1, new Bishop(Bd, Color.Branca));
            PutNewPieces('g', 1, new Horse(Bd, Color.Branca));
            PutNewPieces('h', 1, new Tower(Bd, Color.Branca));
            // Segunda Fileira Branca
            PutNewPieces('a', 2, new Pawn(Bd, Color.Branca));
            PutNewPieces('b', 2, new Pawn(Bd, Color.Branca));
            PutNewPieces('c', 2, new Pawn(Bd, Color.Branca));
            PutNewPieces('d', 2, new Pawn(Bd, Color.Branca));
            PutNewPieces('e', 2, new Pawn(Bd, Color.Branca));
            PutNewPieces('f', 2, new Pawn(Bd, Color.Branca));
            PutNewPieces('g', 2, new Pawn(Bd, Color.Branca));
            PutNewPieces('h', 2, new Pawn(Bd, Color.Branca));
            // Primeira Fileira Preta
            PutNewPieces('a', 8, new Tower(Bd, Color.Preta));
            PutNewPieces('b', 8, new Horse(Bd, Color.Preta));
            PutNewPieces('c', 8, new Bishop(Bd, Color.Preta));
            PutNewPieces('d', 8, new Queen(Bd, Color.Preta));
            PutNewPieces('e', 8, new King(Bd, Color.Preta));
            PutNewPieces('f', 8, new Bishop(Bd, Color.Preta));
            PutNewPieces('g', 8, new Horse(Bd, Color.Preta));
            PutNewPieces('h', 8, new Tower(Bd, Color.Preta));
            // Segunda Fileira Preta
            PutNewPieces('a', 7, new Pawn(Bd, Color.Preta));
            PutNewPieces('b', 7, new Pawn(Bd, Color.Preta));
            PutNewPieces('c', 7, new Pawn(Bd, Color.Preta));
            PutNewPieces('d', 7, new Pawn(Bd, Color.Preta));
            PutNewPieces('e', 7, new Pawn(Bd, Color.Preta));
            PutNewPieces('f', 7, new Pawn(Bd, Color.Preta));
            PutNewPieces('g', 7, new Pawn(Bd, Color.Preta));
            PutNewPieces('h', 7, new Pawn(Bd, Color.Preta));
        }
    }
}
