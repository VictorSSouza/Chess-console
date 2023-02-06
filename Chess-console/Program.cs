using Chess_console;
using boardgame;
using chess;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Board board = new Board(8, 8);

            board.PutPiece(new Tower(board, Color.black), new Position(0, 0));
            board.PutPiece(new King(board, Color.black), new Position(2, 3));
            board.PutPiece(new Tower(board, Color.black), new Position(1, 7));
            board.PutPiece(new Tower(board, Color.white), new Position(5, 4));

            Screen.PrintBoard(board);

        }
        catch(BoardException e)
        {
            Console.WriteLine("Board Error "+ e.Message);
        }
    }
}