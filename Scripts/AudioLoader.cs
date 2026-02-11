using System;
using System.Collections.Generic;

using UnityEngine;


namespace AudioController
{
	public static class AudioLoader
	{
		private static Dictionary<AudioType, AudioClip> audioClips;

		private static void LoadAudioClips()
		{
			audioClips = new ();
			AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio");

			foreach (AudioClip clip in clips)
			{
				if (Enum.TryParse(clip.name, out AudioType clipName)) 
				{
					audioClips.Add(clipName, clip);
				}
				else
				{
					Debug.LogWarning($"El audio '{clip.name}' no tiene un valor correspondiente en el enum AudioType.");
				}
			}
		}

		public static Dictionary<AudioType, AudioClip> GetAudioClips()
		{
			return audioClips;
		}

		public static AudioClip GetClip(AudioType clipName)
		{
			if (audioClips.ContainsKey(clipName))
			{
				return audioClips[clipName];
			}

			Debug.LogWarning($"El clip {clipName} no se encuentra cargado.");
			return null;
		}
	}
}