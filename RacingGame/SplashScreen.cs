using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace RacingGame
{
    public partial class SplashScreen : Form
    {
        private Timer timer;
        private Point pos;
        private bool dragging;

        public SplashScreen()
        {
            InitializeComponent();
            timer1.Start();
            bg1.MouseDown += MouseClickDown;
            bg1.MouseUp += MouseClickUp;
            bg1.MouseMove += MouseClickMove;
            bg2.MouseDown += MouseClickDown;
            bg2.MouseUp += MouseClickUp;
            bg2.MouseMove += MouseClickMove;

        }

        private void MouseClickDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            pos.X = e.X;
            pos.Y = e.Y;
        }

        private void MouseClickUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void MouseClickMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currPoint = PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(currPoint.X - pos.X, currPoint.Y - pos.Y + bg1.Top);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i<10; i++)
            {
                Opacity += 0.1d;
            }

            int speed = -3;
            player.Top += speed;
          
        }


    }
}
