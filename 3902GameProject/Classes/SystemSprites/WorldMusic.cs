using _3902GameProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902GameProject.Classes.SystemSprites
{
    public class WorldMusic : Game1
    {
        public WorldMusic(string songPath, Song song)
        {
            this.SongPath = songPath;
            this.Song = song;
            this.Song = Content.Load<Song>(this.SongPath);
            MediaPlayer.Play(this.Song);
        }

        public Song Song { get; private set; }

        public string SongPath { get; set; }
        
    }
}