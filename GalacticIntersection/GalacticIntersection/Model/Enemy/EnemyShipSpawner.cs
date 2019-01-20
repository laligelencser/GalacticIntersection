// <copyright file="EnemyShipSpawner.cs" company="PlaceholderCompany">
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
    /// Logic for creating the enemy ships.
    /// </summary>
    public class EnemyShipSpawner
    {
        private static Random random = new Random();
        private int defaultSpawnRate = 20;
        private int spawnRate = 20;
        private int spawnCount = 0;
        private Queue<EnemyShip> enemyQueue;
        private int destSize = 10;
        private double firstRank = Config.WindowHeight * 0.1;
        private double secondRank = Config.WindowHeight * 0.2;
        private double thirdRank = Config.WindowHeight * 0.3;
        private double fourthRank = Config.WindowHeight * 0.4;
        private double fifthRank = Config.WindowHeight * 0.5;
        private double sixthRank = Config.WindowHeight * 0.6;
        private double middle = Config.WindowWidth * 0.5;
        private double quarter = Config.WindowWidth * 0.25;
        private double threeQuarter = Config.WindowWidth * 0.75;
        private double right = Config.WindowWidth * 0.9;
        private double left = 0;
        private List<Rect> leftToRightBackRank;
        private List<Rect> rightToLeftBackRank;
        private List<Rect> leftToRightFirstRank;
        private List<Rect> rightToLeftFirstRank;
        private List<Rect> middleToRightToLeftFirstRank;
        private List<Rect> middleToRightToLeftSecondRank;
        private List<Rect> middleToRightToLeftThirdRank;
        private List<Rect> rightDiamond;
        private List<Rect> leftDiamond;
        private List<Rect> leftToRightZigZag;
        private List<Rect> rightToLeftZigZag;
        private List<List<Rect>> allPath;
        private List<List<Rect>> gruntPaths;
        private List<List<Rect>> reaperPaths;
        private List<List<Rect>> dozerPaths;
        private List<List<Rect>> gunshipPaths;
        private int currentWave;
        private List<Dictionary<EnemyTypes, int>> wawes;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyShipSpawner"/> class.
        /// </summary>
        public EnemyShipSpawner()
        {
            this.leftToRightBackRank = new List<Rect>()
            {
                new Rect(this.left, -10, this.destSize, this.destSize),
                new Rect(this.right, -10, this.destSize, this.destSize)
            };
            this.rightToLeftBackRank = new List<Rect>()
            {
                new Rect(this.left, -10, this.destSize, this.destSize),
                new Rect(this.right, -10, this.destSize, this.destSize)
            };
            this.leftToRightFirstRank = new List<Rect>()
            {
                new Rect(this.left, this.firstRank, this.destSize, this.destSize),
                new Rect(this.right, this.firstRank, this.destSize, this.destSize)
            };
            this.rightToLeftFirstRank = new List<Rect>()
            {
                new Rect(this.right, this.firstRank, this.destSize, this.destSize),
                new Rect(this.left, this.firstRank, this.destSize, this.destSize)
            };
            this.middleToRightToLeftFirstRank = new List<Rect>()
            {
                new Rect(this.middle, this.firstRank, this.destSize, this.destSize),
                new Rect(this.right, this.firstRank, this.destSize, this.destSize),
                new Rect(this.left, this.firstRank, this.destSize, this.destSize)
            };
            this.middleToRightToLeftSecondRank = new List<Rect>()
            {
                new Rect(this.middle, this.secondRank, this.destSize, this.destSize),
                new Rect(this.right, this.secondRank, this.destSize, this.destSize),
                new Rect(this.left, this.secondRank, this.destSize, this.destSize)
            };
            this.middleToRightToLeftThirdRank = new List<Rect>()
            {
                new Rect(this.middle, this.thirdRank, this.destSize, this.destSize),
                new Rect(this.right, this.thirdRank, this.destSize, this.destSize),
                new Rect(this.left, this.thirdRank, this.destSize, this.destSize)
            };
            this.rightDiamond = new List<Rect>()
            {
                new Rect(this.middle, this.sixthRank, this.destSize, this.destSize),
                new Rect(this.right, this.thirdRank, this.destSize, this.destSize),
                new Rect(this.middle, this.firstRank, this.destSize, this.destSize),
                new Rect(this.left, this.thirdRank, this.destSize, this.destSize),
            };
            this.leftDiamond = new List<Rect>()
            {
                new Rect(this.middle, this.sixthRank, this.destSize, this.destSize),
                new Rect(this.left, this.thirdRank, this.destSize, this.destSize),
                new Rect(this.middle, this.firstRank, this.destSize, this.destSize),
                new Rect(this.right, this.thirdRank, this.destSize, this.destSize),
            };
            this.rightToLeftZigZag = new List<Rect>()
            {
                new Rect(this.right, this.firstRank, this.destSize, this.destSize),
                new Rect(this.threeQuarter, this.fifthRank, this.destSize, this.destSize),
                new Rect(this.middle, this.firstRank, this.destSize, this.destSize),
                new Rect(this.quarter, this.fifthRank, this.destSize, this.destSize),
                new Rect(this.left, this.firstRank, this.destSize, this.destSize),
                new Rect(this.quarter, this.fifthRank, this.destSize, this.destSize),
                new Rect(this.middle, this.firstRank, this.destSize, this.destSize),
                new Rect(this.threeQuarter, this.fifthRank, this.destSize, this.destSize)
            };
            this.leftToRightZigZag = new List<Rect>()
            {
                new Rect(this.left, this.firstRank, this.destSize, this.destSize),
                new Rect(this.quarter, this.fifthRank, this.destSize, this.destSize),
                new Rect(this.middle, this.firstRank, this.destSize, this.destSize),
                new Rect(this.threeQuarter, this.fifthRank, this.destSize, this.destSize),
                new Rect(this.right, this.firstRank, this.destSize, this.destSize),
                new Rect(this.threeQuarter, this.fifthRank, this.destSize, this.destSize),
                new Rect(this.middle, this.firstRank, this.destSize, this.destSize),
                new Rect(this.quarter, this.fifthRank, this.destSize, this.destSize)
            };
            this.gruntPaths = new List<List<Rect>>()
            {
                this.leftToRightFirstRank,
                this.rightToLeftFirstRank,
                this.middleToRightToLeftFirstRank,
                this.rightDiamond,
                this.leftDiamond,
                this.rightToLeftZigZag,
                this.leftToRightZigZag
            };
            this.reaperPaths = new List<List<Rect>>()
            {
                this.rightDiamond,
                this.leftDiamond,
                this.rightToLeftZigZag,
                this.leftToRightZigZag
            };
            this.dozerPaths = new List<List<Rect>>()
            {
                this.leftToRightFirstRank,
                this.rightToLeftFirstRank
            };
            this.gunshipPaths = new List<List<Rect>>()
            {
                this.leftToRightBackRank,
                this.rightToLeftBackRank
            };
            this.allPath = new List<List<Rect>>()
            {
                this.leftToRightFirstRank,
                this.rightToLeftFirstRank,
                this.middleToRightToLeftFirstRank,
                this.middleToRightToLeftSecondRank,
                this.middleToRightToLeftThirdRank,
                this.rightDiamond,
                this.leftDiamond,
                this.rightToLeftZigZag,
                this.leftToRightZigZag
            };
            this.enemyQueue = new Queue<EnemyShip>();
            this.currentWave = 0;
            this.wawes = new List<Dictionary<EnemyTypes, int>>
            {
                // wawe 1
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.GruntFighter, 2 }
                },

                // wawe 2
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.Reaper, 1 }
                },

                // wawe 3
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.GruntFighter, 3 },
                    { EnemyTypes.Reaper, 1 }
                },

                // wawe 4
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.GruntFighter, 2 },
                    { EnemyTypes.Reaper, 2 }
                },

                // wawe 5
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.GruntFighter, 5 },
                    { EnemyTypes.Reaper, 2 }
                },

                // wawe 6
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.GruntFighter, 2 },
                    { EnemyTypes.Reaper, 3 }
                },

                // wawe 7
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.GruntFighter, 5 },
                    { EnemyTypes.Reaper, 1 },
                    { EnemyTypes.Dozer, 1 }
                },

                // wawe 8
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.GruntFighter, 15 },
                    { EnemyTypes.Reaper, 4 },
                    { EnemyTypes.Dozer, 1 }
                },

                // wawe 9
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.GruntFighter, 15 },
                    { EnemyTypes.Reaper, 4 },
                    { EnemyTypes.Dozer, 1 },
                    { EnemyTypes.Gunship, 1 }
                },

                // wave 10
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.VeteranGrunt, 3 },
                    { EnemyTypes.VeteranReaper, 2 }
                },

                // wave 11
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.VeteranGrunt, 10 },
                    { EnemyTypes.VeteranReaper, 4 },
                    { EnemyTypes.VeteranDozer, 1 }
                },

                // wave 12
                new Dictionary<EnemyTypes, int>
                {
                    { EnemyTypes.VeteranGrunt, 3 },
                    { EnemyTypes.VeteranDozer, 1 },
                    { EnemyTypes.Gunship, 2 }
                },
            };
        }

        /// <summary>
        /// GetNextEnemy
        /// </summary>
        /// <param name="numOfEnemiesAlive">numOfEnemiesAlive</param>
        /// <returns>new enemy</returns>
        public EnemyShip GetNextEnemy(int numOfEnemiesAlive)
        {
            EnemyShip enemyShip = null;
            if (this.enemyQueue.Count == 0 && numOfEnemiesAlive == 0)
            {
                this.GetNextWave().ForEach(e => this.enemyQueue.Enqueue(e));
            }

            if (this.spawnCount == this.spawnRate)
            {
                if (this.enemyQueue.Count > 0)
                {
                    enemyShip = this.enemyQueue.Dequeue();
                }

                if (numOfEnemiesAlive > 0)
                {
                    this.spawnRate = this.defaultSpawnRate * numOfEnemiesAlive;
                }

                this.spawnCount = 0;
            }

            this.spawnCount++;
            return enemyShip;
        }

        private List<EnemyShip> GetNextWave()
        {
            List<EnemyShip> enemyShips = new List<EnemyShip>();
            if (this.currentWave == this.wawes.Count)
            {
                return enemyShips;
            }

            foreach (var waveEnemy in this.wawes[this.currentWave])
            {
                if (waveEnemy.Key == EnemyTypes.GruntFighter)
                {
                    enemyShips.AddRange(this.GetGruntFighters(waveEnemy.Value));
                }
                else if (waveEnemy.Key == EnemyTypes.VeteranGrunt)
                {
                    enemyShips.AddRange(this.GetVeteranGrunt(waveEnemy.Value));
                }
                else if (waveEnemy.Key == EnemyTypes.Reaper)
                {
                    enemyShips.AddRange(this.GetReapers(waveEnemy.Value));
                }
                else if (waveEnemy.Key == EnemyTypes.VeteranReaper)
                {
                    enemyShips.AddRange(this.GetVeteranReapers(waveEnemy.Value));
                }
                else if (waveEnemy.Key == EnemyTypes.Dozer)
                {
                    enemyShips.AddRange(this.GetDozers(waveEnemy.Value));
                }
                else if (waveEnemy.Key == EnemyTypes.VeteranDozer)
                {
                    enemyShips.AddRange(this.GetVeteranDozers(waveEnemy.Value));
                }
                else if (waveEnemy.Key == EnemyTypes.Gunship)
                {
                    enemyShips.AddRange(this.GetGunships(waveEnemy.Value));
                }
            }

            this.currentWave++;
            return enemyShips;
        }

        private List<EnemyShip> GetGruntFighters(int count)
        {
            List<EnemyShip> enemyShips = new List<EnemyShip>();
            for (int i = 0; i < count; i++)
            {
                GruntFighter gruntFighter;
                List<Rect> destinations = this.gruntPaths[random.Next(this.gruntPaths.Count)];
                gruntFighter = new GruntFighter(
                    random.Next(0, (int)Config.WindowWidth),
                    0 - Config.GruntFighterHeight,
                    Config.GruntFighterWidth,
                    Config.GruntFighterHeight,
                    Config.GruntFighterLife,
                    Config.GruntFighterAcceleration,
                    Config.GruntFighterFireRate,
                    Config.GruntFighterPowerUpMultiplier,
                    destinations);

                enemyShips.Add(gruntFighter);
            }

            return enemyShips;
        }

        private List<EnemyShip> GetVeteranGrunt(int count)
        {
            List<EnemyShip> enemyShips = new List<EnemyShip>();
            for (int i = 0; i < count; i++)
            {
                GruntFighter gruntFighter;
                List<Rect> destinations = this.gruntPaths[random.Next(this.gruntPaths.Count)];
                gruntFighter = new GruntFighter(
                    random.Next(0, (int)Config.WindowWidth),
                    0 - Config.GruntFighterHeight,
                    Config.GruntFighterWidth,
                    Config.GruntFighterHeight,
                    Config.GruntFighterLife * 20,
                    Config.GruntFighterAcceleration * 1.2,
                    Config.GruntFighterFireRate * 3,
                    Config.GruntFighterPowerUpMultiplier,
                    destinations);

                enemyShips.Add(gruntFighter);
            }

            return enemyShips;
        }

        private List<EnemyShip> GetReapers(int count)
        {
            List<EnemyShip> enemyShips = new List<EnemyShip>();
            for (int i = 0; i < count; i++)
            {
                Reaper reaper;
                List<Rect> destinations = this.reaperPaths[random.Next(this.reaperPaths.Count)];
                reaper = new Reaper(
                    random.Next(0, (int)Config.WindowWidth),
                    0 - Config.ReaperHeight,
                    Config.ReaperWidth,
                    Config.ReaperHeight,
                    Config.ReaperLife,
                    Config.ReaperAcceleration,
                    Config.ReaperFireRate,
                    Config.ReaperPowerUpMultiplier,
                    destinations);

                enemyShips.Add(reaper);
            }

            return enemyShips;
        }

        private List<EnemyShip> GetVeteranReapers(int count)
        {
            List<EnemyShip> enemyShips = new List<EnemyShip>();
            for (int i = 0; i < count; i++)
            {
                Reaper reaper;
                List<Rect> destinations = this.reaperPaths[random.Next(this.reaperPaths.Count)];
                reaper = new Reaper(
                    random.Next(0, (int)Config.WindowWidth),
                    0 - Config.ReaperHeight,
                    Config.ReaperWidth,
                    Config.ReaperHeight,
                    Config.ReaperLife * 20,
                    Config.ReaperAcceleration * 1.2,
                    Config.ReaperFireRate,
                    Config.ReaperPowerUpMultiplier,
                    destinations);

                enemyShips.Add(reaper);
            }

            return enemyShips;
        }

        private List<EnemyShip> GetDozers(int count)
        {
            List<EnemyShip> enemyShips = new List<EnemyShip>();
            for (int i = 0; i < count; i++)
            {
                Dozer dozer;
                List<Rect> destinations = this.dozerPaths[random.Next(this.dozerPaths.Count)];
                dozer = new Dozer(
                    random.Next(0, (int)Config.WindowWidth),
                    0 - Config.DozerHeight,
                    Config.DozerWidth,
                    Config.DozerHeight,
                    Config.DozerLife,
                    Config.DozerAcceleration,
                    Config.DozerFireRate,
                    Config.DozerHoldFireRate,
                    Config.DozerNumOfShots,
                    Config.DozerPowerUpMultiplier,
                    destinations);

                enemyShips.Add(dozer);
            }

            return enemyShips;
        }

        private List<EnemyShip> GetVeteranDozers(int count)
        {
            List<EnemyShip> enemyShips = new List<EnemyShip>();
            for (int i = 0; i < count; i++)
            {
                Dozer dozer;
                List<Rect> destinations = this.dozerPaths[random.Next(this.dozerPaths.Count)];
                dozer = new Dozer(
                    random.Next(0, (int)Config.WindowWidth),
                    0 - Config.DozerHeight,
                    Config.DozerWidth,
                    Config.DozerHeight,
                    Config.DozerLife * 20,
                    Config.DozerAcceleration,
                    Config.DozerFireRate * 2,
                    Config.DozerHoldFireRate,
                    Config.DozerNumOfShots * 2,
                    Config.DozerPowerUpMultiplier,
                    destinations);

                enemyShips.Add(dozer);
            }

            return enemyShips;
        }

        private List<EnemyShip> GetGunships(int count)
        {
            List<EnemyShip> enemyShips = new List<EnemyShip>();
            for (int i = 0; i < count; i++)
            {
                Gunship gunship;
                List<Rect> destinations = this.gunshipPaths[random.Next(this.gunshipPaths.Count)];
                gunship = new Gunship(
                    random.Next(0, (int)Config.WindowWidth),
                    0 - Config.GunshipHeight,
                    Config.GunshipWidth,
                    Config.GunshipHeight,
                    Config.GunshipLife,
                    Config.GunshipAcceleration,
                    Config.GunshipFireRate,
                    Config.GunshipHoldFireRate,
                    Config.GunshipNumOfShots,
                    Config.GunshipPowerUpMultiplier,
                    destinations);

                enemyShips.Add(gunship);
            }

            return enemyShips;
        }
    }
}
