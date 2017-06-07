using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ORT.UWP
{
    public sealed partial class MainPage 
    {
        public MainPage()
        {
            this.InitializeComponent();
            //SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

           // global::Xamarin.Forms.Forms.Init();

            string dbPath = FileAccessHelper.GetLocalFilePath("FinalV3.db3");

            //LoadApplication(new ORT.App(dbPath, new SQLitePlatformWin()));

            LoadApplication(new ORT.App());
        }
    }
}
