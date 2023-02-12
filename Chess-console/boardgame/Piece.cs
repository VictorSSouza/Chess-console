namespace boardgame {
    abstract class Piece {

        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtyMoviments { get; protected set; }
        public Board Bd { get; protected set; }
         
        public Piece(Board bd, Color color) {
            this.position = null;
            this.Bd = bd;
            this.color = color;
            this.qtyMoviments = 0;
        }

        public void addQtyMoviments() {
            qtyMoviments++;
        }

        public bool PossibleMovesExists()
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

        public bool CanMoveTo(Position pos)
        {
            return PossibleMoves()[pos.row, pos.column];
        }
        public abstract bool[,] PossibleMoves();

    }
}
