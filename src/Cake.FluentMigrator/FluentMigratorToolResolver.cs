using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.FluentMigrator
{
    public class FluentMigratorToolResolver : IFluentMigratorToolResolver
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;
        private readonly IToolLocator _tools;

        public FluentMigratorToolResolver(IFileSystem fileSystem, ICakeEnvironment environment, IToolLocator tools)
        {
            _fileSystem = fileSystem;
            _environment = environment;
            _tools = tools;
        }

        public FilePath ResolvePath()
        {
            var arch = _environment.Platform.Is64Bit ? "AnyCPU" : "x86";
            var frameworkVersion = _environment.Runtime.TargetFramework.Version.Major >= 4 ? "40" : "35";
            var toolPath =_tools.Resolve($"{arch}/{frameworkVersion}/Migrate.exe");

            if(toolPath == null || !_fileSystem.Exist(toolPath))
                throw new CakeException($"Could not locate migrate.exe for {arch}/{frameworkVersion}");

            return toolPath;
        }
    }
}