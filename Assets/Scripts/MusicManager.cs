

using System.Collections;

using UnityEngine;


namespace AudioController
{
	public class MusicManager : AudioBase
	{

#region Fields
	
		public override void Play(AudioType type, bool loop = true)
		{
			base.Play(type, loop);
		}

		public void FadeOutMusic(float duration)
		{
			StartCoroutine(FadeOut(duration));
		}

		private IEnumerator FadeOut(float duration)
		{
			float startVolume = audioSource.volume;

			while (audioSource.volume > 0)
			{
				audioSource.volume -= startVolume * Time.deltaTime / duration;
				yield return null;
			}

			audioSource.Stop();
			audioSource.volume = startVolume; // Restaurar el volumen original
		}

#endregion

	}
}