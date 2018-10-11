using System;
using NasaRover.Enums;

namespace NasaRover.Models
{
    public class Position
    {
        /// <summary>
        /// Position in X axis.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Position in Y axis.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Direction that the rover is facing.
        /// </summary>
        public Direction Direction { get; set; }

        public override string ToString()
        {
            return $"X: {X}{Environment.NewLine}" +
                   $"Y: {Y}{Environment.NewLine}" +
                   $"Direction: {Direction}";
        }
    }
}
