using System;
using System.Globalization;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Utilities;

namespace Cake.FluentMigrator
{
    public class FluentMigratorRunner : Tool<FluentMigratorSettings> {
        private readonly IGlobber _globber;

        public FluentMigratorRunner(IFileSystem fileSystem, 
            ICakeEnvironment environment, 
            IGlobber globber, 
            IProcessRunner processRunner) : base(fileSystem, environment, processRunner)
        {
            _globber = globber;
        }

        /// <summary>
        /// Get FluentMigrator tool name.
        /// </summary>
        /// <returns></returns>
        protected override string GetToolName()
        {
            return "FluentMigrator";
        }

        /// <summary>
        /// Get FluentMigrator's default path.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        protected override FilePath GetDefaultToolPath(FluentMigratorSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (settings.ToolPath != null)
                return settings.ToolPath;

            const string expression = "./**/FluentMigrator.*/tools/Migrate.exe";
            return _globber.GetFiles(expression).FirstOrDefault();
        }

        private ProcessArgumentBuilder GetArguments(FluentMigratorSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings.Provider))
            {
                throw new ArgumentException(
                     string.Format(CultureInfo.InvariantCulture, "{0}: Provider not specified or missing ({1})", GetToolName(), settings.Provider));
            }

            if (string.IsNullOrWhiteSpace(settings.Connection))
            {
                throw new ArgumentException(
                     string.Format(CultureInfo.InvariantCulture, "{0}: ConnectionString not specified or missing ({1})", GetToolName(), settings.Connection));
            }

            if (string.IsNullOrWhiteSpace(settings.Assembly))
            {
                throw new ArgumentException(
                     string.Format(CultureInfo.InvariantCulture, "{0}: Assembly not specified or missing ({1})", GetToolName(), settings.Assembly));
            }

            var builder = new ProcessArgumentBuilder();
            builder.Append("-db");
            builder.Append(settings.Provider);
            builder.Append("-c");
            builder.AppendQuoted(settings.Connection);
            builder.Append("-a");
            builder.AppendQuoted(settings.Assembly);

            return builder;
        }

        public void Run(FluentMigratorSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Run(settings, GetArguments(settings), GetDefaultToolPath(settings));
        }
    }
}