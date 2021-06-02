// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp096Notifications
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc cref="IConfig"/>
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether people who view Scp096's face will be notified.
        /// </summary>
        [Description("Whether people who view Scp096's face will be notified.")]
        public bool Enable096SeenMessage { get; set; } = true;

        /// <summary>
        /// Gets or sets the message to show people who become a target of Scp096.
        /// </summary>
        [Description("The message to show people who become a target of Scp096.")]
        public string Scp096SeenMessage { get; set; } = "You are a target of SCP-096!";

        /// <summary>
        /// Gets or sets a value indicating whether Scp096 will be notified when someone views their face.
        /// </summary>
        [Description("Whether Scp096 will be notified when someone views their face.")]
        public bool Enable096NewTargetMessage { get; set; } = true;

        /// <summary>
        /// Gets or sets the message to show Scp096 when they gain a target.
        /// </summary>
        [Description("The message to show Scp096 when they gain a target.")]
        public string Scp096NewTargetMessage { get; set; } = "<b>$name</b> has viewed your face! They are a <b>$class</b>.";

        /// <summary>
        /// Gets or sets a collection of roles and their respective translations.
        /// </summary>
        [Description("Change the display strings of each class (applies to SCP-096's notification).")]
        public Dictionary<RoleType, string> RoleStrings { get; set; } = new Dictionary<RoleType, string>
        {
            [RoleType.ClassD] = "Class-D Personnel",
            [RoleType.Scientist] = "Scientist",
            [RoleType.FacilityGuard] = "Facility Guard",
            [RoleType.NtfCadet] = "NTF Cadet",
            [RoleType.NtfLieutenant] = "NTF Lieutenant",
            [RoleType.NtfScientist] = "NTF Scientist",
            [RoleType.NtfCommander] = "NTF Commander",
            [RoleType.ChaosInsurgency] = "Chaos Insurgency",
            [RoleType.Tutorial] = "Tutorial",
        };
    }
}
