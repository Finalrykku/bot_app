using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bottler
{
    public static class AppState
    {
        public static List<Location> Locations { get; private set; }

        public static void AddLocation(Location i_location)
        {
            Locations.Add(i_location);
        }

        public static void myLocations()
        {
            Location q = new Location("oooo");
			Locations.Add(q);
			Locations.Add(new Location("loc1"));
			Locations.Add(new Location("loc2"));
            Locations[0].addSubLocation(new Location("sub0"));
		}

        public static int Blub() 
        {
            return 1;
        }
    }
}
