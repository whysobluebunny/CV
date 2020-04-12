using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombeLib
{
    /// <summary>
    /// Main class for getting potential settings
    /// For the terms see documentation
    /// </summary>
    public class BombeCL
    {
        private readonly char input;//Input char
        private readonly char entry;//Current entry char
        public readonly List<BombeEnigma> Enigmas;//List of the enigmas to see possible configs
        public readonly Dictionary<char, Bus> Buses;//Alphabets to define plugboard settings
        private char[] currentKeys;//Current wheel's characters
        private DiagonalBoard diagonalBoard;//To enable or not diagonalboard (first bombes didn't have one)
        public List<PossibleSolutions> solutions = new List<PossibleSolutions>();//Potential settings
        public WheelType[] wheels;//Wheel types used in enigma
        public ReflectorType reflector;//reflector type used in enigma

        public BombeCL(MapConfiguration mapConfiguration)   
            : this(mapConfiguration.MapEntries, mapConfiguration.InputLetter, mapConfiguration.CurrentEntry, mapConfiguration.WheelTypes, mapConfiguration.ReflectorType, mapConfiguration.EnableDiagonalBoard)
        {
        }

        public BombeCL(IEnumerable<MapEntry> mapping, char input, char entry,
                        WheelType[] wheelTypes, ReflectorType reflectorType, bool enableDiagonalBoard)
        {
            wheels = wheelTypes;
            reflector = reflectorType;
            this.input = input;
            this.entry = entry;
            Buses = new Dictionary<char, Bus>();
            for (char c = 'A'; c <= 'Z'; c++) Buses.Add(c, new Bus(c));
            if (enableDiagonalBoard)
                diagonalBoard = new DiagonalBoard(Buses);
            Enigmas = new List<BombeEnigma>();
            foreach (var map in mapping)
            {
                var bombeEnigma = new BombeEnigma(wheelTypes, reflectorType, map.StepsAheadOfKey, Buses[map.LeftChar], Buses[map.RightChar]);
                Enigmas.Add(bombeEnigma);
            }
            currentKeys = new char[wheelTypes.Length];
        }
        /// <summary>
        /// Rotate wheels forward
        /// </summary>
        /// <param name="wheelNum"></param>
        private void IncrementWheels(int wheelNum)
        {
            if (currentKeys[wheelNum] == 'Z')
            {
                if (wheelNum > 0) IncrementWheels(wheelNum - 1);
                currentKeys[wheelNum] = 'A';
            }
            else
            {
                currentKeys[wheelNum]++;
            }
            SetAllWheelPositions();
        }
        /// <summary>
        /// Check if current bus suits to be a solution
        /// </summary>
        /// <returns></returns>
        private bool CheckBusesAllSignaled() => Buses.Values.Where(b => b.EnigmaConnected).Any(bus => bus.AllSignaled);
        /// <summary>
        /// Check if current run could be a solution
        /// </summary>
        /// <returns></returns>
        private bool RunCheck()
        {
            foreach (var bus in Buses.Values) bus.ResetBus();
            var inputBus = Buses[input];
            inputBus.Signal(entry);
            if (!CheckBusesAllSignaled())
                return true; //match found
            return false;
        }
        /// <summary>
        /// Running Bombe itself
        /// </summary>
        /// <returns></returns>
        public void Run()
        {
            char[] startingPositions = new char[] { 'Z', 'Z', 'Z' };//setting starting rotor positions
            currentKeys = new char[startingPositions.Length];
            //copying starting positions in order to operate with them
            startingPositions.CopyTo(currentKeys, 0);
            SetAllWheelPositions();
            do
            {
                if (RunCheck())
                {
                    List<string> currentListKeys = new List<string>();
                    List<Tuple<char, char>> plugboardSets = new List<Tuple<char, char>>();
                    for (int i = 0; i < 3; i++)
                        currentListKeys.Add(currentKeys[i].ToString());
                    for (char i = 'A'; i <= 'Z'; i++)
                    {
                        if (Buses[i].EnigmaConnected)
                        {
                            char[] ch = Buses[i].ListPotentialPlugboardCharacters().ToCharArray();
                            plugboardSets.Add(new Tuple<char, char>(Buses[i].Letter, ch[0]));
                        }
                    }
                    solutions.Add(new PossibleSolutions(currentListKeys, plugboardSets));
                }
                IncrementWheels(currentKeys.Length - 1);
            } while (!DoesStartingPositionMatchCurrentPosition(startingPositions));
        }
        /// <summary>
        /// Check if process neeeds to be ended
        /// </summary>
        /// <param name="startingPositions"></param>
        /// <returns></returns>
        private bool DoesStartingPositionMatchCurrentPosition(char[] startingPositions)
        {
            if (startingPositions.SequenceEqual(currentKeys))
                return true;
            return false;
        }
        /// <summary>
        /// Set enigmas' starting positions
        /// </summary>
        private void SetAllWheelPositions()
        {
            foreach (var enigma in Enigmas)
                enigma.SetRotorsBasedOnBombeKey(currentKeys);
        }
    }
}
