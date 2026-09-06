using Godot;
using Scripts.Data;
using Scripts.Dictionaries.Text;
using Scripts.Enums.Fonts;
using Scripts.Enums.Speakers;
using Scripts.Enums.Text;
using System;

namespace Scripts.Data.Class.Dialogue
{
	public class ContentManager
	{
		private string text;
		private EmotionData emotionData;

		private AudioStreamPlayer voiceSFX;

		private int visibleCharacters = 0;
		private float textTimer = 0f;

		public ContentManager(
			string text,
			EmotionData emotionData,
			AudioStreamPlayer voiceSFX)
		{
			this.text = text;
			this.emotionData = emotionData;
			this.voiceSFX = voiceSFX;
		}

		public void Update(double delta)
		{
			if (visibleCharacters >= text.Length)
				return;

			textTimer += (float)delta;

			SpeedNames speedName =
				Enum.Parse<SpeedNames>(
					emotionData.text.speed
				);

			float speedFloat =
				SpeedDictionary.Speed[speedName];

			if (textTimer >= speedFloat)
			{
				visibleCharacters++;
				textTimer = 0f;

				if (text[visibleCharacters - 1] != ' ')
					PlayVoice();
			}
		}

		private void PlayVoice()
		{
			VoiceNames voiceName =
				Enum.Parse<VoiceNames>(
					emotionData.voice.name
				);

			EmotionNames emotionName =
				Enum.Parse<EmotionNames>(
					emotionData.voice.emotion
				);

			AudioStream voice =
				VoiceDictionary.Sounds[voiceName];

			float emotion =
				EmotionDictionary.Emotion[emotionName];

			float variation =
				(float)GD.RandRange(-0.04, 0.04);

			voiceSFX.Stream = voice;
			voiceSFX.PitchScale =
				emotion + variation;

			voiceSFX.Play();
		}

		public void ShowAll()
		{
			visibleCharacters = text.Length;
			textTimer = 0f;
		}

		public bool IsFinished()
		{
			return visibleCharacters >= text.Length;
		}

		public string GetVisibleText()
		{
			return text.Substring(
				0,
				visibleCharacters
			);
		}

		public int GetSize()
		{
			SizeNames sizeName =
				Enum.Parse<SizeNames>(
					emotionData.text.size
				);

			return SizeDictionary.Sizes[sizeName];
		}

		public void Reset()
		{
			visibleCharacters = 0;
			textTimer = 0f;
		}

        public Font GetFont()
        {
			FontNames fontName = Enum.Parse<FontNames>("DEFAULT"); 
			if(emotionData.text.font != null)
			{
				fontName = 
				Enum.Parse<FontNames>(
						emotionData.text.font
					);
			}  
			return FontDictionary.Fonts[fontName];
        }
    }
}
