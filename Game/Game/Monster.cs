using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Monster : FallingObject
    {
        public static readonly int WIDTH = 55;

        public static readonly int HEIGHT = 50;

        public Monster(Rectangle bounds, Point position) : base(bounds, position)
        {
            Bitmap img = new Bitmap(Game.Properties.Resources.Monster);
            Image = img;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Image, Position.X, Position.Y, WIDTH, HEIGHT);
        }

        public override bool Touches(Point position, int width, int height)
        {
            Rectangle r1 = new Rectangle(Position.X, Position.Y, WIDTH, HEIGHT);
            Rectangle r2 = new Rectangle(position.X, position.Y, width, height);
            return r1.IntersectsWith(r2);
        }

        public override bool HitTheFloor()
        {
            return Position.Y >= Bounds.Bottom - HEIGHT;
        }

        public override char GetCode()
        {
            return 'M';
        }
    }
}
