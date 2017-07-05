using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Bottler
{
    /*
     * Stores the location properties
     */
    public class Location
    {
        public Location(String i_name, bool i_isGroupName = false)
        {
            name = i_name;
            isGroupName = i_isGroupName;
            subLocations = new List<Location>();
            TextColor = Color.Red;
        }

        // groupnames contain only sublocations and DONT work as a location for a stocktaking
        public bool isGroupName;
        public String name { get; private set; }
        public Color TextColor;

        public Location upperLocation { get; private set; }
        public List<Location> subLocations { get; private set; }

        public bool addSubLocation(Location newSubLocation)
        {
            // Check if there are no sublocations with the new name
            if (subLocations != null)
				foreach (Location location in subLocations)
	            {
	                if (location.name == newSubLocation.name)
	                {
	                    return false;
	                }
	            }
            // Add the new location
            subLocations.Add(newSubLocation);
            newSubLocation.addUpperLocation(this);
            isGroupName = true;
            TextColor = getTextColor();
            return true;
        }

        /*
         * Adds the upper location and this location in the upperlocation, if possible
         */
        public bool addUpperLocation(Location i_upperLocation)
        {
            if (i_upperLocation.addSubLocation(this))
            {
                upperLocation = i_upperLocation;
                return true;
            }
            else
                return false;
        }
        
        public void removeSublocation(Location i_sublocation)
        {
            subLocations.Remove(i_sublocation);
        }

        public  Color getTextColor() 
        {
            if (isGroupName)
                return Color.Yellow;
            else
                return Color.Green;
        }

    }
}
