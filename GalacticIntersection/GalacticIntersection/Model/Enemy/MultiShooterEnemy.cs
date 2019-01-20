// <copyright file="MultiShooterEnemy.cs" company="PlaceholderCompany">
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
    /// MultiShooterEnemy
    /// </summary>
    public class MultiShooterEnemy : EnemyShip
    {
        private int holdFireRate;
        private int defaultFireRate;
        private int numOfShots;
        private int countNumOfShots;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiShooterEnemy"/> class.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="w">w</param>
        /// <param name="h">h</param>
        /// <param name="life">life</param>
        /// <param name="acceleration">acceleration</param>
        /// <param name="fireRate">fireRate</param>
        /// <param name="holdFireRate">holdFireRate</param>
        /// <param name="numOfShots">numOfShots</param>
        /// <param name="powerUpMultiplier">powerUpMultiplier</param>
        /// <param name="destinations">destinations</param>
        public MultiShooterEnemy(
            double x,
            double y,
            double w,
            double h,
            int life,
            double acceleration,
            int fireRate,
            int holdFireRate,
            int numOfShots,
            int powerUpMultiplier,
            List<Rect> destinations)
            : base(x, y, w, h, life, acceleration, fireRate, powerUpMultiplier, destinations)
        {
            this.defaultFireRate = fireRate;
            this.holdFireRate = holdFireRate;
            this.FireRate = this.holdFireRate;
            this.numOfShots = numOfShots;
            this.EnemyShotHappened += this.ShootHappened;
        }

        /// <summary>
        /// IsHoldFire
        /// </summary>
        /// <returns>Is Firerate Hold or not</returns>
        public bool IsHoldFire() => this.FireRate == this.holdFireRate;

        private void ShootHappened(EnemyShip ship)
        {
            if (this.countNumOfShots > this.numOfShots)
            {
                this.FireRate = this.holdFireRate;
                this.countNumOfShots = 0;
            }
            else
            {
                this.FireRate = this.defaultFireRate;
            }

            this.countNumOfShots++;
        }
    }
}
