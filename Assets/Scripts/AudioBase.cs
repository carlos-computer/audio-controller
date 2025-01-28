

using System.Collections.Generic;

using UnityEngine;

namespace AudioController
{
	public abstract class AudioBase : MonoBehaviour, IAudioBase
	{

#region Fields
	
		protected AudioSource audioSource;
		protected Dictionary<AudioType, AudioClip> audioClips;

		[Range(0f, 1f)] public float volume = 1f;
		
#endregion

#region Methods

		protected virtual void Start()
		{
			audioSource = GetComponent<AudioSource>();
			audioClips = AudioLoader.Instance.GetAudioClips();
		}

		public virtual void Play(AudioType type, bool loop = false)
		{
			if (audioClips.ContainsKey(type))
			{
				audioSource.clip = audioClips[type];
				audioSource.loop = loop;
				audioSource.volume = volume;
				audioSource.Play();
			}
			else
			{
				Debug.LogWarning($"AudioClip '{type}' no encontrado.");
			}
		}

		public virtual void Stop()
		{
			audioSource.Stop();
		}

		public virtual void SetVolume(float volume)
		{
			this.volume = Mathf.Clamp01(volume);
			audioSource.volume = this.volume;
		}

#endregion

	}
}