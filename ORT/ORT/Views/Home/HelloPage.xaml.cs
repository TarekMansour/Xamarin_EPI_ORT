using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ORT.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelloPage : ContentPage
    {

        public ObservableCollection<Hello> Zoos { get; set; }

        public HelloPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            #region intilize view
            Zoos = new ObservableCollection<Hello>
        {
            new Hello
            {
                ImageUrl ="tradding_room.jpg",
                Name = "EPI TRADING ROOM"
            },
                new Hello
            {
                ImageUrl =  "robotic_event.jpg",
                Name = "ROBOTS DAY"
                },
            new Hello
            {
                ImageUrl = "jentrepeneriat.jpg",
                Name = "FORUMS D'ENTREPRISES"
            },

            new Hello
            {
                ImageUrl ="fnumerique.jpg",
                Name = "FESTIVAL NUMERIQUE LIBRE "
            },

            new Hello
            {
                ImageUrl ="epi_ma.jpg",
                Name = "EPI EDUCATION"
            },

            new Hello
            {
                ImageUrl ="x.jpg",
                Name = "Hello XAMARIN.."
            },

            new Hello
            {
                ImageUrl ="epi_chllng.png",
                Name = "EPI CHALLENGE"
            }
        };
            #endregion

           CarouselHello.ItemsSource = Zoos;
        }
    }
}
