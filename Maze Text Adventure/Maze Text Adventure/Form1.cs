using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Maze_Text_Adventure
{
    public partial class Form1 : Form
    {
        //declaring enums for position
        enum position
        {
            left, right, up, down, still
        }

        // declaring fields for the x and y axis position
        private int _x;
        private int _y;
        //using the enum data type created for the object position
        private position _objPosition;

        public Form1()
        {
            InitializeComponent();

            //once the form loads, position the object at
            //the set x, y and objPosition assignment
            _x = 12;
            _y = 12;
            _objPosition = position.still;   //when the key board is down
            
        }

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    //the png image is choosen as the moving object that
        //    //will start at the position of x and y and the size of 16, 16
        //    e.Graphics.DrawImage(new Bitmap("villan girl.png"), _x, _y, 64, 64);
        //}

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //if the position enum is assigned to object
            //the object should move + 10 to the x-axis
            if (_objPosition == position.right)
            {
                fighterPictureBox.Left += 8;
            }
            else if (_objPosition == position.left)
            {
               fighterPictureBox.Left -= 8;
            }
            else if (_objPosition == position.up)
            {
               fighterPictureBox.Top -= 8;
            }
            else if (_objPosition == position.down)
            {
                fighterPictureBox.Top += 8;
            }
            else if(_objPosition == position.still)
            {
                fighterPictureBox.Top += 0;
                fighterPictureBox.Left += 0;
            }

            //calling this timer method makes the object move
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //assigning the various keys for the position enums
            if (e.KeyCode == Keys.L)
            {
                _objPosition = position.left;
            }
            else if (e.KeyCode == Keys.R)
            {
                _objPosition = position.right;
            }
            else if (e.KeyCode == Keys.U)
            {
                _objPosition = position.up;
            }
            else if (e.KeyCode == Keys.D)
            {
                _objPosition = position.down;
            }

            collision();
            Attach();
        }

        public void collision()
        {
            
            if (fighterPictureBox.Bounds.IntersectsWith(castlePictureBox.Bounds))
            {
                MessageBox.Show("Congratulations! you safely got to the castle");
                _objPosition = position.still;
            }
            
        }

        public void Attach()
        {
            if (fighterPictureBox.Bounds.IntersectsWith(monsterPictureBox.Bounds))
            {
                monsterPictureBox.Top = 2000;
            }
        }

        public void Gate()
        {
            if (fighterPictureBox.Bounds.IntersectsWith(gatePictureBox.Bounds))
            {
                gatePictureBox.Visible = false;
            }
        }


        //private void Form1_TextChanged(object sender, EventArgs e)
        //{
        //    string control = controlLabel.Text.ToUpper();
        //    if (control == "down")
        //    {
        //        _objPosition = position.down;
        //    }
        //    else if (control == "up")
        //    {
        //        _objPosition = position.up;
        //    }
        //    else if (control == "right")
        //    {
        //        _objPosition = position.right;
        //    }
        //    else if (control == "left")
        //    {
        //        _objPosition = position.left;
        //    }


        //}

       
    }
}
