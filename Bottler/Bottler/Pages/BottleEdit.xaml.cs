﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bottler.Pages
{
    public partial class BottleEdit : ContentPage
    {
        Bottle bottle;
        public BottleEdit(Bottle i_bottle)
        {
            InitializeComponent();
            bottle = i_bottle;

            BottleName.Text = bottle.name;
            BottleEAN.Text = bottle.EAN.ToString();
            /* if only full bottles are counted */
            if (bottle.full)
            {
                OptionFullBottle.IsVisible = true;
				picker_count.ItemsSource = countToHundred();
				picker_count.SelectedIndex = bottle.count - 1;
            }
            /* editing the volume of a single bottle */
            else
            {
                OptionIndividualBottle.IsVisible = true;
                // TODO: 
            }
        }

        private List<String> countToHundred() 
        {
            List<String> count = new List<String>();
            for (int i = 1; i <= 100; i += 1)
                count.Add(i.ToString());
            return count;
        }

		/*private void SwitchToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
            bottle.full = !bottle.full;
		}*/

        /// <summary>
        /// Clickeds the finished.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private async void Clicked_Finished(object sender, EventArgs e)
        {
            bottle.count = (int)picker_count.SelectedIndex +1;
            AppState._instance.CurrentSession.save_bottle(bottle);
            await Navigation.PopAsync();
        }
    }
}
