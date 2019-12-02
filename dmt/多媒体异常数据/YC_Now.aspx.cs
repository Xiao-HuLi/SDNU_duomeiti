using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EmptyProjectNet40_FineUI.admin;

namespace EmptyProjectNet20
{
    public partial class YC_Now : System.Web.UI.Page
    {
        public static readonly string conString = ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString;
        public static readonly string dsconString = ConfigurationManager.ConnectionStrings["dssqlCon"].ConnectionString;
        public static string DMTSQL = "", jcdd = "", jkday = "";
        public static int jccount = 0, jcno = 0; public static DataTable pictable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
            imgPhoto.ImageUrl = @"2019-10-30-8-18-36.jpg";
        }

      
        #region BindGrid

        private void BindGrid()
        {
            duomeitiSQL duomeitisql = new duomeitiSQL();
            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）


            // 2.获取当前分页数据GetAll()
           // DataTable table = duomeitisql.ycshishi();
            DataTable table = GetAll();
            
            DataTable newdt = new DataTable(); 
                newdt = table.Clone(); // 克隆dt 的结构，包括所有 dt 架构和约束,并无数据；
                string selecttext = "bz='异常'";
                if (DropDownList4.SelectedItem.Text != "所有学院")
                {
                    selecttext = "bz='异常' and MC='" + DropDownList4.SelectedItem.Text + "'";
                }
                DataRow[] rows = table.Select(selecttext); // 从dt 中查询符合条件的记录； 
                foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                Grid1.RecordCount = newdt.Rows.Count;
                            // 3.绑定到Grid
                Grid1.DataSource = newdt;
            Grid1.DataBind();
        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            return GetAll().Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable()
        {
            int pageIndex = Grid1.PageIndex;
            int pageSize = Grid1.PageSize;

            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;

            DataTable table2 = GetAll();

            DataView view2 = table2.DefaultView;
            view2.Sort = String.Format("{0} {1}", sortField, sortDirection);

            DataTable table = view2.ToTable();

            DataTable paged = table.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > table.Rows.Count)
            {
                rowend = table.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(table.Rows[i]);
            }

            return paged;
        }

