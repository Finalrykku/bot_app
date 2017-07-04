using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bottler.Popups
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupListview : PopupPage
    {
        public PopupListview()
        {
            InitializeComponent();
            listView.ItemsSource = new List<string>
            {
                "Test ListView1",
                "Test ListView2",
                "Test ListView3",
                "Test ListView4",
                "Test ListView5",
                "Test ListView6",
                "Test ListView7",
                "Test ListView8",
                "Test ListView9",
                "Test ListView0",
                "Test ListViewß",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView"
            };
            listView.ItemTapped += ListView_ItemTapped;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //MenuItem item = (MenuItem)e.Item;
            button_close.Text = e.Item.ToString();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        
        private async void OnClose(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}