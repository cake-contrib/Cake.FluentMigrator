using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.FluentMigrator
{
    public static class FluentMigratorExtensions
    {
        [CakeMethodAlias]
        public static void FluentMigrator(this ICakeContext context, FluentMigratorSettings settings)
        {
            var runner = new FluentMigratorRunner(context.FileSystem, context.Environment,context.Globber,
               context.ProcessRunner);

            runner.Run(settings);
        }
    }
}