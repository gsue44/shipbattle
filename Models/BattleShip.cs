using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Models
{
   public class BattleShip:BaseShip
    {

        public BattleShip():base() {
            base.iCellTotal = 5;
            base._cells = new List<Cell>(4);

        }
        public BattleShip(List<Cell> ShipSells) : base( ShipSells)
        {
            base.iCellTotal = 5;
            base._cells = ShipSells;
         }


        public override enShipType ShipType  
        {
            get { return enShipType.BattleShip; }
        }

         

    }
}
