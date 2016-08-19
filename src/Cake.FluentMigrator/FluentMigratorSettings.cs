using System.Collections.Generic;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.FluentMigrator
{
    public class FluentMigratorSettings :  ToolSettings
    {
        public string Connection { get; set; }
        public string Provider { get; set; }
        public FilePath Assembly { get; set; }
        public bool PreviewOnly { get; set; }
        public string Namespace { get; set; }
        public bool NestedNamespaces { get; set; }
        public bool Output { get; set; }
        public string OutputFileName { get; set; }
        public string Task { get; set; }
        public long Version { get; set; }
        public long StartVersion { get; set; }
        public bool NoConnection { get; set; }
        public bool Verbose { get; set; }
        public int Steps { get; set; }
        public string Profile { get; set; }
        public int Timeout { get; set; }
        public string ConnectionStringConfigPath { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public bool TransactionPerSession { get; set; }
        public string ProviderSwitches { get; set; }
        public string ApplicationContext { get; set; }

    }
}