using System;
using System.Collections.Generic;

using UnityEngine;


namespace AudioController
{
	public class AudioLoader : Singleton<AudioLoader>
	{

#region Fields
	
		private Dictionary<AudioType, AudioClip> audioClips;

#endregion

#region Unity Methods

		protected override void Awake()
		{
			base.Awake();
		}

#endregion

#region Methods

		private void LoadAudioClips()
		{
			audioClips = new Dictionary<AudioType, AudioClip>();
			AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio");

			foreach (AudioClip clip in clips)
			{
				if (Enum.TryParse(clip.name, out AudioType clipName)) // Convierte el nombre del clip al enum
				{
					audioClips.Add(clipName, clip);
				}
				else
				{
					Debug.LogWarning($"El audio '{clip.name}' no tiene un valor correspondiente en el enum AudioType.");
				}
			}
		}

		public Dictionary<AudioType, AudioClip> GetAudioClips()
		{
			return audioClips;
		}

		public AudioClip GetClip(AudioType clipName)
		{
			if (audioClips.ContainsKey(clipName))
			{
				return audioClips[clipName];
			}

			Debug.LogWarning($"El clip {clipName} no se encuentra cargado.");
			return null;
		}

#endregion

	}
}