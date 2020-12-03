using System;
using System.Collections.Generic;

namespace RoverJam
{
    public class InputSet
    {
        public Tuple<int, int> GridInput;

        public List<RoverInput> RoverInput;

        public int RoverCount
        {
            get
            {
                return RoverInput.Count;
            }
        }

        public InputSet()
        {
            RoverInput = new List<RoverInput>();
        }
    }

    public class RoverInput
    {
        public int RoverNumber;

        public int XPosition;

        public int YPosition;

        public char Direction;

        public char[] Commands;

        public RoverInput(int roverNumber, int xPosition, int yPosition, char direction)
        {
            RoverNumber = roverNumber;
            XPosition = xPosition;
            YPosition = yPosition;
            Direction = direction;
        }
    }
}
