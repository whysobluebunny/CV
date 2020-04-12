using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BombeLib
{
    /// <summary>
    /// Enigma class to simulate enigma and encode chars
    /// </summary>
    public class Enigma
    {
        public readonly Wheel[] Wheels;//in order left to right.
        public readonly Wheel RightWheel;
        public readonly ReadOnlyDictionary<char, char> PlugboardDictionary;//Plugboard sets
        protected readonly Reflector Reflector;//Reflector type

        public Enigma(WheelType[] wheelTypes, ReflectorType reflectorType, List<Tuple<char, char>> plugboardSettings = null)
        {
            Reflector = Reflector.CreateReflector(reflectorType);
            Wheels = new Wheel[wheelTypes.Length];
            ConfigureWheels(wheelTypes);
            RightWheel = Wheels[Wheels.Length - 1];
            var tempDict = new Dictionary<char, char>();
            if (plugboardSettings != null)
            {
                ValidatePlugboardSettings(plugboardSettings);
                foreach (var tuple in plugboardSettings)
                {
                    tempDict.Add(tuple.Item1, tuple.Item2);
                    if(tuple.Item1!=tuple.Item2)
                        tempDict.Add(tuple.Item2, tuple.Item1);
                }   
            }
            PlugboardDictionary = new ReadOnlyDictionary<char, char>(tempDict);
            RightWheel.RotateNotch += Wheels[1].Rotate;
            Wheels[1].RotateNotch += Wheels[0].Rotate;
            RightWheel.RotateNotchBack += Wheels[1].RotateBack;
            Wheels[1].RotateNotchBack += Wheels[0].RotateBack;
        }

        /// <summary>
        /// Setting wheels to work properly
        /// </summary>
        /// <param name="wheelTypes"></param>
        private void ConfigureWheels(WheelType[] wheelTypes)
        {
            for (int i = 0; i < wheelTypes.Length; i++)
            {
                Wheels[i] = Wheel.CreateWheel(wheelTypes[i]);
                if (i == 0)
                {
                    Reflector.SignalOut = Wheels[0].SignalLeftSide;
                    Wheels[0].SignalOutLeft = Reflector.Signal;
                }
                else
                {
                    Wheels[i - 1].SignalOutRight = Wheels[i].SignalLeftSide;
                    Wheels[i].SignalOutLeft = Wheels[i - 1].SignalRightSide;
                }
            }
        }

        /// <summary>
        /// Checking if plugboard settings are inappropriate
        /// I don't think this might ever happen but I want to know if it does
        /// </summary>
        /// <param name="plugboardSettings"></param>
        private void ValidatePlugboardSettings(IList<Tuple<char, char>> plugboardSettings)
        {
            var characters = new List<char>();
            foreach (var tuple in plugboardSettings)
            {
                if (characters.Contains(tuple.Item1))
                {
                    throw new ArgumentException("The plugboard letter " + tuple.Item1 + " was specified more than once.");
                }
                if (characters.Contains(tuple.Item1))
                {
                    throw new ArgumentException("The plugboard letter " + tuple.Item2 + " was specified more than once.");
                }
            }
        }
        /// <summary>
        /// Encoding char with the rules of enigma encoding
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public char Encode(char p)
        {
            char returnChar = 'A';
            RightWheel.SignalOutRight = i =>
            {
                returnChar = Convert.ToChar(i + 64);
                if (returnChar < 'A' || returnChar > 'Z') throw new InvalidDataException();
            };
            RightWheel.SignalRightSide(TranslateWithPlugboard(p) - 64);
            return TranslateWithPlugboard(returnChar);
        }
        /// <summary>
        /// Rotating rotor and encoding char
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public char RotateAndEncode(char p)
        {
            RightWheel.Rotate();
            return Encode(p);
        }
        /// <summary>
        /// Setting rotor positions
        /// </summary>
        /// <param name="positions"></param>
        public void SetWheelPositions(char[] positions)
        {
            SetWheelPositions(positions.Select(p => (int)p - 64).ToArray());
        }

        public void SetWheelPositions(int[] positions)
        {
            if (positions.Length != Wheels.Length) throw new ArgumentException();
            for (int i = 0; i < positions.Length; i++)
            {
                Wheels[i].Position = positions[i];
            }
        }
        /// <summary>
        /// Last phase of encoding is going throw the plugboard
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private char TranslateWithPlugboard(char c)
        {
            if (PlugboardDictionary.ContainsKey(c))
            {
                return PlugboardDictionary[c];
            }
            return c;
        }
    }
}
