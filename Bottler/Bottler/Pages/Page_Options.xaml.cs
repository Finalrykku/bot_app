using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bottler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Options : ContentPage
    {
        public Page_Options(string param)
        {
            InitializeComponent();
            push1.Text = param;
        }

        private async void Button_back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}