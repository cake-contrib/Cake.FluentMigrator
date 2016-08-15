using Cake.Core.IO;

namespace Cake.FluentMigrator
{
    public interface IFluentMigratorToolResolver
    {
        FilePath ResolvePath();
    }
}