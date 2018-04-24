using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispose
{
    class Position
    {
        public int Row { get; set; }
        public int Colomn { get; set; }
        public Position()
        { }
        public Position(int x, int y)
        {
            Row = x;
            Colomn = y;
        }
    }
}
