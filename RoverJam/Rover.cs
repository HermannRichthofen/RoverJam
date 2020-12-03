using System;

namespace RoverJam
{
    public class Rover
    {
        private readonly int RoverNumber;

        private int PositionOnXAxis;

        private int PositionOnYAxis;

        private char Direction;

        private readonly char[] Instructions;

        public Rover(int xAxis, int yAxis, char direction, char[] instructions, int roverNumber)
        {
            RoverNumber = roverNumber;
            PositionOnXAxis = xAxis;
            PositionOnYAxis = yAxis;
            Direction = direction;
            Instructions = instructions;
        }

        public void Run()
        {
            foreach (var instruction in Instructions)
            {
                Execute(instruction);
            }

            Report();
        }

        private void Execute(char instruction)
        {
            switch (instruction)
            {
                case 'M':
                    MoveForward();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
            }
        }

        private void Report()
        {
            Console.WriteLine($"Rover #{RoverNumber} Reporting: {PositionOnXAxis} {PositionOnYAxis} {Direction}.");
        }

        private void TurnLeft()
        {
            switch (Direction)
            {
                case 'N':
                    Direction = 'W';
                    break;
                case 'E':
                    Direction = 'N';
                    break;
                case 'W':
                    Direction = 'S';
                    break;
                case 'S':
                    Direction = 'E';
                    break;
            }
        }

        private void TurnRight()
        {
            switch (Direction)
            {
                case 'N':
                    Direction = 'E';
                    break;
                case 'E':
                    Direction = 'S';
                    break;
                case 'W':
                    Direction = 'N';
                    break;
                case 'S':
                    Direction = 'W';
                    break;
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case 'N':
                    if (PositionOnYAxis + 1 <= ControlSystem.MaxYCoordinate)
                    {
                        PositionOnYAxis++;

                        return;
                    }

                    goto default;
                case 'E':
                    if (PositionOnYAxis + 1 <= ControlSystem.MaxYCoordinate)
                    {
                        PositionOnXAxis++;

                        return;
                    }

                    goto default;
                case 'W':
                    if (PositionOnYAxis - 1 > 0)
                    {
                        PositionOnXAxis--;

                        return;
                    }

                    goto default;
                case 'S':
                    if (PositionOnYAxis - 1 > 0)
                    {
                        PositionOnYAxis--;

                        return;
                    }

                    goto default;
                default:
                    Console.WriteLine($"WARNING! Rover #{RoverNumber} is pushing out of the plateau. Instruction skipped.");
                    break;
            }
        }
    }
}
