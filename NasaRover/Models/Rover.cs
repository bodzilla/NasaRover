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
        /// Sets the position of the rover.
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Position position) => CurrentPosition = position;

        /// <summary>
        /// Moves the rover according to the given command.
        /// </summary>
        /// <param name="commands">One or more commands.</param>
        public void Move(params Command[] commands)
        {
            // Move the rover.
            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.Move:
                        EvaluateMove();
                        break;

                    case Command.Left:
                        TurnLeft();
                        break;

                    case Command.Right:
                        TurnRight();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(commands));
                }
            }
        }

        /// <summary>
        /// Evaluates direction, then turns rover relatively left.
        /// </summary>
        private void TurnLeft()
        {
            switch (CurrentPosition.Direction)
            {
                case Direction.North:
                    CurrentPosition.Direction = Direction.West;
                    break;

                case Direction.East:
                    CurrentPosition.Direction = Direction.North;
                    break;

                case Direction.South:
                    CurrentPosition.Direction = Direction.East;
                    break;

                case Direction.West:
                    CurrentPosition.Direction = Direction.South;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(CurrentPosition.Direction));
            }
        }

        /// <summary>
        /// Evaluates direction, then turns rover relatively right.
        /// </summary>
        private void TurnRight()
        {
            switch (CurrentPosition.Direction)
            {
                case Direction.North:
                    CurrentPosition.Direction = Direction.East;
                    break;

                case Direction.East:
                    CurrentPosition.Direction = Direction.South;
                    break;

                case Direction.South:
                    CurrentPosition.Direction = Direction.West;
                    break;

                case Direction.West:
                    CurrentPosition.Direction = Direction.North;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(CurrentPosition.Direction));
            }
        }

        /// <summary>
        /// Evaluates the rover's direction, then moves rover accordingly.
        /// </summary>
        private void EvaluateMove()
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
