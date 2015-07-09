using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Thycotic.CLI.Commands;
using Thycotic.CLI.OS;
using Thycotic.Logging;
using Thycotic.RabbitMq.Helper.Installation;
using Thycotic.Utility.IO;

namespace Thycotic.RabbitMq.Helper.Commands.Installation
{
    internal class UninstallPriorErlangCommand : CommandBase, IImmediateCommand
    {

        private readonly ILogWriter _log = Log.Get(typeof(UninstallPriorErlangCommand));

        public override string Area
        {
            get { return CommandAreas.Installation; }
        }

        public override string Description
        {
            get { return "Uninstalls prior installation of Erlang"; }
        }

        public UninstallPriorErlangCommand()
        {

            Action = parameters =>
            {
                _log.Info("Uninstalling prior version of Erlang");

                var executablePath = InstallationConstants.Erlang.UninstallerPath;

                if (!File.Exists(executablePath))
                {
                    _log.Info("No uninstaller found");
                    return 0;
                }

                var externalProcessRunner = new ExternalProcessRunner();

                var directoryInfo = new FileInfo(executablePath);
                var workingPath = directoryInfo.DirectoryName;

                const string silent = "/S";

                externalProcessRunner.Run(executablePath, workingPath, silent);

                try
                {

                    const string erlandProcessKill = " /F /IM epmd.exe";
                    externalProcessRunner.Run("taskkill", workingPath, erlandProcessKill);
                }
                catch (Exception ex)
                {
                    _log.Warn("Failed to terminate erlang process. Clean removal might fail", ex);
                }

                var directoryCleaner = new DirectoryCleaner();

                try
                {
                    directoryCleaner.Clean(InstallationConstants.Erlang.InstallPath);
                }
                catch (Exception ex)
                {
                    _log.Warn("Failed to clean installation path. Clean removal might fail", ex);
                }

                return 0;

            };
        }
    }
}