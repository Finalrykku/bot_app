using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bottler.Pages
{
    public partial class StocktakingCurrent : ContentPage
    {


        public StocktakingCurrent()
        {
            
            InitializeComponent();
            //StocktakingListview.ItemsSource = AppState._instance.CurrentSession.GetBottles();

			StocktakingListview.ItemTapped += delegate (object sender, ItemTappedEventArgs e)
			{
				ListView_ItemTapped(sender, e);
			};
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
            // refill the list so the list refreshes
            StocktakingListview.ItemsSource = new List<String>();
			StocktakingListview.ItemsSource = AppState._instance.CurrentSession.GetBottles();

		}

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new BottleEdit( (Bottler.Bottle)e.Item));
        }

		/*
		private bool _isRefreshing = false;
		public bool isRefreshing {
			get { return _isRefreshing; }
			set {
				isRefreshing = true;
				OnPropertyChanged(nameof(isRefreshing));
			}
		}
		public ICommand RefreshCommand
		{
			get {
				return new Command(async () =>
				{
					isRefreshing = true;
					//await RefreshData();
					RefreshData();
					isRefreshing = false;
				});
			}
		}
		// TODO: Evt. Onlineabgleich machen, wenn mehrere handys gleichzeitig eine Inventur durchführen
		/*private async void RefreshData()
		{
			await StocktakingListview.ItemsSource = AppState._instance.CurrentSession.GetBottles();
		}*/
	}
}
