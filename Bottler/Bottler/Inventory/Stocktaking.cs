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
            sessionStartedTime = 1;
            sessionId = 1;
        }

        public int sessionId { get; set; }
        public Location location { get; private set; }
        public bool locationIsSet { get; private set; }

        public List<Bottle> bottles = new List<Bottle>();
        // Every Bottle in a stocktaking needs a different id
        private int BottleId = 0;
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
        public void new_bootle(UInt64 i_ean, String i_name, bool i_full, int i_volume, int i_count)
        {
            bottles.Add(new Bottle(BottleId, i_ean, i_name, i_full, i_volume, i_count));
            BottleId += 1;
        }
		public void new_bootle(UInt64 i_ean, String i_name, bool i_full, int i_volume)
		{
			bottles.Add(new Bottle(BottleId, i_ean, i_name, i_full, i_volume));
            BottleId += 1;
		}
        /*public void new_bootle(Bottle bottle)
        {
            bottles.Add(bottle);
        }*/

        /// <summary>
        /// Saves the bottle.
        /// TODO: optimization
        /// </summary>
        /// <param name="i_bottle">bottle to save</param>
        public void save_bottle(Bottle i_bottle)
        {
            int i = 0;
            foreach (Bottle bottle in bottles)
            {
                if (bottle.id == i_bottle.id)
                {
                    bottles[i] = i_bottle;
                    return;
                }
                i += 1;
            }
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
