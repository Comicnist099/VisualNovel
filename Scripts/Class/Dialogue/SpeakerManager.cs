using System;
using Godot;
using Scripts.Data;
using Scripts.Dictionaries.Text;
using Scripts.Enums.Text;

namespace Scripts.Data.Class.Dialogue
{
    public class SpeakerManager
    {
        private CharacterData characterData;

        public SpeakerManager(CharacterData characterData)
        {
            this.characterData = characterData;
        }

        public string GetName()
        {
            return characterData.person.name;
        }

        public string GetNickName()
        {
            return characterData.person.nickname;
        }

        public Color GetFavoriteColor()
        {
            ColorNames colorName = Enum.Parse<ColorNames>("DEFAULT"); 
			if(characterData.person.favoriteColor != null && characterData.person.favoriteColor.Length > 0)
			{
				colorName = 
				Enum.Parse<ColorNames>(
						characterData.person.favoriteColor
					);
			}  
			return ColorDictionary.Color[colorName];
        }

    }
}
