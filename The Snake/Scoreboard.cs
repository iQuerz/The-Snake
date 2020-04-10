using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace The_Snake
{
    public partial class Scoreboard : Form
    {
        public Scoreboard()
        {
            InitializeComponent();
        }

        private void Scoreboard_Load(object sender, EventArgs e)
        {
            int score = Game.playerscore;
            set(score);
        }
        private void set(int score)
        {
            label1.ForeColor = Color.White;
            label1.Text = "You Died! Your snake scored " + score + "!";
            label1.Location = new Point(-label1.Width / 2 + this.ClientRectangle.Width/2, label1.Location.Y);
            listBox1.Location = new Point(-listBox1.Width / 2 + this.ClientRectangle.Width / 2, label1.Location.Y + label1.Height + this.FontHeight);

            StreamReader sr = new StreamReader("scores.txt");
            int i = 0;
            List<string> names = new List<string>();
            List<int> scores = new List<int>();
            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(' ');
                names.Add(s[0]);
                scores.Add(Convert.ToInt32(s[1]));
                listBox1.Items.Add(names[i] + " - " + scores[i] + " pointerinos");
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
