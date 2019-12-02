using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;
using System.Configuration;
using System.Data.SqlClient;

namespace EmptyProjectNet40_FineUI.多媒体教学数据
{
    public partial class PicData : System.Web.UI.Page
    {
        public static readonly string conString = ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString;
        public static readonly string dsconString = ConfigurationManager.ConnectionStrings["dssqlCon"].ConnectionString;
        public static string DMTSQL = "", jcdd = "", jkday = "";
       // DMTSQL = "SELECT lujing  FROM (SELECT top 1000000 lujing,min(id)as id FROM [duomeiti].[dbo].[jietu] group by lujing  order by id asc) as num   group by lujing ";
           
        //    DMTSQL = "SELECT room FROM (SELECT top 1000000 room,min(id)as id FROM [duomeiti].[dbo].[jietu] group by room  order by id asc) as num   group by room";
   
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid2();
         //   Grid2.SelectedRowIndex = 0;
            BindGrid1();
          //  Grid1.SelectedRowIndex = 0;
            //BindGrid3();
           // Grid3.SelectedRowIndex = 0;
        }
         #region BindGrid2/BindGrid1

        private void BindGrid2()
        {
            Grid2.DataSource = GetAll(1);
            Grid2.DataBind();
           // Grid2.SelectedRowIndex = 0;
            Grid1.DataSource = GetAll(2);
            Grid1.DataBind();
          //  Grid1.SelectedRowIndex = 0;
            
        }
        private void BindGrid3()
        {
            //if (Grid2.SelectedRowIndex < 0)
            //{
            //    return;
            //}
            //if (Grid1.SelectedRowIndex < 0)
            //{
            //    return;
            //}

           // string lujing = Grid2.DataKeys[Grid2.SelectedRowIndex][0].ToString();
            //string name = Grid1.DataKeys[Grid1.SelectedRowIndex][0].ToString();
            Grid3.DataSource = GetAll(3);
            Grid3.DataBind();
         //   Grid3.SelectedRowIndex = 0;
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            BindGrid1();
        }
        private void BindGrid1()
        {
            if (Grid2.SelectedRowIndex < 0)
            {
                return;
            }
            if (Grid1.SelectedRowIndex < 0)
            {
                return;
            }
            int a = Grid1.SelectedRowIndex;
            int b = Grid2.SelectedRowIndex;
            SqlConnection conn = new SqlConnection(dsconString);
            
                string lujing = Grid2.DataKeys[Grid2.SelectedRowIndex][0].ToString();
                string name = Grid1.DataKeys[Grid1.SelectedRowIndex][0].ToString();
                string sql = "SELECT * FROM  [duomeiti].[dbo].[jietu] where lujing='" + lujing + "' and name='" + name + "' ";
          

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);

            conn.Close();
            da.Dispose();
            conn.Dispose();

            Grid3.DataSource = table;
            Grid3.DataBind();
           // Grid3.SelectedRowIndex = 0;
        //   UpdateClassDesc(classId);
        }

        private void UpdateClassDesc(int classId)
        {
            foreach (DataRow row in  GetAll(1).Rows)
            {
                int currentClassId = (int)row["Id"];
                if (classId == currentClassId)
                {
                    labelClassDesc.Text = String.Format("<div style=\"margin-bottom:10px;\"><strong>班级描述：</strong></div><div>{0}</div>", row["Desc"].ToString());
                    break;
                }
            }
        }

        #endregion

        #region Events

        protected void Grid2_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            BindGrid1(); 
           // BindGrid3();
        }

        protected void Grid1_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            //BindGrid1(); 
            BindGrid3();
        }


        #endregion


        private string backsql()
        {
           

            string sql = "and id in (select MAX(ID) from [duomeiti].[dbo].[YC] WHERE bz='异常' GROUP BY [RoomID] ,[RKJSGH] ,[ZC] ,[XQJ]  ,[JC])";
            return sql;
        }
        private System.Data.DataTable GetAll(int id)
        {
            SqlConnection conn = new SqlConnection(dsconString);
            string sql = "SELECT lujing  FROM (SELECT top 1000000 lujing,min(id)as id FROM [duomeiti].[dbo].[jietu] group by lujing  order by id asc) as num   group by lujing ";
            if (id == 2) { sql = "SELECT room FROM (SELECT top 1000000 room,min(id)as id FROM [duomeiti].[dbo].[jietu] group by room  order by id asc) as num   group by room"; }
            else if (id ==3) {
                string lujing = Grid2.DataKeys[Grid2.SelectedRowIndex][0].ToString();
                string name = Grid1.DataKeys[Grid1.SelectedRowIndex][0].ToString();
                sql = "SELECT * FROM  [duomeiti].[dbo].[jietu] where lujing='" + lujing + "' and name='" + name + "' ";
            }
         
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);
           
            conn.Close();
            da.Dispose();
            conn.Dispose();
            return table;

        }

    }
}