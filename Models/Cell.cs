using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Models
{
  public  class Cell
    {
        public string CellCode
        {
            get {return string.Format("{0}{1}", this.X, this.Y); }
        }
        public int X;
        public int Y;
          

    }
}
