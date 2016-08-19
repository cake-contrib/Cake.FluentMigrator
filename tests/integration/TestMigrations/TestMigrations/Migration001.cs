using FluentMigrator;

namespace TestMigrations
{
    [Migration(001)]
    public class Migration001 : Migration
    {
        public override void Up()
        {
            Create.Table("encryptedkeys")
                .WithColumn("id").AsString(255).PrimaryKey("PK_encryptedkeys")
                .WithColumn("key").AsBinary(128).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("encryptedkeys");
        }
    }
}
