using Godot;
using System.Collections.Generic;
using Scripts.Enums.Text;
using Scripts.Enums.Speakers;

namespace Scripts.Dictionaries.Text
{
	public static class VoiceDictionary
	{
		public static Dictionary<VoiceNames, AudioStream> Sounds = new()
		{
			{ VoiceNames.MAN, GD.Load<AudioStream>("res://Assets/SFX/MAN.ogg") },
			{ VoiceNames.MAN2, GD.Load<AudioStream>("res://Assets/SFX/MAN2.ogg") },
			{ VoiceNames.WOMAN, GD.Load<AudioStream>("res://Assets/SFX/WOMAN.ogg") },
			{ VoiceNames.KEVIN, GD.Load<AudioStream>("res://Assets/SFX/KEVIN.ogg") },
			{ VoiceNames.COBRA, GD.Load<AudioStream>("res://Assets/SFX/COBRA.ogg") }
		};
	}
}
