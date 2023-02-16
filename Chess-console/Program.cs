using System;
using boardgame;
using chess;

namespace Chess_console {
    class Program {
        static void Main(string[] args) {

            try {
                ChessMatch match = new ChessMatch();

                while (!match.Finished) {

                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.ReadChessPosition().toPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possibleMoves = match.Bd.piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.Bd, possibleMoves);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destiny = Screen.ReadChessPosition().toPosition();
                        match.ValidateDestinyPosition(origin, destiny);

                        match.MakeMove(origin, destiny);
                    } 
                    catch (BoardException e) 
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
