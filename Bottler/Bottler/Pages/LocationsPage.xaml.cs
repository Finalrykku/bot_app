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
            /* farben ausprobiert
			var personDataTemplate = new DataTemplate(() =>
			{
                var grid = new Grid();
                var textcell = new TextCell();

                textcell.SetBinding(TextCell.TextProperty, "name");
                textcell.SetBinding(TextCell.TextColorProperty, "TextColor");

                grid.Children.Add(textcell);
                return new ViewCell { View = grid };
			});
*/
            InitializeComponent();

            //getLocations();

			listView.ItemTapped += delegate (object sender, ItemTappedEventArgs e)
            {
                ListView_ItemTapped(sender, e);
            };
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
         * Event, when a item gets selected
         */
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e) 
        {
            ///e.Item; // selected
            Start_Stocktaking(sender,e);
        }
		private async void Start_Stocktaking(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new Stocktaking());
		}

		/*
         * Retrieve the locations being saved in Appstate
         */
        public void getLocations() 
        {

            List<Location> loc_list = new List<Bottler.Location>();
            foreach (Location location in AppState._instance.Locations ) 
            {
                loc_list.Add(location);
                foreach(Location entry in getLocationRecursive(location))
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

