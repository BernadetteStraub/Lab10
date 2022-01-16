using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Straub_Bernadette_Lab10.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Straub_Bernadette_Lab10
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        private readonly ShopList _shopList; 
        
        public ProductPage(ShopList shopList)
        {
            InitializeComponent();
            _shopList = shopList;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var product = (Product) BindingContext;
            await App.Database.SaveProductAsync(product);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var product = (Product) BindingContext;
            await App.Database.DeleteProductAsync(product);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Product p;
            if (e.SelectedItem != null)
            {
                p = e.SelectedItem as Product;
                var lp = new ListProduct()
                {
                    ShopListId = _shopList.Id,
                    ProductId = p.Id
                };
                await App.Database.SaveListProductAsync(lp);
                p.ListProducts = new List<ListProduct> {lp};
                await Navigation.PopAsync();
            }
        }
    }
}