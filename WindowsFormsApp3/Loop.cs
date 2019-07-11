using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WindowsFormsApp3
{
    public partial class Loop : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private double counter = 0;
        private double counter2 = 0;
        


        public Loop()
        {

            InitializeComponent();
            //dimension = new FrameDimension(this.loopGif4.Image.FrameDimensionsList[0]);
            //frameCount = this.loopGif4.Image.GetFrameCount(dimension);
            //this.loopGif4.Paint += new PaintEventHandler(loopGif_Paint);

                label1.Text = DateTime.Now.ToString("h:mm:ss");

            timer.Interval = 16;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (counter >= 100)
            {
                counter = 0;
                circularProgressBar1.Value = (int)counter;
                label2.Text = DateTime.Now.ToString("h:mm:ss");
                

            }
            else
            {
                counter++;
                circularProgressBar1.Value = (int)counter;

            }

            if (int.Parse(loopGif2Label.Text) != 0 )
            {

                if (counter2 >= 100)
                {
                    counter2 = 0;
                    circularProgressBar2.Value = (int)counter2;
                    label2.Text = DateTime.Now.ToString("h:mm:ss");



                }
                else
                {
                    counter2+=0.5;
                    circularProgressBar2.Value = (int)counter2;

                }
                
            }

        }

        //private void loopGif_Paint(object sender, PaintEventArgs e)
        //{
        //    this.loopGif4.Image.SelectActiveFrame(dimension, frameCount);
        //    e.Graphics.DrawImage(this.loopGif4.Image, Point.Empty);
        //}




        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Loop_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Loop_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Loop_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void minimizePictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

       
    }
}
