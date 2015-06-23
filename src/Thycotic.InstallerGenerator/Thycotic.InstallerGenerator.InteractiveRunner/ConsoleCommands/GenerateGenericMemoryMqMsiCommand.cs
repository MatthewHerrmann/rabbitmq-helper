﻿using System;
using Thycotic.CLI;
using Thycotic.CLI.Commands;
using Thycotic.InstallerGenerator.Core;
using Thycotic.InstallerGenerator.Core.WiX;
using Thycotic.InstallerGenerator.Runbooks.Services;
using Thycotic.InstallerGenerator.Runbooks.Services.Internal;
using Thycotic.Logging;

namespace Thycotic.InstallerGenerator.InteractiveRunner.ConsoleCommands
{
    class GenerateGenericMemoryMqMsiCommand : CommandBase, IImmediateCommand
    {
        private readonly ILogWriter _log = Log.Get(typeof(GenerateConfiguredMemoryMqZipCommand));

        public override string Name
        {
            get { return Program.SupportedSwitches.GenerateMemoryMqMsi; }
        }

        public override string Area
        {
            get { return "MSI"; }
        }

        public override string Description
        {
            get { return "Generates generic MemoryMq Site Connector MSI"; }
        }

        public GenerateGenericMemoryMqMsiCommand()
        {

            Action = parameters =>
            {
                var binariesSourcePath = parameters["SourcePath.Binaries"];
                var recipesSourcePath = parameters["SourcePath.Recipes"];

                var installerVersion = parameters["Installer.Version"];

                var steps = new GenericMemoryMqSiteConnectorServiceWiXMsiGeneratorRunbook
                {
                    RecipePath = recipesSourcePath,
                    SourcePath = binariesSourcePath,
                    Version = installerVersion,

                    HeatPathProvider = applicationPath => WiX.ToolPaths.GetHeatPath(applicationPath),
                    CandlePathProvider = applicationPath => WiX.ToolPaths.GetCandlePath(applicationPath),
                    LightPathProvider = applicationPath => WiX.ToolPaths.GetLightPath(applicationPath),
                };
                
                var wrapper = new InstallerGeneratorWrapper();

                var path = wrapper.Generate(new Generator(), steps);

                return 0;

            };
        }
    }
}
