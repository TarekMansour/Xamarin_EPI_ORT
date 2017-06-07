using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ORT.Views.ChapitreByCours.Informatique
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpTest : PopupPage
    {
        public OpTest()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Ch1Q1(0,0));
        }

        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            CloseAllPopup();
        }

        private void CloseAllPopup()
        {
             Navigation.PopAllPopupAsync();
        }
    }
}
