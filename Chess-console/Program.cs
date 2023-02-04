using Chess_console;
using boardgame;
using chess;

internal class Program
{
    private static void Main(string[] args)
    {
        ChessPosition position = new ChessPosition('c', 7);
        Console.WriteLine(position);
        Console.WriteLine(position.ToPosition());
    }
}