using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShapeCapture
{
    public class EllipseCaptureShape : Shape, ICaptureShape
    {
        //inheritance from Shape, and the implementation of ICaptureShape.
        public EllipseCaptureShape(Random random, Size dimensions, Size boardSize, Color color, int Points)
            : base(color)
        {
            _Points = Points;
            base.Dimensions = dimensions;
            base.Reset(random, boardSize);
        }

        private int _Points;
        public int Points
        {
            get { return _Points; }
            set { _Points = value; }
        }


        //Draws Ellipse
        public override void Draw(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(base.FillColor))
                graphics.FillEllipse(brush, new Rectangle(base.Location, base.Dimensions));
        }

        public void OnCollected(Random random, Size boardSize)
        {
            base.Reset(random, boardSize);
        }
    }
}
