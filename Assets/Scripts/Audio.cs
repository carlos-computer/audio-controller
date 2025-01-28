
namespace AudioController
{
	public class Audio : Singleton<Audio>
	{
		public MusicManager musicManager;
		public SFXManager sfxManager;

		protected override void Awake()
		{
			base.Awake();
		}

		public void PlayMusic(AudioType clipName, bool loop = true)
		{
			musicManager.Play(clipName, loop);
		}

		public void StopMusic()
		{
			musicManager.Stop();
		}

		public void PlaySFX(AudioType clipName)
		{
			sfxManager.Play(clipName);
		}

		public void SetMusicVolume(float volume)
		{
			musicManager.SetVolume(volume);
		}

		public void SetSFXVolume(float volume)
		{
			sfxManager.SetVolume(volume);
		}
	}
}