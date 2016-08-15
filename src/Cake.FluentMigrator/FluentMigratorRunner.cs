using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.FluentMigrator
{
    public class FluentMigratorRunner : Tool<FluentMigratorSettings> {

        private readonly IFluentMigratorToolResolver _toolResolver;

        public FluentMigratorRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, IFluentMigratorToolResolver toolResolver) 
            : base(fileSystem, environment, processRunner, tools)
        {
            _toolResolver = toolResolver;
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
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>
        /// The tool executable name.
        /// </returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "AnyCPU/40/Migrate.exe", "AnyCPU/35/Migrate.exe", "x86/40/Migrate.exe", "x86/35/Migrate.exe" };
        }

        /// <summary>
        /// Gets alternative file paths which the tool may exist in
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// The default tool path.
        /// </returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(FluentMigratorSettings settings)
        {
            return new[] { _toolResolver.ResolvePath()};
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

            if (settings.Assembly == null || string.IsNullOrWhiteSpace(settings.Assembly.FullPath))
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
            builder.AppendQuoted(settings.Assembly.FullPath);

            return builder;
        }

        public void Run(FluentMigratorSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(settings));
        }
    }
}