using System.Collections.Generic;
using Scripts.Enums.Text;

namespace Scripts.Dictionaries.Text
{
    public static class SpeedDictionary
    {
        public static Dictionary<SpeedNames, float> Speed = new()
        {
{ SpeedNames.SLOW,      0.05f },
{ SpeedNames.MEDIUM,    0.025f },
{ SpeedNames.FAST,      0.005f },
{ SpeedNames.ULTRAFAST, 0.001f }

        };
    }
}
