using System.Collections.Generic;
using Godot;
using Scripts.Enums.Fonts; 

namespace Scripts.Dictionaries.Text
{
    public static class FontDictionary
    { 
        public static Dictionary<FontNames, Font> Fonts = new()
        {
            { FontNames.DEFAULT,  GD.Load<Font>("res://Assets/Fonts/m6x11.ttf") },
            { FontNames.DARUMADROP,  GD.Load<Font>("res://Assets/Fonts/DarumadropOne-Regular.ttf") },
            { FontNames.RENOGARE,  GD.Load<Font>("res://Assets/Fonts/Renogare-Regular.otf") },
        };
    }
}
