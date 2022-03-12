// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp096Notifications
{
#pragma warning disable SA1118
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Contains methods which use events from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Scp096.OnAddingTarget(AddingTargetEventArgs)"/>
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (ev.Target == null ||
                ev.Target.SessionVariables.ContainsKey("IsNPC") ||
                ev.Scp096.SessionVariables.ContainsKey("IsNPC"))
                return;

            if (plugin.Config.Enable096SeenMessage)
            {
                ev.Target.ShowHint(plugin.Config.Scp096SeenMessage, 5f);
            }

            if (plugin.Config.Enable096NewTargetMessage)
            {
                if (!plugin.Config.RoleStrings.TryGetValue(ev.Target.Role, out string translatedRole))
                    translatedRole = ev.Target.Role.ToString();

                string message = plugin.Config.Scp096NewTargetMessage
                    .Replace("$name", ev.Target.Nickname)
                    .Replace("$class", $"<color={ev.Target.Role.Color.ToHex()}>{translatedRole}</color>");

                ev.Scp096.ShowHint(message, 5f);
            }
        }
    }
}
