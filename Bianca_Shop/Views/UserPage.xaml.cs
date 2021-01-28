using Bianca_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bianca_Shop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;

            //verificare numar telefon sa aiba 10 cifre si sa fie numeric
            if (user.PhoneNumber.Length == 10 && true == int.TryParse(user.PhoneNumber, out _))
            {
                await App.Database.SaveUserAsync(user);
                await Navigation.PopAsync();
            }
            else
            {
                // mesaj eroare (numar telefon gresit)
                await App.Current.MainPage.DisplayAlert("Incorrect telephone number", "Please type 10 digit phone number", "OK");
            }
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            await App.Database.DeleteUserAsync(user);
            await Navigation.PopAsync();
        }
    }
}