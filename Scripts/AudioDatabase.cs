using System;

using UnityEngine;


namespace AudioController
{
	[CreateAssetMenu(fileName = "AudioDatabase", menuName = "Audio/Audio Database")]
	public class AudioDatabase : ScripteableObject
	{
		[SerializedField] private readonly AudioClipEntry[] _audioClips;
		public AudioClipEntry[] AudioClips => _audioClips;	
	}

	[Serializable]
	public class AudioClipEntry
	{
		public AudioType type;
		public AudioClip clip;
	}

	public enum AudioType
	{
		BackgroundMusic = 0,
		JumpSound = 1,
		Explosion = 2,
		Victory = 3,
		Defeat = 4,
	}
}