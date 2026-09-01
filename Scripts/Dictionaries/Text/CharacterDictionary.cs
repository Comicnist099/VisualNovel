using System;
using System.Collections.Generic;

namespace Scripts.Data.Class.Dialogue
{
    public class CharacterDictionary
    {
        private Dictionary<string, CharacterData> characters;

        public CharacterDictionary(CharacterData[] characterData)
        {
            characters =
                new Dictionary<string, CharacterData>(
                    StringComparer.OrdinalIgnoreCase
                );

            foreach (CharacterData character in characterData)
            {
                if (character == null)
                    continue;

                if (character.person == null)
                    continue;

                if (string.IsNullOrEmpty(
                    character.person.name))
                    continue;

                characters[character.person.name] =
                    character;
            }
        }

        public CharacterData Get(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            characters.TryGetValue(
                name,
                out CharacterData character
            );

            return character;
        }
    }
}
