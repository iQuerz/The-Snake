using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace The_Snake
{
    class TheSnek
    {
        public List<Point> snek { get; set; }
        public string direction { get; set; }
        public bool NEDIRAIPOSLEDNJU { get; set; }
        public Point fruit { get; set; }
        public int Score { get; set; }
        public float speed { get; set; }
        private int size = 20;
        public int multiplier { get; set; } //I divide size by multiplier and call timer more frequently, for smoothness

        public TheSnek(Point p)
        {
            snek = new List<Point>();
            direction = "E";
            Score = 0;
            speed = 100;
            snek.Add(p);
            
            multiplier = 2;
        }
        public void ChangeSpeed(int newspeed)
        {
            speed = newspeed;
        }

        public void Add()
        {
            snek.Add(new Point(snek[snek.Count - 1].X, snek[snek.Count - 1].Y));
            NEDIRAIPOSLEDNJU = true;
        }
        public void DirectionChange(string newdirection)
        {
            if (newdirection == "W" && direction != "E" || newdirection == "E" && direction != "W" || newdirection == "N" && direction != "S" || newdirection == "S" && direction != "N")
                direction = newdirection;
        }
        public void Move()
        {
            if (!NEDIRAIPOSLEDNJU&&snek.Count>1)
            {
                snek[snek.Count - 1] = snek[snek.Count - 2];
            }
            else
                NEDIRAIPOSLEDNJU = !NEDIRAIPOSLEDNJU;
            if (direction == "E")
            {

                for (int i = snek.Count - 2; i > 0; i--)
                {
                    snek[i] = new Point(snek[i - 1].X, snek[i - 1].Y);
                }

                snek[0] = new Point(snek[0].X + size/multiplier, snek[0].Y);
            }
            else if (direction == "W")
            {

                for (int i = snek.Count - 2; i > 0; i--)
                {
                    snek[i] = new Point(snek[i - 1].X, snek[i - 1].Y);
                }
                snek[0] = new Point(snek[0].X - size/multiplier, snek[0].Y);
            }
            else if (direction == "N")
            {

                for (int i = snek.Count - 2; i > 0; i--)
                {
                    snek[i] = new Point(snek[i - 1].X, snek[i - 1].Y);
                }
                snek[0] = new Point(snek[0].X, snek[0].Y - size/multiplier);
            }
            else
            {

                for (int i = snek.Count - 2; i > 0; i--)
                {
                    snek[i] = new Point(snek[i - 1].X, snek[i - 1].Y);
                }
                snek[0] = new Point(snek[0].X, snek[0].Y + size/multiplier);
            }

            if (snek[0].X == 10)
                snek[0] = new Point(1000-size, snek[0].Y);

            if (snek[0].Y == 10)
                snek[0] = new Point(snek[0].X, 560-size);

            if (snek[0].Y == 560)
                snek[0] = new Point(snek[0].X, size);

            if (snek[0].X == 1000)
                snek[0] = new Point(size, snek[0].Y);
        }
        public bool CheckDieded()
        {
            for(int i = 1; i < snek.Count-1; i++)
            {
                if (snek[0].X == snek[i].X && snek[0].Y == snek[i].Y)
                {
                    return true;
                }
            }
            return false;
        }
        public void NewFruit()
        {
            bool pass = false;
            while (!pass)
            {
                Random r = new Random();
                fruit = new Point(r.Next(multiplier, 50) * 20 / multiplier, r.Next(multiplier, 28 / multiplier) * (20 / multiplier));
                bool pass2 = true;
                foreach(Point p in snek)
                {
                    if (touches(p, fruit))
                    {
                        pass2 = false;
                        break;
                    }
                }
                if (pass2)
                    pass = true;
            }
        }
        public bool CheckFruitHit()
        {
            if (snek[0].X > fruit.X - size && snek[0].X < fruit.X + size && snek[0].Y > fruit.Y - size && snek[0].Y < fruit.Y + size)
                return true;
            return false;
        }
        public void SpeedUp()
        {
            if (speed > 40)
                speed *= (float)0.9;
            else
                speed -= (float)0.5;
        }
        private bool touches(Point p, Point q)
        {
            if (p.X > q.X - size && p.X < q.X + size && p.Y > q.Y - size && p.Y < q.Y + size)
                return true;
            return false;
        }
    }
}
