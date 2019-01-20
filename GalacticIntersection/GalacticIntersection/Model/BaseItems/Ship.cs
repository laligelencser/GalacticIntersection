// <copyright file="Ship.cs" company="PlaceholderCompany">
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
    /// Ship class
    /// </summary>
    public class Ship : MovingObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="w">w</param>
        /// <param name="h">h</param>
        /// <param name="life">life</param>
        /// <param name="acceleration">acceleration</param>
        /// <param name="fireRate">fireRate</param>
        public Ship(double x, double y, double w, double h, int life, double acceleration, int fireRate)
            : base(x, y, w, h)
        {
            this.Life = life;
            this.Acceleration = acceleration;
            this.FireRate = fireRate;
            this.Deceleration = Config.PlayerShipDeceleration;
        }

        /// <summary>
        /// Gets or sets life
        /// </summary>
        public int Life { get; set; }

        /// <summary>
        /// Gets or sets deceleration
        /// </summary>
        public double Deceleration { get; set; }

        /// <summary>
        /// Gets or sets fireRate
        /// </summary>
        public int FireRate { get; set; }

        /// <summary>
        /// Gets or sets fireLockCount
        /// </summary>
        public int FireLockCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether readyToFire
        /// </summary>
        public bool ReadyToFire { get; set; }

        /// <summary>
        /// Decelerating ship object.
        /// </summary>
        public void Decelerate()
        {
            this.MovementVector = Vector.Multiply(this.Deceleration, this.MovementVector);
        }
    }
}
