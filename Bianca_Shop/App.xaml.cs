using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Bianca_Shop.Views;
using Bianca_Shop.Data;
using System.IO;

namespace Bianca_Shop
{
    public partial class App : Application
    {
        // database
        public static ShopDatabase database;

        // security code
        public static string securityCode = "1234";

        public static ShopDatabase Database
        {
            get
            {
                if (database == null)
                {
                    // create shop database 
                    database = new ShopDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                        LocalApplicationData), "ShopDatabase.db3"));
                }
                return database;
            }
        }

        public App()
        {   
            // constructor
            InitializeComponent();

            // configurare pagina principala cu taburile de navigare: Users, Products, Returns
            MainPage = new AppShell();

        }

        protected override async void OnStart()
        {
            // request cod de inceput cu pop up cu returnare mesaj scris de user
            string typedCode = await App.Current.MainPage.DisplayPromptAsync("Security code", "Please type security code");

            // cat timp codul este null sau e diferit de cel salvat, se solicita recurent 
            while(typedCode == null || !typedCode.Equals(securityCode))
            {
                // ask for code again
                typedCode = await App.Current.MainPage.DisplayPromptAsync("Incorrect code", "Please type security code");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
