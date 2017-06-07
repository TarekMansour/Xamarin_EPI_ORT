using ORT.ViewModel.Home;
using ORT.Views.Home;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using ORT.Views.CoursEntite;
using ORT.Views.ChapitreByCours.Informatique;

namespace ORT.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Acceuil : ContentPage
    { 
        public Acceuil()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            List<Entite> EntiteList = await App.EntiteDb.GetItemsNotDoneAsync();
            ObservableCollection<Entite> EntiteCollection = new ObservableCollection<Entite>(EntiteList);
            //set the items of my entities list (using the Binding of each entity)
            flvList.FlowItemsSource = EntiteCollection;
        }

        private void flvList_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var index = (flvList.FlowItemsSource as ObservableCollection<Entite>).IndexOf(e.Item as Entite);
            Navigation.PushAsync(new Cours_G_Info(index + 1));
        }
    }
}
