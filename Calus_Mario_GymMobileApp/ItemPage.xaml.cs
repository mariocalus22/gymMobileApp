using Calus_Mario_GymMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calus_Mario_GymMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        GymList gl;
        public ItemPage(GymList glist)
        {
            InitializeComponent();
            gl = glist;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;
            await App.Database.SaveItemAsync(item);
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;
            await App.Database.DeleteItemAsync(item);
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Item i;
            if (e.SelectedItem != null)
            {
                i = e.SelectedItem as Item;
                var li = new ListItem()
                {
                    GymListID = gl.ID,
                    ItemID = i.ID
                };
                await App.Database.SaveListItemAsync(li);
                i.ListItems = new List<ListItem> { li };

                await Navigation.PopAsync();
            }
        }
    }
}