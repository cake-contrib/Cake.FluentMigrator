using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using NSubstitute;

namespace Cake.FluentMigrator.UnitTests
{
    class ToolResolverFixture
    {
        public ICakeEnvironment Environment { get; set; }
        public IFileSystem FileSystem { get; set; }
        public IToolLocator ToolLocator { get; set; }

        public ToolResolverFixture(PlatformFamily family, bool is64Bit, Version frameworkVersion)
        {
            Environment = Substitute.For<ICakeEnvironment>();
            Environment.Platform.Returns(info =>
            {
                var platform = Substitute.For<ICakePlatform>();
                platform.Is64Bit.Returns(is64Bit);
                platform.Family.Returns(family);
                return platform;
            });
            Environment.Runtime.Returns(info =>
            {
                var runtime = Substitute.For<ICakeRuntime>();
                runtime.TargetFramework.Returns(callInfo => new FrameworkName(".Net 4.5.2", frameworkVersion));
                return runtime;
            });

            FileSystem = Substitute.For<IFileSystem>();
            ToolLocator = Substitute.For<IToolLocator>();
        }
    }
}
