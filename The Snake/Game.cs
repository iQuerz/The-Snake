using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Snake
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();

        }
        TheSnek snake = new TheSnek(new Point(200, 200));

        private void Game_Load(object sender, EventArgs e)
        {
            this.Width = 1200;
            this.Height = 900;
            this.Text = "s n e k";
            pictureBox1.Width = this.ClientRectangle.Width;
            pictureBox1.Height = this.ClientRectangle.Height;
            snake.NewFruit();
            timer1.Interval = (int)snake.speed/snake.multiplier;
            snake.Add();
            snake.Add();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 10), 15, 15, 1000, 560);
            e.Graphics.FillEllipse(Brushes.Red, snake.fruit.X, snake.fruit.Y, 20, 20);
            for (int i = 0; i < snake.snek.Count; i++)
            {
                e.Graphics.FillEllipse(Brushes.Black, snake.snek[i].X, snake.snek[i].Y, 20, 20);

            }

            e.Graphics.DrawString("Score: " + snake.Score.ToString(), this.Font, Brushes.Black, this.Width/2, 700);
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            snake.Move();
            if (i == snake.multiplier-1)
            {
                if (snake.CheckDieded())
                    this.Dispose();
                if (snake.CheckFruitHit())
                {
                    snake.Score += Convert.ToInt32((2000 - br) / snake.speed);
                    br = 0;
                    snake.NewFruit();
                    snake.Add();
                    snake.SpeedUp();
                    timer1.Interval = (int)snake.speed / snake.multiplier;
                }
                i = 0;
            }
            i++; //moving the snake more frequently just to look smoother
            pictureBox1.Refresh();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
        //    if (e.KeyCode == Keys.W)
        //    {
        //        snake.DirectionChange("N");
        //    }
        //    if (e.KeyCode == Keys.A)
        //    {
        //        snake.DirectionChange("W");
        //    }
        //    if (e.KeyCode == Keys.S)
        //    {
        //        snake.DirectionChange("S");
        //    }
        //    if (e.KeyCode == Keys.D)
        //    {
        //        snake.DirectionChange("E");
        //    }
        }
        int br = 0;
        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w' || e.KeyChar == 'W')
            {
                snake.DirectionChange("N");
            }
            if (e.KeyChar == 'a' || e.KeyChar == 'A')
            {
                snake.DirectionChange("W");
            }
            if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                snake.DirectionChange("S");
            }
            if (e.KeyChar == 'd' || e.KeyChar == 'D')
            {
                snake.DirectionChange("E");
            }
            if(e.KeyChar == 'p')
            {
                snake.speed = snake.speed;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            br++;
            if (br == 201)
                br--;
        }
    }
}