using System;
using System.Collections.Generic;

namespace Bottler
{
    /*
     * Stores the location properties
     */
    public class Location
    {
        public Location(String i_name, Location i_upperLocation = null, bool i_isGroupName = false)
        {
            name = i_name;
            upperLocation = i_upperLocation;
            isGroupName = i_isGroupName;
        }

        // groupnames contain only sublocations and DONT work as a location for a stocktaking
        public bool isGroupName;
        public String name { get; private set; }

        public Location upperLocation { get; private set; }
        public List<Location> subLocations { get; private set; }

        public bool addSubLocation(Location newSubLocation)
        {
            // Check if there are no sublocations with the new name
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
            return true;
        }

        public void addUpperLocation(Location i_upperLocation)
        {
            upperLocation = i_upperLocation;
        }
        
        public void removeSublocation(Location i_sublocation)
        {
            subLocations.Remove(i_sublocation);
        }
    }
}
