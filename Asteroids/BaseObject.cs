using System;
using System.Drawing;

namespace Asteroids
{

    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        static Image image = Image.FromFile("Images\\star.png");
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public BaseObject(int x, int y, int dx, int dy, int width, int height)
        {
            Pos = new Point(x, y);
            Dir = new Point(dx, dy);
            Size = new Size(width, height);
        }


        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }


    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }

    class Asteroid : BaseObject
    {
        static Image image = Image.FromFile("Images\\asteroid.png");

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
         }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }

    

    class Flash : BaseObject
    {
        static Image image = Image.FromFile("Images\\flash.png");
        public Flash(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()

        {

            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);

        }

        public override void Update()
        {
            Random rand = new Random();

            Pos.X = rand.Next(0, Game.Width);
            Pos.Y = rand.Next(0, Game.Height);

        }
    }

    class Line : BaseObject
    {

        public Line(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()

        {

            Game.Buffer.Graphics.DrawLine(Pens.Silver, Pos.X, Pos.Y, Size.Width, Size.Height);

        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }

}

