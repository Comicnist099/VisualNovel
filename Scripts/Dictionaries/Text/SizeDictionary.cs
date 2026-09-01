using System.Collections.Generic;
using Scripts.Enums.Text;

namespace Scripts.Dictionaries.Text
{
    public static class SizeDictionary
    {
        public static Dictionary<SizeNames, int> Sizes = new()
        {
            { SizeNames.SMALL,  10},
            { SizeNames.MEDIUM, 20 },
            { SizeNames.BIG, 30 }
        };
    }
}
