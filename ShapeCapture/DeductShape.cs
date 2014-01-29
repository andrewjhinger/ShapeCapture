using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShapeCapture
{
    public class DeductShape : Shape, ICaptureShape
    {
        public DeductShape(Random random, Size dimensions, Size boardSize, Color color, int Points)
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