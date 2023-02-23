using boardgame;

namespace chess 
{
    class ChessPosition 
    {

        public char column { get; set; } // coluna
        public int row { get; set; } // linha

        public ChessPosition(char column, int row) // construtor
        {
            this.column = column;
            this.row = row;
        }

        public Position toPosition() // metodo que converte a posicao digitada pelo usuario para o tabuleiro armazenar a posicao correta  por exemplo a1, equivale a 0,0 no array
        {
            return new Position(8 - row, column - 'a');
        }

        public override string ToString() // Converte os valores para string
        {
            return "" + column + row;
        }
    }
}
