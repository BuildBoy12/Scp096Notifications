// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp096Notifications
{
    using System;
    using Exiled.API.Features;
    using Events = Exiled.Events.Handlers;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        /// <inheritdoc />
        public override string Name { get; } = "Scp096Notifications";

        /// <inheritdoc />
        public override string Author { get; } = "Build";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        /// <summary>
        /// Gets an instance of the <see cref="Scp096Notifications.EventHandlers"/> class.
        /// </summary>
        public EventHandlers EventHandlers { get; private set; }

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            EventHandlers = new EventHandlers(Config);
            Events.Scp096.AddingTarget += EventHandlers.OnAddingTarget;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            Events.Scp096.AddingTarget -= EventHandlers.OnAddingTarget;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}
