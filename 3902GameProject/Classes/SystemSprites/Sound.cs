using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _3902GameProject.Classes.SystemSprites
{
    public static class Sound{

        //Music variables
        public static Song mainTheme;
        public static Song underworldTheme;
        public static Song underwaterTheme;
        public static Song castleTheme;
        public static Song starmanTheme;
        public static Song levelcompleteTheme;
        public static Song deadTheme;
        public static Song gameover1Theme;
        public static Song gameover2Theme;
        public static Song tunnelTheme;
        public static Song endingTheme;
        public static Song hurryTheme;
        public static Song hurryUndergroundTheme;
        public static Song hurryUnderwaterTheme;
        public static Song hurryCastleTheme;
        public static Song hurryStarmanTheme;
        public static Song hurryOverworldTheme;
        public static Song silence;
        public static Song castleComplete;

        //Effect variables
        public static SoundEffect powerup1upEffect;
        public static SoundEffect bowserFallEffect;
        public static SoundEffect bowerFireEffect;
        public static SoundEffect breakBlockEffect;
        public static SoundEffect bumpEffect;
        public static SoundEffect coinEffect;
        public static SoundEffect fireballEffect;
        public static SoundEffect fireworksEffect;
        public static SoundEffect flagpoleEffect;
        public static SoundEffect gameoverEffect;
        public static SoundEffect jumpSmallEffect;
        public static SoundEffect jumpSuperEffect;
        public static SoundEffect kickEffect;
        public static SoundEffect marioDieEffect;
        public static SoundEffect pauseEffect;
        public static SoundEffect pipeEffect;
        public static SoundEffect powerupEffect;
        public static SoundEffect powerupAppearsEffect;
        public static SoundEffect scoreEffect;
        public static SoundEffect stageClearEffect;
        public static SoundEffect stompEffect;
        public static SoundEffect swimEffect;
        public static SoundEffect vineEffect;
        public static SoundEffect warningEffect;
        public static SoundEffect worldClearEffect;

        public static void InitializeSounds(ContentManager Content)
        {
            LoadSounds(Content);
        }

        public static void LoadSounds(ContentManager Content)
        {
            //Music Initialize 
            mainTheme = Content.Load<Song>("Music/Level/01-main-theme-overworld");
            underworldTheme = Content.Load<Song>("Music/Level/02-underworld");
            underwaterTheme = Content.Load<Song>("Music/Level/03-underwater");
            castleTheme = Content.Load<Song>("Music/Level/04-castle");
            starmanTheme = Content.Load<Song>("Music/Level/05-starman");
            levelcompleteTheme = Content.Load<Song>("Music/Level/06-level-complete");
            castleComplete = Content.Load<Song>("Music/Level/07-castle-complete");
            deadTheme = Content.Load<Song>("Music/Level/08-you-re-dead");
            gameover1Theme = Content.Load<Song>("Music/Level/09-game-over");
            gameover2Theme = Content.Load<Song>("Music/Level/10-game-over-2");
            tunnelTheme = Content.Load<Song>("Music/Level/11-into-the-tunnel");
            endingTheme = Content.Load<Song>("Music/Level/12-ending");
            hurryTheme = Content.Load<Song>("Music/Level/13-hurry");
            hurryUndergroundTheme = Content.Load<Song>("Music/Level/14-hurry-underground-");
            hurryUnderwaterTheme = Content.Load<Song>("Music/Level/15-hurry-underwater-");
            hurryCastleTheme = Content.Load<Song>("Music/Level/16-hurry-castle-");
            hurryStarmanTheme = Content.Load<Song>("Music/Level/17-hurry-starman-");
            hurryOverworldTheme = Content.Load<Song>("Music/Level/18-hurry-overworld-");


            //Effect Initialize
            powerup1upEffect = Content.Load<SoundEffect>("Music/smb_1-up");
            bowserFallEffect = Content.Load<SoundEffect>("Music/smb_bowserfall");
            bowerFireEffect = Content.Load<SoundEffect>("Music/smb_bowserfire");
            breakBlockEffect = Content.Load<SoundEffect>("Music/smb_breakblock");
            bumpEffect = Content.Load<SoundEffect>("Music/smb_bump");
            coinEffect = Content.Load<SoundEffect>("Music/smb_coin");
            fireballEffect = Content.Load<SoundEffect>("Music/smb_fireball");
            fireworksEffect = Content.Load<SoundEffect>("Music/smb_fireworks");
            flagpoleEffect = Content.Load<SoundEffect>("Music/smb_flagpole");
            gameoverEffect = Content.Load<SoundEffect>("Music/smb_gameover");
            jumpSmallEffect = Content.Load<SoundEffect>("Music/smb_jumpsmall");
            jumpSuperEffect = Content.Load<SoundEffect>("Music/smb_jump-super");
            kickEffect = Content.Load<SoundEffect>("Music/smb_kick");
            marioDieEffect = Content.Load<SoundEffect>("Music/smb_mariodie");
            pauseEffect = Content.Load<SoundEffect>("Music/smb_pause");
            pipeEffect = Content.Load<SoundEffect>("Music/smb_pipe");
            powerupEffect = Content.Load<SoundEffect>("Music/smb_powerup");
            powerupAppearsEffect = Content.Load<SoundEffect>("Music/smb_powerup_appears");
            scoreEffect = Content.Load<SoundEffect>("Music/smb_score");
            stageClearEffect = Content.Load<SoundEffect>("Music/smb_stage_clear");
            stompEffect = Content.Load<SoundEffect>("Music/smb_stomp");
            swimEffect = Content.Load<SoundEffect>("Music/smb_stomp");
            vineEffect = Content.Load<SoundEffect>("Music/smb_vine");
            warningEffect = Content.Load<SoundEffect>("Music/smb_warning");
            worldClearEffect = Content.Load<SoundEffect>("Music/smb_world_clear");

        }

    }
}
