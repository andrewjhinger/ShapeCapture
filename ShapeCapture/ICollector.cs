using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShapeCapture
{
    public interface ICollector
    {
        Size Dimensions { get; set; }
        Point Location { get; set; }
        Color FillColor { get; set; }
        void Draw(Graphics graphics);
        int Collected { get; }
        int CollectedPoints { get; }
        void Collect(ICaptureShape collectorShape, Random random, Size boardSize);
        void Reset();
    }
}
