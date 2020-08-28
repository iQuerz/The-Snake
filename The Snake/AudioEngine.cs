using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace The_Snake {
    public class AudioEngine {
        private SoundPlayer player;
        private bool disabled = false;
        public AudioEngine() {
            player = new SoundPlayer("intro.wav");
        }

        public void setFile(string path) {
            player = new SoundPlayer(path);
        }
        public void play() {
            if (!disabled)
                player.PlayLooping();
        }
        public void playDeath() {
            player = new SoundPlayer("oof.wav");
            player.Play();
        }
        public void pause() {
            player.Stop();
        }
        public void disable() {
            disabled = true;
            pause();
        }
        public void enable() {
            disabled = false;
            play();
        }
        public void reset() {
            player = new SoundPlayer("intro.wav");
            play();
        }
    }
}
