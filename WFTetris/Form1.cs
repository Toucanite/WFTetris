using System;
using System.Drawing;
using System.Windows.Forms;

namespace WFTetris
{
    public partial class Form1 : Form
    {

        Tetris game = new Tetris();


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void screenTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.Paint(sender, e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //game.clearPiece(Tetris.Pieces.O, where);
            //if (e.KeyCode == Keys.Left)
            //    where.X -= 1;
            //if (e.KeyCode == Keys.Right)
            //    where.X += 1;
            //game.setPiece(Tetris.Pieces.O, where);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
