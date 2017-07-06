using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Bottler.Pages
{
    public partial class StocktakingCurrent : ContentPage
    {
        public StocktakingCurrent()
        {
            
            InitializeComponent();
            StocktakingListview.ItemsSource = AppState._instance.CurrentSession.GetBottles();
        }
    }
}
