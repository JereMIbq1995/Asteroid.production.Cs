using Raylib_cs;

namespace genie.services.raylib {
    class RaylibAudioService {
        
        private Dictionary<string, Sound> soundCache;
        
        public RaylibAudioService() {
            Raylib.InitAudioDevice();
            this.soundCache = new Dictionary<string, Sound>();
        }

        private Sound LoadSound(string path) {
            Sound sound = Raylib.LoadSound(path);
            this.soundCache[path] = sound;
            return sound;
        }

        public void PlaySound(string path, float volume = 1) {
            try {

                //Determine whether to pull from the cache or load new
                Sound sound = !this.soundCache.ContainsKey(path) ? this.LoadSound(path) : this.soundCache[path];
                
                // Set the volume
                Raylib.SetSoundVolume(sound, volume);

                // Play!
                Raylib.PlaySound(sound);

            }
            catch (Exception e) {
                // In case path is not found...
                Console.WriteLine(e.Message);
            }
        }
    }
}