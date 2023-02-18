using System;
using System.Collections.Generic;
using boardgame;
using chess;

namespace Chess_console {
    class Screen {

        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Bd);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.Turn);
            if (!match.Finished)
            {
                Console.WriteLine("Vez do Jogador (Cor): " + match.CurrentPlayer);
                if (match.Check)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUE-MATE!");
                Console.WriteLine("Vencedor: "+ match.CurrentPlayer);
            }
        }
        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            PrintSet(match.CapturedPieces(Color.Branca));
            Console.WriteLine();        
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            PrintSet(match.CapturedPieces(Color.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach(Piece x in set)
            {
                Console.Write(x+" ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board) {

            for (int i=0; i<board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j=0; j<board.columns; j++) {
                   PrintPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions) {

            ConsoleColor BackOrigin = Console.BackgroundColor;
            ConsoleColor BackChanged = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    if (possiblePositions[i, j]) {
                        Console.BackgroundColor = BackChanged;
                    }
                    else {
                        Console.BackgroundColor = BackOrigin;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = BackOrigin;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = BackOrigin;
        }

        public static ChessPosition ReadChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void PrintPiece(Piece piece) {

            if (piece == null) {
                Console.Write("- ");
            }
            else {
                if (piece.color == Color.Branca) {
                    Console.Write(piece);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

    }
}
