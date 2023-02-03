using Chess_console;
using Entities;
internal class Program
{
    private static void Main(string[] args)
    {
        Board chessbd = new Board(8, 8);
        Screen.PrintBoard(chessbd);
        
    }
}