// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp096Notifications
{
#pragma warning disable SA1118
    using System;
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Contains methods which use events from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="config">An instance of the <see cref="Config"/> class.</param>
        public EventHandlers(Config config) => this.config = config;

        /// <inheritdoc cref="Exiled.Events.Handlers.Scp096.OnAddingTarget(AddingTargetEventArgs)"/>
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (ev.Target.IsNpc() || ev.Scp096.IsNpc())
                return;

            if (config.Enable096SeenMessage)
            {
                ev.Target.ShowHint(config.Scp096SeenMessage, 5f);
            }

            if (config.Enable096NewTargetMessage)
            {
                if (!config.RoleStrings.TryGetValue(ev.Target.Role, out string translatedRole))
                    translatedRole = ev.Target.Role.ToString();

                string message = config.Scp096NewTargetMessage.ReplaceAfterToken('$', new[]
                {
                    new Tuple<string, object>("name", ev.Target.Nickname),
                    new Tuple<string, object>("class", $"<color={ev.Target.RoleColor.ToHex()}>{translatedRole}</color>"),
                });

                ev.Scp096.ShowHint(message, 5f);
            }
        }
    }
}
