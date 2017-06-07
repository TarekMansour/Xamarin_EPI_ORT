using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ORT.Views.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notes : ContentPage
    {
        List<string> items = new List<string>();
        Label lbl = new Label();
        public Notes()
        {
            InitializeComponent();
        }

        private void saveItem_Clicked(object sender, EventArgs e)
        {
            //items.Add(noteEditor.Text);
            lbl.Text = noteEditor.Text;
            this.notestck.Children.Add(lbl);
            
        }

        protected override void OnAppearing()
        {
            this.notestck.Children.Add(lbl);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Notes());
        }

       
    }
}
