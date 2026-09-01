using Scripts.Data;

namespace Scripts.Data.Class.Dialogue
{
	public class CharacterManager
	{
		private CharacterDictionary characterDictionary;

		public CharacterManager(
			CharacterData[] characters)
		{
			characterDictionary =
				new CharacterDictionary(
					characters
				);
		}

		public CharacterData GetCharacter(
			string name)
		{
			return characterDictionary.Get(name);
		}

		public EmotionData GetEmotion(
			CharacterData character,
			string emotionName)
		{
			if (character == null)
				return null;

			if (character.emotions == null)
				return null;

			foreach (EmotionData emotion
				in character.emotions)
			{
				if (emotion == null)
					continue;

				if (emotion.name.Equals(
					emotionName,
					System.StringComparison.OrdinalIgnoreCase))
				{
					return emotion;
				}
			}

			return null;
		}
	}
}
