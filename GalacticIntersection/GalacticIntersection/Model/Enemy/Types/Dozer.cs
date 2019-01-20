// <copyright file="Dozer.cs" company="PlaceholderCompany">
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
    /// Dozer
    /// </summary>
    public class Dozer : MultiShooterEnemy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dozer"/> class.
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
        public Dozer(double x, double y, double w, double h, int life, double acceleration, int fireRate, int holdFireRate, int numOfShots, int powerUpMultiplier, List<Rect> destinations)
            : base(x, y, w, h, life, acceleration, fireRate, holdFireRate, numOfShots, powerUpMultiplier, destinations)
        {
        }
    }
}
