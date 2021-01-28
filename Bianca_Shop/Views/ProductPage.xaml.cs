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
    public partial class ProductPage : ContentPage
    {  
        public ProductPage()
        {   //constructor
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {  
            // cautare produs in baza de date cu ajutorul variabilei locale si update fields
            var product = (Product)BindingContext;
            await App.Database.SaveProductAsync(product);
            // revenire la pagina produselor
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {   // cautare produs in baza de date cu ajutorul variabilei locale si update fields cu stergere produs
            var product = (Product)BindingContext;
            await App.Database.DeleteProductAsync(product);
            // revenire la pagina produselor
            await Navigation.PopAsync();
        }

    }
} 