// <copyright file="PowerUpSpawner.cs" company="PlaceholderCompany">
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
    /// Holds the logic of spawning powerups
    /// </summary>
    public class PowerUpSpawner
    {
        private static Random random = new Random();
        private static int minSpread = 10;
        private static int maxSpread = 30;

        /// <summary>
        /// GetPowerUps
        /// </summary>
        /// <param name="enemyShip">enemyShip</param>
        /// <returns>List of power ups</returns>
        public List<PowerUp> GetPowerUps(EnemyShip enemyShip)
        {
            List<PowerUp> powerUps = new List<PowerUp>();
            int chance = random.Next(101);
            int spread = random.Next(minSpread, maxSpread);
            if (chance < Config.PowerUpLifeChance * enemyShip.PowerUpMultiplier)
            {
                powerUps.Add(new PowerUp(
                    enemyShip.Area.X,
                    enemyShip.Area.Y,
                    Config.PowerUpWidth,
                    Config.PowerUpHeight,
                    Config.PowerUpMoveVector,
                    PowerUpType.PlusLife));
            }

            chance = random.Next(101);
            spread = random.Next(minSpread, maxSpread);
            if (chance < Config.PowerUpWeaponSpeedChance * enemyShip.PowerUpMultiplier)
            {
                powerUps.Add(new PowerUp(
                    enemyShip.Area.X + Config.PowerUpWidth + spread,
                    enemyShip.Area.Y,
                    Config.PowerUpWidth,
                    Config.PowerUpHeight,
                    Config.PowerUpMoveVector,
                    PowerUpType.WeaponSpeed));
            }

            chance = random.Next(101);
            spread = random.Next(minSpread, maxSpread);
            if (chance < Config.PowerUpWeaponStrengthChance * enemyShip.PowerUpMultiplier)
            {
                powerUps.Add(new PowerUp(
                    enemyShip.Area.X,
                    enemyShip.Area.Y + Config.PowerUpHeight + spread,
                    Config.PowerUpWidth,
                    Config.PowerUpHeight,
                    Config.PowerUpMoveVector,
                    PowerUpType.WeaponStrength));
            }

            chance = random.Next(101);
            spread = random.Next(minSpread, maxSpread);
            if (chance < Config.PowerUpExtraProjectileChance * enemyShip.PowerUpMultiplier)
            {
                powerUps.Add(new PowerUp(
                    enemyShip.Area.X + Config.PowerUpWidth + spread,
                    enemyShip.Area.Y + Config.PowerUpHeight + spread,
                    Config.PowerUpWidth,
                    Config.PowerUpHeight,
                    Config.PowerUpMoveVector,
                    PowerUpType.ExtraProjectile));
            }

            return powerUps;
        }
    }
}
