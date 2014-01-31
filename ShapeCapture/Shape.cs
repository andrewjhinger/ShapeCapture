using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShapeCapture
{
    public abstract class Shape : IShape
    {
        //enum controls both where the shape starts, and the direction the shape will move when animated.
        private enum StartingPositions { Top, Bottom, Left, Right }

        private StartingPositions _startPosition;
        private Point _location;
        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }
        private Size _dimensions;
        public Size Dimensions
        {
            get { return _dimensions; }
            set { _dimensions = value; }
        }
        private Color _fillColor;
        public Color FillColor
        {
            get { return _fillColor; }
            set { _fillColor = value; }
        }

        public Shape(Color color)
        {
            _fillColor = color;
        }
        public bool Hit(Point location, Size dimensions)
        {
            // Check rectangle 1 against rectangle 2 to detect a collision checking left, right,
            // top, then bottom to see if any way they collide, then negate result
            Rectangle r1 = new Rectangle(location, dimensions);
            Rectangle r2 = new Rectangle(_location, _dimensions);
            //test to find out whether any of the sides of one rectangle could possibly be within the other rectangle.
            return !(r1.X + r1.Width < r2.X || r1.Y + r1.Height < r2.Y || r1.X > r2.X + r2.Width || r1.Y > r2.Y + r2.Height);
        }
        public void Animate(Size boardSize)
        {
            switch (_startPosition)
            {
                case Shape.StartingPositions.Top:
                    _location.Y++;
                    if (_location.Y >= boardSize.Height) _location.Y = 0 - _dimensions.Height;
                    break;
                case Shape.StartingPositions.Bottom:
                    _location.Y--;
                    if (_location.Y + _dimensions.Height <= 0) _location.Y = boardSize.Height;
                    break;
                case Shape.StartingPositions.Left:
                    _location.X++;
                    if (_location.X >= boardSize.Width) _location.X = 0 - _dimensions.Width;
                    break;
                case Shape.StartingPositions.Right:
                    _location.X--;
                    if (_location.X + _dimensions.Width <= 0) _location.X = boardSize.Width;
                    break;
            }
        }



        public void Reset(Random random, Size boardSize)
        {
            // Generate random starting position
            var values = Enum.GetValues(typeof(StartingPositions));
            int positionIndex = random.Next(values.Length);
            int counter = 0;
            foreach (var value in values)
            {
                if (counter++ == positionIndex)
                {
                    _startPosition = (StartingPositions)value;
                    break;
                }
            }
            // Based on starting position, generate actual random x or y
            switch (_startPosition)
            {
                case StartingPositions.Top:
                    _location = new Point(random.Next(boardSize.Width - _dimensions.Width), 0);
                    break;
                case StartingPositions.Bottom:
                    _location = new Point(random.Next(boardSize.Width - _dimensions.Width), boardSize.Height);
                    break;
                case StartingPositions.Left:
                    _location = new Point(0, random.Next(boardSize.Height - _dimensions.Height));
                    break;
                case StartingPositions.Right:
                    _location = new Point(boardSize.Width - _dimensions.Width, random.Next(boardSize.Height - _dimensions.Height));
                    break;
            }
        }

        public abstract void Draw(Graphics graphics);
    }
}
