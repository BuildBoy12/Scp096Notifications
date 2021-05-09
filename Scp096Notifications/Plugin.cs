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
        private static readonly Plugin InstanceValue = new Plugin();

        private Plugin()
        {
        }

        /// <summary>
        /// Gets a static instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; } = InstanceValue;

        /// <inheritdoc />
        public override string Name { get; } = "Scp096Notifications";

        /// <inheritdoc />
        public override string Author { get; } = "Thunder, version by Build";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            EventHandlers.Config = this.Config;
            Events.Scp096.AddingTarget += EventHandlers.OnAddingTarget;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            Events.Scp096.AddingTarget -= EventHandlers.OnAddingTarget;
            base.OnDisabled();
        }
    }
}
