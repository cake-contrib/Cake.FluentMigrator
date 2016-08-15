using System;
using Cake.Core;
using Cake.Core.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Cake.FluentMigrator.UnitTests
{
    [TestClass]
    public class FluentMigratorToolResolverTests
    {
        [TestMethod]
        public void ResolvePath_AnyCPU_40()
        {
            var fixture = new ToolResolverFixture(PlatformFamily.Windows, true, Version.Parse("4.5.2"));
            var rootPath = new DirectoryPath("c:/tests/tools/FluentMigrator.Tools/tools/AnyCPU/40");
            fixture.ToolLocator.Resolve("AnyCPU/40/Migrate.exe")
                .Returns(rootPath.CombineWithFilePath("Migrate.exe"));
            fixture.FileSystem.Exist(Arg.Any<FilePath>())
                .Returns(true);

            var toolResolver = new FluentMigratorToolResolver(fixture.FileSystem, fixture.Environment, fixture.ToolLocator);

            var toolPath = toolResolver.ResolvePath();

            Assert.AreEqual(rootPath.CombineWithFilePath("Migrate.exe").FullPath, toolPath.FullPath);
        }

        [TestMethod]
        public void ResolvePath_AnyCPU_35()
        {
            var fixture = new ToolResolverFixture(PlatformFamily.Windows, true, Version.Parse("3.5.0"));
            var rootPath = new DirectoryPath("c:/tests/tools/FluentMigrator.Tools/tools/AnyCPU/35");
            fixture.ToolLocator.Resolve("AnyCPU/35/Migrate.exe")
                .Returns(rootPath.CombineWithFilePath("Migrate.exe"));
            fixture.FileSystem.Exist(Arg.Any<FilePath>())
                .Returns(true);

            var toolResolver = new FluentMigratorToolResolver(fixture.FileSystem, fixture.Environment, fixture.ToolLocator);

            var toolPath = toolResolver.ResolvePath();

            Assert.AreEqual(rootPath.CombineWithFilePath("Migrate.exe").FullPath, toolPath.FullPath);
        }

        [TestMethod]
        public void ResolvePath_x86_40()
        {
            var fixture = new ToolResolverFixture(PlatformFamily.Windows, false, Version.Parse("4.5.2"));
            var rootPath = new DirectoryPath("c:/tests/tools/FluentMigrator.Tools/tools/x86/40");
            fixture.ToolLocator.Resolve("x86/40/Migrate.exe")
                .Returns(rootPath.CombineWithFilePath("Migrate.exe"));
            fixture.FileSystem.Exist(Arg.Any<FilePath>())
                .Returns(true);

            var toolResolver = new FluentMigratorToolResolver(fixture.FileSystem, fixture.Environment, fixture.ToolLocator);

            var toolPath = toolResolver.ResolvePath();

            Assert.AreEqual(rootPath.CombineWithFilePath("Migrate.exe").FullPath, toolPath.FullPath);
        }

        [TestMethod]
        public void ResolvePath_x86_35()
        {
            var fixture = new ToolResolverFixture(PlatformFamily.Windows, false, Version.Parse("3.5.0"));
            var rootPath = new DirectoryPath("c:/tests/tools/FluentMigrator.Tools/tools/x86/35");
            fixture.ToolLocator.Resolve("x86/35/Migrate.exe")
                .Returns(rootPath.CombineWithFilePath("Migrate.exe"));
            fixture.FileSystem.Exist(Arg.Any<FilePath>())
                .Returns(true);

            var toolResolver = new FluentMigratorToolResolver(fixture.FileSystem, fixture.Environment, fixture.ToolLocator);

            var toolPath = toolResolver.ResolvePath();

            Assert.AreEqual(rootPath.CombineWithFilePath("Migrate.exe").FullPath, toolPath.FullPath);
        }
    }
}
