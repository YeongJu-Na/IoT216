using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGraphic
{
    public partial class Form1 : Form
    {
        Graphics GDC;
        //Pen pp=new Pen(Color.Red,3);    //초기값 

        int width=2, px=10, py=10;
        public Form1()
        {
            InitializeComponent();
            //GDC=CreateGraphics();   //form1다이얼로그 자체의 것(this)
            GDC = Canvas.CreateGraphics();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            //Pen pp = new Pen(Color.Red,10);
            //e.Graphics.DrawEllipse(pp,100,100,200,200);
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Pen pp = new Pen(Color.Red, width);
                GDC.DrawEllipse(pp, e.X-px/2, e.Y-py/2, px, py);
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Canvas_Resize(object sender, EventArgs e)
        {
            GDC = Canvas.CreateGraphics();

        }

        private void mnuEraseAll_Click(object sender, EventArgs e)
        {
            GDC.Clear(DefaultBackColor);
        }
       
        private void mnuPenSet_Click(object sender, EventArgs e)
        {
            penSet dlg = new penSet(px,py,width);   //new penSet(cirX, cirY, thickness)-- 방법2.
            DialogResult ret =  dlg.ShowDialog();

            if (ret == DialogResult.OK)
            {
                if (dlg.pwidth != -1) width = dlg.pwidth;
                if (dlg.px != -1) px = dlg.px;
                if (dlg.py != -1) py = dlg.py;
            }

            //py = int.Parse(ps.y);         //입력문자열이 잘못된 경우 바로 에러뜸
        }
    }
}
