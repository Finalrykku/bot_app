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
            addDebugStuff();
        }

        public List<Location> Locations { get; private set; }
        public Stocktaking CurrentSession { get; private set; }

        /*
         * Add a new location
         */
        public void AddLocation(Location i_location)
        {
            Locations.Add(i_location);
        }

        public void saveBottle(Bottle i_bottle)
        {
            
        }

        /*
         * Debug random locations
         */
        private void addDebugStuff()
        {
            
            Locations.Add(new Location("gruppe1", true));
			Locations.Add(new Location("loc1"));
			Locations.Add(new Location("loc2"));
            Locations[0].addSubLocation(new Location("subloc0"));

            CurrentSession = new Stocktaking(Locations[1]);

            CurrentSession.new_bootle(1, "flascheA", true, 1,5);
            CurrentSession.new_bootle(12, "flascheB", true, 1,3);
            CurrentSession.new_bootle(134, "flascheC", false, 1);
		}


    }
}
