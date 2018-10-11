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
            Position newPosition = new Position();

            // Move the rover.
            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.Move:
                        if (CurrentPosition.Direction == Direction.North)
                        {
                            CurrentPosition.Y++;
                        }
                        else if (CurrentPosition.Direction == Direction.East)
                        {
                            CurrentPosition.X++;
                        }
                        else if (CurrentPosition.Direction == Direction.South)
                        {
                            CurrentPosition.Y--;
                        }
                        else if (CurrentPosition.Direction == Direction.West)
                        {
                            CurrentPosition.X--;
                        }
                        break;
                    case Command.Left:
                        //TODO
                        break;
                    case Command.Right:
                        //TODO
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(commands));
                }
            }

            // Set the new position of the rover.
            SetPosition(newPosition);
        }
    }
}
