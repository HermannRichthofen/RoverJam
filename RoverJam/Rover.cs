using System;

namespace RoverJam
{
    public class Rover
    {
        private int XAxis;

        private int YAxis;

        private char Direction;

        private readonly char[] Commands;

        private readonly int RoverNumber;

        public Rover(int xAxis, int yAxis, char direction, char[] commands, int roverNumber)
        {
            XAxis = xAxis;
            YAxis = yAxis;
            Direction = direction;
            Commands = commands;
            RoverNumber = roverNumber;
        }

        public void Run()
        {
            foreach (var command in Commands)
            {
                if (command == 'M')
                {
                    if (Direction == 'N')
                    {
                        YAxis++;
                    }
                    else if (Direction == 'E')
                    {
                        XAxis++;
                    }
                    else if (Direction == 'W')
                    {
                        XAxis--;
                    }
                    else if (Direction == 'S')
                    {
                        YAxis--;
                    }
                }
                else if (command == 'L')
                {
                    if (Direction == 'N')
                    {
                        Direction = 'W';
                    }
                    else if (Direction == 'E')
                    {
                        Direction = 'N';
                    }
                    else if (Direction == 'W')
                    {
                        Direction = 'S';
                    }
                    else if (Direction == 'S')
                    {
                        Direction = 'E';
                    }
                }
                else if (command == 'R')
                {
                    if (Direction == 'N')
                    {
                        Direction = 'E';
                    }
                    else if (Direction == 'E')
                    {
                        Direction = 'S';
                    }
                    else if (Direction == 'W')
                    {
                        Direction = 'N';
                    }
                    else if (Direction == 'S')
                    {
                        Direction = 'W';
                    }
                }
            }

            Console.WriteLine($"Rover Number#{RoverNumber} Reporting: {XAxis} {YAxis} {Direction}");
        }
    }
}
