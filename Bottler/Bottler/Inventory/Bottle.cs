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
        private UInt64 EAN { get; set; }
        private String name { get; set; }
        // public String location { get; set; }
        private bool full;
        private int volume { get; set; }

        /*k
         * 
         */
    }
}
