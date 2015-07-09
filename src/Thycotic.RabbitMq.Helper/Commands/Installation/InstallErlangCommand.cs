﻿using System;
using System.IO;
using Thycotic.CLI.Commands;
using Thycotic.CLI.OS;
using Thycotic.Logging;
using Thycotic.RabbitMq.Helper.Installation;
using Thycotic.Utility.Reflection;

namespace Thycotic.RabbitMq.Helper.Commands.Installation
{
    internal class InstallErlangCommand : CommandBase, IImmediateCommand
    {
        
        private readonly ILogWriter _log = Log.Get(typeof (InstallErlangCommand));

        public override string Area
        {
            get { return CommandAreas.Installation; }
        }

        public override string Description
        {
            get { return "Installs Erlang"; }
        }

        public InstallErlangCommand()
        {

            Action = parameters =>
            {
                var executablePath = DownloadErlangCommand.ErlangInstallerPath;

                if (!File.Exists(executablePath))
                {
                    _log.Debug("No installer found");
                    return 0;
                }

                var externalProcessRunner = new ExternalProcessRunner
                {
                    EstimatedProcessDuration = TimeSpan.FromMinutes(2)
                };


                var assemblyEntryPointProvider = new AssemblyEntryPointProvider();

                var workingPath = assemblyEntryPointProvider.GetAssemblyDirectory(typeof(Program));

                const string silent = "/S";

                _log.Info("Installing Erlang, please wait...");

                externalProcessRunner.Run(executablePath, workingPath, silent);

                return 0;
            };
        }
    }
}