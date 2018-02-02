using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    public class MigrationHelper
    {
        public static void Execute(string connectionString, Action<string> logger)
        {
            Assembly assembly = typeof(MigrationHelper).Assembly;

            Announcer announcer = new TextWriterAnnouncer(logger);
            IRunnerContext runnerContext = new RunnerContext(announcer);

            ProcessorOptions options = new ProcessorOptions()
            {
                PreviewOnly = false,
                Timeout = 60
            };

            var factory = new SqlServer2008ProcessorFactory();
            using (IMigrationProcessor processor = factory.Create(connectionString, announcer, options))
            {
                var runner = new MigrationRunner(assembly, runnerContext, processor);
                runner.MigrateUp(true);
            }
        }
    }
}
