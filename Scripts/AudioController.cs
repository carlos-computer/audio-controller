using System.Collections.Generic;

using UnityEngine;


namespace AudioController
{
	public sealed class AudioController : MonoBehaviour, IAudioBase
	{
		private AudioSource audioSource;
		private Dictionary<AudioType, AudioClip> audioClips;
		[Range(0f, 1f)] public float volume = 1f;

		private void Start()
		{
			audioSource = GetComponent<AudioSource>();
			audioClips = AudioLoader.Instance.GetAudioClips();
		}

		public void Play(AudioType type, bool loop = false)
		{
			if (audioClips.TryGetValue(type, out AudioClip? value))
			{
				audioSource.clip = value;
				audioSource.loop = loop;
				audioSource.volume = volume;
				audioSource.Play();
			}
			else
			{
				Debug.LogWarning($"AudioClip '{type}' no encontrado.");
			}
		}

		public void Stop()
		{
			audioSource.Stop();
		}

		public void SetVolume(float volume)
		{
			this.volume = Mathf.Clamp01(volume);
			audioSource.volume = this.volume;
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
			audioSource.volume = startVolume;
		}
	}
}