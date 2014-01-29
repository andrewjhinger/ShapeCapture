using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShapeCapture
{
    public interface ICaptureShape : IShape
    {
        // AH This interface inherits from IShape. Includes only a property
        // AH indicating how many points the shape is worth, and a method to be called when the shape has been collected.
        int Points { get; set; }
        void OnCollected(Random random, Size boardSize);
    }
}