using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calus_Mario_GymMobileApp.Models;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calus_Mario_GymMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var elist = (GymList)BindingContext;
            elist.Date = DateTime.UtcNow;
            await App.Database.SaveGymListAsync(elist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var elist = (GymList)BindingContext;
            await App.Database.DeleteGymListAsync(elist);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemPage((GymList)
           this.BindingContext)
            {
                BindingContext = new Item()
            });

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var gyml = (GymList)BindingContext;

            listView.ItemsSource = await App.Database.GetListItemsAsync(gyml.ID);
        }


    }
}