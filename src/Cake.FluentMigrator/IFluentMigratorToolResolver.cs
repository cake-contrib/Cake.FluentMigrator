using Cake.Core.IO;

namespace Cake.FluentMigrator
{
    /// <summary>
    /// Represents a FluentMigerator path resolver.
    /// </summary>
    public interface IFluentMigratorToolResolver
    {
        /// <summary>
        /// Locate the path to the FluentMigrator tool.
        /// </summary>
        /// <returns>The path to the FluentMigrator tool.</returns>
        FilePath ResolvePath();
    }
}