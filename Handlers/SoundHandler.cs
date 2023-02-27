using OceansFortune.Game.DataTypes;
using Raylib_cs;

namespace OceansFortune.Handlers
{
    
    public class SoundHandler
    {
        Sound seagull;
        Sound ambience;
        public SoundHandler()
        {
            Raylib.InitAudioDevice();
            this.seagull = Raylib.LoadSound("res/gull.ogg");
            Raylib.SetSoundVolume(this.seagull, 0.2f);
            this.ambience = Raylib.LoadSound("res/ambience.ogg");
        }


        public void PlaySound(Sounds sound)
        {
            switch(sound)
            {
                case Sounds.Seagull:
                    Raylib.PlaySoundMulti(this.seagull);
                    break;
                case Sounds.Ambience:
                    if (!Raylib.IsSoundPlaying(this.ambience))
                    {
                        Raylib.PlaySound(this.ambience);
                    }
                    break;
            }
        }

        public void CleanUp()
        {
            Raylib.StopSoundMulti();
            Raylib.UnloadSound(this.seagull);
            Raylib.UnloadSound(this.ambience);
            Raylib.CloseAudioDevice();
        }


    }
}
