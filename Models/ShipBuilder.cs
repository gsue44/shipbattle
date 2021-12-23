using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Models
{

    public class ShipBuilder
    {

        List<string> UsedCells = new List<string>(15);


        public BaseShip BuildShip(enShipType ShipType)
        {

            BaseShip bs;

            switch (ShipType)
            {
                case enShipType.Destroyer:
                    bs = new Destroyer();
                     break;
               default:
                    bs = new BattleShip();
                    break;
            }
            bs.SetCells(  GenCells(bs.CellCount));
            return bs;
        }


        List<Cell> GenCells(int iCellCount)
        {
            Random r = new Random();
            Cell p = new Cell();
            int iBaseAdr = 9 - iCellCount;
             /*
             0-vertical
             1-horizontal
             */
            #region dicethrow
            int iResult = 1;
            List<Cell> cl;
            do
            {
                int iDir = r.Next(-2, 2);
                 
                if (iDir >0)
                {
                    iDir = 1;
                    p.X = r.Next(0, iBaseAdr);
                    p.Y = r.Next(0, 9);
                }
                else
                {
                    iDir = 0;

                    p.X = r.Next(0, 9);
                    p.Y = r.Next(0, iBaseAdr);

                }
                #endregion

                 cl = new List<Cell>(iCellCount);
                iResult = GenCL(p, iDir, ref cl, iCellCount);

             } while (iResult > 0);

            return cl;
        }
         

        int GenCL(Cell p,int iDir, ref List<Cell> cl, int iCellCount)
        {

            int iRes = 0;
            for (int i = 0; i < iCellCount; i++)
            {
                Cell px = new Cell();

                if (iDir == 0)
                {
                    px.X = p.X;
                    px.Y = p.Y + i;

                }
                else
                {

                    px.X = p.X + i;
                    px.Y = p.Y;
                }
                 
                 if (UsedCells.Count > 0)
                {
                    if (UsedCells.FindIndex(a => a == px.CellCode) > -1) {
                        iRes = 100;
                        break;
                    }
                }
                cl.Add(px);
            }

            for (int i= 0; i < cl.Count; i++) {
                UsedCells.Add(cl[i].CellCode);
            }

            

            return iRes;
        }


    }
}