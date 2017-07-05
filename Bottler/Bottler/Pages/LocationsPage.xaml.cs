using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bottler.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Locations : ContentPage
    {
        public Locations()
        {
            InitializeComponent();
            Location q = new Location("o");
            AppState._instance.myLocations();
            getLocations();
            /*
			listView.ItemsSource = new List<string>
			{
				"Test ListView1",
				"Test ListView2",
				"Test ListView3",
				"Test ListView4",
				"Test ListView5",

			};*/
			//listView.ItemTapped += ListView_ItemTapped;
        }

        public void getLocations() 
        {
            List<String> loc_list = new List<String>();
            foreach (Location location in AppState._instance.Locations ) 
            {
                loc_list.Add(location.name);
                foreach(String entry in getLocationRecursive(location))
                {
                    loc_list.Add(entry);
                }
            }
            listView.ItemsSource = loc_list;
        }
        private List<String> getLocationRecursive(Location i_locations)
        {
			List<String> loc_list = new List<String>();
            foreach (Location location in i_locations.subLocations)
			{
				loc_list.Add(location.name);
				foreach (String entry in getLocationRecursive(location))
				{
					loc_list.Add(entry);
				}
			}
            return loc_list;
		}

    }
}

