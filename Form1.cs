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
//using MyClassLibrary ;
using ClassLibrary1;
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
        public static string GetToken(int idx, char deli, string str)
        //구분자로 split된 문자열의 idx위치의 값 반환
        {
            return str.Split(deli)[idx];
        }
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
                sbFileName.BackColor = Color.Green;
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

        string tableName;       //다른 메뉴에서 사용할 DB테이블 이름
        int runSql(String sql)
        {
            try
            {
                //ex) select * from fstatus
                sqlcmd.CommandText = sql.Trim();
                
                if(ClassLibrary1.test.GetToken(0,' ', sql).ToLower()=="select")
                {               //select문일 때 --> 해당하는 결과를 dbgrid에 표시하기 위함
                    SqlDataReader sdr = sqlcmd.ExecuteReader();
                    tableName = GetToken(3, ' ', sql);
                    
                    dbGrid.Rows.Clear();            //이전 결과 삭제
                    dbGrid.Columns.Clear();
                    
                    for(int i = 0; sdr.Read(); i++)     //다음행이 존재하는 동안
                    {
                        //string buf = "";
                        if (i == 0) {       //속성들의 이름 표시위함
                            for (int j = 0; j < sdr.FieldCount; j++)
                            {
                                dbGrid.Columns.Add(sdr.GetName(j), sdr.GetName(j));
                            }
                        }
                        dbGrid.Rows.Add();      //해당 i번째 행을 위한 row생성
                        for (int j = 0; j < sdr.FieldCount; j++)
                        {
                            
                            dbGrid.Rows[i].Cells[j].Value = sdr.GetValue(j);
                          
                            //object str = sdr.GetString(j);
                            //buf += $"{str} ";
                        }
                        //tbsql.Text += $"\r\n{ buf}\r\n";
                    }
                    sdr.Close();
                    
                }
                else
                {
                    sqlcmd.ExecuteNonQuery();
                }
                
                
                sbPanel1.Text = "Success";
                sbPanel1.BackColor = Color.AliceBlue;
            }
            catch(SqlException e1)
            {
                MessageBox.Show(e1.Message);

                sbPanel1.Text = "Error: sqlException";
                sbPanel1.BackColor = Color.Red;
            }
            catch(InvalidOperationException e2)
            {
                MessageBox.Show(e2.Message);

                sbPanel1.Text = "Error: InvalidOperationException";
                sbPanel1.BackColor = Color.Red;
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
        int line_idx = 0;
        private void tbsql_TextChanged(object sender, EventArgs e)
        {
            //tbsql.SelectionStart = 0;
            //int line = 1;
            /*
            if (tbsql.Text.Substring(idx+1).Contains("\r\n"))
            {
                string sql = tbsql.Text.Substring(idx);
                runSql(sql);
                //line = tbsql.Lines.Length;
                idx = tbsql.Text.Length;
            }*/
        }
        int cnt = 0;
        private void tbsql_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (e.KeyChar == (char)Keys.Enter)
            {
                
                if (tbsql.Lines[line_idx].Equals(null)) return;
                string str = tbsql.Lines[line_idx];
                runSql(str);
                line_idx++;
        }*/
            
        }

        private void tbsql_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode != Keys.Enter) return;
            string str = tbsql.Text;
            string[] sArr = str.Split('\n');
            runSql(sArr[sArr.Length - 1].Trim());
            
        }

        private void dbGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dbGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "."; //전체 텍스트검색해서 tooltiptext가 .인것
        }

        private void mnuUpdate_Click(object sender, EventArgs e)  //dbgrid에서 변경한 값을 원본테이블에도 적용하기
        {                           
            for(int i = 0; i < dbGrid.Rows.Count; i++)
            {
                for(int j = 0; j < dbGrid.Columns.Count; j++)
                {
                    string s = dbGrid.Rows[i].Cells[j].ToolTipText;
                    if (s == ".")       
        //update [Table(tn)] set [field(fn)]=[cellText(ct)] where [1st_col name(KeyName)]=[1st col.celltext]
                    {
                        string tn = tableName;
                        string fn = dbGrid.Columns[j].HeaderText;   //속성
                        string ct = (string) dbGrid.Rows[i].Cells[j].Value;
                        string kn = dbGrid.Columns[0].HeaderText;
                        string kt = (string)dbGrid.Rows[i].Cells[0].Value;
                        string sql = $"update {tn} set {fn}={ct} where {kn}={kt}";
                        runSql(sql);
                    }
                }
            }
        }
    }
}
