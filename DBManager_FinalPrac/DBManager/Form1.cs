using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection sqlConn = new SqlConnection();   //잠재적 수정사항 클릭 필요!
        SqlCommand sqlCmd = new SqlCommand();


        private void nEwToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //grid 초기화
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            textBox1.Clear();
            
            //status bar 초기화
            sbPanel1.Text = "DB File Name";
            sbPanel2.Text = "Initialized";
            sbDropDown.Text = "Table List";
            sbDropDown.DropDownItems.Clear();

            //
            sqlConn.Close();

        }


        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamReader sdr = new StreamReader(openFileDialog1.FileName);
            string buf = sdr.ReadLine();        //각 컬럼의 headerText들 먼저 
            string[] sArr = buf.Split(',');

            for(int i = 0; i < sArr.Length; i++)
            {
                dataGrid.Columns.Add(sArr[i], sArr[i]);
            }
            while (true)
            {
                buf = sdr.ReadLine();
                if (buf == null) return;

                sArr = buf.Split(',');
                dataGrid.Rows.Add(sArr);    //한줄씩 값 넣기
            }
            sdr.Close();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            string buf = "";
            for(int i = 0; i < dataGrid.ColumnCount; i++)
            {
                buf += dataGrid.Columns[i].HeaderText;
                if (i < dataGrid.ColumnCount - 1) buf += ",";
            }
            sw.Write(buf + "\r\n");
            
            for(int i = 0; i < dataGrid.RowCount; i++)
            {
                buf = "";
                for(int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    buf += dataGrid.Rows[i].Cells[j].Value;
                    if (i < dataGrid.ColumnCount - 1) buf += ",";
                }
                sw.Write(buf + "\r\n");
            }
            sw.Close();
        }
        string sConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=;Integrated Security=True;Connect Timeout=30";
        private void mnuFileOpenDB_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            try
            {

                string[] sArr = sConn.Split(';');
                sConn = $"{sArr[0]};{sArr[1]};{openFileDialog1.FileName};{sArr[2]};{sArr[3]}";
                sqlConn.ConnectionString = sConn;
                sqlConn.Open();
                sqlCmd.Connection = sqlConn;
                sbPanel1.Text = openFileDialog1.SafeFileName;
                sbPanel1.BackColor = Color.Green;

                DataTable dt = sqlConn.GetSchema("Tables");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sbDropDown.DropDownItems.Add(dt.Rows[i].ItemArray[2].ToString());
                }
                sbPanel2.Text = "Success";
                sbPanel2.BackColor = Color.Gray;
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message,"Error가 발생했습니다.");
                sbPanel2.Text = "error";
                sbPanel2.BackColor = Color.Red;
            }

        }

        private void sbDropDown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbDropDown.Text = e.ClickedItem.Text;
            runSql($"select * from {sbDropDown.Text}");
        }

        private void ClearGrid()
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
        }
        public string GetToken(int i, string src, char del)
        {
            string[] sArr = src.Split(del);
            return sArr[i];
        }

        private void runSql(string Sql)
        {
            try
            {
                string sql = GetToken(0, Sql.Trim().ToLower(), ' ');
                sqlCmd.CommandText = Sql;
                if (sql == "select")
                {
                    ClearGrid();            //현재 표시되고있는 datagrid 비우기
                    SqlDataReader sr = sqlCmd.ExecuteReader();
                    for (int i = 0; i < sr.FieldCount; i++)
                    {
                        dataGrid.Columns.Add(sr.GetName(i), sr.GetName(i));
                    }
                    for (int i = 0; sr.Read(); i++)   //sr --> 레코드 단위로
                    {
                        object[] oArr = new object[sr.FieldCount];  //framework이 new로 생성된 애들 처리해줌
                        sr.GetValues(oArr);             //현재 행의 값들을 oArr로
                        dataGrid.Rows.Add(oArr);        //oArr값들을 row로
                    }
                }
            }


        }

    }
}
