using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Redo_Undo
{
    class PenParam
    {
        public int StarX1, StarY1;
        public int StarX2, StarY2;
        public int ActionBehovior;
        Pen myPen = new Pen(Color.Black);

        public PenParam()
        {
            this.StarX1 = -1;
            this.StarX2 = -1;
            this.StarY1 = -1;
            this.StarY2 = -1;
            this.ActionBehovior = 0;
        }

        public void DrawGraphics(Graphics g)
        {
            switch (ActionBehovior)
            {
                case 0:
                    myPen.Width = 3;
                    g.DrawLine(myPen, StarX1, StarY1, StarX2, StarY2);
                    break;
                case 1:
                    
                    break;
                case 2:
                    break;
            }
        }
    }
}
