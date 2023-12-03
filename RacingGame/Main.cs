using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGame
{
    public partial class Main : Form
    {

        private Point pos;
        private bool dragging;
        public Main()
        {
            InitializeComponent();
            MouseDown += MouseClickDown;
            MouseUp += MouseClickUp;
            MouseMove += MouseClickMove;
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
                this.Location = new Point(currPoint.X - pos.X, currPoint.Y - pos.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            helpForm2cs helpForm2Cs = new helpForm2cs();
            helpForm2Cs.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            aboutForm aboutForm = new aboutForm();
            aboutForm.Show();
        }
    }
}
