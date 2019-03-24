// <copyright file="Config.cs" company="PlaceholderCompany">
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
    /// Holds all the configurable parameters
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Gets or sets WindowWidth
        /// </summary>
        public static double WindowWidth { get; set; } = 1200;

        /// <summary>
        /// Gets or sets windowHeight
        /// </summary>
        public static double WindowHeight { get; set; } = 700;

        /// <summary>
        /// Gets or sets playerSpawnPoint
        /// </summary>
        public static Point PlayerSpawnPoint { get; set; } = new Point(400, 490);

        /// <summary>
        /// Gets or sets playerWidth
        /// </summary>
        public static double PlayerWidth { get; set; } = 55;

        /// <summary>
        /// Gets or sets playerHeight
        /// </summary>
        public static double PlayerHeight { get; set; } = 82;

        /// <summary>
        /// Gets or sets defaultPlayerProjectileMoveVector
        /// </summary>
        public static Vector DefaultPlayerProjectileMoveVector { get; set; } = new Vector(0, -10);

        /// <summary>
        /// Gets or sets playerProjectileWidth
        /// </summary>
        public static double PlayerProjectileWidth { get; set; } = 5;

        /// <summary>
        /// Gets or sets playerProjectileHeight
        /// </summary>
        public static double PlayerProjectileHeight { get; set; } = 30;

        /// <summary>
        /// Gets or sets playerFireRate
        /// </summary>
        public static int PlayerFireRate { get; set; } = 30;

        /// <summary>
        /// Gets or sets playerShipAcceleration
        /// </summary>
        public static double PlayerShipAcceleration { get; set; } = 1.85;

        /// <summary>
        /// Gets or sets gruntFighterProjectileMoveVector
        /// </summary>
        public static Vector GruntFighterProjectileMoveVector { get; set; } = new Vector(0, 5);

        /// <summary>
        /// Gets or sets EnemeyDefaultProjectileWidth
        /// </summary>
        public static double EnemeyDefaultProjectileWidth { get; set; } = 20;

        /// <summary>
        /// Gets or sets EnemeyDefaultProjectileHeight
        /// </summary>
        public static double EnemeyDefaultProjectileHeight { get; set; } = 20;

        /// <summary>
        /// Gets or sets gruntFighterWidth
        /// </summary>
        public static double GruntFighterWidth { get; set; } = 60;

        /// <summary>
        /// Gets or sets gruntFighterHeight
        /// </summary>
        public static double GruntFighterHeight { get; set; } = 60;

        /// <summary>
        /// Gets or sets gruntFighterAcceleration
        /// </summary>
        public static double GruntFighterAcceleration { get; set; } = 1.5;

        /// <summary>
        /// Gets or sets gruntFighterFireRate
        /// </summary>
        public static int GruntFighterFireRate { get; set; } = 50;

        /// <summary>
        /// Gets or sets playerStartingLife
        /// </summary>
        public static int PlayerStartingLife { get; set; } = 3;

        /// <summary>
        /// Gets or sets gruntFighterLife
        /// </summary>
        public static int GruntFighterLife { get; set; } = 5;

        /// <summary>
        /// Gets or sets defaultShipDeceleration
        /// </summary>
        public static double DefaultShipDeceleration { get; set; } = 0.6;

        /// <summary>
        /// Gets or sets playerShipDeceleration
        /// </summary>
        public static double PlayerShipDeceleration { get; set; } = 0.8;

        /// <summary>
        /// Gets or sets powerUpWidth
        /// </summary>
        public static double PowerUpWidth { get; set; } = 20;

        /// <summary>
        /// Gets or sets powerUpHeight
        /// </summary>
        public static double PowerUpHeight { get; set; } = 20;

        /// <summary>
        /// Gets or sets powerUpMoveVector
        /// </summary>
        public static Vector PowerUpMoveVector { get; set; } = new Vector(0, 1);

        /// <summary>
        /// Gets or sets powerUpLifeChance
        /// </summary>
        public static int PowerUpLifeChance { get; set; } = 9;

        /// <summary>
        /// Gets or sets powerUpWeaponStrengthChance
        /// </summary>
        public static int PowerUpWeaponStrengthChance { get; set; } = 6;

        /// <summary>
        /// Gets or sets powerUpWeaponSpeedChance
        /// </summary>
        public static int PowerUpWeaponSpeedChance { get; set; } = 7;

        /// <summary>
        /// Gets or sets powerUpExtraProjectileChance
        /// </summary>
        public static int PowerUpExtraProjectileChance { get; set; } = 7;

        /// <summary>
        /// Gets or sets playerWeaponStrength
        /// </summary>
        public static int PlayerWeaponStrength { get; set; } = 1;

        /// <summary>
        /// Gets or sets playerNumOfProjectiles
        /// </summary>
        public static int PlayerNumOfProjectiles { get; set; } = 1;

        /// <summary>
        /// Gets or sets playerMaxProjectiles
        /// </summary>
        public static int PlayerMaxProjectiles { get; set; } = 8;

        /// <summary>
        /// Gets or sets playerMaxWeaponStrength
        /// </summary>
        public static int PlayerMaxWeaponStrength { get; set; } = 5;

        /// <summary>
        /// Gets or sets reaperWidth
        /// </summary>
        public static double ReaperWidth { get; set; } = 120;

        /// <summary>
        /// Gets or sets reaperHeight
        /// </summary>
        public static double ReaperHeight { get; set; } = 90;

        /// <summary>
        /// Gets or sets reaperLife
        /// </summary>
        public static int ReaperLife { get; set; } = 10;

        /// <summary>
        /// Gets or sets reaperAcceleration
        /// </summary>
        public static double ReaperAcceleration { get; set; } = 2;

        /// <summary>
        /// Gets or sets reaperFireRate
        /// </summary>
        public static int ReaperFireRate { get; set; } = 100;

        /// <summary>
        /// Gets or sets reaperProjectileMoveVector
        /// </summary>
        public static Vector ReaperProjectileMoveVector { get; set; } = new Vector(0, 8);

        /// <summary>
        /// Gets or sets gruntFighterPowerUpMultiplier
        /// </summary>
        public static int GruntFighterPowerUpMultiplier { get; set; } = 1;

        /// <summary>
        /// Gets or sets reaperPowerUpMultiplier
        /// </summary>
        public static int ReaperPowerUpMultiplier { get; set; } = 2;

        /// <summary>
        /// Gets or sets dozerWidth
        /// </summary>
        public static double DozerWidth { get; set; } = 150;

        /// <summary>
        /// Gets or sets dozerHeight
        /// </summary>
        public static double DozerHeight { get; set; } = 150;

        /// <summary>
        /// Gets or sets dozerLife
        /// </summary>
        public static int DozerLife { get; set; } = 300;

        /// <summary>
        /// Gets or sets dozerAcceleration
        /// </summary>
        public static double DozerAcceleration { get; set; } = 1;

        /// <summary>
        /// Gets or sets dozerFireRate
        /// </summary>
        public static int DozerFireRate { get; set; } = 5;

        /// <summary>
        /// Gets or sets dozerHoldFireRate
        /// </summary>
        public static int DozerHoldFireRate { get; set; } = 400;

        /// <summary>
        /// Gets or sets dozerNumOfShots
        /// </summary>
        public static int DozerNumOfShots { get; set; } = 30;

        /// <summary>
        /// Gets or sets dozerProjectileMoveVector
        /// </summary>
        public static Vector DozerProjectileMoveVector { get; set; } = new Vector(0, 8);

        /// <summary>
        /// Gets or sets dozerPowerUpMultiplier
        /// </summary>
        public static int DozerPowerUpMultiplier { get; set; } = 4;

        /// <summary>
        /// Gets or sets dozerProjectileMoveVectorLeft
        /// </summary>
        public static Vector DozerProjectileMoveVectorLeft { get; set; } = new Vector(-4, 8);

        /// <summary>
        /// Gets or sets dozerProjectileMoveVectorRight
        /// </summary>
        public static Vector DozerProjectileMoveVectorRight { get; set; } = new Vector(4, 8);

        /// <summary>
        /// Gets or sets gunshipWidth
        /// </summary>
        public static double GunshipWidth { get; set; } = 700;

        /// <summary>
        /// Gets or sets gunshipHeight
        /// </summary>
        public static double GunshipHeight { get; set; } = 200;

        /// <summary>
        /// Gets or sets gunshipLife
        /// </summary>
        public static int GunshipLife { get; set; } = 5000;

        /// <summary>
        /// Gets or sets gunshipAcceleration
        /// </summary>
        public static double GunshipAcceleration { get; set; } = 0.5;

        /// <summary>
        /// Gets or sets gunshipFireRate
        /// </summary>
        public static int GunshipFireRate { get; set; } = 4;

        /// <summary>
        /// Gets or sets gunshipHoldFireRate
        /// </summary>
        public static int GunshipHoldFireRate { get; set; } = 500;

        /// <summary>
        /// Gets or sets gunshipNumOfShots
        /// </summary>
        public static int GunshipNumOfShots { get; set; } = 90;

        /// <summary>
        /// Gets or sets gunshipProjectileMoveVector
        /// </summary>
        public static Vector GunshipProjectileMoveVector { get; set; } = new Vector(0, 5);

        /// <summary>
        /// Gets or sets gunshipProjectileMoveVectorLeft
        /// </summary>
        public static Vector GunshipProjectileMoveVectorLeft { get; set; } = new Vector(-2, 5);

        /// <summary>
        /// Gets or sets gunshipProjectileMoveVectorRight
        /// </summary>
        public static Vector GunshipProjectileMoveVectorRight { get; set; } = new Vector(2, 5);

        /// <summary>
        /// Gets or sets gunshipPowerUpMultiplier
        /// </summary>
        public static int GunshipPowerUpMultiplier { get; set; } = 10;

        /// <summary>
        /// Gets or sets gunshipProjectileMoveVectorHardRight
        /// </summary>
        public static Vector GunshipProjectileMoveVectorHardRight { get; set; } = new Vector(6, 5);

        /// <summary>
        /// Gets or sets gunshipProjectileMoveVectorHardLeft
        /// </summary>
        public static Vector GunshipProjectileMoveVectorHardLeft { get; set; } = new Vector(-6, 5);
    }
}
