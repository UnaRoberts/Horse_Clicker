using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace HorseClicker
{
    public class StableHand : Sprite
    {
        /*
      cost to hire
       abi;ity to feed horses - automatically 

         */

        public int CostToHire { get; private set; }



        public Hay(Texture2D texture) : base(texture)
        {
            // constructor
        }


        public void AutoFeed()
        {
            //list the amount of food they provide 

        }
    }
}
