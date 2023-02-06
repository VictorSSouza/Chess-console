using System;
using boardgame;
using chess;

namespace Chess_console
{
    internal class Screen
    {
        public static void PrintBoard(Board bd)
        {
            for (int i = 0; i < bd.rows; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < bd.columns; j++)
                {
                    if (bd.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(bd.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece.color == Color.white)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
