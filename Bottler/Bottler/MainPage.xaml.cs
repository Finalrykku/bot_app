using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bottler
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_goto_options(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Page_Options(Options.Text));
        }
        private async void Button_Clicked_goto_testpage(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Testpage());
        }
    }
}
