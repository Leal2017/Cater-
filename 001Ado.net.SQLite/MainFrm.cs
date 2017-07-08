using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _001Ado.net.SQLite
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            LoadManagerInfo();

        }

        private void LoadManagerInfo()
        {
            //string connStr = @"data source=E:\My Documents\Visual Studio 2015\Projects\CaterDemo\ManagerDb.sql;Version=3";
            string connStr = @"data source=E:\My Documents\Visual Studio 2015\Projects\CaterDemo\ItcastCater.db;Version=3";
            string sql = "select MId, MName, MPwd, MType from ManagerInfo";
            List<ManagerInfo> mList=new List<ManagerInfo>();
            //using (SQLiteTransaction scope = new SQLiteTransaction(conn,true) )
            //{
                
            //}
            using ( SQLiteConnection conn=new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();
                cmd.CommandText = sql;
                SQLiteDataAdapter adapter=new SQLiteDataAdapter(sql,conn);
                 DataTable table=new DataTable();
                 adapter.Fill(table);
                foreach (DataRow row in table.Rows )
                {
                    mList.Add(new ManagerInfo()
                    {
                        MId = int.Parse(row["MId"].ToString()),
                        MName = row["MName"] == DBNull.Value
                        ? string.Empty
                        : row["MName"].ToString(),
                        MPwd = row["MPwd"] == DBNull.Value
                        ? string.Empty
                        : row["MPwd"].ToString(),
                        MType = short.Parse(row["MType"].ToString())
                    });
                }   
                 this.dgvManagerInfo.DataSource = mList;
                  
            }//end conn
        }
    }
}
