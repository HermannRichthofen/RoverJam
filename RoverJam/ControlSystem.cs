using System;
using System.Collections.Generic;

namespace RoverJam
{
    public static class ControlSystem
    {
        public static int MaxXCoordinate { get; private set; }

        public static int MaxYCoordinate { get; private set; }

        private static List<Rover> DeployedRovers;

        public static void Main()
        {
            OnStart();

            var inputValues = RunInputSystem();

            CreateGridForPlateau(inputValues.GridInput);
            DeployRovers(inputValues.RoverInput);

            RunRovers(DeployedRovers);

            OnExit();
        }

        private static void OnExit()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("All rovers successfully reported. End of operations...");
            Console.WriteLine("Press any key to exit RoverJam system.");
            Console.ReadLine();
        }

        public static void OnStart()
        {
            Console.WriteLine("Initializing RoverJam Mars Rover Control System..." + Environment.NewLine);
        }

        private static InputSet RunInputSystem()
        {
            var inputSystem = new InputSystem();

            while (!inputSystem.EndOfInput)
            {
                inputSystem.AskForInput();
            }

            return inputSystem.InputValues;
        }

        private static void CreateGridForPlateau(Tuple<int, int> gridInput)
        {
            MaxXCoordinate = gridInput.Item1;
            MaxYCoordinate = gridInput.Item2;
        }

        public static void DeployRovers(List<RoverInput> roverInput)
        {
            DeployedRovers = new List<Rover>();

            foreach (var input in roverInput)
            {
                DeployedRovers.Add(new Rover(input.XPosition, input.YPosition, input.Direction, input.Commands, input.RoverNumber));
            }
        }

        public static void RunRovers(List<Rover> rovers)
        {
            Console.WriteLine(Environment.NewLine);

            rovers.ForEach(rover => rover.Run());
        }
    }
}
