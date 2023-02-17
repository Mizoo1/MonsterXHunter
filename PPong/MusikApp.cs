using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using static SDL2.SDL;
using static SDL2.SDL_mixer;
namespace Monster
{
    class MusicApp
    {
        private IntPtr l;
        bool success = true;
        private String file;


        public MusicApp(String s)
        {
            this.file = s;
            Instalize();
            loadMedia();
        }
        public void playMusik()
        {
            Mix_PlayMusic(l, 0);
        }
        public void Instalize()
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_AUDIO) < 0)
            {
                SDL_Log("IMAGE_FAILD");
                success = false;
            }

            if (Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 1, 1024) < 0)
            {
                SDL_Log("MIXER_FAILD");
                success = false;
            }
        }
        bool loadMedia()
        {

            //Load music
            l = Mix_LoadMUS(file);
            if (l == IntPtr.Zero)
            {
                SDL_Log("LoadMUS_FAILD");
                success = false;
            }
            return success;
        }

        public void close()
        {
            Mix_HaltMusic();
        }
    }
}
