using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        //String str;       //default는 private이므로 form1에서 접근 x
        public string str;
        public Form2()
        {
            InitializeComponent();
            str = "테스트 문자열";
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
