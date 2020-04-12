using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombeLib
{
    /// <summary>
    /// Class that represents a configuration for the Bombe
    /// </summary>
    public class MapConfiguration
    {
        public WheelType[] WheelTypes { get; set; }
        public ReflectorType ReflectorType { get; set; }
        public bool EnableDiagonalBoard { get; set; }
        public char CurrentEntry { get; set; }
        public char InputLetter { get; set; }
        public MapEntry[] MapEntries { get; set; }

        public MapConfiguration(WheelType[] types, ReflectorType type, bool enableDB, char entry, char letter, MapEntry[] entries)
        {
            WheelTypes = types;
            ReflectorType = type;       
            EnableDiagonalBoard = enableDB;
            CurrentEntry = entry;
            InputLetter = letter;
            MapEntries = entries;
        }
    }
    /// <summary>
    /// Class which represents a configuration which is brought from the diagram
    /// </summary>
    public class MapEntry
    {
        public int StepsAheadOfKey { get; set; }
        public char LeftChar { get; set; }
        public char RightChar { get; set; }

        public MapEntry(int stepsAhead, char leftChar, char rightChar)
        {
            if (leftChar >= rightChar) throw new ArgumentException("It seems like you've made" +
                "a mistake while making a diagram");
            this.StepsAheadOfKey = stepsAhead;
            this.LeftChar = leftChar;
            this.RightChar = rightChar;
        }

        public override string ToString()
        {
            return $"Steps Ahead of Key: {StepsAheadOfKey}. LeftChar: {LeftChar}, RightChar: {RightChar}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this == null) return false;
            MapEntry entry = obj as MapEntry;
            if (entry == null) return base.Equals(obj);
            return StepsAheadOfKey == entry.StepsAheadOfKey && LeftChar == entry.LeftChar && RightChar == entry.RightChar;
        }
    }
}
