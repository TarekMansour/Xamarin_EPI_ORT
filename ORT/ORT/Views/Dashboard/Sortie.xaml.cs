using ORT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ORT.Views.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sortie : ContentPage
    {
        public Sortie()
        {
            
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            await Task.Delay(2000);
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

    }
}
