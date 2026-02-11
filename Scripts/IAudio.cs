using UnityEngine;


namespace AudioController
{
	public interface IAudio
	{
		public void Play(AudioType type, bool loop = false);
		public void Stop();
    	public void SetVolume(float volume);
	}
}