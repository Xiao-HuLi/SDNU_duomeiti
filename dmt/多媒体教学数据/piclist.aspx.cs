using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using FineUI;

namespace EmptyProjectNet40_FineUI.多媒体教学数据
{
    public partial class piclist : System.Web.UI.Page

    {
        public static readonly string conString = ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString;
        public static readonly string dsconString = ConfigurationManager.ConnectionStrings["dssqlCon"].ConnectionString;
        public static string DMTSQL = "", jk1 = "", jk2 = "";
        public static System.Data.DataTable sdnudate = new System.Data.DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData(); LoadData2();
            }
        }

        private void LoadData()
        {
            // 模拟从数据库返回数据表
            DataTable table = CreateDataTable();

            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["Id"], ds.Tables[0].Columns["ParentId"]);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.IsNull("ParentId"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Text"].ToString();
                    node.Expanded = true; 
                    node.EnableClickEvent = true;
                    Tree1.Nodes.Add(node);
                    
                    ResolveSubTree(row, node);
                }
            }
        }
        private void LoadData2()
        {
            // 模拟从数据库返回数据表
            DataTable table = CreateDataTable2();

            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["Id"], ds.Tables[0].Columns["ParentId"]);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.IsNull("ParentId"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Text"].ToString();
                    node.Expanded = true;
                    node.EnableClickEvent = true;
                    Tree2.Nodes.Add(node);

                    ResolveSubTree(row, node);
                }
            }
        }

        private void ResolveSubTree(DataRow dataRow, FineUI.TreeNode treeNode)
        {
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
               // treeNode.Expanded = true;
                treeNode.EnableClickEvent = true;
                foreach (DataRow row in rows)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["Text"].ToString();
                    treeNode.Nodes.Add(node);
                    node.EnableClickEvent = true;
                    ResolveSubTree(row, node);
                }
            }
        }
        protected void Tree1_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            if (e.Node.ParentNode != null)
            {
                jk1 = e.Node.Text;
                if (jk1!=""&&jk2!="")
                {
                    SqlConnection conn = new SqlConnection(dsconString);
                    conn.Open();
                    //DMTSQL = "select [id],[room],[time],[sf] ,[lujing],[name] from [duomeiti].[dbo].[jietu] where roomid='" + keys[0] + "' and lujing='" + keys[1] + "' and time>'" + bt + "' and time<'" + et + "' order by time";
                    DMTSQL = "select [id],[room],[time],[sf] ,[lujing],[name] from [duomeiti].[dbo].[jietu] where room='" + jk2 + "' and lujing='" + jk1 + "'  order by time";

                    SqlDataAdapter da = new SqlDataAdapter(DMTSQL, conn);
                   // System.Data.DataTable sdnudate = new System.Data.DataTable();
                    sdnudate.Clear();
                    da.Fill(sdnudate);
                    if (sdnudate.Rows.Count > 0)
                    {
                        imgPhoto.ImageUrl = @"http://172.27.16.250/pic/" + sdnudate.Rows[0][4] + @"/" + sdnudate.Rows[0][1] + @"/" + sdnudate.Rows[0][5] + ".jpg";
                        Grid1.DataSource = sdnudate;
                        Grid1.DataBind();
                    }
                    conn.Close();
                    da.Dispose();
                    conn.Dispose();
                }
                labResult.Text = "你点击了树节点：" + e.Node.Text + "<br/>父节点：" + e.Node.ParentNode.Text;
            }
        }

        protected void Grid1_RowClick(object sender, GridRowClickEventArgs e)
        {
           // Alert.ShowInTop(String.Format("你点击了第 {0} 行（单击）", e.RowIndex + 1));
           // imgPhoto.ImageUrl = @"http://172.27.16.250/pic/" + sdnudate.Rows[e.RowIndex][4] + @"/" + sdnudate.Rows[e.RowIndex][1] + @"/" + sdnudate.Rows[e.RowIndex][5] + ".jpg";
            imgPhoto.ImageUrl = @"http://172.23.1.107/pic/" + sdnudate.Rows[e.RowIndex][4] + @"/" + sdnudate.Rows[e.RowIndex][1] + @"/" + sdnudate.Rows[e.RowIndex][5] + ".jpg";

        }

        protected void Tree2_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            if (e.Node.ParentNode != null)
            {
                jk2 = e.Node.Text;
                if (jk1 != "" && jk2 != "")
                {
                    SqlConnection conn = new SqlConnection(dsconString);
                    conn.Open();
                    //DMTSQL = "select [id],[room],[time],[sf] ,[lujing],[name] from [duomeiti].[dbo].[jietu] where room='" + keys[0] + "' and lujing='" + keys[1] + "' and time>'" + bt + "' and time<'" + et + "' order by time";
                    DMTSQL = "select [id],[room],[time],[sf] ,[lujing],[name] from [duomeiti].[dbo].[jietu] where room='" + jk2 + "' and lujing='" + jk1 + "'  order by time";

                    SqlDataAdapter da = new SqlDataAdapter(DMTSQL, conn);
                    sdnudate.Clear();
                    //System.Data.DataTable sdnudate = new System.Data.DataTable();
                    da.Fill(sdnudate);
                   
                    if (sdnudate.Rows.Count > 0)
                    {
                       // imgPhoto.ImageUrl = @"http://172.27.16.250/pic/" + sdnudate.Rows[0][4] + @"/" + sdnudate.Rows[0][1] + @"/" + sdnudate.Rows[0][5] + ".jpg";
                        imgPhoto.ImageUrl = @"http://172.23.1.107/pic/" + sdnudate.Rows[0][4] + @"/" + sdnudate.Rows[0][1] + @"/" + sdnudate.Rows[0][5] + ".jpg";
                      
                        Grid1.DataSource = sdnudate;
                        Grid1.DataBind();
                    }
                    conn.Close();
                    da.Dispose();
                    conn.Dispose();
                }
                labResult.Text = "你点击了树节点：" + e.Node.Text + "<br/>父节点：" + e.Node.ParentNode.Text;
            }
        }
     

        #region CreateDataTable

        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            DataTable table2 = new DataTable(); DataTable table1 = new DataTable();
            DataColumn column1 = new DataColumn("Id", typeof(string));
            DataColumn column2 = new DataColumn("Text", typeof(String));
            DataColumn column3 = new DataColumn("ParentId", typeof(string));
            table.Columns.Add(column1);
            table.Columns.Add(column2);
            table.Columns.Add(column3);

            DataRow row = table.NewRow();
            row[0] = "root";
            row[1] = "2018-2学期";
            row[2] = DBNull.Value;
            table.Rows.Add(row);

            string sql = "SELECT  lujing  FROM (SELECT top 1000000 lujing,min(id)as id FROM [duomeiti].[dbo].[jietu] where time>'2018-08-27 00:00:00.000' and time<'2019-01-01 00:00:00.000'  group by lujing  order by id asc) as num   group by lujing ";
           
            SqlConnection conn = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            
            da.Fill(table1);
            string sqls  = "SELECT room FROM (SELECT top 1000000 room,min(id)as id FROM [duomeiti].[dbo].[jietu] group by room  order by id asc) as num   group by room"; 

            SqlConnection conn2 = new SqlConnection(conString);
            SqlDataAdapter da2 = new SqlDataAdapter(sqls, conn2);

            da2.Fill(table2);
            int aa = 1;
            for (int i = 0; i < table1.Rows.Count-1;i++ ) 
            {
                row = table.NewRow();
                row[0] = table1.Rows[i][0].ToString();
                row[1] = table1.Rows[i][0].ToString();
                row[2] = "root";
                table.Rows.Add(row);
                //for (int j = 0; j < table2.Rows.Count - 1; j++)
                //{
                //    row = table.NewRow();
                //    row[0] = "henan" + aa;
                //    row[1] = table2.Rows[j][0].ToString();
                //    row[2] = table1.Rows[i][0].ToString();
                //    table.Rows.Add(row);
                //    aa++;
                //}
            }

            

            return table;
        }

        private DataTable CreateDataTable2()
        {
            DataTable table = new DataTable();
            DataTable table2 = new DataTable(); DataTable table1 = new DataTable();
            DataColumn column1 = new DataColumn("Id", typeof(string));
            DataColumn column2 = new DataColumn("Text", typeof(String));
            DataColumn column3 = new DataColumn("ParentId", typeof(string));
            table.Columns.Add(column1);
            table.Columns.Add(column2);
            table.Columns.Add(column3);

            DataRow row = table.NewRow();
            //row[0] = "root";
            //row[1] = "2018-2学期";
            //row[2] = DBNull.Value;
            //table.Rows.Add(row);

            string sql = @"SELECT [room],b.BuildingName  FROM [duomeiti].[dbo].[RoomInfo]as a,[duomeiti].[dbo].[buildinginfo] as b, [duomeiti].[dbo].[jietu] as c
  where  a.RoomID=c.RoomID and a.BuildingID=b.BuildingID group by [room],b.BuildingName ";
            SqlConnection conn = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.Fill(table1);
            string sqls = "SELECT [BuildingName]   FROM [duomeiti].[dbo].[buildinginfo]";

            SqlConnection conn2 = new SqlConnection(conString);
            SqlDataAdapter da2 = new SqlDataAdapter(sqls, conn2);

            da2.Fill(table2);
            int aa = 0;
            for (int i = 0; i < table2.Rows.Count - 1; i++)
            {
                row = table.NewRow();
                row[0] = table2.Rows[i][0].ToString();
                row[1] = table2.Rows[i][0].ToString();
                row[2] = DBNull.Value;
                table.Rows.Add(row);
                DataRow[] Row = table1.Select("BuildingName='" + table2.Rows[i][0].ToString() + "'");
                for (int j = 0; j < Row.Length - 1; j++)
                {
                    row = table.NewRow();
                    row[0] = "henan" + aa;
                    row[1] = Row[j][0].ToString();
                    row[2] = table2.Rows[i][0].ToString();
                    table.Rows.Add(row);
                    aa++;
                }
            }



            return table;
        }
        #endregion

    }
}