        #endregion
        private string backsql()
        {
            //string XN = DropDownList1.Text, XQ = DropDownList2.Text;
            //if (XN == "2018-2019") { XN = "[YC2018-2019-1]"; } else { XN = "[YC2017-2018-2]"; }
            string sql = @"select top 8 [XN] ,[XQ] ,[CLASS_ID],[duomeiti].[dbo].[yc].[RoomID] ,[RKJSGH] ,[ZC] ,[XQJ] ,[DSZ] ,[JC] ,[SKRQ] ,[inKB] ,[outROOM] ,[yuancheng] ,[DJZ] ,[id] ,[bz],[duomeiti].[dbo].[DMT_YKT].XM,
[duomeiti].[dbo].[DMT_YKT].MC,[duomeiti].[dbo].[RoomInfo].[RoomName],[duomeiti].[dbo].[buildinginfo].[BuildingName] from 
[duomeiti].[dbo].[YC],[duomeiti].[dbo].[DMT_YKT],[duomeiti].[dbo].[RoomInfo],[duomeiti].[dbo].[buildinginfo] where [duomeiti].[dbo].[RoomInfo].[RoomID]=[duomeiti].[dbo].[yc].[RoomID] and [duomeiti].[dbo].[buildinginfo].[BuildingID]=[duomeiti].[dbo].[RoomInfo].[BuildingID] and
[duomeiti].[dbo].[DMT_YKT].RYBH = [duomeiti].[dbo].[YC].RKJSGH and bz='异常' and jc='1-2' ";

            //if (DropDownList1.SelectedItem != null)
            //{
            //    sql = sql + "and [XN]='" + DropDownList1.SelectedItem.Text+ "' ";
            //}
            //if (DropDownList2.SelectedItem != null)
            //{
            //    sql = sql + "and [XQ]='" + DropDownList2.SelectedItem.Text + "' ";
            //}
            //if (DropDownList3.SelectedItem != null)
            //{
            //    sql = sql + "and [DJZ]='" + DropDownList3.SelectedItem.Text + "' ";
            //}
            if (DropDownList4.SelectedItem.Text != "所有学院")
            {
                sql = sql + "and [MC]='" + DropDownList4.SelectedItem.Text + "' ";
            }


            sql =sql +"and id in (select MAX(ID) from [duomeiti].[dbo].[YC] WHERE bz='异常' GROUP BY [RoomID] ,[RKJSGH] ,[ZC] ,[XQJ]  ,[JC])";
            return sql;
        }
        private System.Data.DataTable GetAll()
        {
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            DMTSQL = backsql();
            SqlDataAdapter da = new SqlDataAdapter(DMTSQL, conn);
            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);
            conn.Close();
            da.Dispose();
            conn.Dispose();
            return table;
            
        }


        #region Events

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    labResult.Text = HowManyRowsAreSelected(Grid1);
        //}

        protected void Grid1_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            // Alert.ShowInTop(String.Format("你选中了第 {0} 行，行ID：{1}", e.RowIndex + 1, e.RowID)); 0:00:00
             object[] keys = Grid1.DataKeys[e.RowIndex];

             keys[1] = DateTime.Today.GetDateTimeFormats('s')[0].ToString().Replace(" ", "-").Remove(10).Trim();
             DateTime day = DateTime.Today;
            DateTime bt=day, et=day; 
           

            if (keys[2].Equals("1-2")) 
            {
                bt = Convert.ToDateTime(keys[1]).AddHours(7);
                et = Convert.ToDateTime(keys[1]).AddHours(10);
            }
            else if (keys[2].Equals("3-4"))
            {
                bt = Convert.ToDateTime(keys[1]).AddHours(10);
                et = Convert.ToDateTime(keys[1]).AddHours(13);
            }
            else if (keys[2].Equals("5-6"))
            {
                bt = Convert.ToDateTime(keys[1]).AddHours(13);
                et = Convert.ToDateTime(keys[1]).AddHours(16);
            }
            else if (keys[2].Equals("7-8"))
            {
                bt = Convert.ToDateTime(keys[1]).AddHours(16);
                et = Convert.ToDateTime(keys[1]).AddHours(18);
            }
            else if (keys[2].Equals("9-10"))
            {
                bt = Convert.ToDateTime(keys[1]).AddHours(18);
                et = Convert.ToDateTime(keys[1]).AddHours(21);
            }
            pictable.Clear();

            SqlConnection conn = new SqlConnection(dsconString);
            conn.Open();
            string weeksql = "select [id],[room],[time],[sf] ,[lujing],[name] from [duomeiti].[dbo].[jietu] where roomid='" + keys[0] + "' and lujing='" + keys[1] + "' and time>'" + bt + "' and time<'" + et + "' order by time";
            //DataTable sdnudate = new DataTable();
            SqlDataAdapter daweek = new SqlDataAdapter(weeksql, conn);
            daweek.Fill(pictable);

            if (pictable.Rows.Count > 0)

            {
                jccount = pictable.Rows.Count - 1;
                jcno = 0;
                jkshow(0, pictable);

                //imgPhoto.ImageUrl = @"http://172.27.16.250/pic/" + sdnudate.Rows[0][4] + @"/" + sdnudate.Rows[0][1] + @"/" + sdnudate.Rows[0][5] + ".jpg";
            }
            else { labResult.Text = "没有合适截图！"; }
             conn.Close();
             daweek.Dispose();
             conn.Dispose();
           
        }

        protected void jkshow(int no, DataTable pictable)
        {



            if (jccount > 0)
            {
               // imgPhoto.ImageUrl = @"http://172.27.16.250/pic/" + pictable.Rows[no][4] + @"/" + pictable.Rows[no][1] + @"/" + pictable.Rows[no][5] + ".jpg";
                imgPhoto.ImageUrl = "E:/pic/2019-9-17/1-109/2019-9-17-8-47-21.jpg";
                
               // labResult.Text = pictable.Rows[jcno][1] + "教室 日期：" + pictable.Rows[no][2];
             // //  HtmlEditor1.Text = "<br><div>讲台检测教师：无</div><div ><span>多媒体设备使用：关</span></div>";
            //  //  TextArea1.Text = HtmlEditor1.Text;
            }
            else
            {
               // imgPhoto.ImageUrl = "http://172.27.16.250/pic/11.jpg";

                imgPhoto.ImageUrl = "E:/pic/2019-9-17/1-109/2019-9-17-8-47-21.jpg";
                labResult.Text = " 无视频截图！";
            }



        }
        protected void firstpic_Click(object sender, EventArgs e)
        {
            if (jcno > 0)
            {
                
                jcno = 0;
                jkshow(0, pictable);
                labResult.Text = " 最早的一张了！";
            }
            else
            {
                labResult.Text = " 最早的一张了！";
            }
           
        }
        protected void nextpic_Click(object sender, EventArgs e)
        {
            if (jcno < jccount)
            {
                labResult.Text = "";
                ++jcno;
                jkshow(jcno, pictable);

            }
            else
            {
                labResult.Text = " 最新的一张了！";
            }
        }
        protected void propic_Click(object sender, EventArgs e)
        {
            if (jcno > 0)
            {
                labResult.Text = "";
                --jcno;
                jkshow(jcno, pictable);

            }
            else
            {
                labResult.Text = " 最早的一张了！";
            }
           
        }
        protected void endpic_Click(object sender, EventArgs e)
        {
            if (jccount > 0)
            {
                jcno = jccount;

                jkshow(jccount, pictable);
                labResult.Text = " 最新的一张了！";
            }
            else
            {
                labResult.Text = " 最新的一张了！";
            }
        }
        
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            //Grid1.PageIndex = e.NewPageIndex;

            BindGrid();
        }

        protected void Grid1_Sort(object sender, GridSortEventArgs e)
        {
            //Grid1.SortDirection = e.SortDirection;
            //Grid1.SortField = e.SortField;

            BindGrid();
        }
        private void CheckSelection()
        {
           // if (DropDownList4.SelectedItem != null)
           // {
               // labResult.Text = String.Format("选中项：{0}（值：{1}）", DropDownList1.SelectedItem.Text, DropDownList1.SelectedValue);


            BindGrid();
            
            
          //  }
            //else
            //{
            //    labResult.Text = "无选中项";
            //}
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // CheckSelection();
            BindGrid();
        }
      
        #endregion

        protected void cx_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}
