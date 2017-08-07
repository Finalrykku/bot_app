using System;
using Android.App;
using Android.Graphics;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Content;
using Bottler.Pages;
using System.Linq;
using Android.Hardware;
using System.Threading.Tasks;
using Bottler.Droid;

[assembly: Xamarin.Forms.ExportRenderer(typeof(StocktakingCamera), typeof(StocktakingCameraRenderer))]
namespace Bottler.Droid
{
    public class StocktakingCameraRenderer: PageRenderer, TextureView.ISurfaceTextureListener
    {
        

		RelativeLayout mainLayout;
		TextureView liveView;
		PaintCodeButton capturePhotoButton;

        bool takePictures;

		Android.Hardware.Camera camera;

		Activity Activity => this.Context as Activity;

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
		{
            takePictures = true;
			base.OnElementChanged(e);
			SetupUserInterface();
            //SetupEventHandlers();

            /*capturePhotoButton.Click += async (sender, e) =>
			{
				await TakePhoto();
				//var bytes = await TakePhoto();
				//(Element as StocktakingCamera).SetPhotoResult(bytes, liveView.Bitmap.Width, liveView.Bitmap.Height);
			};*/
            //var task = TakePhoto();
            //Task.Run(async () => { await TakePhoto(); });
            //(Element as StocktakingCamera).
            TakePhoto2();

		}
        
		void SetupUserInterface()
		{
			mainLayout = new RelativeLayout(Context);

			//RelativeLayout.LayoutParams mainLayoutParams = new RelativeLayout.LayoutParams(
			//  RelativeLayout.LayoutParams.MatchParent,
			//  RelativeLayout.LayoutParams.MatchParent);
			//mainLayout.LayoutParameters = mainLayoutParams;

			liveView = new TextureView(Context);

			RelativeLayout.LayoutParams liveViewParams = new RelativeLayout.LayoutParams(
				RelativeLayout.LayoutParams.MatchParent,
				RelativeLayout.LayoutParams.MatchParent);
			liveView.LayoutParameters = liveViewParams;
			mainLayout.AddView(liveView);

			capturePhotoButton = new PaintCodeButton(Context);
			RelativeLayout.LayoutParams captureButtonParams = new RelativeLayout.LayoutParams(
				RelativeLayout.LayoutParams.WrapContent,
				RelativeLayout.LayoutParams.WrapContent);
			captureButtonParams.Height = 120;
			captureButtonParams.Width = 120;
			capturePhotoButton.LayoutParameters = captureButtonParams;
			mainLayout.AddView(capturePhotoButton);
            liveView.SurfaceTextureListener = this;
			//AddView(mainLayout);
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			base.OnLayout(changed, l, t, r, b);
			if (!changed)
				return;
			var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
			var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
			mainLayout.Measure(msw, msh);
			mainLayout.Layout(0, 0, r - l, b - t);

			capturePhotoButton.SetX(mainLayout.Width / 2 - 60);
			capturePhotoButton.SetY(mainLayout.Height - 200);
		}

		/*public void SetupEventHandlers()
		{
			capturePhotoButton.Click += async (sender, e) =>
			{
                await TakePhoto();
				var bytes = await TakePhoto();
                (Element as StocktakingCamera).SetPhotoResult(bytes, liveView.Bitmap.Width, liveView.Bitmap.Height);
			};
			liveView.SurfaceTextureListener = this;
		}*/

		public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
		{
			if (keyCode == Keycode.Back)
			{
                (Element as StocktakingCamera).Cancel();
				return false;
			}
			return base.OnKeyDown(keyCode, e);
		}

        public void TakePhoto2()
        {
			while (takePictures)
			{
				(Element as StocktakingCamera).Countme();
				camera.StopPreview();
				var ratio = ((decimal)Height) / Width;
				var image = Bitmap.CreateBitmap(liveView.Bitmap, 0, 0, liveView.Bitmap.Width, (int)(liveView.Bitmap.Width * ratio));
				byte[] imageBytes = null;
				using (var imageStream = new System.IO.MemoryStream())
				{
					 image.CompressAsync(Bitmap.CompressFormat.Jpeg, 50, imageStream);
					image.Recycle();
					imageBytes = imageStream.ToArray();
				}
				camera.StartPreview();
				(Element as StocktakingCamera).SetPhotoResult(imageBytes, liveView.Bitmap.Width, liveView.Bitmap.Height);
				 Task.Delay(TimeSpan.FromSeconds(2));
				//return imageBytes;
			}

		}

		public async Task TakePhoto()
		{
            while (takePictures)
            {
                (Element as StocktakingCamera).Countme();
				camera.StopPreview();
				var ratio = ((decimal)Height) / Width;
				var image = Bitmap.CreateBitmap(liveView.Bitmap, 0, 0, liveView.Bitmap.Width, (int)(liveView.Bitmap.Width * ratio));
				byte[] imageBytes = null;
				using (var imageStream = new System.IO.MemoryStream())
				{
					await image.CompressAsync(Bitmap.CompressFormat.Jpeg, 50, imageStream);
					image.Recycle();
					imageBytes = imageStream.ToArray();
				}
				camera.StartPreview();
                (Element as StocktakingCamera).SetPhotoResult(imageBytes, liveView.Bitmap.Width, liveView.Bitmap.Height);
                await Task.Delay(TimeSpan.FromSeconds(2));
				//return imageBytes;
            }

		}

		private void StopCamera()
		{
			camera.StopPreview();
			camera.Release();
		}

		private void StartCamera()
		{
			camera.SetDisplayOrientation(90);
			camera.StartPreview();
		}


		#region TextureView.ISurfaceTextureListener implementations

		public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
		{
			camera = Android.Hardware.Camera.Open();
			var parameters = camera.GetParameters();
			var aspect = ((decimal)height) / ((decimal)width);

			// Find the preview aspect ratio that is closest to the surface aspect
			var previewSize = parameters.SupportedPreviewSizes
										.OrderBy(s => Math.Abs(s.Width / (decimal)s.Height - aspect))
										.First();

			System.Diagnostics.Debug.WriteLine($"Preview sizes: {parameters.SupportedPreviewSizes.Count}");

			parameters.SetPreviewSize(previewSize.Width, previewSize.Height);
			camera.SetParameters(parameters);

			camera.SetPreviewTexture(surface);
			StartCamera();
		}

		public bool OnSurfaceTextureDestroyed(Android.Graphics.SurfaceTexture surface)
		{
			StopCamera();
			return true;
		}

		public void OnSurfaceTextureSizeChanged(Android.Graphics.SurfaceTexture surface, int width, int height)
		{
		}

		public void OnSurfaceTextureUpdated(Android.Graphics.SurfaceTexture surface)
		{
		}
		#endregion
	}
}
