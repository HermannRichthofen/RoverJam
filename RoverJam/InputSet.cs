using System;
using System.Collections.Generic;

namespace RoverJam
{
    public class InputSet
    {
        public Tuple<int, int> GridInput;

        public List<Tuple<int, int, char, char[]>> RoverInput;

        public int RoverCount
        {
            get
            {
                return RoverInput.Count;
            }
        }

        public InputSet()
        {
            RoverInput = new List<Tuple<int, int, char, char[]>>();
        }
    }
}
