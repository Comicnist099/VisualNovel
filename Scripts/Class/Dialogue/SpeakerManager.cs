using Scripts.Data;

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
    }
}
