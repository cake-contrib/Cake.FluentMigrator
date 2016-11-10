using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.FluentMigrator
{
    /// <summary>
    /// <para>Contains aliases related to <see href="https://github.com/schambers/fluentmigrator">FluentMigrator</see>.</para>
    /// <para>
    /// In order to use the commands for this addin, you will need to include the following in your build.cake file to download and
    /// reference from NuGet.org:
    /// <code>
    /// #addin Cake.FluentMigrator
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("FluentMigrator")]
    public static class FluentMigratorAliases
    {
        /// <summary>
        /// Executes FluentMigrator using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     FluentMigrator(new FluentMigratorSettings{
        ///         Connection = "Data Source=.\\sqlexpress;Initial Catalog=DataBase;integrated security=true",
        ///         Provider= "sqlserver",
        ///         Assembly = "./My.Migrations/bin/Debug/My.Migrations.dll"
        ///     });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void FluentMigrator(this ICakeContext context, FluentMigratorSettings settings)
        {
            var resolver = new FluentMigratorToolResolver(context.FileSystem, context.Environment, context.Tools);
            var runner = new FluentMigratorRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Run(settings);
        }

        /// <summary>
        /// Executes FluentMigrator using the specified parameters.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="connection">The connection string.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="assembly">The path to the assembly.</param>
        /// <example>
        /// <code>
        ///     FluentMigrator("Data Source=.\\sqlexpress;Initial Catalog=DataBase;integrated security=true",
        ///         "sqlserver",
        ///         "./My.Migrations/bin/Debug/My.Migrations.dll");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void FluentMigrator(this ICakeContext context, string connection, string provider, FilePath assembly)
        {
            context.FluentMigrator(new FluentMigratorSettings {Connection = connection, Provider = provider, Assembly = assembly});
        }
    }
}