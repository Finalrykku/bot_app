using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Bottler.Pages
{
    public partial class StocktakingCamera : ContentPage
    {
        int count;

        public StocktakingCamera()
        {
            InitializeComponent();

        }

		public delegate void PhotoResultEventHandler(PhotoResultEventArgs result);

		public event PhotoResultEventHandler OnPhotoResult;

		public void SetPhotoResult(byte[] image, int width = -1, int height = -1)
		{
			//OnPhotoResult?.Invoke(new PhotoResultEventArgs(image, width, height));
            PictureCam.Source = ImageSource.FromStream(() => new System.IO.MemoryStream(image));
		}

		public void Cancel()
		{
			OnPhotoResult?.Invoke(new PhotoResultEventArgs());
		}

        public void Countme()
        {
            count++;
            counter.Text = count.ToString();
        }
    }
    /*
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
		public bool Success { get; private set; }
	}*/
}
