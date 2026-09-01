using Godot;
using System.Collections.Generic;
using Scripts.Enums.Text;
using Scripts.Data.Class.Dialogue;

namespace Scripts.Dictionaries.Text
{
    public static class ImageDictionary
    {

        public static Dictionary<EmotionNames, ImageConfig> Vero = new()
        {
            {
                EmotionNames.NORMAL,
                new ImageConfig(
                    GD.Load<Texture2D>(
                        "res://Assets/Images/VERO/VeroNORMAL.png"
                    ),
                    new Vector2(576, 350),
                    new Vector2(0.35f, 0.35f)
                )
            },
            {
                EmotionNames.HAPPY,
                new ImageConfig(
                    GD.Load<Texture2D>(
                        "res://Assets/Images/VERO/VeroHAPPY.png"
                    ),
                    new Vector2(576, 350),
                    new Vector2(0.35f, 0.35f)
                )
            },
            {
                EmotionNames.SAD,
                new ImageConfig(
                    GD.Load<Texture2D>(
                        "res://Assets/Images/VERO/VeroSAD.png"
                    ),
                    new Vector2(576, 350),
                    new Vector2(0.35f, 0.35f)
                )
            },
            {
                EmotionNames.ANGRY,
                new ImageConfig(
                    GD.Load<Texture2D>(
                        "res://Assets/Images/VERO/VeroANGRY.png"
                    ),
                    new Vector2(576, 350),
                    new Vector2(0.35f, 0.35f)
                )
            },
            {
                EmotionNames.SCARY,
                new ImageConfig(
                    GD.Load<Texture2D>(
                        "res://Assets/Images/VERO/VeroSCARY.png"
                    ),
                    new Vector2(576, 350),
                    new Vector2(0.35f, 0.35f)
                )
            }
        };
        public static Dictionary<EmotionNames, ImageConfig> Namgyu = new()
        {
            {
                EmotionNames.NORMAL,
                new ImageConfig(
                    GD.Load<Texture2D>(
                        "res://Assets/Images/NAMGYU/NamgyuNORMAL.png"
                    ),
                    new Vector2(576, 350),
                    new Vector2(0.35f, 0.35f)
                )
            },
            {
                EmotionNames.SAD,
                new ImageConfig(
                    GD.Load<Texture2D>(
                        "res://Assets/Images/NAMGYU/NamgyuSAD.png"
                    ),
                    new Vector2(576, 350),
                    new Vector2(0.35f, 0.35f)
                )
            },
            {
                EmotionNames.ANGRY,
                new ImageConfig(
                    GD.Load<Texture2D>(
                        "res://Assets/Images/NAMGYU/NamgyuANGRY.png"
                    ),
                    new Vector2(576, 350),
                    new Vector2(0.35f, 0.35f)
                )
            },
            {
                EmotionNames.SCARY,
                new ImageConfig(
                    GD.Load<Texture2D>(
                        "res://Assets/Images/NAMGYU/NamgyuSCARY.png"
                    ),
                    new Vector2(576, 350),
                    new Vector2(0.35f, 0.35f)
                )
            }

        };
        public static Dictionary<string, Dictionary<EmotionNames, ImageConfig>> Characters = new()
        {
            { "Veronica", Vero },
            { "Namgyu", Namgyu }
        };
    }
}