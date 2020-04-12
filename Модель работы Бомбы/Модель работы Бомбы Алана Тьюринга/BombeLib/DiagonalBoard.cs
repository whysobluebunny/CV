using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombeLib
{
    /// <summary>
    /// Class which represents a Bombe's diagonalboard
    /// </summary>
    public class DiagonalBoard
    {
        public readonly Dictionary<char, Bus> Buses;

        public DiagonalBoard(Dictionary<char, Bus> buses)
        {
            Buses = buses;

            foreach (var A_bus in buses.Values)
            {
                A_bus.SignalEvent += (sender, c) =>
                {
                    var bus = (Bus)sender;
                    if (c != bus.Letter)
                        buses[c].Signal(bus.Letter);
                };
            }
        }
    }
}
