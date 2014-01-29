using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShapeCapture
{
    //AH inheritance from Shape, and the implementation of ICaptureShape.
    public class RectangleCaptureShape : Shape, ICaptureShape
    {
        public RectangleCaptureShape(Random random, Size dimensions, Size boardSize, Color color, int points)
            : base(color)
        {
            _points = points;
            base.Dimensions = dimensions;
            base.Reset(random, boardSize);
        }

        private int _points;
        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        //AH Draws Rectangles
        public override void Draw(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(base.FillColor))
                graphics.FillRectangle(brush, new Rectangle(base.Location, base.Dimensions));
        }

        public void OnCollected(Random random, Size boardSize)
        {
            base.Reset(random, boardSize);
        }
    }
}