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
    public partial class ReturnsPage : ContentPage
    {
        public ReturnsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetReturnsAsync();
        }

        async void OnReturnAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReturnPage
            {
                BindingContext = new Return()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ReturnPage
                {
                    BindingContext = e.SelectedItem as Return
                });
            }
        }
    }
}