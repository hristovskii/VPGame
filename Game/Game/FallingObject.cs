using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public abstract class FallingObject
    {
        //the bounds in which the object can move
        public Rectangle Bounds { get; set; }

        //the current position of the falling object
        public Point Position { get; set; }

        //the image representing the falling object
        public Bitmap Image { get; set; }

        //the velocity that every falling object moves with
        private static int VELOCITY = 10;

        public FallingObject(Rectangle bounds, Point position)
        {
            Bounds = bounds;
            Position = position;
        }

        //moves the falling object down
        public void Move()
        {
            Position = new Point(Position.X, Position.Y + VELOCITY);
        }

        //increments the velocity of the falling objects (max 20)
        public static void UpdateVelocity()
        {
            if (VELOCITY < 20)
            {
                VELOCITY++;
            }
        }

        //draws the falling object 
        public abstract void Draw(Graphics g);

        //checkes if the rectangle representing the falling object touches the rectangle with the width, height and position 
        //returns true if they have touched 
        public abstract bool Touches(Point position, int width, int height);
        
        //checks if the falling object is outside the bounds
        public abstract bool HitTheFloor();

        //returns the code of each falling object (the code is unique depending on the class that inherits from FallingObject)
        public abstract char GetCode();
    }
}
