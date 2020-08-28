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
        AudioEngine audio;
        Form1 mainMenu;
        int score;
        List<string> names = new List<string>();
        List<int> scores = new List<int>();
        public Scoreboard(AudioEngine audio1, Form1 form)
        {
            InitializeComponent();
            audio = audio1;
            mainMenu = form;
        }

        private void Scoreboard_Load(object sender, EventArgs e)
        {
            score = Game.playerscore;
            set(score);
        }
        private void set(int score)
        {
            label1.ForeColor = Color.White;
            label1.Text = "You Died! Your snake scored " + score + "!";
            label1.Location = new Point(-label1.Width / 2 + this.ClientRectangle.Width/2, label1.Location.Y);
            listBox1.Location = new Point(-listBox1.Width / 2 + this.ClientRectangle.Width / 2, label1.Location.Y + label1.Height + this.FontHeight);
            textBox1.ForeColor = Color.White;
            textBox1.BackColor = Color.Black;
            textBox1.Text = "My snek's name";
            textBox1.Width = 500;
            textBox1.Location = new Point(this.ClientRectangle.Width / 2 - textBox1.Width / 2,label1.Location.Y-label1.Height-textBox1.Height/2);

            StreamReader sr = new StreamReader("scores.txt");
            int i = 0;
            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(' ');
                names.Add(s[0]);
                scores.Add(Convert.ToInt32(s[1]));
                listBox1.Items.Add(names[i] + " - " + scores[i] + " pointerinos");
                i++;
            }
            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "My snek's name" || textBox1.Text == "snek must have a name :((" || textBox1.Text == "") {
                textBox1.Text = "snek must have a name :((";
                return;
            }
            StreamWriter sw = new StreamWriter("scores.txt");
            bool checkCurrent = true;
            for (int i = 0; i < names.Count; i++) {
                if (checkCurrent && score >= scores[i]) {
                    sw.WriteLine(textBox1.Text + " " + score);
                    i--;
                    checkCurrent = false;
                }
                else sw.WriteLine(names[i] + " " + scores[i].ToString());
            }
            if (checkCurrent)
                sw.WriteLine(textBox1.Text + " " + score);
            sw.Flush();
            mainMenu.resetAudio();
            mainMenu.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e) {
            if (textBox1.Text == "My snek's name" || textBox1.Text == "snek must have a name :((" || textBox1.Text == "") {
                textBox1.Text = "";
                return;
            }
        }
    }
}
