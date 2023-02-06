using System;
using boardgame;

namespace chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool finished;

        public ChessMatch()
        {
            board = new Board(8,8);
            turn = 1;
            currentPlayer = Color.white;
            finished = false;
            PutPieces();
        }

        public void Performsmovement(Position origin, Position destiny)
        {
            Piece p = board.RemovePiece(origin);
            p.IncrementQtyMovements();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PutPiece(p, destiny);
        }
        public void PutPieces()
        {
            board.PutPiece(new Tower(board, Color.white), new ChessPosition('c', 1).ToPosition());
            board.PutPiece(new Tower(board, Color.white), new ChessPosition('c', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.white), new ChessPosition('d', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.white), new ChessPosition('e', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.white), new ChessPosition('e', 1).ToPosition());
            board.PutPiece(new King(board, Color.white), new ChessPosition('d', 1).ToPosition());

            board.PutPiece(new Tower(board, Color.black), new ChessPosition('c', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.black), new ChessPosition('c', 8).ToPosition());
            board.PutPiece(new Tower(board, Color.black), new ChessPosition('d', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.black), new ChessPosition('e', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.black), new ChessPosition('e', 8).ToPosition());
            board.PutPiece(new King(board, Color.black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
