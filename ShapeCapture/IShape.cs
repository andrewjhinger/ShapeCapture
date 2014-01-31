using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShapeCapture
{
    public interface IShape
    {
        //properties and a method for creating shapes, detecting a collision, and a method to move or animate a shape. 
        Size Dimensions { get; set; }
        Point Location { get; set; }
        Color FillColor { get; set; }
        void Draw(Graphics graphics);
        bool Hit(Point location, Size dimensions);
        void Animate(Size boardSize);
    }
}
