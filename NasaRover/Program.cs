using System;
using NasaRover.Enums;
using NasaRover.Models;

namespace NasaRover
{
    public class Program
    {
        private static void Main()
        {
            // Instantiate the rover.
            Rover rover = new Rover
            {
                // Set the rover's initial position.
                CurrentPosition = new Position
                {
                    X = 1,
                    Y = 2,
                    Direction = Direction.North
                }
            };

            // Display the current position of the rover.
            Console.WriteLine($"Current position:{Environment.NewLine}{rover.CurrentPosition}");

            // Send commands to the rover.
            rover.Move(
                Command.Left, Command.Move,
                Command.Left, Command.Move,
                Command.Left, Command.Move,
                Command.Left, Command.Move,
                Command.Move
                );

            // Display the new position of the rover.
            Console.WriteLine($"New position:{Environment.NewLine}{rover.CurrentPosition}");
            Console.Read();
        }
    }
}
