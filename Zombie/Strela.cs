using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Zombie
{
    internal class Strela
    {
        public string smer;
        public int strelaLeft;
        public int strelaTop;

        private int rychlost = 30;
        private PictureBox strela = new PictureBox();
        private Timer strelaTimer = new Timer();


        public void VytvorStrelu(Form form)
        {
            //funkce prida strelu do hry


            strela.BringToFront();
            strela.BackColor = Color.Gold;
            strela.Size = new Size(5, 5);
            strela.Tag = "strela";
            strela.Top = strelaTop;
            strela.Left = strelaLeft;

            form.Controls.Add(strela); 
            //přidání strely do form

            strelaTimer.Interval = 30;
            //StrelaTimer.Tick += new EventHandler(TimerHra);

            strelaTimer.Tick += new EventHandler(StrelaTimerEvent);
            //přidáme k Timeru Event 
            strelaTimer.Start();


        }

        private void StrelaTimerEvent(object sender, EventArgs e)
        {
            //funkce smer kulky
            if(smer == "vlevo")
            {
                strela.Left -= rychlost;
            }
            if(smer == "vpravo")
            {
                strela.Left += rychlost;
            }
            if(smer == "nahoru")
            {
                strela.Top -= rychlost;
            }
            if(smer == "dolu")
            {
                strela.Top += rychlost;
            }

            // if the bullet is less the 16 pixel to the left OR
            // if the bullet is more than 860 pixels to the right OR
            // if the bullet is 10 pixels from the top OR
            // if the bullet is 616 pixels to the bottom OR
            // IF ANY ONE OF THE CONDITIONS ARE MET THEN THE FOLLOWING CODE WILL BE EXECUTED 

            //pokud strela prekroci uvedene hodnoty smaze se
            if (strela.Left < 15 || strela.Left > 1180 || strela.Top < 10 || strela.Top > 600)
            {
                strelaTimer.Stop();
                strelaTimer.Dispose();
                strela.Dispose();
                strelaTimer = null;
                strela = null;
            }


        }

    }
}
