// <copyright file="PowerUp.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GalacticIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// PowerUp
    /// </summary>
    public class PowerUp : MovingObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PowerUp"/> class.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="w">w</param>
        /// <param name="h">h</param>
        /// <param name="movementVector">movementVector</param>
        /// <param name="type">type</param>
        public PowerUp(double x, double y, double w, double h, Vector movementVector, PowerUpType type)
            : base(x, y, w, h)
        {
            this.MovementVector = movementVector;
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets type
        /// </summary>
        public PowerUpType Type { get; set; }
    }
}
