// <copyright file="GruntFighter.cs" company="PlaceholderCompany">
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
    /// GruntFighter enemy
    /// </summary>
    public class GruntFighter : EnemyShip
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GruntFighter"/> class.
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
        public GruntFighter(double x, double y, double w, double h, int life, double acceleration, int fireRate, int powerUpMultiplier, List<Rect> destinations)
            : base(x, y, w, h, life, acceleration, fireRate, powerUpMultiplier, destinations)
        {
        }
    }
}
