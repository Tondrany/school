using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombie
{
    public partial class Form1 : Form

    {
        
        bool jdiVlevo, jdiVpravo, jdiNahoru, jdiDolu, konecHry;
        string smer = "nahoru";
        int zivotyHrace = 100;
        int rychlostHrace = 10;
        int naboje = 10;
        int rychlostNepritel = 3;
        int body;
        Random Random = new Random();



        List<PictureBox> nepritelList = new List<PictureBox>(); 
        public Form1()
        {
         
            InitializeComponent();
            Restart();

        }

        private void Timer(object sender, EventArgs e)
        {
            if(zivotyHrace > 0)
            {
                ZivotyBar.Value = zivotyHrace; //zeleny bar na zivoty
            }
            else
            {
                konecHry = true;
                hrac.Image = Properties.Resources.dead;
                GameTimer.Stop();
            }


            labelNaboje.Text = "Náboje: " + naboje;
            labelBody.Text = "Body: " + body;
            

            //pohyb hrace
            if(jdiVlevo == true && hrac.Left > 0 )
            {
                hrac.Left -= rychlostHrace;
            }
            if(jdiVpravo == true && hrac.Left + hrac.Width < this.ClientSize.Width)
            {
                hrac.Left += rychlostHrace;
            }
            if(jdiNahoru == true && hrac.Top > 40)
            {
                hrac.Top -= rychlostHrace;  
            }
            if(jdiDolu == true && hrac.Top + hrac.Height  < this.ClientSize.Height)
            {
                hrac.Top += rychlostHrace;
            }



            foreach(Control x  in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "naboje") //huh
                {
                    if (hrac.Bounds.IntersectsWith(x.Bounds))//hrac se dotkne obrazku naboju
                    {
                        this.Controls.Remove(x);//bruh idk neco to smaze
                        ((PictureBox)x).Dispose();
                        naboje += 5;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "nepritel")
                   
                    
                {
                    if (hrac.Bounds.IntersectsWith(x.Bounds))//pokud se hrac dotkne nepritele, klesnou hraci zivoty
                    {
                        zivotyHrace -= 1;
                    }


                    //jakakoliv je lokalita hrace, nepritel jde za nim
                    if (x.Left > hrac.Left)
                    {
                        x.Left -= rychlostNepritel;
                        ((PictureBox)x).Image = Properties.Resources.gLeft;
                       
                    }
                    if(x.Left < hrac.Left)
                    {
                        x.Left += rychlostNepritel;
                        ((PictureBox)x).Image = Properties.Resources.gRight;
                    }
                    if(x.Top > hrac.Top)
                    {
                        x.Top -= rychlostNepritel;
                        ((PictureBox)x).Image = Properties.Resources.gUp;
                    }
                    if(x.Top < hrac.Top)
                    {
                        x.Top += rychlostNepritel;
                        ((PictureBox)x).Image = Properties.Resources.gDown;
                    }
                }


                foreach(Control y in this.Controls)
                if (y is PictureBox && (string)y.Tag == "strela" && x is PictureBox && (string)x.Tag == "nepritel" )
                {
                        if (x.Bounds.IntersectsWith(y.Bounds))//strela se dotkne nepritele
                        {
                            body++;

                            this.Controls.Remove(y);//odstraneni steli pri zasahu nepritele
                            ((PictureBox)y).Dispose();
                            this.Controls.Remove(x);//odstraneni nepritele
                            ((PictureBox)x).Dispose();
                            nepritelList.Remove(((PictureBox)x));
                            VytvorNepritele();
                        }
                }
            }

        }

        private void Strileni (string direction)
        {

            Strela vystrelit = new Strela();
            vystrelit.smer = direction;
            vystrelit.strelaLeft = hrac.Left + (hrac.Width / 2); //strela se vytvori uprostred hrace
            vystrelit.strelaTop = hrac.Top + (hrac.Height / 2);
            vystrelit.VytvorStrelu(this);

        }






        //co se ma dit pri stisku dane klavesy
        private void KeyZmacknut(object sender, KeyEventArgs e)
        {
            //hrac se nemuze pohybovat pokud mu zivoty klesly na 0
            if(konecHry == true)
            {
                return;
            }

            //sipka vlevo
            if (e.KeyCode == Keys.Left)
            {
                jdiVlevo = true;
                smer = "vlevo";
                hrac.Image = Properties.Resources.left;
            }

            
            if (e.KeyCode == Keys.Right)
            {
                jdiVpravo = true;
                smer = "vpravo";
                hrac.Image = Properties.Resources.right;
            }

            //sipka nahoru
            if (e.KeyCode == Keys.Up)
            {
                jdiNahoru = true;
                smer = "nahoru";
                hrac.Image = (Properties.Resources.up);
            }

            //sipka dolu
            if (e.KeyCode == Keys.Down)
            {
                jdiDolu = true;
                smer = "dolu";
                hrac.Image = (Properties.Resources.down);
            }

        }

        //co se deje pokus klavesa NENI zmacknuta
        private void KeyNezmacknut(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                jdiVlevo = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                jdiVpravo = false;

            }
            if (e.KeyCode == Keys.Up)
            {
                jdiNahoru = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                jdiDolu = false;
            }


            //mohu vystrelit pokud je zmacknut mezernik, hrac ma naboje a nebyl konec hry
            if (e.KeyCode == Keys.Space && naboje > 0 && konecHry == false)
                
            {
                naboje--;
                Strileni(smer);

                if (naboje == 0) //pokud hrac nema naboje, na zemi se objevi nove naboje
                {

                    vytvorNaboje();
                }
            }

            //pokud hrac umre a zmackne enter, hra se restartuje
            if(e.KeyCode == Keys.Enter && konecHry == true)
            {
                Restart();
            }
 
        }

       

        private void VytvorNepritele()
        {
            PictureBox nepritel = new PictureBox();
            nepritel.Tag = "nepritel";
            nepritel.Image = Properties.Resources.gUp;
            nepritel.Left = Random.Next(0, 900);
            nepritel.Top = Random.Next(0, 700);
            nepritel.SizeMode = PictureBoxSizeMode.AutoSize;

            nepritelList.Add(nepritel);
            this.Controls.Add(nepritel);

            hrac.BringToFront();
        }

        //funkce pro vytvareni naboju
        private void vytvorNaboje()
        {
            PictureBox naboje = new PictureBox();
            naboje.Image = Properties.Resources.ammo_Image;
            naboje.SizeMode = PictureBoxSizeMode.AutoSize;
            naboje.Left = Random.Next(10, this.ClientSize.Width);
            naboje.Top = Random.Next(45, this.ClientSize.Height);
            naboje.Tag = "naboje";
            this.Controls.Add(naboje);

            naboje.BringToFront();
            hrac.BringToFront();
        }

        //
        private void Restart() 
        {
            hrac.Image = Properties.Resources.up;

            foreach(PictureBox i in nepritelList)
            {
                this.Controls.Remove(i); //odstrani vsechny PictureBoxy nepratel z Listu
            }

            nepritelList.Clear();

            for (int i = 0; i < 3; i++) // vytvarej soupere dokud jejich pocet neni vic jak 3
            {
                VytvorNepritele();
            }

            jdiDolu = false;
            jdiNahoru = false;
            jdiDolu = false;
            jdiNahoru = false;
            konecHry = false;


            zivotyHrace = 100;
            body = 0;
            naboje = 10;

            GameTimer.Start();
            
        }
    }
}
