using System;
using boardgame;

namespace chess {
    class ChessMatch {

        public Board Bd { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch() {
            Bd = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.Branca;
            Finished = false;
            PutPieces();
        }

        public void PerformMovements(Position origin, Position destiny) {
            Piece p = Bd.removePiece(origin);
            p.addQtyMoviments();
            Piece capturedPiece = Bd.removePiece(destiny);
            Bd.PutPiece(p, destiny);
        }

        public void MakeMove(Position origin, Position destiny)
        {
            PerformMovements(origin, destiny);
            Turn++;
            ChangePlayer();
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
            if (!Bd.piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("A posição de destino escolhida é inválida!");
            }
        }
        private void PutPieces() {
            Bd.PutPiece(new Tower(Bd, Color.Branca), new ChessPosition('c', 1).toPosition());
            Bd.PutPiece(new Tower(Bd, Color.Branca), new ChessPosition('c', 2).toPosition());
            Bd.PutPiece(new Tower(Bd, Color.Branca), new ChessPosition('d', 2).toPosition());
            Bd.PutPiece(new Tower(Bd, Color.Branca), new ChessPosition('e', 2).toPosition());
            Bd.PutPiece(new Tower(Bd, Color.Branca), new ChessPosition('e', 1).toPosition());
            Bd.PutPiece(new King(Bd, Color.Branca), new ChessPosition('d', 1).toPosition());

            Bd.PutPiece(new Tower(Bd, Color.Preta), new ChessPosition('c', 7).toPosition());
            Bd.PutPiece(new Tower(Bd, Color.Preta), new ChessPosition('c', 8).toPosition());
            Bd.PutPiece(new Tower(Bd, Color.Preta), new ChessPosition('d', 7).toPosition());
            Bd.PutPiece(new Tower(Bd, Color.Preta), new ChessPosition('e', 7).toPosition());
            Bd.PutPiece(new Tower(Bd, Color.Preta), new ChessPosition('e', 8).toPosition());
            Bd.PutPiece(new King(Bd, Color.Preta), new ChessPosition('d', 8).toPosition());
        }
    }
}
