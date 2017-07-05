using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Bottler.Pages
{
    public partial class LocationsEditPage : ContentPage
    {
        public LocationsEditPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        /*
         * The list will be refreshed every time on Appearing
         */
		protected override void OnAppearing()
		{
			base.OnAppearing();
            getLocations();
		}

		/*
		 * Retrieve the locations being saved in Appstate
		 */
		public void getLocations()
		{
			List<Location> loc_list = new List<Bottler.Location>();
			foreach (Location location in AppState._instance.Locations)
			{
				loc_list.Add(location);
				foreach (Location entry in getLocationRecursive(location))
				{
					loc_list.Add(entry);
				}
			}

			if (loc_list.Count != 0)
			{
				listView.ItemsSource = loc_list;
			}

			/*
             * TODO: something, when the list is still empty
             */
		}
		private List<Location> getLocationRecursive(Location i_locations)
		{
			List<Location> loc_list = new List<Location>();
			if (i_locations.subLocations != null)
			{
				foreach (Location location in i_locations.subLocations)
				{
					loc_list.Add(location);
					foreach (Location entry in getLocationRecursive(location))
					{
						loc_list.Add(entry);
					}
				}
			}
			return loc_list;
		}

		private async void AddLocation_clicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new LocationAdd());
		}

    }
}
