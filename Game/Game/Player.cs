using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;


namespace Game
{
    public class Player
    {
        //the current position of the player
        public Point Position { get; set; }

        //the bounds where the player can move
        public Rectangle Bounds { get; set; }

        //number of lifes the player has
        public int Lifes { get; set; }

        //number of points the player has scored
        public int Score { get; set; }

        //image representing the player
        public Bitmap Image { get; set; }

        //the width of the player
        public static readonly int WIDTH = 88;

        //the height of the player
        public static readonly int HEIGHT = 165;

        //velocity for moving left and right
        public static readonly int VELOCITY_X = 15;

        //velocity for jumping up and down
        public static readonly int VELOCITY_Y = 120;

        public Player(Rectangle bounds)
        {
            Bounds = bounds;
            
            //position of the player in the middle of the form
            Position = new Point(Bounds.Right / 2, Bounds.Bottom - HEIGHT-65);

            //in the beginning the player has 3 lifes and 0 score
            Lifes = 3;
            Score = 0;

            Bitmap img = new Bitmap(Game.Properties.Resources.princeza);
            Image = img;

        }

        //move left withing the bounds
        public void MoveLeft()
        {
            if (Position.X -VELOCITY_X >= Bounds.Left)
            {
                Position = new Point(Position.X - VELOCITY_X, Position.Y);
               
            }
        }

        //move right within the bounds
        public void MoveRight()
        {
            if (Position.X + 22 + WIDTH <= Bounds.Right)
            {

                Position = new Point(Position.X + VELOCITY_X, Position.Y);
                
            }
        }

        //jumps up
        public void JumpUp()
        {
            Position = new Point(Position.X, Position.Y - VELOCITY_Y);
        }


        //jumps back down 
        public void JumpDown()
        {
            Position = new Point(Position.X, Position.Y + VELOCITY_Y);
        }

        
        //checks if the rectangle representing the player touches the circle representing the black ball
        //returns true if they have touched
        public bool TouchesBlackBall(Point position)
        {
            int dx = position.X-Math.Max(Position.X, Math.Min(position.X, Position.X + WIDTH));
            int dy = position.Y - Math.Max(Position.Y, Math.Min(position.Y, Position.Y + HEIGHT));
            return (dx * dx + dy * dy) <= BlackBall.RADIUS * BlackBall.RADIUS;

        }

        //draws the player on graphics
        public void Draw(Graphics g)
        {
            g.DrawImage(Image, Position.X, Position.Y, WIDTH, HEIGHT);
        }

        //returns if player is dead
        public bool IsDead()
        {
            return Lifes == 0;
        }
    }
}
