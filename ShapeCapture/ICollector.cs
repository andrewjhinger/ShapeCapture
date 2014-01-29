using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShapeCapture
{
    public interface ICollector
    {
        /*AH The following properties and methods belong to the Interface and must be implemented.
        includes properties that tabulate the number of shapes that have been collected, 
        the total number of points from items that have been collected, 
        a Collect method to enable the Collector to collect a shape, and a method to reset the Collector. */
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