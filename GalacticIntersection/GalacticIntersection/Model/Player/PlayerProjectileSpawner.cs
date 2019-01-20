// <copyright file="PlayerProjectileSpawner.cs" company="PlaceholderCompany">
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
    /// PlayerProjectileSpawner
    /// </summary>
    public class PlayerProjectileSpawner
    {
        private int spread = 10;
        private double speedModifier;

        /// <summary>
        /// GetProjectiles
        /// </summary>
        /// <param name="spawnArea">spawnArea</param>
        /// <param name="numOfProjectiles">numOfProjectiles</param>
        /// <param name="weaponStrength">weaponStrength</param>
        /// <returns>List of projectiles</returns>
        public List<PlayerProjectile> GetProjectiles(Rect spawnArea, int numOfProjectiles, int weaponStrength)
        {
            List<PlayerProjectile> projectiles = new List<PlayerProjectile>();
            this.speedModifier = weaponStrength > 1 ? weaponStrength * 1 : weaponStrength;

            if (numOfProjectiles == 1)
            {
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2),
                    spawnArea.Y));
            }
            else if (numOfProjectiles == 2)
            {
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width,
                    spawnArea.Y));
            }
            else if (numOfProjectiles == 3)
            {
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2),
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width,
                    spawnArea.Y));
            }
            else if (numOfProjectiles == 4)
            {
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2) - this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2) + this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width,
                    spawnArea.Y));
            }
            else if (numOfProjectiles == 5)
            {
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2) - this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2),
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2) + this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width,
                    spawnArea.Y));
            }
            else if (numOfProjectiles == 6)
            {
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X - this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2) - this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2) + this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width + this.spread,
                    spawnArea.Y));
            }
            else if (numOfProjectiles == 7)
            {
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X - this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2) - this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2),
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2) + this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width + this.spread,
                    spawnArea.Y));
            }
            else if (numOfProjectiles == 8)
            {
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X - (this.spread * 2),
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X - this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2) - this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + (spawnArea.Width / 2) + this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width + this.spread,
                    spawnArea.Y));
                projectiles.Add(this.GetPlayerProjectile(
                    spawnArea.X + spawnArea.Width + (this.spread * 2),
                    spawnArea.Y));
            }

            return projectiles;
        }

        private PlayerProjectile GetPlayerProjectile(double x, double y)
        {
            return new PlayerProjectile(
                x,
                y,
                Config.PlayerProjectileWidth,
                Config.PlayerProjectileHeight,
                Vector.Multiply(this.speedModifier, Config.DefaultPlayerProjectileMoveVector));
        }
    }
}
