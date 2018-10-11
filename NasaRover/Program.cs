using System;
using NasaRover.Enums;
using NasaRover.Models;

namespace NasaRover
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Instantiate the rover.
            Rover rover = new Rover();

            // Create the rover's initial position.
            Position position = new Position
            {
                X = 0,
                Y = 0,
                Direction = Direction.North
            };

            // Set the rover's initial position.
            rover.SetPosition(position);

            // Display the current position of the rover.
            Console.WriteLine($"Current position: {rover.CurrentPosition}");

            // Send commands to the rover.
            rover.Move(Command.Left, Command.Move, Command.Right);

            // Display the new position of the rover.
            Console.WriteLine($"New position: {rover.CurrentPosition}");
        }
    }
}
