using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Bottler.Pages
{
    public partial class picview : ContentPage
    {
        public picview()
        {
            InitializeComponent();
            Photo.Source = AppState._instance.lastphoto;
        }
    }
}
