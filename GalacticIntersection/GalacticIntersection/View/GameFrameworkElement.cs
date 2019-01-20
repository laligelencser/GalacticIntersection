// <copyright file="GameFrameworkElement.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GalacticIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;

    /// <summary>
    /// GameFrameworkElement
    /// </summary>
    public class GameFrameworkElement : FrameworkElement
    {
        private DispatcherTimer timer;
        private GameMechanics gameMechanics;
        private bool isGameOver;
        private Rect bgRect1 = new Rect(0, 0, Config.WindowWidth, Config.WindowHeight);
        private Rect bgRect2 = new Rect(0, 0 - Config.WindowHeight, Config.WindowWidth, Config.WindowHeight);
        private double translateSpeed = 1;
        private ImageBrush playerShipImage;
        private ImageBrush bgImage;
        private ImageBrush gruntFighterImage;
        private ImageBrush reaperImage;
        private ImageBrush dozerImage;
        private ImageBrush gunshipImage;
        private ImageBrush enemyProjectileImage;
        private ImageBrush palyerProjectileImage;
        private ImageBrush powerUpFireRateImage;
        private ImageBrush powerUpWeaponStrengthImage;
        private ImageBrush powerUpLifeImage;
        private ImageBrush powerUpExtraProjectileImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameFrameworkElement"/> class.
        /// </summary>
        public GameFrameworkElement()
        {
            this.Loaded += this.GameFrameworkElement_Loaded;
            this.KeyDown += this.GameFrameworkElement_KeyDown;
            this.gameMechanics = new GameMechanics();
            this.gameMechanics.PlayerDied += this.OnGameOver;
        }

        /// <summary>
        /// Initializing
        /// </summary>
        public void Init()
        {
            this.playerShipImage = new ImageBrush(new BitmapImage(new Uri("Images\\ship.png", UriKind.Relative)));
            this.bgImage = new ImageBrush(new BitmapImage(new Uri("Images\\bg.png", UriKind.Relative)));
            this.gruntFighterImage = new ImageBrush(new BitmapImage(new Uri("Images\\grunt_fighter.png", UriKind.Relative)));
            this.reaperImage = new ImageBrush(new BitmapImage(new Uri("Images\\reaper.png", UriKind.Relative)));
            this.dozerImage = new ImageBrush(new BitmapImage(new Uri("Images\\dozer.png", UriKind.Relative)));
            this.gunshipImage = new ImageBrush(new BitmapImage(new Uri("Images\\gunship.png", UriKind.Relative)));
            this.enemyProjectileImage = new ImageBrush(new BitmapImage(new Uri("Images\\enemy_shot.png", UriKind.Relative)));
            this.palyerProjectileImage = new ImageBrush(new BitmapImage(new Uri("Images\\player_shot.png", UriKind.Relative)));
            this.powerUpLifeImage = new ImageBrush(new BitmapImage(new Uri("Images\\powerup_life.png", UriKind.Relative)));
            this.powerUpFireRateImage = new ImageBrush(new BitmapImage(new Uri("Images\\powerup_firerate.png", UriKind.Relative)));
            this.powerUpExtraProjectileImage = new ImageBrush(new BitmapImage(new Uri("Images\\powerup_extraproj.png", UriKind.Relative)));
            this.powerUpWeaponStrengthImage = new ImageBrush(new BitmapImage(new Uri("Images\\powerup_power.png", UriKind.Relative)));
            this.InvalidateVisual();
        }

        /// <summary>
        /// Rendering
        /// </summary>
        /// <param name="drawingContext">drawingContext</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (this.gameMechanics != null)
            {
                drawingContext.DrawRectangle(this.bgImage, null, new Rect(0, 0, Config.WindowWidth, Config.WindowHeight));
                drawingContext.DrawRectangle(this.bgImage, null, this.bgRect1);
                drawingContext.DrawRectangle(this.bgImage, null, this.bgRect2);
                this.bgRect1.Y += this.translateSpeed;
                this.bgRect2.Y += this.translateSpeed;
                if (this.bgRect1.Y >= Config.WindowHeight)
                {
                    this.bgRect1.Y = Config.WindowHeight * -1;
                }

                if (this.bgRect2.Y >= Config.WindowHeight)
                {
                    this.bgRect2.Y = Config.WindowHeight * -1;
                }

                this.gameMechanics.Movers.ForEach(mover =>
                {
                    if (mover is EnemyProjectile)
                    {
                        drawingContext.DrawRectangle(this.enemyProjectileImage, null, mover.Area);
                    }
                    else if (mover is PlayerProjectile)
                    {
                        drawingContext.DrawRectangle(this.palyerProjectileImage, null, mover.Area);
                    }
                    else if (mover is PowerUp)
                    {
                        PowerUp powerUp = mover as PowerUp;
                        switch (powerUp.Type)
                        {
                            case PowerUpType.PlusLife:
                                drawingContext.DrawRectangle(this.powerUpLifeImage, null, mover.Area);
                                break;
                            case PowerUpType.WeaponSpeed:
                                drawingContext.DrawRectangle(this.powerUpFireRateImage, null, mover.Area);
                                break;
                            case PowerUpType.WeaponStrength:
                                drawingContext.DrawRectangle(this.powerUpWeaponStrengthImage, null, mover.Area);
                                break;
                            case PowerUpType.ExtraProjectile:
                                drawingContext.DrawRectangle(this.powerUpExtraProjectileImage, null, mover.Area);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (mover is GruntFighter)
                    {
                        drawingContext.DrawRectangle(this.gruntFighterImage, null, mover.Area);
                    }
                    else if (mover is Reaper)
                    {
                        drawingContext.DrawRectangle(this.reaperImage, null, mover.Area);
                    }
                    else if (mover is Dozer)
                    {
                        drawingContext.DrawRectangle(this.dozerImage, null, mover.Area);
                    }
                    else if (mover is Gunship)
                    {
                        drawingContext.DrawRectangle(this.gunshipImage, null, mover.Area);
                    }
                    else if (mover is PlayerShip)
                    {
                        drawingContext.DrawRectangle(this.playerShipImage, null, mover.Area);
                    }
                });
                this.DrawLife(drawingContext);
                if (this.isGameOver)
                {
                    this.timer.Stop();
                    this.DrawGameOver(drawingContext);
                }
            }
        }

        private void GameFrameworkElement_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
            this.timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10)
            };
            this.timer.Tick += this.Timer_Tick;
            this.timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.gameMechanics.NextStep();
            this.gameMechanics.CheckAndActOnMovementKeys();
            this.gameMechanics.CheckAndActOnShootingKeys();
            this.InvalidateVisual();
        }

        private void OnGameOver()
        {
            this.isGameOver = true;
        }

        private void DrawGameOver(DrawingContext drawingContext)
        {
            FormattedText gameOverText = new FormattedText(
                    "Game over",
                    CultureInfo.CurrentUICulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Verdana"),
                    32,
                    Brushes.White);
            FormattedText pressEnterText = new FormattedText(
                    "press 'Enter' to restart",
                    CultureInfo.CurrentUICulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Verdana"),
                    18,
                    Brushes.White);
            drawingContext.DrawText(gameOverText, new Point((this.ActualWidth / 2) - (gameOverText.Width / 2), (this.ActualHeight / 2) - (gameOverText.Height / 2)));
            drawingContext.DrawText(pressEnterText, new Point((this.ActualWidth / 2) - (gameOverText.Width / 2), (this.ActualHeight / 2) - (gameOverText.Height / 2) + 40));
        }

        private void DrawLife(DrawingContext drawingContext)
        {
            FormattedText formattedText = new FormattedText(
                this.gameMechanics.PlayerLifes.ToString() + " X Life",
                CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                16,
                Brushes.White);

            drawingContext.DrawText(formattedText, new Point(20, Config.WindowHeight * 0.9));
        }

        private void GameFrameworkElement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (this.isGameOver)
                {
                    this.gameMechanics = new GameMechanics();
                    this.gameMechanics.PlayerDied += this.OnGameOver;
                    this.isGameOver = false;
                    this.timer.Start();
                    this.InvalidateVisual();
                }
            }
        }
    }
}
