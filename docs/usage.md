Example:
```C#
#addin "Cake.FluentMigrator"

...

Task("Migrate")
    .Does(() =>
{
    FluentMigrator(new FluentMigratorSettings{
            Connection = "Data Source=.\\sqlexpress;Initial Catalog=DataBase;integrated security=true",
            Provider= "sqlserver",
            Assembly = "./My.Migrations/bin/Debug/My.Migrations.dll"
        });
});
```