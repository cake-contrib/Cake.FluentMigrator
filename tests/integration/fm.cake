#tool nuget:?package=FluentMigrator.Tools

#r "../../src/Cake.FluentMigrator/bin/Release/Cake.FluentMigrator.dll"
#r "tools/FluentMigrator.Tools/tools/AnyCPU/40/System.Data.SqlServerCe.dll"

using System.Data.SqlServerCe;

const string connStr = "Data Source=.\\output\\Test.sdf";
var dbDir = Directory("./output/");


TaskSetup((context, task) =>
{
    Information("Creating SqlCe Database...");
    EnsureDirectoryExists(dbDir);
    CleanDirectory(dbDir);
    using(var eng = new SqlCeEngine(connStr))
    {
        eng.CreateDatabase();
    }

    Information("SqlCe Database Successfully Created!");
});

Task("FM-MigrateSimple")
    .Does(() =>
{
    FluentMigrator(connStr, "SqlServerCe", "./TestMigrations/TestMigrations/bin/Debug/TestMigrations.dll");
});

Task("FM-MigrateAdvanced")
    .Does(() =>
{
    var outPath = MakeAbsolute(new FilePath(System.IO.Path.Combine(dbDir.ToString(), "fm-out.txt"))).FullPath;
    Information("outPath = " + outPath);

    FluentMigrator(new FluentMigratorSettings
    {
        Connection = connStr,
        Provider = "SqlServerCe",
        Assembly = "./TestMigrations/TestMigrations/bin/Debug/TestMigrations.dll",
        Output = true,
        OutputFileName = outPath,
        PreviewOnly = false,
        Task = "migrate:up",
        Verbose = true,
        ApplicationContext = "FM-Migrate2"
    });
});

Task("Default")
    .Does(() => 
{
    RunTarget("FM-MigrateSimple");
    RunTarget("FM-MigrateAdvanced");
});

RunTarget(Argument("target", "Default"));