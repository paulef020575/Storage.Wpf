using Storage.Migrations;
using Storage.Wpf.Classes;
using Storage.Wpf.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Storage.Wpf
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MigrationHelper.Execute(Settings.Default.ConnectionString, Logger);
            Database.ConnectionString = Settings.Default.ConnectionString;
        }

        private void Logger(string s)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + " - " + s);
        }
    }
}
