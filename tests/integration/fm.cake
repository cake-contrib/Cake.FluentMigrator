#tool nuget:?package=FluentMigrator.Tools

//#r "../../src/Cake.FluentMigrator/bin/Release/Cake.FluentMigrator.dll"
#r "tools/FluentMigrator.Tools/tools/AnyCPU/40/System.Data.SqlServerCe.dll"

using System.Data.SqlServerCe;

var dbDir = Directory("./output/");
EnsureDirectoryExists(dbDir);
CleanDirectory(dbDir);
using(var eng = new SqlCeEngine("Data Source=.\\output\\Test.sdf"))
{
    eng.CreateDatabase();
}