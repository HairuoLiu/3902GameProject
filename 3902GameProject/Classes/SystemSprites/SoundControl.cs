using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _3902GameProject.Classes.UtilityClasses;

namespace _3902GameProject.Classes.SystemSprites
{
    public static class SoundControl
    {
        private static bool muted = false;

        public static void PlaySoundEffect(SoundEffect effect)
        {
            effect.Play();
            // MediaPlayer.Play(effect);
            //MediaPlayer.IsRepeating = false;
        }

        public static void PlaySong(Song song, bool loop)
        {
            try
            {
                MediaPlayer.Stop();
                MediaPlayer.IsRepeating = loop;
                MediaPlayer.Play(song);
            }
            catch 
            {
                Console.WriteLine("Unable to play.");
                throw;
            }
        }

        public static bool IsPlaying()
        {
            return MediaPlayer.State != MediaState.Stopped;
        }

        public static void StopSong()
        {
            MediaPlayer.Stop();
        }

        public static void PauseSong()
        {
            MediaPlayer.Pause();
        }

        public static void UnpauseSong()
        {
            MediaPlayer.Resume();
        }

        public static void ToggleMute()
        {
            muted = !muted;
            MediaPlayer.Volume = muted ? 0 : SystemUtilityConsts.Volume;
            SoundEffect.MasterVolume = muted ? 0 : SystemUtilityConsts.Volume;
        }
    }
}
