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
    public partial class penSet : Form
    {
        public int pwidth;
        public int px;
        public int py;
        public penSet(int x, int y, int t)
        {
            px = x; py= y; pwidth = t;
            InitializeComponent();
        }
        
        private void penSet_Load(object sender, EventArgs e)
        {
            tbThick.Text = $"{pwidth}";
            tbX.Text = $"{px}";
            tbY.Text = $"{py}";
        }
        private bool isNumericValue(string str)
        {
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < '0' || arr[i] > '9') return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if(tbThick.Text!="") thick = int.Parse(tbThick.Text);
            if (tbX.Text != "") x = int.Parse(tbX.Text);
            if (tbY.Text != "") y= int.Parse(tbY.Text);*/
            string wid = tbThick.Text;
            string xx = tbX.Text;
            string yy = tbY.Text;

            // 숫자가 아닌 값이 들어갔을 때 오류 발생 --> 예외 처리
            if (!isNumericValue(wid) || !isNumericValue(xx) || !isNumericValue(yy))
            {
                MessageBox.Show("잘못된 문자열입니다.");
                return;
            }
            //빈칸은 기존의 값 유지되도록 -1을 반환해 알림
            if (wid != "") pwidth = int.Parse(wid);
            else pwidth = -1;
            if (xx != "") px = int.Parse(xx);
            else px = -1;
            if (yy != "") py = int.Parse(yy);
            else py = -1;

            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
