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
    public partial class ProductsPage : ContentPage
    {   
        //constructor
        public ProductsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {   
            // superconstructor
            base.OnAppearing();
            // populare sursa lista din baza de date 
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }

        async void OnProductAddedClicked(object sender, EventArgs e)
        {   
            // navigare spre pagina noua Product si primeste ca si context un produs nou
            await Navigation.PushAsync(new ProductPage
            {
                BindingContext = new Product()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {   // daca produsul nu este null, daca exista in baza de date
            if (e.SelectedItem != null)
            {   
                // navigare spre pagina noua Product si primeste ca si context un produsul selectat
                await Navigation.PushAsync(new ProductPage
                {
                    BindingContext = e.SelectedItem as Product
                });
            }
        }

    }
}