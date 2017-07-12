using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;


namespace Bottler.Pages
{
    public partial class Stocktaking : ContentPage
    {
        //readonly Image image = new Image();

        //private Capture _caputure = null;
        public Stocktaking()
        {
            InitializeComponent();

            Camera_button_takepic.Clicked += async (sender, e) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    DisplayAlert("No Camera", "no cam biatch", "ok");
                    return;
                }
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    Directory = "ample",
                    Name = "test.jpg"
                });
                if (file == null)
                    return;

                await DisplayAlert("file location", file.Path, "ok");


                cam_image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };



        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
