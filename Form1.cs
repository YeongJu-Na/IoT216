using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int status = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //object sender: caller,
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (status==0)
            {
                btn_Test.Text = "버튼테스트 1";
                status = 1;
            }
            else
            {
                btn_Test.Text = "버튼테스트 2";
                status = 0;
            }

        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.Cancel) return; //파일이 선택되지 않으면 리턴

            string fName = openFileDialog1.FileName;
            StreamReader sr = new StreamReader(fName);
            string buf = sr.ReadToEnd();
            textBox1.Text = buf;
            sr.Close();
        }

        private void btnFileSave_Click(object sender, EventArgs e)
        {
            DialogResult ret = saveFileDialog1.ShowDialog();
            if (ret == DialogResult.Cancel) return; //파일이 선택되지 않으면 리턴

            string fName = saveFileDialog1.FileName;    //fullpath
            StreamWriter sw = new StreamWriter(fName);

            sw.Write(textBox1.Text);
            sw.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string src = tb1.Text;      
            string target = src.ToUpper(); //대문자로 바꾼 복사본 되돌릴 뿐 원본 그대로

            tb2.Text = target;
            //tb3.Text = src.Length.ToString();
            //string etc = src.Length.ToString(); //c++ CString에서 숫자를 문자형으로 바꿀때 번거로웠음-> str.Format("%d",src.Length());
            //string etc = "문자열 길이는 "+src.Length+"입니당.";
            string etc = $"문자열의 길이는 {src.Length}입니당.";   //보간문자열 - 매번 +로 연결하지 않고 괄호안에, "--> \"로 써야 
            
            
            tb3.Text = etc;

        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();   //new키워드로 반드시 생성자 호출해서 초기값 지정해야 아래 수행가능
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = frm2.cb1.Text+"\n\r";
                
                //"\n"만으로는 줄바꿈 안됨 --> "\r\n"
                
            }
        }

    }
}
