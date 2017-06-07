using ORT.Views.ChapitreByCours.Informatique;
using ORT.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ORT.Views.Score
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailScore : ContentPage
    {   
        public int score;
        string msg;
        int idCr;

        public DetailScore()
        {

        }
        public DetailScore(int score, string msg, int idCr)
        {
            this.score = score;
            this.msg = msg;
            this.idCr = idCr;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            this.lblScore.Text = score.ToString();
            this.obsLbl.Text = msg;
            this.lbltimer.Text = (DateTime.Now.ToString());

            //feedback label work
           
            //label tap event
            var feedBackLabel_tap = new TapGestureRecognizer();
            feedBackLabel_tap.Tapped += (s, e) =>
            {
                //  Do work here.
                //Navigation.PushAsync(new FeedBackPage());

                var EmailTask = Plugin.Messaging.MessagingPlugin.EmailMessenger;

                if (EmailTask.CanSendEmail)
                {
                    EmailTask.SendEmail("EPI.ORT.Team@gmail.com");
                   // DisplayAlert("votre commentaire est envoyé avec succès", "Ok"," ");
                }
                else
                    DisplayAlert("Ouups !! échec", "Ok", " ");

            };
            labl_ff.GestureRecognizers.Add(feedBackLabel_tap);
        }

        private void reloadTest_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Chapitres_CSahrp(idCr));
        }

        private void exitClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Acceuil());
        }

        private void facebookTap(object sender, EventArgs e)
        {
            var u = new Uri("https://www.facebook.com/");
            Device.OpenUri(u);
            
        }

        private void twitterTap(object sender, EventArgs e)
        {
            var u = new Uri("https://twitter.com/");
            Device.OpenUri(u);
        }

        private void googleTap(object sender, EventArgs e)
        {
            var u = new Uri("https://plus.google.com/");
            Device.OpenUri(u);
        }
    }
}
