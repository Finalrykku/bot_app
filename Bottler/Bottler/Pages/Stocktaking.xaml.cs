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

            AppState._instance.lastphoto = ImageSource.FromStream(() => new MemoryStream(result.Image));
            int a = 1;
        }

        /*

		public delegate void PhotoResultEventHandler(PhotoResultEventArgs result);

		public event PhotoResultEventHandler OnPhotoResult;

		public void SetPhotoResult(byte[] image, int width = -1, int height = -1)
		{
			OnPhotoResult?.Invoke(new PhotoResultEventArgs(image, width, height));
		}

		public void Cancel()
		{
			OnPhotoResult?.Invoke(new PhotoResultEventArgs());
		}

	}

	public class PhotoResultEventArgs : EventArgs
	{

		public PhotoResultEventArgs()
		{
			Success = false;
		}

		public PhotoResultEventArgs(byte[] image, int width, int height)
		{
			Success = true;
			Image = image;
			Width = width;
			Height = height;
		}

		public byte[] Image { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }
		public bool Success { get; private set; }*/
	}
}
