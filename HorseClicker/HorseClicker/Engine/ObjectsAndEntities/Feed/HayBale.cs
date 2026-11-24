using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace HorseClicker
{
    internal class HayBale : Sprite
    {
        /*
        strength it gives when eaten
        eaten/ not eaten - bool 

         */
        public int StrengthBoost; //how much strength the horses get from eating the hay bale
        public bool Eaten;

        public Hay(Texture2D texture) : base(texture)
        {
            // constructor
        }



        public void getEaten()
        {
            Eaten == true;

            if (Eaten == true)
            {
                //make image disappear - call function probably 


            }
        }


    }
}
