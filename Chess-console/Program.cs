using Chess_console;
using boardgame;
using chess;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            ChessMatch match = new ChessMatch();
            while (!match.finished)
            {

                Console.Clear();
                Screen.PrintBoard(match.board);

                Console.WriteLine();
                Console.Write("Origin:");
                Position origin = Screen.ReadChessPosition().ToPosition();

                Console.Write("Destiny: ");
                Position destiny = Screen.ReadChessPosition().ToPosition();

                match.Performsmovement(origin, destiny);
            }


        }
        catch (BoardException e)
        {
            Console.WriteLine("Board Error " + e.Message);
        }
    }
}