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
using System.Data.SqlClient;

namespace WindowsFormsDBManager
{
    public partial class DBManager : Form
    {
        
        public DBManager()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            //int col = sr.ReadLine().Split(',').Length;

            /*
            string str = tbInput.Text;

            dbGrid.Columns.Add(str,str);    //속성이름, 헤더 텍스트
            dbGrid.Rows.Add();
            */
        }

        private void btnValue_Click(object sender, EventArgs e) //tbValue에 입력된 행, 열, 값--> 해당 위치에 값 넣기
        {
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void mnuFileMgr_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.Cancel) return;
            string fName = dlg.FileName;
            StreamReader sr = new StreamReader(fName);
            string str = sr.ReadLine();
            int col = 0;
            for (int i = 0; i < str.Split(',').Length; i++)
            {
                dbGrid.Columns.Add(str.Split(',')[i], str.Split(',')[i]);
                col++;
            }
            //int row = 0;

            while (true)
            {
                str = sr.ReadLine();
                if (str == null) break;
                dbGrid.Rows.Add(str.Split(','));    //아래 주석내용과 같음
                /*
                int row = dbGrid.Rows.Add();
                for (int i = 0; i < col; i++)
                {
                    dbGrid.Rows[row].Cells[i].Value = str.Split(',')[i];
                }*/
            }
           //MessageBox.Show($"{str.Length},{str.Split(',').Length},{sr.ReadToEnd().Split('\n').Length},{sr.ReadLine().Split(',').Length}");
            
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=;Integrated Security=True;Connect Timeout=30";
        
        SqlConnection sqlCon = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();

        private void mnuDBOpen_Click(object sender, EventArgs e)
        {
            try
            {   //예외 발생 시 
                DialogResult ret = openFileDialog1.ShowDialog();
                if (ret == DialogResult.Cancel) return;
                string fName = openFileDialog1.FileName;
                
                string[] ss = conn.Split(';');
                //string s1 = $"{ss[1]}{fName}";
                //SqlConnection sqlCon = new SqlConnection();
                //sqlCon.ConnectionString = conn;             
                //SqlCommand sqlcmd = new SqlCommand();       //sql 명령어 처리기
                sqlcmd.Connection = sqlCon;
                sqlCon.ConnectionString = $"{ss[0]};{ss[1]}{fName};{ss[2]};{ss[3]}";
                sqlCon.Open();                          //void 반환 --> 결과 확인 어렵
                sbFileName.Text = openFileDialog1.SafeFileName;
                sbPanel1.Text = "success";           //발생 없을 시 
                sbPanel1.BackColor = Color.Green;       

                //sql command에서 sql문으로 

            }
            catch(Exception ee)
            {       //예외 발생 시
                MessageBox.Show(ee.Message);        //오류 메세지 출력
                sbPanel1.BackColor = Color.Red;
                sbPanel1.Text = ee.Message;

            }
        }
        int runSql(String sql)
        {
            try
            {
                sqlcmd.CommandText = sql;
                sqlcmd.ExecuteNonQuery();
            }
            catch(SqlException e1)
            {
                MessageBox.Show(e1.Message);
            }
            return 0;
            
        }
        
        private void mnuExecSql_Click(object sender, EventArgs e)
        {
            string sql = tbsql.Text;
            runSql(sql);
            /*
            sqlcmd.CommandText = sql;
            sqlcmd.ExecuteNonQuery();   //select문 제외 , 리턴값 x
            */
            //sqlcmd.ExecuteReader();

        }

        private void mnuExecSelSql_Click(object sender, EventArgs e)
        {

        }
    }
}
