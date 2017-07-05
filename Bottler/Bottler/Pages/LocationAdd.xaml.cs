using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Bottler.Pages
{
    public partial class LocationAdd : ContentPage
    {
        private bool isGroupname;

        public LocationAdd()
        {
            BindingContext = this;
            InitializeComponent();
            List<Location> locss = getLocations();
			picker_locations.ItemsSource = locss;
        }



        /*
         * Save new Location and get back to last page
         */
		private async void Add_Clicked(object sender, EventArgs e)
		{
            if(CreateLocation())
    			await Navigation.PopAsync();
            else 
            {
                loc_status.Text = "Fehler";
            }
		}

        /*
         * Creates the new location
         * TODO: onlineabgleich
         */
        private bool CreateLocation()
        {
            Location newloc = new Location(loc_name.Text, isGroupname);
            if(picker_locations.SelectedItem != null)
            {
				return newloc.addUpperLocation((Bottler.Location)picker_locations.SelectedItem);
            }
            else
            {
                AppState._instance.AddLocation(newloc);
            }
            return true;

        }

        private void SwitchToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            isGroupname = !isGroupname;
            if (isGroupname)
            {
                ToggleLabel.Text = "Fungiert als Gruppenname";
            }
            else
            {
                ToggleLabel.Text = "Fungiert als Location";
            }

        }
		/*
         * Retrieve the locationgroupnames being saved in Appstate
         */
		public List<Location> getLocations()
		{
			List<Location> loc_list = new List<Bottler.Location>();
			foreach (Location location in AppState._instance.Locations)
			{
                if (location.isGroupName) {
					loc_list.Add(location);
					foreach (Location entry in getLocationRecursive(location))
					{
						if (location.isGroupName)
							loc_list.Add(entry);
					}
                }
			}
			return loc_list;
		}
		private List<Location> getLocationRecursive(Location i_locations)
		{
			List<Location> loc_list = new List<Location>();
			if (i_locations.subLocations != null)
			{
				foreach (Location location in i_locations.subLocations)
				{
                    if (location.isGroupName)
                    {
                        loc_list.Add(location);
                        foreach (Location entry in getLocationRecursive(location))
                        {
                            if (location.isGroupName)
                                loc_list.Add(entry);
                        }
                    }
				}
			}
			return loc_list;
		}

    }
}
// isToggled="{Binding SwitchBool, Mode=TwoWay}"