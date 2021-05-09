namespace Scp096Notifications
{
#pragma warning disable SA1118
    using System;
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Contains methods which use events from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public static class EventHandlers
    {
        /// <summary>
        /// Gets an instance of the <see cref="Scp096Notifications.Config"/> class.
        /// </summary>
        public static Config Config { get; internal set; }

        /// <inheritdoc cref="Exiled.Events.Handlers.Scp096.OnAddingTarget(AddingTargetEventArgs)"/>
        public static void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (Config.Enable096SeenMessage)
            {
                ev.Target.ShowHint(Config.Scp096SeenMessage, 5f);
            }

            if (Config.Enable096NewTargetMessage)
            {
                if (!Config.RoleStrings.TryGetValue(ev.Target.Role, out string translatedRole))
                    translatedRole = ev.Target.Role.ToString();

                string message = Config.Scp096NewTargetMessage.ReplaceAfterToken('$', new[]
                {
                    new Tuple<string, object>("name", ev.Target.Nickname),
                    new Tuple<string, object>("class", $"<color={ev.Target.RoleColor.ToHex()}>{translatedRole}</color>"),
                });

                ev.Scp096.ShowHint(message, 5f);
            }
        }
    }
}
