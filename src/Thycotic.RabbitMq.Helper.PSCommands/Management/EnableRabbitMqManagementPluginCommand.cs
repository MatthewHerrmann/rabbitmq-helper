﻿using System;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using Thycotic.RabbitMq.Helper.Logic;
using Thycotic.RabbitMq.Helper.Logic.OS;
using Thycotic.RabbitMq.Helper.PSCommands.Installation;

namespace Thycotic.RabbitMq.Helper.PSCommands.Management
{
    /// <summary>
    ///     Enables the RabbitMq management plugin (https://www.rabbitmq.com/management.html)
    /// </summary>
    /// <para type="synopsis"> Enables the RabbitMq management plugin (https://www.rabbitmq.com/management.html)</para>
    /// <para type="description"></para>
    /// <para type="link" uri="http://www.thycotic.com">Thycotic Software Ltd</para>
    /// <example>
    ///     <para>PS C:\></para> 
    ///     <code>Enable-RabbitMqManagementPlugin</code>
    /// </example>
    [Cmdlet(VerbsLifecycle.Enable, "RabbitMqManagementPlugin")]
    public class EnableRabbitMqManagementPluginCommand : Cmdlet
    {
        /// <summary>
        ///     Gets or sets whether to open console when ready. Defaults to true.
        /// </summary>
        /// <value>
        ///    Boolean
        /// </value>
        /// <para type="description">Gets or sets whether to open console when ready. Defaults to true.</para>
        [Parameter(
             Position = 0,
             ValueFromPipeline = true,
             ValueFromPipelineByPropertyName = true)]
        public SwitchParameter OpenConsoleAfterInstall { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnableRabbitMqManagementPluginCommand"/> class.
        /// </summary>
        public EnableRabbitMqManagementPluginCommand()
        {
            OpenConsoleAfterInstall = true;
        }

        /// <summary>
        ///     Processes the record.
        /// </summary>
        protected override void ProcessRecord()
        {
            //we have to use local host because guest account does not work under FQDN
            const string pluginUrl = "http://localhost:15672/";
            const string executable = "rabbitmq-plugins.bat";
            var pluginsExecutablePath = Path.Combine(InstallationConstants.RabbitMq.BinPath, executable);

            var externalProcessRunner = new ExternalProcessRunner
            {
                EstimatedProcessDuration = TimeSpan.FromSeconds(60)
            };

            const string parameters2 = "enable rabbitmq_management";

            WriteVerbose("Enabling management console");

            var output = externalProcessRunner.Run(pluginsExecutablePath, InstallationConstants.RabbitMq.BinPath, parameters2);

            if (!output.Contains("started") && !output.Contains("Plugin configuration unchanged."))
            {
                throw new ApplicationException(CtlRabbitMqProcessInteractor.ExceptionMessages.InvalidOutput);
            }

            WriteVerbose(output);

            if (!OpenConsoleAfterInstall)
            {
                return;
            }

            WriteVerbose($"Opening management console at {pluginUrl}");
            Process.Start(pluginUrl);
        }
    }
}