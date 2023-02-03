
namespace Entities
{
    internal class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
        {
            Row = Row;
            Column = column;
        }

        public override string ToString()
        {
            return "Row: " + Row
                   + "\nColumn: " + Column;
        }
    }
}
