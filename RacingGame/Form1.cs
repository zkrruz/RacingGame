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
    public partial class Form1 : Form
    {

        private Point pos;
        private bool dragging, lose = false;
        private int countCoins = 0;


        public Form1()
        {
            InitializeComponent();

            bg1.MouseDown += MouseClickDown;
            bg1.MouseUp += MouseClickUp;
            bg1.MouseMove += MouseClickMove;
            bg2.MouseDown += MouseClickDown;
            bg2.MouseUp += MouseClickUp;
            bg2.MouseMove += MouseClickMove;

            labelLose.Visible = false;
            btnExit.Visible = false;
            btnRestart.Visible = false;

            KeyPreview = true;
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


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                Main main = new Main();
                main.Show();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int speed = 10;
            bg1.Top += speed;
            bg2.Top += speed;

            int carSpeed = 7;
            enemy1.Top += carSpeed;
            enemy2.Top += carSpeed;

            coin.Top += speed;

            if (bg1.Top >=  525) { 
                bg1.Top = 0;
                bg2.Top = -525;
            }

            if(coin.Top >= 525)
            {
                coin.Top = -50;
                Random rand = new Random();
                coin.Left = rand.Next(120, 450);
            }

            if (enemy1.Top >= 525)
            {
                enemy1.Top = -130;
                Random rand = new Random();
                enemy1.Left = rand.Next(120, 240);
            }
            
            if(enemy2.Top >=525) 
            { 
                enemy2.Top = -400; 
                Random rand = new Random();
                enemy2.Left = rand.Next(300, 450);
            }

            if (player.Bounds.IntersectsWith(enemy1.Bounds) || player.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer.Enabled = false;
                labelLose.Visible = true;
                btnRestart.Visible = true;
                btnExit.Visible = true;
                lose = true;
            }

            if (player.Bounds.IntersectsWith(coin.Bounds))
            {
                countCoins++;
                labelCoins.Text = "Монеты: " + countCoins.ToString();
                coin.Top = -50;
                Random rand = new Random();
                coin.Left = rand.Next(120, 450);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (lose) return;

            int speed = 10;
            if((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && player.Left > 120) { 
                player.Left -= speed;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && player.Right < 530)
            {
                player.Left += speed;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Main main = new Main();
            main.Show();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            enemy1.Top = -130;
            enemy2.Top = -400;
            labelLose.Visible = false;
            btnRestart.Visible = false;
            btnExit.Visible=false;
            timer.Enabled = true;
            lose = false;
            countCoins = 0;
            labelCoins.Text = "Монеты: 0";
            coin.Top = -500;
        }
    }
}
