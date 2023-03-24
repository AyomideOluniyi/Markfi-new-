using System;
using Markfi.Services;
using Markfi.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
namespace Markfi
{
    public partial class App : Application
    {
        public static DatabaseHelper Database;

        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.db3");
            Database = new DatabaseHelper(dbPath);


            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}