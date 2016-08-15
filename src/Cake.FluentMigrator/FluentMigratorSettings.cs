using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.FluentMigrator
{
    public class FluentMigratorSettings :  ToolSettings
    {
        public string Connection { get; set; }
        public string Provider { get; set; }
        public FilePath Assembly { get; set; }
    }
}