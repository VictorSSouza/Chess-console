using System;
using boardgame;

namespace chess {
    class ChessMatch {

        public Board bd { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool finished { get; private set; }

        public ChessMatch() {
            bd = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            finished = false;
            PutPieces();
        }

        public void PerformMovements(Position origin, Position destiny) {
            Piece p = bd.removePiece(origin);
            p.addQtyMoviments();
            Piece capturedPiece = bd.removePiece(destiny);
            bd.PutPiece(p, destiny);
        }

        private void PutPieces() {
            bd.PutPiece(new Tower(bd, Color.Branca), new ChessPosition('c', 1).toPosition());
            bd.PutPiece(new Tower(bd, Color.Branca), new ChessPosition('c', 2).toPosition());
            bd.PutPiece(new Tower(bd, Color.Branca), new ChessPosition('d', 2).toPosition());
            bd.PutPiece(new Tower(bd, Color.Branca), new ChessPosition('e', 2).toPosition());
            bd.PutPiece(new Tower(bd, Color.Branca), new ChessPosition('e', 1).toPosition());
            bd.PutPiece(new King(bd, Color.Branca), new ChessPosition('d', 1).toPosition());

            bd.PutPiece(new Tower(bd, Color.Preta), new ChessPosition('c', 7).toPosition());
            bd.PutPiece(new Tower(bd, Color.Preta), new ChessPosition('c', 8).toPosition());
            bd.PutPiece(new Tower(bd, Color.Preta), new ChessPosition('d', 7).toPosition());
            bd.PutPiece(new Tower(bd, Color.Preta), new ChessPosition('e', 7).toPosition());
            bd.PutPiece(new Tower(bd, Color.Preta), new ChessPosition('e', 8).toPosition());
            bd.PutPiece(new King(bd, Color.Preta), new ChessPosition('d', 8).toPosition());
        }
    }
}
