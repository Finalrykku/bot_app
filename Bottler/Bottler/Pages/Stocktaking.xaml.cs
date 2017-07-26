using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;
using Bottler;
using System.IO;


namespace Bottler.Pages
{
    public partial class Stocktaking : ContentPage
    {
        //readonly Image image = new Image();

        //private Capture _caputure = null;
        public Stocktaking()
        {
            InitializeComponent();

            TakePhotoButton.Clicked += TakePhotoButton_Clicked;

        }
        async void TakePhotoButton_Clicked(object sender, System.EventArgs e)
        {
            var cameraPage = new CameraPage();
            cameraPage.OnPhotoResult += CameraPage_OnPhotoResult;
            await Navigation.PushModalAsync(cameraPage);
        }

        async void CameraPage_OnPhotoResult(PhotoResultEventArgs result)
        {
            await Navigation.PopModalAsync();
            if (!result.Success)
                return;

            Photo.Source = ImageSource.FromStream(() => new MemoryStream(result.Image));
        }
    }
}
