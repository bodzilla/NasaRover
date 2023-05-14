using System;
using System.Collections.Generic;
using NasaRover.Enums;

namespace NasaRover.Models
{
    public class Rover
    {
        public Position CurrentPosition { get; }

        private static readonly Dictionary<Command, Action<Rover>> CommandStrategies = new Dictionary<Command, Action<Rover>>
        {
            { Command.Move, rover => rover.Move() },
            { Command.Right, rover => rover.Turn(Command.Right) },
            { Command.Left, rover => rover.Turn(Command.Left) }
        };

        private static readonly Dictionary<(Direction, Command), Direction> DirectionStrategies = new Dictionary<(Direction, Command), Direction>
        {
            { (Direction.North, Command.Left), Direction.West },
            { (Direction.North, Command.Right), Direction.East },
            { (Direction.East, Command.Left), Direction.North },
            { (Direction.East, Command.Right), Direction.South },
            { (Direction.South, Command.Left), Direction.East },
            { (Direction.South, Command.Right), Direction.West },
            { (Direction.West, Command.Left), Direction.South },
            { (Direction.West, Command.Right), Direction.North }
        };

        private static readonly Dictionary<Direction, Action<Position>> MoveStrategies = new Dictionary<Direction, Action<Position>>
        {
            { Direction.North, position => position.Y++ },
            { Direction.East, position => position.X++ },
            { Direction.South, position => position.Y-- },
            { Direction.West, position => position.X-- }
        };

        public Rover(Position initialPosition) => CurrentPosition = initialPosition ?? throw new ArgumentNullException(nameof(initialPosition));

        public void ExecuteCommands(params Command[] commands)
        {
            if (commands is null) throw new ArgumentNullException(nameof(commands));

            foreach (var command in commands)
            {
                if (!CommandStrategies.TryGetValue(command, out var commandStrategy))
                    throw new ArgumentException($"No command strategy exists for: {command}", nameof(commands));

                commandStrategy(this);
            }
        }

        private void Turn(Command turnCommand)
        {
            if (!DirectionStrategies.TryGetValue((CurrentPosition.Direction, turnCommand), out var newDirection))
                throw new ArgumentException($"No turn strategy exists for: {turnCommand} at direction: {CurrentPosition.Direction}", nameof(turnCommand));

            CurrentPosition.Direction = newDirection;
        }

        private void Move()
        {
            if (!MoveStrategies.TryGetValue(CurrentPosition.Direction, out var moveStrategy))
                throw new ArgumentException($"No move strategy exists for: {CurrentPosition.Direction}", nameof(CurrentPosition.Direction));

            moveStrategy(CurrentPosition);
        }
    }
}
