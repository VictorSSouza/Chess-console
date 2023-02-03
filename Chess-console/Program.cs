using Chess_console;
using boardgame;
using chess;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Board chessbd = new Board(8, 8);
            chessbd.PutPiece(new Tower(chessbd, Color.black), new Position(0, 0));
            chessbd.PutPiece(new King(chessbd, Color.black), new Position(0, 3));
            chessbd.PutPiece(new Tower(chessbd, Color.black), new Position(2, 4));

            Screen.PrintBoard(chessbd);
        }
        catch(BoardException e)
        {
            Console.WriteLine("Board error: "+ e.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Unexpected error: "+ex.Message);
        }
    }
}