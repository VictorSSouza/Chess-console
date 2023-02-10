using System;
using boardgame;
using chess;

namespace Chess_console {
    class Program {
        static void Main(string[] args) {

            try {
                ChessMatch partida = new ChessMatch();

                while (!partida.finished) {

                    Console.Clear();
                    Screen.PrintBoard(partida.bd);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPosition().toPosition();

                    bool[,] posicoesPossiveis = partida.bd.piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(partida.bd, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadChessPosition().toPosition();

                    partida.PerformMovements(origin, destiny);
                }

            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
