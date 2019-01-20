// <copyright file="PlayerShip.cs" company="PlaceholderCompany">
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
    /// PlayerShip
    /// </summary>
    public class PlayerShip : Ship
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerShip"/> class.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="w">w</param>
        /// <param name="h">h</param>
        /// <param name="life">life</param>
        /// <param name="acceleration">acceleration</param>
        /// <param name="fireRate">fireRate</param>
        /// <param name="weaponStregth">weaponStregth</param>
        /// <param name="numOfProjectiles">numOfProjectiles</param>
        public PlayerShip(
            double x,
            double y,
            double w,
            double h,
            int life,
            double acceleration,
            int fireRate,
            int weaponStregth,
            int numOfProjectiles)
            : base(x, y, w, h, life, acceleration, fireRate)
        {
            this.Deceleration = Config.PlayerShipDeceleration;
            this.FireLockCount = 0;
            this.ReadyToFire = true;
            this.WeaponStrength = weaponStregth;
            this.NumOfProjectiles = numOfProjectiles;
        }

        /// <summary>
        /// Gets or sets weaponStrength
        /// </summary>
        public int WeaponStrength { get; set; }

        /// <summary>
        /// Gets or sets numOfProjectiles
        /// </summary>
        public int NumOfProjectiles { get; set; }
    }
}
