// <copyright file="GameObject.cs" company="PlaceholderCompany">
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
    /// GameObject is the base class of all the other object
    /// </summary>
    public class GameObject
    {
        private Rect area;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="w">w</param>
        /// <param name="h">h</param>
        public GameObject(double x, double y, double w, double h)
        {
            this.area = new Rect(x, y, w, h);
        }

        /// <summary>
        /// Gets area
        /// </summary>
        public Rect Area { get => this.area; }

        /// <summary>
        /// ChangePosition of the rect
        /// </summary>
        /// <param name="movementVector">The value to move by.</param>
        public void ChangePosition(Vector movementVector)
        {
            this.area.X += movementVector.X;
            this.area.Y += movementVector.Y;
        }
    }
}
