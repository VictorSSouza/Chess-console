namespace boardgame {
    class Position {
        // Classe 'Posicao' em 2 dimensoes
        public int row { get; set; } // linha
        public int column { get; set; } // coluna

        public Position(int row, int column) // construtor
        {
            this.row = row;
            this.column = column;
        }

        public void SetValues(int row, int column) // define os valores de uma peca especifica no caso de um movimento possivel
        {
            this.row = row;
            this.column = column;
        }

        public override string ToString() // metodo para converter para string a linha e coluna
        {
            return row
                + ", "
                + column;
        }
    }
}
