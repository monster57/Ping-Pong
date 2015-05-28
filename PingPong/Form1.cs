using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        public int speed_left = 4; // speed of the ball
        public int speed_top = 4;
        public int points = 0;       // scored points 
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();          //hide the cursor
            this.FormBorderStyle = FormBorderStyle.None;        // Remove any border
            this.TopMost = true;            // Bring the form to the front
            this.Bounds = Screen.PrimaryScreen.Bounds;  // make it full screen
            racket2.Top = playground.Top - (playground.Top/10);
            racket1.Top = playground.Bottom - (playground.Bottom/40); //set the position of racket
            gameover_lbl.Left = (playground.Width/2) - (gameover_lbl.Width/2); // Position to centre 
            gameover_lbl.Top = (playground.Height/2) - (gameover_lbl.Height/2);
            gameover_lbl.Visible = false; // Hide
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket1.Left = Cursor.Position.X - (racket1.Width - 2);       // set the centre of the racket to the position of the cursor
            racket2.Left = Cursor.Position.X - (racket2.Width - 2);
            ball.Left += speed_left;        //Move the ball
            ball.Top += speed_top;

            if ((ball.Bottom >= racket1.Top && ball.Bottom <= racket1.Bottom && ball.Left >= racket1.Left &&
                ball.Right <= racket1.Right)|| (ball.Top <= racket2.Bottom && ball.Top >= racket2.Top && ball.Left >= racket2.Left &&
                ball.Right <= racket2.Right) )    //racket collition
            {
                speed_top += 1;
                speed_left += 1;
                speed_top = -speed_top;     //Change direction
                points += 1;
                points_lbl.Text = points.ToString();
                Random r =  new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));    //get a random rbg color and set is as playground backcolor 
            }
            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top <=playground.Top)
            {
                speed_top = -speed_top;
            }
            if (ball.Bottom >= playground.Bottom  || ball.Top <= playground.Top)
            {
                timer1.Enabled = false;         // Ball is out -> stop the game
                gameover_lbl.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();  // Press escape to quit 
            if (e.KeyCode== Keys.Space)        //Reload game
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                points = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                gameover_lbl.Visible = false;
                playground.BackColor = Color.White;
            }

        }

        private void ball_Click(object sender, EventArgs e)
        {

        }

     
    }
}
