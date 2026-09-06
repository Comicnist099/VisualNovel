using Godot;
using System.Collections.Generic;
using Scripts.Enums.Text;

namespace Scripts.Dictionaries.Text
{
    public static class ColorDictionary
    {
        public static Dictionary<ColorNames, Color> Color = new()
        {
            { ColorNames.DEFAULT , new Color(0,0,0,1) }, 
            { ColorNames.RED , new Color(1,0,0,1) }, 
            { ColorNames.GREEN , new Color(0,1,0,1) }, 
            { ColorNames.BLUE , new Color(0,0,1,1) }, 
        };
    }
}