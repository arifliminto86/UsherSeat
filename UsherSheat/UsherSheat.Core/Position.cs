﻿namespace UsherSheat.Core
{
    public class Position
    {
        /// <summary>
        /// X position 
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y position
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
