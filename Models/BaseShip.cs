using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Models
{
    public enum enShipType
    {
        BattleShip = 0,
        Destroyer = 1

    }

    public enum enShipStatus
    {
        Intact = -1,
        UnderFire = 0,
        Destroyed = 1

    }

    public abstract class BaseShip
    {
    
       protected  List<Cell> _cells;
        protected int iCellTotal;
        public BaseShip()
        {

          }
        public BaseShip(List<Cell>ShipSells )
        {
           _cells = ShipSells;
        }
         
        public void SetCells(List<Cell> ShipSells)
        {
            _cells = ShipSells;
        }

        public abstract enShipType ShipType
        {
            get;
        }
        public int CellCount {
            get { return this.iCellTotal; }
        }

        public int iShootCell(string cTag) {
            int iShootResult = 0;

            int iCellIndex = this._cells.FindIndex(c => c.CellCode == cTag);

            if (iCellIndex > -1) {
                this._cells.RemoveAt(iCellIndex); 
                iShootResult = 1;
            } 
             return iShootResult;
        } 


        public enShipStatus ShipStatus
        {
            get
            {
                 
                if (_cells.Count== iCellTotal)
                {
                    return enShipStatus.Intact;
                }
                else
                {
                    if (_cells.Count ==0)
                    {
                        return enShipStatus.Destroyed;
                    }
                    else
                    {
                        return enShipStatus.UnderFire;
                    }
                }


            }
        }



    }
}
