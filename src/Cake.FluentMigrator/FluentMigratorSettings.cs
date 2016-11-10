using System.Collections.Generic;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.FluentMigrator
{
    /// <summary>
    /// Contains settings used by <see cref="FluentMigratorRunner"/>.
    /// </summary>
    public class FluentMigratorSettings :  ToolSettings
    {
        /// <summary>
        /// Gets or sets the Connection string that will be used.
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the Provider that will be used by FluentMigrator.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the FilePath to the assembly that will be used.
        /// </summary>
        public FilePath Assembly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether execution should only a preview.
        /// </summary>
        public bool PreviewOnly { get; set; }

        /// <summary>
        /// Gets or sets the default namespace to be used.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether nested namespaces should be used.
        /// </summary>
        public bool NestedNamespaces { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to output the result.
        /// </summary>
        public bool Output { get; set; }

        /// <summary>
        /// Gets or sets the name of the output file.
        /// </summary>
        public string OutputFileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        public string Task { get; set; }

        /// <summary>
        /// Gets or sets the version number to be used.
        /// </summary>
        public long Version { get; set; }

        /// <summary>
        /// Gets or sets the start version number for the execution.
        /// </summary>
        public long StartVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether no connection.
        /// </summary>
        public bool NoConnection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether verbose output should be used.
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// Gets or sets the number of steps.
        /// </summary>
        public int Steps { get; set; }

        /// <summary>
        /// Gets or sets the profile name to be used.
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Gets or sets the timeout period.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the path to the connection string configuration.
        /// </summary>
        public string ConnectionStringConfigPath { get; set; }

        /// <summary>
        /// Gets or sets the list of tags to be used.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether transaction are based per session.
        /// </summary>
        public bool TransactionPerSession { get; set; }

        /// <summary>
        /// Gets or sets the provider switches that should be applied.
        /// </summary>
        public string ProviderSwitches { get; set; }

        /// <summary>
        /// Gets or sets the application context.
        /// </summary>
        public string ApplicationContext { get; set; }

    }
}