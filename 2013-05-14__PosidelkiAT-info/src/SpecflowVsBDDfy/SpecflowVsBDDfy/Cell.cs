using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecflowVsBDDfy
{
    public class Cell
    {
        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", Row, Col);
        }
    }

}
