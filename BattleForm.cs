using BS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<BaseShip> bsl = new List<BaseShip>(3);

        public Form1()
        {
            InitializeComponent();

 

            int iSize = Math.Min(panel1.Width, panel1.Height) / 10;

            int iStartPos = (panel1.Width - (iSize + 1) * 10) / 2;

            ShipBuilder shb = new ShipBuilder();

            bsl.Add(shb.BuildShip(enShipType.Destroyer));
            bsl.Add(shb.BuildShip(enShipType.Destroyer));
            bsl.Add(shb.BuildShip(enShipType.BattleShip));
            Point p = new Point(iStartPos, 0);
            Button[] btnArray = new Button[100];

            int iY = 0;
            int iX = 0;

            for (int n = 0; n < 100; n++)
            {
                btnArray[n] = new Button();
                btnArray[n].Width = iSize;
                btnArray[n].Height = iSize;
                if (n > 0 & n % 10 == 0)
                {
                    p.X = iStartPos;
                    p.Y = p.Y + btnArray[n].Height + 1;
                    iY++;
                    iX = 0;
                }
                btnArray[n].Left = p.X;
                btnArray[n].Top = p.Y;
                panel1.Controls.Add(btnArray[n]);
                p.X = p.X + btnArray[n].Width + 1;
                btnArray[n].Tag = string.Format("{0}{1}", iX, iY);
                btnArray[n].Click += Form1_Click; ;
                iX++;
            }
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            bool bShot = false;
            string cShipCellCode = b.Tag.ToString();
            for (int i = 0; i < this.bsl.Count; i++)
            {

                if (bsl[i].iShootCell(cShipCellCode) > 0)
                {
                    bShot = true;
                    if ((bsl[i].ShipStatus == enShipStatus.Destroyed))
                    {
                        bsl.RemoveAt(i);

                    }
                    break;
                }
            }
            if (bShot)
            {
                b.Text = "X";
                b.BackColor = Color.Red;
                b.Enabled = false;
                if (bsl.Count == 0)
                {
                    MessageBox.Show("Game over. You have won again!!!");
                }

            }
            else {
                b.Text = ".";
                b.BackColor = Color.BlanchedAlmond;

            }

        }
    }


}





