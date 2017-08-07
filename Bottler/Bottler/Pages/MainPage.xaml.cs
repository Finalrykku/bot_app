using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bottler.Pages;
using Xamarin.Forms;

namespace Bottler
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		/*
         * The list will be refreshed every time on Appearing
         */
		protected override void OnAppearing()
		{
			base.OnAppearing();
            CheckCurrentSession();
		}

        /*
         * What if a session is still open
         */
        private void CheckCurrentSession()
        {
            if (AppState._instance.CurrentSession != null && !AppState._instance.CurrentSession.sessionFinished)
            {
                /*
                 * Make Buttons visisble for current session
                 */
                StocktCurrent.IsVisible = true;
                StocktContinue.IsVisible = true;
            }
        }

        /*
         * Buttonactions
         */
        private async void Button_Clicked_goto_options(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page_Options());
        }
        private async void Button_Clicked_goto_testpage(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new Testpage());
		}
		private async void Button_Clicked_goto_newInventory(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new Locations());
		}

		private async void Button_Clicked_goto_currentStocktaking(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new StocktakingCurrent());
		}
		private async void Button_Clicked_goto_Picview(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new picview());
		}
    }
}
