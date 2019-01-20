// <copyright file="EnemyProjectile.cs" company="PlaceholderCompany">
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
    /// EnemyProjectile
    /// </summary>
    public class EnemyProjectile : MovingObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyProjectile"/> class.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="w">w</param>
        /// <param name="h">h</param>
        /// <param name="movementVector">movementVector</param>
        public EnemyProjectile(double x, double y, double w, double h, Vector movementVector)
            : base(x, y, w, h)
        {
            this.MovementVector = movementVector;
        }
    }
}
