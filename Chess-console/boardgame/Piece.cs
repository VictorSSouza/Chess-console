namespace boardgame {
    abstract class Piece {

        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtyMoviments { get; protected set; }
        public Board bd { get; protected set; }
         
        public Piece(Board bd, Color color) {
            this.position = null;
            this.bd = bd;
            this.color = color;
            this.qtyMoviments = 0;
        }

        public void addQtyMoviments() {
            qtyMoviments++;
        }

        public abstract bool[,] PossibleMoves();
    }
}
