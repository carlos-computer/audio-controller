

using UnityEngine;


namespace AudioController
{
	public interface IAudioBase
	{

#region Methods
	
		public void Play(AudioType type, bool loop = false);
		public void Stop();
    	public void SetVolume(float volume);

#endregion

	}
}