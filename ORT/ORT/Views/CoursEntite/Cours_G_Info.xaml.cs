using ORT.ViewModel.Cours;
using ORT.Views.ChapitreByCours.Informatique;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ORT.Views.CoursEntite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cours_G_Info : ContentPage
    {
        int idEntity;
        public Cours_G_Info(int idEntity)
        {
            this.idEntity = idEntity;
            InitializeComponent();
            this.listCR.RowHeight = 80;
        }

        protected override async void OnAppearing()
        {
            this.Title = "Filiére N° " + idEntity.ToString() ;
            //test sur cours
            List<Cours> CoursList = await App.CoursDb.GetCoursByEntity(idEntity);
            bool result;

            if (CoursList.Count == 0)
            {
                result = await DisplayAlert("Ouups :(", "COMMING SOON we are still working on it ;)", "Bye", "Ok");
                if (result)
                    Navigation.RemovePage(this);
                else
                    Navigation.RemovePage(this);
            }

            else
            {
                ObservableCollection<Cours> CoursCollection = new ObservableCollection<Cours>(CoursList);
                listCR.ItemsSource = CoursCollection;
            }
        }

        private async void listCR_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            List<Cours> CoursList2;
            //get index of listView itemSelected
            var index = (listCR.ItemsSource as ObservableCollection<Cours>).IndexOf(e.SelectedItem as Cours);

            List<Cours> ll = await App.CoursDb.GetCoursByEntity(idEntity);

            int idEntity2;

            if (idEntity == 1)
                Navigation.PushAsync(new Chapitres_CSahrp(index + 1));

            else if (idEntity > 1)
            {
                
                int indice = 0;
               // var x = idEntity - 1;
                do
                {
                    
                    CoursList2 = await App.CoursDb.GetCoursByEntity(idEntity -= 1);
                    if (CoursList2.Count == 0)
                    {
                        CoursList2 = await App.CoursDb.GetCoursByEntity(idEntity -= 1); //ou bien x-1 ou idEntity - x
                    }
                    else
                    {
                        indice = CoursList2[CoursList2.Count - 1].IdCours;
                        indice += index;
                        Navigation.PushAsync(new Chapitres_CSahrp(indice + 1));
                    }
                } while ((CoursList2.Count ==  0));

                indice = CoursList2[CoursList2.Count - 1].IdCours;
                indice += index;
                Navigation.PushAsync(new Chapitres_CSahrp(indice + 1));


            }




        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //var img = new Image();
            //img.Source = "star2.png";
            //this.BackgroundImage = "star2.png";

        }
    }
}
