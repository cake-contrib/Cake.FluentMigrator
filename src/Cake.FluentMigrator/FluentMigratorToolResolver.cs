using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.FluentMigrator
{
    /// <summary>
    /// Contains FluentMigrator resolver functionality
    /// </summary>
    public class FluentMigratorToolResolver : IFluentMigratorToolResolver
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;
        private readonly IToolLocator _toolLocator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentMigratorToolResolver" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="toolLocator">The tool locator.</param>
        public FluentMigratorToolResolver(IFileSystem fileSystem, ICakeEnvironment environment, IToolLocator toolLocator)
        {
            _fileSystem = fileSystem;
            _environment = environment;
            _toolLocator = toolLocator;
        }

        /// <summary>
        /// Resolves the path to Migrate.exe.
        /// </summary>
        /// <returns>The path to Migrate.exe.</returns>
        public FilePath ResolvePath()
        {
            var arch = _environment.Platform.Is64Bit ? "AnyCPU" : "x86";
            var frameworkVersion = _environment.Runtime.TargetFramework.Version.Major >= 4 ? "40" : "35";
            var toolPath = _toolLocator.Resolve($"{arch}/{frameworkVersion}/Migrate.exe");

            if (toolPath == null || !_fileSystem.Exist(toolPath))
            {
                throw new CakeException($"Could not locate Migrate.exe for {arch}/{frameworkVersion}");
            }

            return toolPath;
        }
    }
}