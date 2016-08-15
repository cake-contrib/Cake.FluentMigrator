using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.FluentMigrator
{
    public static class FluentMigratorExtensions
    {
        [CakeMethodAlias]
        public static void FluentMigrator(this ICakeContext context, FluentMigratorSettings settings)
        {
            var resolver = new FluentMigratorToolResolver(context.FileSystem, context.Environment, context.Tools);
            var runner = new FluentMigratorRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static void FluentMigrator(this ICakeContext context, string connection, string provider, FilePath assembly)
        {
            context.FluentMigrator(new FluentMigratorSettings {Connection = connection, Provider = provider, Assembly = assembly});
        }
    }
}