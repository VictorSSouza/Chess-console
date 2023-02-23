namespace boardgame {
    class Board 
    {
        // Classe 'Tabuleiro' generico para jogar
        public int rows { get; set; } // linhas
        public int columns { get; set; } // colunas
        private Piece[,] pieces; // array pecas que contem linhas e colunas

        public Board(int rows, int columns) //Construtor
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns]; 
        }

        public Piece piece(int row, int column) // metodo que retorna para a classe 'Tela' para imprimir a peca
        {
            return pieces[row, column];
        }

        public Piece piece(Position pos) // metodo que retorna uma linha e coluna especifica de uma posicao
        {
            return pieces[pos.row, pos.column];
        }

        public bool PieceExists(Position pos) // metodo que verifica se a peca existe
        {
            validatePosition(pos); // valida a posicao da peca
            return piece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos) // metodo para colocar a peca no tabuleiro
        {
            if (PieceExists(pos)) 
            {
                throw new BoardException("Já existe uma peça nessa posição!");
            }
            pieces[pos.row, pos.column] = p; // adicionar a peca ao array
            p.position = pos;
        }

        public Piece removePiece(Position pos) // metodo para remover peca do tabuleiro
        {
            if (piece(pos) == null) // se a posicao da peca e igual a nulo  
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.row, pos.column] = null; // retirar a peca do array
            return aux; // ou seja retorna a peca na posicao nula
        }

        public bool ValidPosition(Position pos)  // metodo booleabo que verifica se a posicao e valida
        {
            if (pos.row <0 || pos.row >=rows || pos.column <0 || pos.column >=columns) 
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos) // metodo para validar a posicao escolhida pelo usuario
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Posição inválida!");
            }
        }
    }
}
