using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace The_Snake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AudioEngine audio = new AudioEngine();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1280;
            this.Height = 720;
            button1.Location = new Point(100, 390);
            button2.Location = new Point(100, 510);
            checkBox1.Checked = true;
            checkBox1.Location = new Point(button2.Location.X + button2.Width + 15, button2.Location.Y + button2.Height / 2 - checkBox1.Height / 2);
            this.Text = "s n e k";

            audio = new AudioEngine();
            audio.play();
        }

        public void resetAudio() {
            audio.reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            audio.pause();
            Game game = new Game(audio, this);
            game.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1.Checked)
                audio.enable();
            else audio.disable();
        }
    }
}
