// <copyright file="GameMechanics.cs" company="PlaceholderCompany">
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
    using System.Windows.Input;

    /// <summary>
    /// Main game logic
    /// </summary>
    public class GameMechanics
    {
        private List<MovingObject> movers;
        private List<MovingObject> projectilesToAdd;
        private PlayerShip player;
        private EnemyShipSpawner enemySpawner;
        private PowerUpSpawner powerUpSpawner;
        private PlayerProjectileSpawner playerProjectileSpawner;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameMechanics"/> class.
        /// </summary>
        public GameMechanics()
        {
            this.player = new PlayerShip(
                Config.PlayerSpawnPoint.X,
                Config.PlayerSpawnPoint.Y,
                Config.PlayerWidth,
                Config.PlayerHeight,
                Config.PlayerStartingLife,
                Config.PlayerShipAcceleration,
                Config.PlayerFireRate,
                Config.PlayerWeaponStrength,
                Config.PlayerNumOfProjectiles);
            this.movers = new List<MovingObject>
            {
                this.player
            };
            this.projectilesToAdd = new List<MovingObject>();
            this.enemySpawner = new EnemyShipSpawner();
            this.powerUpSpawner = new PowerUpSpawner();
            this.playerProjectileSpawner = new PlayerProjectileSpawner();
        }

        /// <summary>
        /// PlayerDiedEvent
        /// </summary>
        public delegate void PlayerDiedEvent();

        /// <summary>
        /// Gets or sets playerDied
        /// </summary>
        public PlayerDiedEvent PlayerDied { get; set; }

        /// <summary>
        /// Gets playerLifes
        /// </summary>
        public int PlayerLifes
        {
            get
            {
                return this.player.Life;
            }
        }

        /// <summary>
        /// Gets movers
        /// </summary>
        public List<MovingObject> Movers
        {
            get
            {
                return this.movers;
            }
        }

        /// <summary>
        /// Do all the things that are needed in the current timestep.
        /// </summary>
        public void NextStep()
        {
            this.RemoveUnusedObjects();
            this.CheckEnemyCollisionWithProjectiles();
            this.CheckPlayerCollisionWithProjetiles();
            this.CheckPlayerCollisionWithPowerUps();
            EnemyShip enemy = this.enemySpawner.GetNextEnemy(this.movers.Count(m => m is EnemyShip));
            if (enemy != null)
            {
                enemy.EnemyShotHappened += this.OnEnemyShooting;
                this.movers.Add(enemy);
            }

            foreach (var mover in this.movers)
            {
                if (mover is IDecideWhatToDo)
                {
                    IDecideWhatToDo ai = mover as IDecideWhatToDo;
                    ai.DecideNextStep();
                }

                mover.Move();
                if (mover is Ship)
                {
                    Ship ship = mover as Ship;
                    ship.Decelerate();
                }
            }

            this.movers.AddRange(this.projectilesToAdd);
            this.projectilesToAdd.Clear();
        }

        /// <summary>
        /// Checks if a movement key is pressed and call the appropriate movement function.
        /// </summary>
        public void CheckAndActOnMovementKeys()
        {
            if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
            {
                this.player.Up();
            }

            if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
            {
                this.player.Down();
            }

            if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
            {
                this.player.Left();
            }

            if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
            {
                this.player.Right();
            }
        }

        /// <summary>
        /// Checks if the shooting key is pressed then if ready to fire, shooting happens.
        /// </summary>
        public void CheckAndActOnShootingKeys()
        {
            if (Keyboard.IsKeyDown(Key.Space) && this.player.ReadyToFire)
            {
                this.movers.AddRange(this.playerProjectileSpawner.GetProjectiles(this.player.Area, this.player.NumOfProjectiles, this.player.WeaponStrength));
                this.player.FireLockCount = 0;
                this.player.ReadyToFire = false;
            }

            this.player.FireLockCount++;
            if (this.player.FireLockCount > this.player.FireRate)
            {
                this.player.ReadyToFire = true;
            }
        }

        private void RemoveUnusedObjects()
        {
            List<MovingObject> unusables = this.movers.FindAll(m => m is PlayerProjectile || m is EnemyProjectile || m is PowerUp);
            foreach (var mover in unusables)
            {
                if (!mover.Area.IntersectsWith(new Rect(0, 0, Config.WindowWidth, Config.WindowHeight)))
                {
                    this.movers.Remove(mover);
                }
            }
        }

        private void CheckPlayerCollisionWithProjetiles()
        {
            List<MovingObject> enemyProjectiles = this.movers.FindAll(m => m is EnemyProjectile);
            foreach (var projectile in enemyProjectiles)
            {
                if (this.player.Area.IntersectsWith(projectile.Area))
                {
                    this.player.Life--;
                    this.movers.Remove(projectile);
                    if (this.player.Life == 0)
                    {
                        this.PlayerDied.Invoke();
                    }
                }
            }
        }

        private void CheckPlayerCollisionWithPowerUps()
        {
            List<MovingObject> powerUps = this.movers.FindAll(m => m is PowerUp);
            foreach (var powerUp in powerUps)
            {
                if (this.player.Area.IntersectsWith(powerUp.Area))
                {
                    this.movers.Remove(powerUp);
                    PowerUp pUp = powerUp as PowerUp;
                    switch (pUp.Type)
                    {
                        case PowerUpType.PlusLife:
                            this.player.Life++;
                            break;
                        case PowerUpType.WeaponSpeed:
                            if (this.player.FireRate - 1 > 0)
                            {
                                this.player.FireRate--;
                            }

                            break;
                        case PowerUpType.WeaponStrength:
                            if (this.player.WeaponStrength + 1 <= Config.PlayerMaxWeaponStrength)
                            {
                                this.player.WeaponStrength++;
                            }

                            break;
                        case PowerUpType.ExtraProjectile:
                            if (this.player.NumOfProjectiles + 1 <= Config.PlayerMaxProjectiles)
                            {
                                this.player.NumOfProjectiles++;
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void CheckEnemyCollisionWithProjectiles()
        {
            List<MovingObject> enemyShips = this.movers.FindAll(m => m is EnemyShip);
            List<MovingObject> playerProjectiles = this.movers.FindAll(m => m is PlayerProjectile);
            foreach (var enemyShip in enemyShips)
            {
                foreach (var projectile in playerProjectiles)
                {
                    if (enemyShip.Area.IntersectsWith(projectile.Area))
                    {
                        EnemyShip ship = enemyShip as EnemyShip;
                        ship.Life -= this.player.WeaponStrength;
                        this.movers.Remove(projectile);
                        if (ship.Life <= 0)
                        {
                            this.movers.Remove(enemyShip);
                            List<PowerUp> powerUps = this.powerUpSpawner.GetPowerUps(ship);
                            this.movers.InsertRange(0, powerUps);
                        }
                    }
                }
            }
        }

        private void OnEnemyShooting(EnemyShip enemyShip)
        {
            if (enemyShip is GruntFighter)
            {
                this.projectilesToAdd.Add(
                    new EnemyProjectile(
                        enemyShip.Area.X + (enemyShip.Area.Width / 2),
                        enemyShip.Area.Y + enemyShip.Area.Height,
                        Config.EnemeyDefaultProjectileWidth,
                        Config.EnemeyDefaultProjectileHeight,
                        Config.GruntFighterProjectileMoveVector));
            }
            else if (enemyShip is Reaper)
            {
                this.projectilesToAdd.Add(
                    new EnemyProjectile(
                        enemyShip.Area.X,
                        enemyShip.Area.Bottom,
                        Config.EnemeyDefaultProjectileWidth,
                        Config.EnemeyDefaultProjectileHeight,
                        Config.ReaperProjectileMoveVector));
                this.projectilesToAdd.Add(
                    new EnemyProjectile(
                        enemyShip.Area.Right,
                        enemyShip.Area.Bottom,
                        Config.EnemeyDefaultProjectileWidth,
                        Config.EnemeyDefaultProjectileHeight,
                        Config.ReaperProjectileMoveVector));
            }
            else if (enemyShip is Dozer)
            {
                this.projectilesToAdd.Add(
                    new EnemyProjectile(
                        enemyShip.Area.X + (enemyShip.Area.Width / 2),
                        enemyShip.Area.Y + enemyShip.Area.Height,
                        Config.EnemeyDefaultProjectileWidth,
                        Config.EnemeyDefaultProjectileHeight,
                        Config.DozerProjectileMoveVector));
                this.projectilesToAdd.Add(
                    new EnemyProjectile(
                        enemyShip.Area.Left,
                        enemyShip.Area.Y + enemyShip.Area.Height,
                        Config.EnemeyDefaultProjectileWidth,
                        Config.EnemeyDefaultProjectileHeight,
                        Config.DozerProjectileMoveVectorLeft));
                this.projectilesToAdd.Add(
                    new EnemyProjectile(
                        enemyShip.Area.Right,
                        enemyShip.Area.Y + enemyShip.Area.Height,
                        Config.EnemeyDefaultProjectileWidth,
                        Config.EnemeyDefaultProjectileHeight,
                        Config.DozerProjectileMoveVectorRight));
            }
            else if (enemyShip is Gunship)
            {
                Gunship gunship = enemyShip as Gunship;
                if (gunship.FireType == GunshipFireType.Normal)
                {
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.X + (enemyShip.Area.Width * 0.5),
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVector));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.Left,
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVectorLeft));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.Right,
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVectorRight));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.X + (enemyShip.Area.Width * 0.8),
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVectorHardLeft));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.X + (enemyShip.Area.Width * 0.2),
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVectorHardRight));
                    if (gunship.IsHoldFire())
                    {
                        gunship.FireType = GunshipFireType.Cannon;
                    }
                }
                else if (gunship.FireType == GunshipFireType.Cannon)
                {
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.X + (enemyShip.Area.Width * 0.1),
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVector));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.X + (enemyShip.Area.Width * 0.2),
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVector));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.X + (enemyShip.Area.Width * 0.3),
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVector));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.X + (enemyShip.Area.Width * 0.4),
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVector));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.X + (enemyShip.Area.Width * 0.7),
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVector));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.X + (enemyShip.Area.Width * 0.8),
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVector));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.X + (enemyShip.Area.Width * 0.9),
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVector));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.Left,
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVectorLeft));
                    this.projectilesToAdd.Add(
                        new EnemyProjectile(
                            enemyShip.Area.Right,
                            enemyShip.Area.Y + enemyShip.Area.Height,
                            Config.EnemeyDefaultProjectileWidth,
                            Config.EnemeyDefaultProjectileHeight,
                            Config.GunshipProjectileMoveVectorRight));
                    if (gunship.IsHoldFire())
                    {
                        gunship.FireType = GunshipFireType.Normal;
                    }
                }
            }
        }
    }
}
