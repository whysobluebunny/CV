using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombeLib
{
    /// <summary>
    /// Class represents possible enigma setting to decode a message
    /// </summary>
    public class PossibleSolutions
    {
        public List<string> rotorSets;
        public List<Tuple<char, char>> plugboardSets;

        public PossibleSolutions(List<string> rotor, List<Tuple<char, char>> plugboard)
        {
            rotorSets = rotor;
            plugboardSets = plugboard;
            plugboardSets = plugboard;
            CheckPlugboard();
        }

        public string Print(List<Tuple<char, char>> plugboard)
        {
            string wholesome = "";
            for (int i = 0; i < plugboard.Count; i++)
                wholesome += plugboard[i].Item1 + ": " + plugboard[i].Item2 + " \r\n";
            return wholesome;
        }

        public string Print(List<string> elems)
        {
            string wholesome = "";
            for (int i = 0; i < elems.Count; i++)
            {
                if (i == 0) wholesome = $"{elems[i]}";
                else wholesome += $", {elems[i]}";
            }
            return wholesome;
        }
        /// <summary>
        /// Removing unneccessary chars from the solution
        /// </summary>
        void CheckPlugboard()
        {
            for (int i = 0; i < plugboardSets.Count; i++)
            {
                for (int j = i + 1; j < plugboardSets.Count; j++)
                {
                    if (j != i)
                        if (plugboardSets[i].Item1 == plugboardSets[j].Item1 || plugboardSets[i].Item2 == plugboardSets[j].Item2
                            || plugboardSets[i].Item1 == plugboardSets[j].Item2 || plugboardSets[i].Item2 == plugboardSets[j].Item1)
                            plugboardSets.RemoveAt(j);
                }
            }
        }

        public override string ToString()
        {
            return $"Potential rotor settings:{Print(rotorSets)}."
                + $"\r\nPotential plugboard settings: \r\n{Print(plugboardSets)}";
        }
    }
}
