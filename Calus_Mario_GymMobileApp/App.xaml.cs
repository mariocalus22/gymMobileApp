using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Calus_Mario_GymMobileApp.Data;
using System.IO;

namespace Calus_Mario_GymMobileApp
{
    public partial class App : Application
    {
        static GymDatabase database;
        public static GymDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   GymDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "GymDatabase.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new ListEntryPage());

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
