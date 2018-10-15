using System;
using NasaRover.Enums;

namespace NasaRover.Models
{
    public class Rover
    {
        /// <summary>
        /// Current position of the rover.
        /// </summary>
        public Position CurrentPosition { get; set; }

        /// <summary>
        /// Actions the rover according to the given command.
        /// </summary>
        /// <param name="commands">One or more commands.</param>
        public void ExecuteCommands(params Command[] commands)
        {
            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.Move:
                        Move();
                        break;

                    case Command.Left:
                        Turn(Command.Left);
                        break;

                    case Command.Right:
                        Turn(Command.Right);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(commands));
                }
            }
        }

        /// <summary>
        /// Evaluates direction, then turns rover relatively from it's current position either left or right.
        /// </summary>
        private void Turn(Command turnCommand)
        {
            switch (CurrentPosition.Direction)
            {
                case Direction.North:
                    if (turnCommand == Command.Left) CurrentPosition.Direction = Direction.West;
                    else if (turnCommand == Command.Right) CurrentPosition.Direction = Direction.East;
                    else throw new ArgumentOutOfRangeException(nameof(turnCommand));
                    break;

                case Direction.East:
                    if (turnCommand == Command.Left) CurrentPosition.Direction = Direction.North;
                    else if (turnCommand == Command.Right) CurrentPosition.Direction = Direction.South;
                    else throw new ArgumentOutOfRangeException(nameof(turnCommand));
                    break;

                case Direction.South:
                    if (turnCommand == Command.Left) CurrentPosition.Direction = Direction.East;
                    else if (turnCommand == Command.Right) CurrentPosition.Direction = Direction.West;
                    else throw new ArgumentOutOfRangeException(nameof(turnCommand));
                    break;

                case Direction.West:
                    if (turnCommand == Command.Left) CurrentPosition.Direction = Direction.South;
                    else if (turnCommand == Command.Right) CurrentPosition.Direction = Direction.North;
                    else throw new ArgumentOutOfRangeException(nameof(turnCommand));
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(CurrentPosition.Direction));
            }
        }

        /// <summary>
        /// Evaluates the rover's direction, then moves rover accordingly.
        /// </summary>
        private void Move()
        {
            switch (CurrentPosition.Direction)
            {
                case Direction.North:
                    CurrentPosition.Y++;
                    break;

                case Direction.East:
                    CurrentPosition.X++;
                    break;

                case Direction.South:
                    CurrentPosition.Y--;
                    break;

                case Direction.West:
                    CurrentPosition.X--;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(CurrentPosition.Direction));
            }
        }
    }
}
