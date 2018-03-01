using System;
using System.Collections.Generic;
using System.Globalization;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.FluentMigrator
{
    /// <summary>
    /// The FluentMigrator Runner used to execute FluentMigrator
    /// </summary>
    public class FluentMigratorRunner : Tool<FluentMigratorSettings>
    {
        private readonly IFluentMigratorToolResolver _resolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentMigratorRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="toolLocator">The tool locator.</param>
        /// <param name="resolver">The tool resolver</param>
        public FluentMigratorRunner(IFileSystem fileSystem, ICakeEnvironment environment,
            IProcessRunner processRunner, IToolLocator toolLocator, IFluentMigratorToolResolver resolver)
            : base(fileSystem, environment, processRunner, toolLocator)
        {
            _resolver = resolver;
        }

        /// <summary>
        /// Executes FluentMigrator using the provided settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(FluentMigratorSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(settings));
        }

        /// <summary>
        /// Gets alternative file paths which the tool may exist in
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default tool path.</returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(FluentMigratorSettings settings)
        {
            return new[] { _resolver.ResolvePath() };
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[]
            {
                "AnyCPU/40/Migrate.exe",
                "AnyCPU/35/Migrate.exe",

                "x86/40/Migrate.exe",
                "x86/35/Migrate.exe"
            };
        }

        /// <summary>
        /// Get FluentMigrator tool name.
        /// </summary>
        /// <returns></returns>
        protected override string GetToolName()
        {
            return "FluentMigrator";
        }

        private static void AddArgument(ProcessArgumentBuilder builder, string @switch, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return;
            }

            builder.Append(@switch);
            builder.AppendQuoted(value);
        }

        private static void AddArgument(ProcessArgumentBuilder builder, string @switch, bool value)
        {
            if (!value)
            {
                return;
            }

            builder.Append(@switch);
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
            AddArgument(builder, "-db", settings.Provider);
            AddArgument(builder, "-c", settings.Connection);
            AddArgument(builder, "-a", settings.Assembly.FullPath);
            AddArgument(builder, "-configPath", settings.ConnectionStringConfigPath);
            AddArgument(builder, "-ns", settings.Namespace);
            AddArgument(builder, "-nested", settings.NestedNamespaces);
            AddArgument(builder, "-o", settings.Output);
            AddArgument(builder, "-of", settings.OutputFileName);
            AddArgument(builder, "-p", settings.PreviewOnly);
            AddArgument(builder, "-steps", settings.Steps.ToString());
            AddArgument(builder, "-t", settings.Task);
            AddArgument(builder, "-version", settings.Version.ToString());
            AddArgument(builder, "-startVersion", settings.StartVersion.ToString());
            AddArgument(builder, "-noConnection", settings.NoConnection);
            AddArgument(builder, "-verbose", settings.Verbose);
            AddArgument(builder, "-profile", settings.Profile);
            AddArgument(builder, "-context", settings.ApplicationContext);
            AddArgument(builder, "-timeout", settings.Timeout.ToString());
            AddArgument(builder, "-tps", settings.TransactionPerSession);

            if (settings.Tags != null)
            {
                foreach (var tag in settings.Tags)
                {
                    AddArgument(builder, "-tag", tag);
                }
            }

            return builder;
        }
    }
}