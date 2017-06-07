using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ORT.Views.Score
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedBackPage : ContentPage
    {
        public FeedBackPage()
        {
            InitializeComponent();
        }

        private void sendEmailCLick(object sender, EventArgs e)
        {
            var EmailTask = MessagingPlugin.EmailMessenger;

            if (EmailTask.CanSendEmail)
                // EmailTask.SendEmail(EmailTo.Text, EmailSubject.Text, EmailBody.Text);

                EmailTask.SendEmail("blancsang@gmail.com", "ORT_feedback" , user_email.Text);
        }
    }
}
