using ORT.ViewModel.Chapitre;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;
using System.Threading.Tasks;
using ORT.ViewModel.Question;
using ORT.Views.Score;

namespace ORT.Views.ChapitreByCours.Informatique
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chapitres_CSahrp : ContentPage
    {
        int idCr;
        public Chapitres_CSahrp(int idCr)
        {
            this.idCr = idCr;
            InitializeComponent();
            this.MyList.RowHeight = 80;
        }

        protected override async void OnAppearing()
        {
            this.Title = "Cours N° " + idCr.ToString();
            List<Chapitre> ChapitreList1 = await App.ChapitreDb.GetChapitreForCours1(idCr);
            ObservableCollection<Chapitre> ChapitreCollection1 = new ObservableCollection<Chapitre>(ChapitreList1);
            MyList.ItemsSource = ChapitreCollection1;
        }

        private async void MyList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.Title = "Cours N° " + idCr.ToString();
            List<Chapitre> ChapitreList;

            //get index of listView itemSelected
            var index = (MyList.ItemsSource as ObservableCollection<Chapitre>).IndexOf(e.SelectedItem as Chapitre);
            DetailScore sc = new DetailScore();
            int x = 20;
            if (idCr == 1)
            {
                var result = await DisplayAlert("Commencer un test", "Votre meilleur score pour ce chapitre est "+sc.score, "Ok", "annuler"); // since we are using async, we should specify the DisplayAlert as awaiting.
                if (result)
                {
                    await Navigation.PushAsync(new Ch1Q1(0, index + 1, 0, idCr));
                }
                else
                {
                    return;
                }
            }
            

            else if (idCr > 1)
            {
                ChapitreList = await App.ChapitreDb.GetChapitreForCours1(idCr - 1);
                var indice = ChapitreList[ChapitreList.Count - 1].IdChapitre;
                indice += index;
                //if (index == 0)
                //    indice += index;
                //else if (index > 0)
                //    indice += 1;

                var result = await DisplayAlert("Commencer un test", "Votre meilleur score pour ce chapitre est 50 %", "Ok", "annuler"); // since we are using async, we should specify the DisplayAlert as awaiting.
                if (result)
                {
                    await Navigation.PushAsync(new Ch1Q1(0, indice + 1, 0, idCr));
                }
                else
                {
                    return;
                }

                

            }
            //else if ((idCr > 1) && (index > 0))



            //List<Question> QuestionPreviousList = await App.QuestionDb.GetQuestionByChapter();

                //if (index == 0)
                //{
                //    var result = await DisplayAlert("Commencer un test", "Votre meilleur score pour ce chapitre est 50 %", "Ok", "annuler"); // since we are using async, we should specify the DisplayAlert as awaiting.
                //    if (result)
                //    {
                //        await Navigation.PushAsync(new Ch1Q1(0, index +1,0));
                //    }
                //    else 
                //    {
                //        return;
                //    }
                //}

                //if (index == 2)
                //{
                //    var result = await DisplayAlert("Commencer un test", "Votre meilleur score pour ce chapitre est 75 %", "Ok", "annuler"); // since we are using async, we should specify the DisplayAlert as awaiting.
                //    if (result)
                //    {
                //        await Navigation.PushAsync(new Ch2Q1(0));
                //    }
                //    else
                //    {
                //        return;
                //    }
                //}

                //if (index == 4)
                //{
                //    var result = await DisplayAlert("Commencer un test", "Votre meilleur score pour ce chapitre est 45 %", "Ok", "annuler"); // since we are using async, we should specify the DisplayAlert as awaiting.
                //    if (result)
                //    {
                //        await Navigation.PushAsync(new Ch4Q1(0));
                //    }
                //    else
                //    {
                //        return;
                //    }
                //}
        }
        }


    
}
