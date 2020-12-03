using System;
using System.Collections.Generic;

namespace RoverJam
{
    public static class ControlSystem
    {
        public static int MaxXAxis { get; private set; }

        public static int MaxYAxis { get; private set; }

        private static List<Rover> DeployedRovers;

        public static void Main()
        {
            OnStart();

            var inputSystem = RunInputSystem();

            CreateVirtualMap(inputSystem.InputValues.GridInput);
            DeployRovers(inputSystem.InputValues.RoverInput);

            RunRovers(DeployedRovers);

            OnExit();
        }

        private static void OnExit()
        {
            Console.WriteLine("The operation is done. Press any key to exit...");
            Console.ReadLine();
        }

        public static void OnStart()
        {
            Console.WriteLine("Initializing RoverJam Mars Rover Control System...");
            Console.WriteLine(Environment.NewLine);
        }

        private static InputSystem RunInputSystem()
        {
            var inputSystem = new InputSystem();

            while (!inputSystem.EndOfInput)
            {
                inputSystem.AskForInput();
            }

            return inputSystem;
        }

        private static void CreateVirtualMap(Tuple<int, int> gridInput)
        {
            MaxXAxis = gridInput.Item1;
            MaxYAxis = gridInput.Item2;
        }

        public static void DeployRovers(List<Tuple<int, int, char, char[]>> roverInput)
        {
            DeployedRovers = new List<Rover>();

            foreach (var input in roverInput)
            {
                DeployedRovers.Add(new Rover(input.Item1, input.Item2, input.Item3, input.Item4));
            }
        }

        public static void RunRovers(List<Rover> rovers)
        {
            foreach (var rover in rovers)
            {
                rover.Run();
            }
        }
    }
}
