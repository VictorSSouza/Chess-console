using System;
using boardgame;
using chess;

namespace Chess_console {
    class Program
    {
        static void Main(string[] args)
        {

            try {
                /* Aqui a variavel local 'match' ou traduzindo partida, que e da classe PartidaXadrez, e a variavel 
                 * responsavel por mostrar o ciclo  de inicio e fim de uma partida de xadrez para o usuario
                 */
                ChessMatch match = new ChessMatch();

                while (!match.Finished) {

                    try
                    {
                        Console.Clear(); // limpa o terminal console
                        Screen.PrintMatch(match); // imprime o tabuleiro

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.ReadChessPosition().toPosition(); // ler a posicao da peca de origem
                        match.ValidateOriginPosition(origin); // valida a posicao de origem da peca

                        // ler os movimentos possiveis para a peca de origem escolhida
                        bool[,] possibleMoves = match.Bd.piece(origin).PossibleMoves();                  

                        Console.Clear();
                        Screen.PrintBoard(match.Bd, possibleMoves); // imprime os movimentos possiveis para escolher

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destiny = Screen.ReadChessPosition().toPosition();// ler a posicao da peca de destino
                        match.ValidateDestinyPosition(origin, destiny); // valida a posicao de destino da peca

                        match.MakeMove(origin, destiny); // realiza o movimento da jogada da origem A ate destino B
                    } 
                    catch (BoardException e) // imprime a excecao do tabuleiro
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine(); // possibilita voltar caso o usuario erre nas regras do jogo
                    }
                    catch (Exception e) // Erro geral dentro da partida
                    {
                        Console.WriteLine("Error:"+e.Message);
                        Console.ReadLine(); // possibilita voltar por causa de um erro generico ex: formato
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match); // Aqui termina o jogo mostrando o vencedor
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
