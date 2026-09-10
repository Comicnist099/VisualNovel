using Godot;
using System.Collections.Generic;
using Scripts.Enums.Text;

namespace Scripts.Dictionaries.Text
{
    public static class IconFilenameDictionary
    {
        public static Dictionary<IconFileNames, Texture2D> Texture = new()
        {
            { IconFileNames.DEFAULT , GD.Load<Texture2D>("res://Assets/Icons/TEST/TEST_NUM1.png") },  
            { IconFileNames.NUM1 , GD.Load<Texture2D>("res://Assets/Icons/TEST/TEST_NUM1.png") },  
            { IconFileNames.NUM2 , GD.Load<Texture2D>("res://Assets/Icons/TEST/TEST_NUM2.png") },  
            { IconFileNames.NUM3 , GD.Load<Texture2D>("res://Assets/Icons/TEST/TEST_NUM3.png") },  
        };
    }
}