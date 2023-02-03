using System;
using Entities;
namespace Chess_console
{
    internal class Screen
    {
        public static void PrintBoard(Board bd)
        {
            for (int i = 0; i < bd.rows; i++)
            {
                for (int j = 0; j < bd.columns; j++)
                {
                    if (bd.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(bd.piece(i, j) + "- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
