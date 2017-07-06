using System;

namespace Bottler
{
    public class Bottle
    {
        public Bottle(UInt64 i_ean, String i_name, bool i_full, int i_volume)
        {
            EAN = i_ean;
            name = i_name;
            full = i_full;
            volume = i_volume;
        }
        public UInt64 EAN { get; private set; }
        public String name { get; private set; }
        // public String location { get; set; }
        public bool full;
        public int volume { get; set; }

        /*k
         * 
         */
    }
}
