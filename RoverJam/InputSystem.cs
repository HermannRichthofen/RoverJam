using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RoverJam
{
    public class InputSystem
    {
        #region Public Members

        public bool EndOfInput;

        public InputSet InputValues;

        public InputSystem()
        {
            InputValues = new InputSet();

            CurrentInputType = InputType.GridSize;
        }

        public void AskForInput()
        {
            do
            {
                PrintInputDescription();

                GetInput();

                if (IsBreakCommand())
                {
                    break;
                }
            } while (!Validate());

            CommitInput();
        }

        private bool IsBreakCommand()
        {
            if (CurrentInput == "GO")
            {
                if (CurrentInputType == InputType.GridSize)
                {
                    Console.WriteLine("Invalid GO command. You need to set the grid size.");

                    return false;
                }
                else if (CurrentInputType == InputType.RoverCommands)
                {
                    Console.WriteLine("Invalid GO command. You have defined a rover without giving it a command sequence.");

                    return false;
                }
                else if (CurrentInputType == InputType.RoverPosition && InputValues.RoverCount == 0)
                {
                    Console.WriteLine("Invalid GO command. You haven't defined any rovers.");

                    return false;
                }

                return true;
            }

            return false;
        }

        private void CommitInput()
        {
            switch (CurrentInputType)
            {
                case InputType.GridSize:
                    InputValues.GridInput = (int.Parse(CurrentInput.Split(' ')[0]), int.Parse(CurrentInput.Split(' ')[1])).ToTuple();
                    CurrentInputType = InputType.RoverPosition;
                    break;
                case InputType.RoverPosition:
                    break;
                case InputType.RoverCommands:
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Private Members

        private InputType CurrentInputType;

        private string CurrentInput;

        private void GetInput()
        {
            CurrentInput = Console.ReadLine();
        }

        private bool Validate()
        {
            bool isValid = false;

            if (!RunNullCheckForInput())
            {
                goto exit;
            }

            isValid = CurrentInputType switch
            {
                InputType.GridSize => RunValidationForGridInput(),
                InputType.RoverPosition => RunValidationForRoverPositionInput(),
                InputType.RoverCommands => RunValidationForRoverCommandsInput(),
                _ => false,
            };

        exit:
            if (!isValid)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Invalid input... Please, try again.");
                Console.WriteLine(Environment.NewLine);
            }

            return isValid;
        }

        private bool RunValidationForRoverCommandsInput()
        {
            if (CurrentInput.All(character => new[] { 'M', 'L', 'R' }.Contains(character)))
            {
                return false;
            }

            return true;
        }

        private bool RunValidationForRoverPositionInput()
        {
            if (CurrentInput.Split(' ').Length != 3)
            {
                return false;
            }

            var parameters = CurrentInput.ToUpperInvariant().Split(' ');

            if (parameters[0].Any(character => !char.IsDigit(character)) || parameters[1].Any(character => !char.IsDigit(character)))
            {
                return false;
            }

            if (parameters[2].All(character => !new[] { 'E', 'N', 'S', 'W' }.Contains(character)))
            {
                return false;
            }

            return true;
        }

        private bool RunValidationForGridInput()
        {
            if (CurrentInput.Split(' ').Length != 2)
            {
                return false;
            }

            if (CurrentInput.Split(' ').Any(parameter => parameter.Any(character => !char.IsDigit(character) || character == '0')))
            {
                return false;
            }

            return true;
        }

        private bool RunNullCheckForInput()
        {
            if (string.IsNullOrWhiteSpace(CurrentInput))
            {
                return false;
            }

            return true;
        }

        private void PrintInputDescription()
        {
            switch (CurrentInputType)
            {
                case InputType.GridSize:
                    Console.WriteLine("Please, enter the grid parameters." +
                        "Grid parameters are max-x axis and max-y axis integers with a single white space between them. (Ex: 5 5)");
                    Console.Write("Grid Parameters:");
                    break;
                case InputType.RoverPosition:
                    Console.WriteLine("Please, enter the starting positon of the rover." +
                        "The position will be an x-y coordinate pair with an uppercase direction letter." +
                        "Please, leave a single white space between each parameter. (Ex: 3 1 N)");
                    Console.Write("Grid Parameters:");
                    break;
                case InputType.RoverCommands:
                    Console.WriteLine("Please, enter the commands to be executed by the rover." +
                        "The commands are uppercase L or R or M letters. You should not leave any spece between them." +
                        "(Ex: RLLRMMRLMR)");
                    break;
                default:
                    break;
            }
        }

        private enum InputType
        {
            GridSize,
            RoverPosition,
            RoverCommands
        }

        #endregion
    }
}
