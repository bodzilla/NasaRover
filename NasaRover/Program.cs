using System;
using NasaRover.Enums;
using NasaRover.Models;

namespace NasaRover
{
    public class Program
    {
        private static void Main()
        {
            var rover = new Rover(new Position
            {
                X = 1,
                Y = 2,
                Direction = Direction.North
            });

            Console.WriteLine($"Current position:{Environment.NewLine}{rover.CurrentPosition}");

            rover.ExecuteCommands(
                Command.Left, Command.Move,
                Command.Left, Command.Move,
                Command.Left, Command.Move,
                Command.Left, Command.Move,
                Command.Move, Command.Right,
                Command.Move
                );

            Console.WriteLine($"New position:{Environment.NewLine}{rover.CurrentPosition}");
            Console.Read();
        }
    }
}
