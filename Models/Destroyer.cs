using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Models
{
   public class Destroyer:BaseShip
    {

        public Destroyer():base() {
            base.iCellTotal = 4;
            base._cells = new List<Cell>(4);

        }
        public Destroyer(List<Cell> ShipSells) : base( ShipSells)
        {
            base.iCellTotal = 4;
            base._cells = ShipSells;
         }


        public override enShipType ShipType  
        {
            get { return enShipType.Destroyer; }
        }

         

    }
}
