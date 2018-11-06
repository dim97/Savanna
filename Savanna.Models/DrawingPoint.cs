using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savanna.Models
{
    public struct DrawingPoint
    {
        public Point Position { get; set; }
        public char Sign { get; set; }

        public DrawingPoint(Point position, char sign)
        {
            Position = position;
            Sign = sign;
        }
    }
}
