namespace boardgame {
    abstract class Piece 
    {
        // Classe abstrata 'Peca' 
        public Position position { get; set; } // posicao
        public Color color { get; protected set; } // cor
        public int qtyMoviments { get; protected set; } // Quantidade de movimentos
        public Board Bd { get; protected set; } // tabuleiro
         
        public Piece(Board bd, Color color) // construtor
        {
            this.position = null;
            this.Bd = bd;
            this.color = color;
            this.qtyMoviments = 0;
        }

        public void addQtyMoviments() // incrementa a quantidade de movimento de uma peca
        {
            qtyMoviments++;
        }
        public void removeQtyMoviments() // decrementa a quantidade de movimento de uma peca
        {
            qtyMoviments--;
        }

        public bool PossibleMovesExists() // Verifica se existe algum movimento possível das pecas no tabuleiro
        {
            bool[,] mat = PossibleMoves();

            for (int i = 0; i < Bd.rows; i++)
            {
                for (int j = 0; j < Bd.columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PossibleMove(Position pos) // metodo que retorna os movimentos possiveis de uma peca escolhida
        {
            return PossibleMoves()[pos.row, pos.column];
        }
        public abstract bool[,] PossibleMoves(); // metodo abstrato movimentos possiveis 

    }
}
