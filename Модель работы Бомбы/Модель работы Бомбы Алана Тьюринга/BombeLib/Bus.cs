﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombeLib
{
    /// <summary>
    /// Class which consists of characters to look over possible 
    /// combinations in plugboard
    /// </summary>
    public class Bus
    {
        public readonly char Letter;
        public readonly Dictionary<char, bool> Signaled;
        public event EventHandler<char> SignalEvent;
        public bool EnigmaConnected { get; set; }

        public Bus(char letter)
        {
            Letter = letter;
            Signaled = new Dictionary<char, bool>();
            for (char c = 'A'; c <= 'Z'; c++) Signaled.Add(c, false);
        }

        public bool AllSignaled
        {
            get
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    if (!Signaled[c]) return false;
                }
                return true;
            }
        }

        public void ResetBus()
        {
            for (char c = 'A'; c <= 'Z'; c++)
                Signaled[c] = false;
        }

        public void Signal(char c)
        {
            if (!Signaled[c])
            {
                Signaled[c] = true;
                OnSignalEvent(c);
            }
        }

        protected void OnSignalEvent(char c) => SignalEvent?.Invoke(this, c);


        public string ListPotentialPlugboardCharacters()
        {
            if (Signaled.Count(s => s.Value) > 1)
            {
                return string.Join("", Signaled.Where(s => !s.Value).Select(s => s.Key));
            }
            else
            {
                return string.Join("", Signaled.Where(s => s.Value).Select(s => s.Key));
            }
        }
    }
}
