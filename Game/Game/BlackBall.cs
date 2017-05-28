using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BlackBall
    {
        //the current position of the black ball
        public Point Position { get; set; }
        
        //the bounds in which the ball can move
        public Rectangle Bounds { get; set; }

        //the radius of each black ball
        public static readonly int RADIUS = 25;

        //the velocity with each black ball moves
        public static readonly int VELOCITY = 90;

        
        public static readonly Color COLOR = Color.Black;

        public BlackBall(Rectangle bounds)
        {
            Bounds = bounds;

            //staring position 
            Position = new Point(0, Bounds.Bottom - 2 * RADIUS-50);
        }

        //move the black ball to the right
        public void Move()
        {
            Position = new Point(Position.X +VELOCITY, Position.Y);
        }

        //draws the black ball
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(COLOR);
            g.FillEllipse(b, Position.X - RADIUS, Position.Y - RADIUS, 2 * RADIUS, 2 * RADIUS);
            b.Dispose();
        }
    }
}
