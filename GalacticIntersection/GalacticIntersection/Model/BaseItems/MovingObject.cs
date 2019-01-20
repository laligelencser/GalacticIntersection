// <copyright file="MovingObject.cs" company="PlaceholderCompany">
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
    /// MovingObject
    /// </summary>
    public class MovingObject : GameObject, IMove
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovingObject"/> class.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="w">w</param>
        /// <param name="h">h</param>
        public MovingObject(double x, double y, double w, double h)
            : base(x, y, w, h)
        {
        }

        /// <summary>
        /// Gets or sets movementVector
        /// </summary>
        public Vector MovementVector { get; set; }

        /// <summary>
        /// Gets or sets acceleration
        /// </summary>
        public double Acceleration { get; set; }

        /// <summary>
        /// Move
        /// </summary>
        public void Move()
        {
            this.ChangePosition(this.MovementVector);
        }

        /// <summary>
        /// Up
        /// </summary>
        public void Up()
        {
            this.MovementVector = Vector.Add(this.MovementVector, new Vector(0, -1 * this.Acceleration));
        }

        /// <summary>
        /// Down
        /// </summary>
        public void Down()
        {
            this.MovementVector = Vector.Add(this.MovementVector, new Vector(0, this.Acceleration));
        }

        /// <summary>
        /// Left
        /// </summary>
        public void Left()
        {
            this.MovementVector = Vector.Add(this.MovementVector, new Vector(-1 * this.Acceleration, 0));
        }

        /// <summary>
        /// Right
        /// </summary>
        public void Right()
        {
            this.MovementVector = Vector.Add(this.MovementVector, new Vector(this.Acceleration, 0));
        }
    }
}
