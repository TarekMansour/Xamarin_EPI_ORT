using ORT.ViewModel.Question;
using ORT.ViewModel.QuestionReponse;
using ORT.Views.Score;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using ORT.Data;
using XLabs.Forms.Controls;
using XLabs;
using ORT.ViewModel.Chapitre;

namespace ORT.Views.ChapitreByCours.Informatique
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ch1Q1 : ContentPage
    {
        ListView listViewrep;
        int compteurQuestion; //compteur pour avoir le question en train de le manipuler
        IEnumerable<Reponse> listItems;
        IEnumerable<Reponse> CorrectlistItems;
        int idChp;
        int idCr;
        int previousObject = 0; // question id of last item in previousQuestionList
        //int previousChapterObject = 0; // question id of last item in previousChapterList
        int nbcorrect; //number of correct answers selected
        int score = 0;
        string msg = null;

        ObservableCollection<Reponse> reponseCollection;
        ObservableCollection<Reponse> Correct_reponseCollection;

        //ctor v1
        public Ch1Q1(int compteurQuestion, int idChp, int score ,int idCr)
        {
            this.compteurQuestion = compteurQuestion;
            this.idChp = idChp;
            this.nbcorrect = 0;
            this.score = score;
            this.idCr = idCr;
            InitializeComponent();
        }

        //ctor v2
        public Ch1Q1(int compteurQuestion, int previousObject, int idChp, int score, int idCr)
        {
            this.compteurQuestion = compteurQuestion;
            this.previousObject = previousObject;
            this.idChp = idChp;
            this.nbcorrect = 0;
            this.score = score;
            this.idCr = idCr;
            InitializeComponent();
        }

        //traitement se déclenche lors de l'affichage de la vue des questions et ses réponses
        protected override async void OnAppearing()
        {
            bool result;
            this.Title = "Chapitre N° " + idChp.ToString();
            List<Question> QuestionPreviousList;

            List<Question> QuestionList = await App.QuestionDb.GetQuestionByChapter(idChp);
            ObservableCollection<Question>  QuestionCollection = new ObservableCollection<Question>(QuestionList);

            //if ((idCr == 1))
            //    ChapterPreviousList = await App.ChapitreDb.GetChapitreForCours1(1);
            //else
            //    ChapterPreviousList = await App.ChapitreDb.GetChapitreForCours1(idCr - 1);
            //................
            if ((idChp == 1))
                QuestionPreviousList = await App.QuestionDb.GetQuestionByChapter(1);
            //else
            //if ((idChp - (idChp-1))  == 2)
            //QuestionPreviousList = await App.QuestionDb.GetQuestionByChapter(idChp - 2);//list of question for previous chapter
            else
                QuestionPreviousList = await App.QuestionDb.GetQuestionByChapter(idChp - 1);

                #region Manual ListView
                listViewrep = new ListView
            {
                // Define template for displaying each item.
                ItemTemplate = new DataTemplate(() =>
                {
                    CheckBox answerCheckBox = new CheckBox();
                    answerCheckBox.TextColor = Color.Blue;
                    answerCheckBox.SetBinding(CheckBox.DefaultTextProperty, "TextR");

                    //CustomRadioButton answerRadioButton = new CustomRadioButton();
                    //BindableRadioGroup answerRadioButton = new BindableRadioGroup();
                    Label answerRadioButton = new Label();
                    answerRadioButton.TextColor = Color.Blue;
                    answerRadioButton.VerticalOptions =LayoutOptions.Center ;
                    answerRadioButton.SetBinding(Label.TextProperty, "TextR");

                    StackLayout ss = new StackLayout();
                    if ((compteurQuestion >= 0 && compteurQuestion < QuestionCollection.Count) && (QuestionList[compteurQuestion].TypeQ == "QCM"))
                    {
                        ss.Children.Add(answerCheckBox);
                        //answerCheckBox.CheckedChanged += ListViewrep_ItemCheked;
                    }
                    else if ((compteurQuestion >= 0 && compteurQuestion < QuestionCollection.Count) && (QuestionList[compteurQuestion].TypeQ == "QCU"))
                    {
                        ss.VerticalOptions = LayoutOptions.Center; ss.Padding = 5;
                        ss.Children.Add(answerRadioButton);
                        //listViewrep.ItemSelected += ListViewrep_ItemSelected;
                    }

                    return new ViewCell
                    {
                        View = ss
                        //View = answerRadioButton

                    };
                })
        };
            #endregion

            List<Reponse> ReponseList = await App.ReponseDb.GetReponseforQues1();
            reponseCollection = new ObservableCollection<Reponse>(ReponseList);

            List<Reponse> coorecte_ReponseList = await App.ReponseDb.GetCorrect_ReponseforQues1();
            Correct_reponseCollection = new ObservableCollection<Reponse>(coorecte_ReponseList);

            List<Object> correctRepByChapter = await App.ReponseDb.GetCorrect_ReponseByChapter();

            try
            {
                if (compteurQuestion == (QuestionList.Count))
                {
                    if (score == 0)
                    {
                        score = 0 ;
                        msg = "échec";
                    }
                    else if (score == QuestionCollection.Count)
                    {
                        score = 100;
                        msg = "succés";
                    }
                    else if(score == ((QuestionCollection.Count)/2))
                    {
                        score = 50;
                        msg = "succés";
                    }
                    else if (score < ((QuestionCollection.Count)/2))
                    {
                        score = 25;
                        msg = "échec";
                    }
                    else if ((score > ((QuestionCollection.Count) / 2)) && (score != QuestionCollection.Count))
                    {
                        score = 75;
                        msg = "succés";
                    }
                    Navigation.PushAsync(new DetailScore(score, msg, this.idCr));
                }
                else if (compteurQuestion < 0)
                {
                    Navigation.PushAsync(new Chapitres_CSahrp(idCr));
                }
                else
                    {
                    if (QuestionList.Count == 0)
                        { result = await DisplayAlert("Erreur", "Ouups !!! ce chapitre ne contient pas de questions :(", "annuler", "Ok");
                        if (result)
                            Navigation.RemovePage(this);
                        else Navigation.RemovePage(this);
                        }

                    else
                        QuestionLbl.Text = QuestionCollection[compteurQuestion].TextQ.ToString();
                }

                //if (previousChapterObject == 0)
                //    previousChapterObject = ChapterPreviousList[ChapterPreviousList.Count - 1].IdChapitre;

                if (previousObject == 0)
                    previousObject = QuestionPreviousList[QuestionPreviousList.Count - 1].IdQues;//recuperation de l'id du dernier question dans la liste des question pour le premier chapitre


                if(idChp == 1)
                listItems = reponseCollection.Where(i => i.IdQues == (compteurQuestion + 1));
                else
                    listItems = reponseCollection.Where(i => i.IdQues == (previousObject + 1));

                // Build the page.
                this.stck.Children.Add(listViewrep);

                listItems.Count();
                
                // Source of data items.
                listViewrep.ItemsSource = listItems.ToList();
                listViewrep.ItemSelected += ListViewrep_ItemSelected;

                //source of correct data items
                if(idChp == 1)
                CorrectlistItems = Correct_reponseCollection.Where(i => i.IdQues == (compteurQuestion + 1));
                else
                    CorrectlistItems = Correct_reponseCollection.Where(i => i.IdQues == (previousObject + 1));
                listCorrect_Rep.RowHeight = 30;
                listCorrect_Rep.ItemsSource = CorrectlistItems.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async void ListViewrep_ItemCheked(object sender, EventArgs<bool> e)
        {
            var w = (listViewrep.ItemsSource as List<Reponse>).IndexOf(sender as Reponse);

            var x =sender.ToString();
            //string gg = sender.GetType().Name;
            //nbcorrect = CalculScore(sender as Reponse);

            if (idChp == 1)
            {
                listItems = reponseCollection.Where(i => i.IdQues == (compteurQuestion + 1));
                nbcorrect = CalculScore(sender as Reponse);
            }
            else
            {
                listItems = reponseCollection.Where(i => i.IdQues == (previousObject + 1));
                nbcorrect = CalculScore(sender as Reponse);
            }
        }
        private void ListViewrep_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // get index of listView itemSelected
            var w = (listViewrep.ItemsSource as List<Reponse>).IndexOf(e.SelectedItem as Reponse);

            if (idChp == 1)
            {
                listItems = reponseCollection.Where(i => i.IdQues == (compteurQuestion + 1));
                nbcorrect = CalculScore(listItems.ElementAt(w));
            }
            else
            {
                listItems = reponseCollection.Where(i => i.IdQues == (previousObject + 1));
                nbcorrect = CalculScore(listItems.ElementAt(w));
            }
        }


        //bouton pour passer au question suivant
        private async void nextButton_Clicked(object sender, EventArgs e)
        {
            //list of correct answers
            List<Reponse> coorecte_ReponseList = await App.ReponseDb.GetCorrect_ReponseforQues1();
            var CorrectlistItems = coorecte_ReponseList.Where(i => i.IdQues == (compteurQuestion + 1));


            //if (CorrectlistItems.Count() == nbcorrect)
            if (nbcorrect > 0)
                score += 1;

            if(idChp == 1)
            Navigation.PushAsync(new Ch1Q1(compteurQuestion += 1, idChp, score, idCr));
            else
                Navigation.PushAsync(new Ch1Q1((compteurQuestion += 1), previousObject += 1, idChp, score, idCr));
        }

        //bouton pour retourner au question précedent
        private void previousButton_Clicked(object sender, EventArgs e)
        {
            if(idChp == 1)
            Navigation.PushAsync(new Ch1Q1(compteurQuestion -= 1, idChp, score, idCr));
            else
                Navigation.PushAsync(new Ch1Q1((compteurQuestion -= 1), previousObject -= 1, idChp, score, idCr));
        }

        private async void item1_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Confirmation de terminaison du test", "vous êtes sûr de terminer ce test ?", "confirmer", "aanuler"); // since we are using async, we should specify the DisplayAlert as awaiting.
            if (result)
            {
                
                this.msg = "échec";
                Navigation.PushAsync(new DetailScore(score*10, msg, idCr));

                //calcul score
                return;
            }
            else
            {
                return;
            }
        }

        private async void Showitem_Clicked(object sender, EventArgs e)
        {
            stackRightAnswer.IsVisible = true;
            await Task.Delay(10000);
            stackRightAnswer.IsVisible = false;
        }

        //méthode pour le calcul de score
        public int CalculScore(Reponse myitem)
        {
            int nb = 0;
                if ((myitem.Correction=="true") || (myitem.Correction == "True"))
                    nb += 1;

                //}
            //foreach (myitem in reponseCollection)
            //{
            //    foreach (var correct_item in correctRepCollection)
            //    {
            //        if (myitem.Equals(correct_item))
            //            nb++;
            //    }

            //}
            return nb;
        }


        //index of an IEnumerable list
        
    }
}
