using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Bottler.Pages;

namespace Bottler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Options : ContentPage
    {
        public Page_Options()
        {
            InitializeComponent();
        }

		private async void Button_back_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
		private async void Location_clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new LocationsEditPage());
		}
        // TODO
        private async void Changekey_clicked(object sender, EventArgs e) 
        {
			var answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        }
    }
}