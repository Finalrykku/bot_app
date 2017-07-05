using System;
using System.Collections.Generic;
/*
 * Contains a stocktaking session
 * 
 */
/*
 * vars:
 * 
 * functions:
 * flasche bearbeiten,
 * flasche löschen
 */

namespace Bottler
{
    public class Stocktaking
    {
        public Stocktaking(Location i_location)
        {
            location = i_location;
            /*
             * TODO: sessionstartedtime, sessionid
             */
        }

        public int sessionId { get; set; }
        public Location location { get; private set; }
        public bool locationIsSet { get; private set; }

        private List<Bottle> bottles = new List<Bottle>();
        public int sessionStartedTime { get; private set; }
        public bool sessionFinished;
        public int SessionFinishedTime { get; private set; }

        public void SetLocation(Location i_location)
        {
            if (!locationIsSet) {
                location = i_location;
                locationIsSet = true;
            }
                
        }

        // Adding a new bottle to the current stocktaking
        public void new_bootle(UInt64 i_ean, String i_name, bool i_full, int i_volume)
        {
            bottles.Add(new Bottle(i_ean,  i_name,  i_full, i_volume));
        }

        // Remove a bottle
        public void remove_bottle(Bottle i_bottle)
        {
            bottles.Remove(i_bottle);
        }

        public List<Bottle> GetBottles() 
        {
            return bottles;
        }

    }
}
