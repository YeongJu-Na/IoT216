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
using myLibrary;

namespace WindowsFormsEdit
{
    public partial class Form1 : Form       //메모장 기능 구현
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            DialogResult ret = openFileDialog1.ShowDialog();   //==DoModal() (C++)
            if (ret == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;    //full path, openFileDialog.SafeFileName;  // file name only
                StreamReader sr = new StreamReader(fName);  //FILE* (C), CFile(c++)
                tb1.Text = sr.ReadToEnd();
                //Form1.ActiveForm.Text =fName;
                sr.Close();
                string[] arr = fName.Split('\\');      //char[], 백슬래시 이므로 한번 더 써줘야
                //Form1.ActiveForm.Text = arr[arr.Length-1].Split('.')[0]; 
                //this.Text= arr[arr.Length - 1].Split('.')[0];   //현재 폼==this로 접근 가능
                int n = myLib.Count('\\', fName);
                this.Text += myLib.GetToken(n, '\\', fName);
                Font f = tb1.Font;
                sbLabel1.Text = f.Name;
                sbLabel2.Text = f.Size.ToString();
            }
        }
        private void font_display()
        {
            sbLabel1.Text = tb1.Font.Name;
            sbLabel2.Text = $"{tb1.Font.Size}";
        }
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            DialogResult ret = saveFileDialog1.ShowDialog();        //호출, 생성
            string fName = saveFileDialog1.FileName;
            StreamWriter sw = new StreamWriter(fName);
            if (ret == DialogResult.Cancel) return;
            sw.Write(tb1.Text);
            sw.Close();
        }

        private void mnuViewFont_Click(object sender, EventArgs e)
        {
            DialogResult ret = fontDialog1.ShowDialog();
            if (ret == DialogResult.Cancel) return;

            
            Font f = fontDialog1.Font;
            tb1.Font = f;
            font_display();
            /*
            sbLabel1.Text = f.Name;
            sbLabel2.Text = f.Size.ToString();
            */
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            tb1.Text = "";
        }


        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tb1.WordWrap) tb1.WordWrap = false;
            else tb1.WordWrap = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            font_display();
        }
    }
}
