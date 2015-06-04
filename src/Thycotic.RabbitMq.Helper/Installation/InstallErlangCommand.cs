﻿using System;
using System.IO;
using Thycotic.CLI;
using Thycotic.CLI.OS;
using Thycotic.Logging;
using Thycotic.Utility.Reflection;

namespace Thycotic.RabbitMq.Helper.Installation
{
    internal class InstallErlangCommand : ConsoleCommandBase
    {
        
        private readonly ILogWriter _log = Log.Get(typeof (InstallErlangCommand));

        public override string Name
        {
            get { return "installErlang"; }
        }

        public override string Area
        {
            get { return "Installation"; }
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

                externalProcessRunner.Run(executablePath, workingPath, silent);

                return 0;
            };
        }
    }
}