using System;
using System.Collections.Generic;
using boardgame;
using chess;

namespace Chess_console {
    class Screen 
    {
        // Aqui é a classe 'Tela' onde possue metodos que reune o conteudo que vai aparecer no console do usuario
        public static void PrintMatch(ChessMatch match) // metodo para imprimir a partida
        {
            PrintBoard(match.Bd); // imprime o tabuleiro
            Console.WriteLine();
            PrintCapturedPieces(match); // imprime as pecas capturadas na partida atual
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.Turn); // turno atual
            if (!match.Finished)
            {
                Console.WriteLine("Vez do Jogador (Cor): " + match.CurrentPlayer); // mostra  a cor de quem vai jogar
                Console.WriteLine("Regra: primeiro escolher a Coluna e depois a linha, desta maneira a1");
                
                if (match.Check) // caso o jogador atual esteja em xeque
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                // Aqui a partida é finalizada com o xeque-mate, ou seja, a captura do rei
                Console.WriteLine("XEQUE-MATE!");
                Console.WriteLine("Vencedor: "+ match.CurrentPlayer);
            }
        }
        public static void PrintCapturedPieces(ChessMatch match) // metodo para imprimir pecas capturadas
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            PrintSet(match.CapturedPieces(Color.Branca)); // imprime o conjunto de pecas capturadas
            Console.WriteLine();        
            Console.Write("Pretas: ");
            // mudar a cor das letras e simbolos
            ConsoleColor aux = Console.ForegroundColor; 
            Console.ForegroundColor = ConsoleColor.Green;
            PrintSet(match.CapturedPieces(Color.Preta));
            Console.ForegroundColor = aux; // aqui volta a cor padrao
            Console.WriteLine();
        }
        public static void PrintSet(HashSet<Piece> set) // metodo para imprimir os conjuntos de pecas capturadas
        {
            Console.Write("[");
            foreach(Piece x in set) // pecas capturadas
            {
                Console.Write(x+" ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board) // metodo para imprimir o tabuleiro
        {

            for (int i=0; i<board.rows; i++) // linhas
            {
                Console.Write(8 - i + " ");
                for (int j=0; j<board.columns; j++) // colunas
                {
                   PrintPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions) // imprime o tabuleiro com os movimentos possiveis para o usuario escolher na hora de colocar a peca no destino
        {

            ConsoleColor BackOrigin = Console.BackgroundColor; // cor de fundo original
            ConsoleColor BackChanged = ConsoleColor.DarkGray; // cor de fundo modificado

            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) 
                {
                    // com base nas posicoes, que depende da peca e posicao no tabuleiro, ira mostrar em cor cinza os movimentos possiveis de escolha do usuario
                    if (possiblePositions[i, j]) 
                    {
                        Console.BackgroundColor = BackChanged;
                    }
                    else 
                    {
                        Console.BackgroundColor = BackOrigin;
                    }
                    PrintPiece(board.piece(i, j)); // imprime a peca
                    Console.BackgroundColor = BackOrigin; // voltar a cor de fundo original
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = BackOrigin;
        }

        public static ChessPosition ReadChessPosition() // metodo que ler a posicao escolhida no tabuleiro
        {
            string s = Console.ReadLine();
            char column = s[0]; // ler primeiro a coluna ex 'a'
            int row = int.Parse(s[1] + ""); // ler em seguida a linha '1'
            return new ChessPosition(column, row);
        }

        public static void PrintPiece(Piece piece) // imprime as pecas no tabuleiro
        {

            if (piece == null) // caso não exista uma peca naquela posicao
            {
                Console.Write("- ");
            }
            else 
            {
                // diferenciando as cores da pecas para ajudar na compreensao
                if (piece.color == Color.Branca)
                {
                    // aqui a peca e branca
                    Console.Write(piece);
                }
                else 
                {
                    // aqui a cor da peca e mostrada na cor verde
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
