// <copyright file="EnemyShip.cs" company="PlaceholderCompany">
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
    /// Enemy ship class.
    /// </summary>
    public class EnemyShip : Ship, IDecideWhatToDo
    {
        private Rect currentDestination;
        private List<Rect> destinations;
        private int destinationIndex;
        private int powerUpMultiplier;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyShip"/> class.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="w">w</param>
        /// <param name="h">h</param>
        /// <param name="life">life</param>
        /// <param name="acceleration">acceleration</param>
        /// <param name="fireRate">fireRate</param>
        /// <param name="powerUpMultiplier">powerUpMultiplier</param>
        /// <param name="destinations">destinations</param>
        public EnemyShip(double x, double y, double w, double h, int life, double acceleration, int fireRate, int powerUpMultiplier, List<Rect> destinations)
            : base(x, y, w, h, life, acceleration, fireRate)
        {
            this.Deceleration = Config.DefaultShipDeceleration;
            this.destinations = destinations;
            this.destinationIndex = 0;
            this.powerUpMultiplier = powerUpMultiplier;
            this.currentDestination = this.destinations[this.destinationIndex];
        }

        /// <summary>
        /// EnemyShootEvent delegate
        /// </summary>
        /// <param name="enemyShip">Enemy ship that made the shot.</param>
        public delegate void EnemyShootEvent(EnemyShip enemyShip);

        /// <summary>
        /// Gets or sets enemy ship shot happened event.
        /// </summary>
        public EnemyShootEvent EnemyShotHappened { get; set; }

        /// <summary>
        /// Gets or sets powerUpMultiplier
        /// </summary>
        public int PowerUpMultiplier { get => this.powerUpMultiplier; set => this.powerUpMultiplier = value; }

        /// <summary>
        /// Decide what this object should do in the next step.
        /// </summary>
        public void DecideNextStep()
        {
            if (this.Area.IntersectsWith(this.currentDestination))
            {
                this.currentDestination = this.GetNextDestination();
            }

            this.ControllMovement();
            this.Shoot();
        }

        private void Shoot()
        {
            if (this.ReadyToFire)
            {
                this.FireLockCount = 0;
                this.ReadyToFire = false;
                this.EnemyShotHappened.Invoke(this);
            }

            this.FireLockCount++;
            if (this.FireLockCount > this.FireRate)
            {
                this.ReadyToFire = true;
            }
        }

        private void ControllMovement()
        {
            if (this.Area.X < this.currentDestination.Right)
            {
                this.Right();
            }

            if (this.Area.X > this.currentDestination.Left)
            {
                this.Left();
            }

            if (this.Area.Y < this.currentDestination.Bottom)
            {
                this.Down();
            }

            if (this.Area.Y > this.currentDestination.Top)
            {
                this.Up();
            }
        }

        private Rect GetNextDestination()
        {
            this.destinationIndex++;
            if (this.destinationIndex == this.destinations.Count)
            {
                this.destinationIndex = 0;
            }

            return this.destinations[this.destinationIndex];
        }
    }
}
