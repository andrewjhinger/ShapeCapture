using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShapeCapture
{
    public class CaptureGame
    {
        private Size _boardSize;
        public Size BoardSize { set { _boardSize = value; } }
        private Random _random = new Random();
        private Collector _collector;
        
        //an array of interface implementations of the ICaptureShape interface
        private ICaptureShape[] _captureShapes;
        private ICaptureShape[] _deductShapes;

        public int CollectorHits { get { return _collector.Collected; } }
        public int CollectorPoints { get { return _collector.CollectedPoints; } }

        public Point CollectorPosition
        {
            set
            {
                value.X -= _collector.Dimensions.Width;
                value.Y -= _collector.Dimensions.Height;
                _collector.Location = value;
            }
        }

        public CaptureGame(int collectorShapeCount, Size boardSize)
        {
            _boardSize = boardSize;

            _captureShapes = new ICaptureShape[collectorShapeCount];
            _deductShapes = new ICaptureShape[collectorShapeCount];

            _collector = new Collector(Color.Blue, new Point(0, 0), new Size(30, 30));

            for (int i = 0; i < _captureShapes.Length; i++)
                    _captureShapes[i] = new EllipseCaptureShape(_random, new Size(20, 20), _boardSize, Color.Green, 5);

            for (int i = 0; i < _deductShapes.Length; i++)
                    _deductShapes[i] = new DeductShape(_random, new Size(10, 10), _boardSize, Color.Red, -5);


        }

        public void DrawCollectorShapes(Graphics graphics)
        {

            foreach (ICaptureShape collectorShape in _captureShapes)
                collectorShape.Draw(graphics);
            foreach (ICaptureShape collectorShape in _deductShapes)
                collectorShape.Draw(graphics);
             


        }

        public void AnimateCollectorShapes(int value)
        {
            //using for statement to change 

                for (int i = 0; i < _captureShapes.Length - value; i++)
                {
                    _captureShapes[i].Animate(_boardSize);
                    if (_captureShapes[i].Hit(_collector.Location, _collector.Dimensions))
                        _collector.Collect(_captureShapes[i], _random, _boardSize);
                }
                for (int i = 0; i < _deductShapes.Length - value; i++)
                {
                    _deductShapes[i].Animate(_boardSize);
                    if (_deductShapes[i].Hit(_collector.Location, _collector.Dimensions))
                        _collector.Collect(_deductShapes[i], _random, _boardSize);
                }

         }
        

        public void DrawCollector(Graphics graphics)
        {
            _collector.Draw(graphics);
        }

        public void Reset()
        {
            _collector.Reset();
        }
    }
}
