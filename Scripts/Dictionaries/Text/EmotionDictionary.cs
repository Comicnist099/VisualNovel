using Godot;
using System.Collections.Generic;
using Scripts.Enums.Text;

namespace Scripts.Dictionaries.Text
{
    public static class EmotionDictionary
    {
        public static Dictionary<EmotionNames, float> Emotion = new()
        {
            { EmotionNames.SCARY , 1.25f },
            { EmotionNames.HAPPY, 1.15f },
            { EmotionNames.NORMAL, 1f },
            { EmotionNames.SAD, 0.85f },    
            { EmotionNames.ANGRY, 0.7f },
        };
    }
}