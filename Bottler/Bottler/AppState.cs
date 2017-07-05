using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Singleton instance for storing something appwide
 */
namespace Bottler
{
    class AppState
    {
        public static readonly AppState _instance = new AppState();

        AppState()
        {
            Locations = new List<Location>();
        }

        public List<Location> Locations;// { get; private set; }

        public  void AddLocation(Location i_location)
        {
            Locations.Add(i_location);
        }

        public  void myLocations()
        {
            Location q = new Location("oooo");
			Locations.Add(q);
			Locations.Add(new Location("loc1"));
			Locations.Add(new Location("loc2"));
            Locations[0].addSubLocation(new Location("sub0"));
		}

        public  int Blub() 
        {
            return 1;
        }
    }
}
