using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XLabs.Ioc;
using XLabs.Forms;
using XLabs.Forms.Controls;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
using Bottler.Popups;

namespace Bottler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Testpage : ContentPage
    {
        public Testpage()
        {
            InitializeComponent();

        }
        /*
         * Popups
         */

        async void TemporaryPopup(object sender, EventArgs e)
        {

                var page = new PopupListview();
                await Navigation.PushPopupAsync(page);
            
        }

        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
            testfield.Text = answer.ToString();
        }

        /*
         * Popups ende
         */

        private async void Button_back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}