using System;

namespace Bottler
{
    public class Bottle
    {
        public Bottle(int i_BottleId, UInt64 i_ean, String i_name, bool i_full, int i_volume, int i_count = 1)
        {
            id = i_BottleId;
            EAN = i_ean;
            name = i_name;
            full = i_full;
            volume = i_volume;
            count = i_count;
        }
        public int id { get; private set; }
        public UInt64 EAN { get; private set; }
        public String name { get; private set; }
        // public String location { get; set; }
        public bool full { get; set; }
        public int volume { get; set; }
        public int count { get; set; }
        /*k
         * 
         */
    }
}
