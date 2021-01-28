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
    public partial class ReturnPage : ContentPage
    {
        public ReturnPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var returnn = (Return)BindingContext;
            await App.Database.SaveReturnAsync(returnn);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var returnn = (Return)BindingContext;
            await App.Database.DeleteReturnAsync(returnn);
            await Navigation.PopAsync();
        }
    }
}