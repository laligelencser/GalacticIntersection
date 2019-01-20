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
        private static double windowWidth = 1200;
        private static double windowHeight = 700;
        private static double defaultShipDeceleration = 0.6;
        private static double playerShipDeceleration = 0.8;
        private static Point playerSpawnPoint = new Point(400, 490);
        private static double playerWidth = 55;
        private static double playerHeight = 82;
        private static double playerShipAcceleration = 1.85;
        private static int playerFireRate = 30;
        private static int playerWeaponStrength = 1;
        private static int playerMaxWeaponStrength = 5;
        private static int playerNumOfProjectiles = 1;
        private static int playerMaxProjectiles = 8;
        private static double playerProjectileWidth = 5;
        private static double playerProjectileHeight = 30;
        private static Vector defaultPlayerProjectileMoveVector = new Vector(0, -10);
        private static int playerStartingLife = 3;
        private static double gruntFighterWidth = 60;
        private static double gruntFighterHeight = 60;
        private static int gruntFighterLife = 5;
        private static double gruntFighterAcceleration = 1.5;
        private static int gruntFighterFireRate = 50;
        private static Vector gruntFighterProjectileMoveVector = new Vector(0, 5);
        private static int gruntFighterPowerUpMultiplier = 1;
        private static double enemyDefaultProjectileWidth = 20;
        private static double enemyDefaultProjectileHeight = 20;
        private static double reaperWidth = 120;
        private static double reaperHeight = 90;
        private static int reaperLife = 10;
        private static double reaperAcceleration = 2;
        private static int reaperFireRate = 100;
        private static Vector reaperProjectileMoveVector = new Vector(0, 8);
        private static int reaperPowerUpMultiplier = 2;
        private static double dozerWidth = 150;
        private static double dozerHeight = 150;
        private static int dozerLife = 300;
        private static double dozerAcceleration = 1;
        private static int dozerFireRate = 5;
        private static int dozerHoldFireRate = 400;
        private static int dozerNumOfShots = 30;
        private static Vector dozerProjectileMoveVector = new Vector(0, 8);
        private static Vector dozerProjectileMoveVectorLeft = new Vector(-4, 8);
        private static Vector dozerProjectileMoveVectorRight = new Vector(4, 8);
        private static int dozerPowerUpMultiplier = 4;
        private static double gunshipWidth = 700;
        private static double gunshipHeight = 200;
        private static int gunshipLife = 5000;
        private static double gunshipAcceleration = 0.5;
        private static int gunshipFireRate = 4;
        private static int gunshipHoldFireRate = 500;
        private static int gunshipNumOfShots = 90;
        private static Vector gunshipProjectileMoveVector = new Vector(0, 5);
        private static Vector gunshipProjectileMoveVectorLeft = new Vector(-2, 5);
        private static Vector gunshipProjectileMoveVectorRight = new Vector(2, 5);
        private static Vector gunshipProjectileMoveVectorHardLeft = new Vector(-6, 5);
        private static Vector gunshipProjectileMoveVectorHardRight = new Vector(6, 5);
        private static int gunshipPowerUpMultiplier = 10;
        private static double powerUpWidth = 20;
        private static double powerUpHeight = 20;
        private static Vector powerUpMoveVector = new Vector(0, 1);
        private static int powerUpLifeChance = 9;
        private static int powerUpWeaponStrengthChance = 6;
        private static int powerUpWeaponSpeedChance = 7;
        private static int powerUpExtraProjectileChance = 7;

        /// <summary>
        /// Gets or sets WindowWidth
        /// </summary>
        public static double WindowWidth { get => windowWidth; set => windowWidth = value; }

        /// <summary>
        /// Gets or sets windowHeight
        /// </summary>
        public static double WindowHeight { get => windowHeight; set => windowHeight = value; }

        /// <summary>
        /// Gets or sets playerSpawnPoint
        /// </summary>
        public static Point PlayerSpawnPoint { get => playerSpawnPoint; set => playerSpawnPoint = value; }

        /// <summary>
        /// Gets or sets playerWidth
        /// </summary>
        public static double PlayerWidth { get => playerWidth; set => playerWidth = value; }

        /// <summary>
        /// Gets or sets playerHeight
        /// </summary>
        public static double PlayerHeight { get => playerHeight; set => playerHeight = value; }

        /// <summary>
        /// Gets or sets defaultPlayerProjectileMoveVector
        /// </summary>
        public static Vector DefaultPlayerProjectileMoveVector { get => defaultPlayerProjectileMoveVector; set => defaultPlayerProjectileMoveVector = value; }

        /// <summary>
        /// Gets or sets playerProjectileWidth
        /// </summary>
        public static double PlayerProjectileWidth { get => playerProjectileWidth; set => playerProjectileWidth = value; }

        /// <summary>
        /// Gets or sets playerProjectileHeight
        /// </summary>
        public static double PlayerProjectileHeight { get => playerProjectileHeight; set => playerProjectileHeight = value; }

        /// <summary>
        /// Gets or sets playerFireRate
        /// </summary>
        public static int PlayerFireRate { get => playerFireRate; set => playerFireRate = value; }

        /// <summary>
        /// Gets or sets playerShipAcceleration
        /// </summary>
        public static double PlayerShipAcceleration { get => playerShipAcceleration; set => playerShipAcceleration = value; }

        /// <summary>
        /// Gets or sets gruntFighterProjectileMoveVector
        /// </summary>
        public static Vector GruntFighterProjectileMoveVector { get => gruntFighterProjectileMoveVector; set => gruntFighterProjectileMoveVector = value; }

        /// <summary>
        /// Gets or sets EnemeyDefaultProjectileWidth
        /// </summary>
        public static double EnemeyDefaultProjectileWidth { get => enemyDefaultProjectileWidth; set => enemyDefaultProjectileWidth = value; }

        /// <summary>
        /// Gets or sets EnemeyDefaultProjectileHeight
        /// </summary>
        public static double EnemeyDefaultProjectileHeight { get => enemyDefaultProjectileHeight; set => enemyDefaultProjectileHeight = value; }

        /// <summary>
        /// Gets or sets gruntFighterWidth
        /// </summary>
        public static double GruntFighterWidth { get => gruntFighterWidth; set => gruntFighterWidth = value; }

        /// <summary>
        /// Gets or sets gruntFighterHeight
        /// </summary>
        public static double GruntFighterHeight { get => gruntFighterHeight; set => gruntFighterHeight = value; }

        /// <summary>
        /// Gets or sets gruntFighterAcceleration
        /// </summary>
        public static double GruntFighterAcceleration { get => gruntFighterAcceleration; set => gruntFighterAcceleration = value; }

        /// <summary>
        /// Gets or sets gruntFighterFireRate
        /// </summary>
        public static int GruntFighterFireRate { get => gruntFighterFireRate; set => gruntFighterFireRate = value; }

        /// <summary>
        /// Gets or sets playerStartingLife
        /// </summary>
        public static int PlayerStartingLife { get => playerStartingLife; set => playerStartingLife = value; }

        /// <summary>
        /// Gets or sets gruntFighterLife
        /// </summary>
        public static int GruntFighterLife { get => gruntFighterLife; set => gruntFighterLife = value; }

        /// <summary>
        /// Gets or sets defaultShipDeceleration
        /// </summary>
        public static double DefaultShipDeceleration { get => defaultShipDeceleration; set => defaultShipDeceleration = value; }

        /// <summary>
        /// Gets or sets playerShipDeceleration
        /// </summary>
        public static double PlayerShipDeceleration { get => playerShipDeceleration; set => playerShipDeceleration = value; }

        /// <summary>
        /// Gets or sets powerUpWidth
        /// </summary>
        public static double PowerUpWidth { get => powerUpWidth; set => powerUpWidth = value; }

        /// <summary>
        /// Gets or sets powerUpHeight
        /// </summary>
        public static double PowerUpHeight { get => powerUpHeight; set => powerUpHeight = value; }

        /// <summary>
        /// Gets or sets powerUpMoveVector
        /// </summary>
        public static Vector PowerUpMoveVector { get => powerUpMoveVector; set => powerUpMoveVector = value; }

        /// <summary>
        /// Gets or sets powerUpLifeChance
        /// </summary>
        public static int PowerUpLifeChance { get => powerUpLifeChance; set => powerUpLifeChance = value; }

        /// <summary>
        /// Gets or sets powerUpWeaponStrengthChance
        /// </summary>
        public static int PowerUpWeaponStrengthChance { get => powerUpWeaponStrengthChance; set => powerUpWeaponStrengthChance = value; }

        /// <summary>
        /// Gets or sets powerUpWeaponSpeedChance
        /// </summary>
        public static int PowerUpWeaponSpeedChance { get => powerUpWeaponSpeedChance; set => powerUpWeaponSpeedChance = value; }

        /// <summary>
        /// Gets or sets powerUpExtraProjectileChance
        /// </summary>
        public static int PowerUpExtraProjectileChance { get => powerUpExtraProjectileChance; set => powerUpExtraProjectileChance = value; }

        /// <summary>
        /// Gets or sets playerWeaponStrength
        /// </summary>
        public static int PlayerWeaponStrength { get => playerWeaponStrength; set => playerWeaponStrength = value; }

        /// <summary>
        /// Gets or sets playerNumOfProjectiles
        /// </summary>
        public static int PlayerNumOfProjectiles { get => playerNumOfProjectiles; set => playerNumOfProjectiles = value; }

        /// <summary>
        /// Gets or sets playerMaxProjectiles
        /// </summary>
        public static int PlayerMaxProjectiles { get => playerMaxProjectiles; set => playerMaxProjectiles = value; }

        /// <summary>
        /// Gets or sets playerMaxWeaponStrength
        /// </summary>
        public static int PlayerMaxWeaponStrength { get => playerMaxWeaponStrength; set => playerMaxWeaponStrength = value; }

        /// <summary>
        /// Gets or sets reaperWidth
        /// </summary>
        public static double ReaperWidth { get => reaperWidth; set => reaperWidth = value; }

        /// <summary>
        /// Gets or sets reaperHeight
        /// </summary>
        public static double ReaperHeight { get => reaperHeight; set => reaperHeight = value; }

        /// <summary>
        /// Gets or sets reaperLife
        /// </summary>
        public static int ReaperLife { get => reaperLife; set => reaperLife = value; }

        /// <summary>
        /// Gets or sets reaperAcceleration
        /// </summary>
        public static double ReaperAcceleration { get => reaperAcceleration; set => reaperAcceleration = value; }

        /// <summary>
        /// Gets or sets reaperFireRate
        /// </summary>
        public static int ReaperFireRate { get => reaperFireRate; set => reaperFireRate = value; }

        /// <summary>
        /// Gets or sets reaperProjectileMoveVector
        /// </summary>
        public static Vector ReaperProjectileMoveVector { get => reaperProjectileMoveVector; set => reaperProjectileMoveVector = value; }

        /// <summary>
        /// Gets or sets gruntFighterPowerUpMultiplier
        /// </summary>
        public static int GruntFighterPowerUpMultiplier { get => gruntFighterPowerUpMultiplier; set => gruntFighterPowerUpMultiplier = value; }

        /// <summary>
        /// Gets or sets reaperPowerUpMultiplier
        /// </summary>
        public static int ReaperPowerUpMultiplier { get => reaperPowerUpMultiplier; set => reaperPowerUpMultiplier = value; }

        /// <summary>
        /// Gets or sets dozerWidth
        /// </summary>
        public static double DozerWidth { get => dozerWidth; set => dozerWidth = value; }

        /// <summary>
        /// Gets or sets dozerHeight
        /// </summary>
        public static double DozerHeight { get => dozerHeight; set => dozerHeight = value; }

        /// <summary>
        /// Gets or sets dozerLife
        /// </summary>
        public static int DozerLife { get => dozerLife; set => dozerLife = value; }

        /// <summary>
        /// Gets or sets dozerAcceleration
        /// </summary>
        public static double DozerAcceleration { get => dozerAcceleration; set => dozerAcceleration = value; }

        /// <summary>
        /// Gets or sets dozerFireRate
        /// </summary>
        public static int DozerFireRate { get => dozerFireRate; set => dozerFireRate = value; }

        /// <summary>
        /// Gets or sets dozerHoldFireRate
        /// </summary>
        public static int DozerHoldFireRate { get => dozerHoldFireRate; set => dozerHoldFireRate = value; }

        /// <summary>
        /// Gets or sets dozerNumOfShots
        /// </summary>
        public static int DozerNumOfShots { get => dozerNumOfShots; set => dozerNumOfShots = value; }

        /// <summary>
        /// Gets or sets dozerProjectileMoveVector
        /// </summary>
        public static Vector DozerProjectileMoveVector { get => dozerProjectileMoveVector; set => dozerProjectileMoveVector = value; }

        /// <summary>
        /// Gets or sets dozerPowerUpMultiplier
        /// </summary>
        public static int DozerPowerUpMultiplier { get => dozerPowerUpMultiplier; set => dozerPowerUpMultiplier = value; }

        /// <summary>
        /// Gets or sets dozerProjectileMoveVectorLeft
        /// </summary>
        public static Vector DozerProjectileMoveVectorLeft { get => dozerProjectileMoveVectorLeft; set => dozerProjectileMoveVectorLeft = value; }

        /// <summary>
        /// Gets or sets dozerProjectileMoveVectorRight
        /// </summary>
        public static Vector DozerProjectileMoveVectorRight { get => dozerProjectileMoveVectorRight; set => dozerProjectileMoveVectorRight = value; }

        /// <summary>
        /// Gets or sets gunshipWidth
        /// </summary>
        public static double GunshipWidth { get => gunshipWidth; set => gunshipWidth = value; }

        /// <summary>
        /// Gets or sets gunshipHeight
        /// </summary>
        public static double GunshipHeight { get => gunshipHeight; set => gunshipHeight = value; }

        /// <summary>
        /// Gets or sets gunshipLife
        /// </summary>
        public static int GunshipLife { get => gunshipLife; set => gunshipLife = value; }

        /// <summary>
        /// Gets or sets gunshipAcceleration
        /// </summary>
        public static double GunshipAcceleration { get => gunshipAcceleration; set => gunshipAcceleration = value; }

        /// <summary>
        /// Gets or sets gunshipFireRate
        /// </summary>
        public static int GunshipFireRate { get => gunshipFireRate; set => gunshipFireRate = value; }

        /// <summary>
        /// Gets or sets gunshipHoldFireRate
        /// </summary>
        public static int GunshipHoldFireRate { get => gunshipHoldFireRate; set => gunshipHoldFireRate = value; }

        /// <summary>
        /// Gets or sets gunshipNumOfShots
        /// </summary>
        public static int GunshipNumOfShots { get => gunshipNumOfShots; set => gunshipNumOfShots = value; }

        /// <summary>
        /// Gets or sets gunshipProjectileMoveVector
        /// </summary>
        public static Vector GunshipProjectileMoveVector { get => gunshipProjectileMoveVector; set => gunshipProjectileMoveVector = value; }

        /// <summary>
        /// Gets or sets gunshipProjectileMoveVectorLeft
        /// </summary>
        public static Vector GunshipProjectileMoveVectorLeft { get => gunshipProjectileMoveVectorLeft; set => gunshipProjectileMoveVectorLeft = value; }

        /// <summary>
        /// Gets or sets gunshipProjectileMoveVectorRight
        /// </summary>
        public static Vector GunshipProjectileMoveVectorRight { get => gunshipProjectileMoveVectorRight; set => gunshipProjectileMoveVectorRight = value; }

        /// <summary>
        /// Gets or sets gunshipPowerUpMultiplier
        /// </summary>
        public static int GunshipPowerUpMultiplier { get => gunshipPowerUpMultiplier; set => gunshipPowerUpMultiplier = value; }

        /// <summary>
        /// Gets or sets gunshipProjectileMoveVectorHardRight
        /// </summary>
        public static Vector GunshipProjectileMoveVectorHardRight { get => gunshipProjectileMoveVectorHardRight; set => gunshipProjectileMoveVectorHardRight = value; }

        /// <summary>
        /// Gets or sets gunshipProjectileMoveVectorHardLeft
        /// </summary>
        public static Vector GunshipProjectileMoveVectorHardLeft { get => gunshipProjectileMoveVectorHardLeft; set => gunshipProjectileMoveVectorHardLeft = value; }
    }
}
