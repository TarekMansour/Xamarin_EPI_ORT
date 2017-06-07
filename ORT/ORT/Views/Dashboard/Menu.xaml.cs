using System;
using System.Collections.Generic;
using ORT.ViewModel;
using ORT.Views.Home;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ORT.Views.Dashboard
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public Menu()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var Hellopage = new MasterPageItem() { Title = "Nouveauté", Icon = "news.png", TargetType = typeof(HelloPage) };
            var page = new MasterPageItem() { Title = "Filières", Icon = "myhome.png", TargetType = typeof(Acceuil) };
            var page1 = new MasterPageItem() { Title = "Paramètres", Icon = "setting2.png", TargetType = typeof(Prametres) };
            var page2 = new MasterPageItem() { Title = "A propos", Icon = "about.png", TargetType = typeof(APropos) };
            var page3 = new MasterPageItem() { Title = "Notes", Icon = "file.png", TargetType = typeof(Notes) };
            var page4 = new MasterPageItem() { Title = "Sortir", Icon = "exit2.png", TargetType = typeof(Sortie) };
            var page5 = new MasterPageItem() { Title = "Language", Icon = "language.png", TargetType = typeof(Language) };

            // Adding menu items to menuList
            menuList.Add(Hellopage);
            menuList.Add(page);
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page5);
            menuList.Add(page4);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            //Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Acceuil)));

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HelloPage)));

        }

        //private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{

        //    var item = (MasterPageItem)e.SelectedItem;
        //    Type page = item.TargetType;

        //    Detail = new NavigationPage((Page)Activator.CreateInstance(page));
        //    IsPresented = false;
        //}

        private void navigationDrawerList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var item = (MasterPageItem)e.Item;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
