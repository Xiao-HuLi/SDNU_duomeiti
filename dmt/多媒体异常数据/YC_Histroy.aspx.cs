﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace EmptyProjectNet20
{
    public partial class YC_Histroy: System.Web.UI.Page
    {
        public static readonly string conString = ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString;
        public static readonly string dsconString = ConfigurationManager.ConnectionStrings["dssqlCon"].ConnectionString;
        public static string DMTSQL = "", jcdd = "", jkday = "";
        public static int jccount = 0, jcno = 0; public static DataTable pictable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid(); CheckSelection();
            imgPhoto.ImageUrl = @"1.png";
            
        }

        
        #region BindGrid

        private void BindGrid()
        {

            


            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            Grid1.RecordCount = GetTotalCount();

            // 2.获取当前分页数据
            DataTable table = GetAll();
            for(int i=0;i<table.Rows.Count;i++)
            {
                table.Rows[i][8]=table.Rows[i][8].ToString()+"节";
            }
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataView view = table.DefaultView;
            view.Sort = String.Format("{0} {1}", sortField, sortDirection);
            
            
            // 3.绑定到Grid
            Grid1.DataSource = view;
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
            string sql = @"select [XN] ,[XQ] ,[CLASS_ID],[duomeiti].[dbo].[yc].[RoomID] ,[RKJSGH] ,[ZC] ,[XQJ] ,[DSZ] ,[JC] ,[SKRQ] ,[inKB] ,[outROOM] ,[yuancheng] ,[DJZ] ,[id] ,[bz],[duomeiti].[dbo].[DMT_YKT].XM,[duomeiti].[dbo].[DMT_YKT].MC,[duomeiti].[dbo].[RoomInfo].[RoomName],[duomeiti].[dbo].[RoomInfo].[RoomName],[duomeiti].[dbo].[buildinginfo].[BuildingName] from 
[duomeiti].[dbo].[YC],[duomeiti].[dbo].[DMT_YKT],[duomeiti].[dbo].[RoomInfo],[duomeiti].[dbo].[buildinginfo] where [duomeiti].[dbo].[RoomInfo].[RoomID]=[duomeiti].[dbo].[yc].[RoomID] and [duomeiti].[dbo].[buildinginfo].[BuildingID]=[duomeiti].[dbo].[RoomInfo].[BuildingID] and
[duomeiti].[dbo].[DMT_YKT].RYBH = [duomeiti].[dbo].[YC].RKJSGH and bz='异常'  ";

            if (DropDownList1.SelectedItem != null)
            {
                sql = sql + "and [XN]='" + DropDownList1.SelectedItem.Text+ "' ";
            }
            if (DropDownList2.SelectedItem != null)
            {
                sql = sql + "and [XQ]='" + DropDownList2.SelectedItem.Text + "' ";
            }
            if (DropDownList3.SelectedItem != null)
            {
                List<string> texts = new List<string>(); string xz = "";
                

                    foreach (FineUI.ListItem item in DropDownList3.SelectedItemArray)
                    {
                        texts.Add(item.Text);

                        
                    }
                    for (int i = 0; i < texts.Count;i++ )
                    {
                        if (i == 0) { xz = " and ([DJZ]='" + texts[i] + "'"; }
                        else 
                        {
                            xz = xz+" or [DJZ]='" + texts[i] + "' ";
                        }


                        if (i == texts.Count-1) { xz = xz+") "; }
                    }
                
                sql = sql + xz ;
            }
            if (DropDownList4.SelectedItem.Text != "所有学院")
            {
                sql = sql + "and [MC] like'%" + DropDownList4.SelectedItem.Value + "%' ";
            }


            sql =sql +"and id in (select MAX(ID) from [duomeiti].[dbo].[YC] WHERE bz='异常' GROUP BY [RoomID] ,[RKJSGH]  ,[XQJ]  ,[JC])";
            return sql;
        }
        private System.Data.DataTable GetAll()
        {
            SqlConnection conn = new SqlConnection(conString);
            DMTSQL = backsql(); conn.Open();
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
           // Alert.ShowInTop(String.Format("你选中了第 {0} 行，行ID：{1}", e.RowIndex + 1, e.RowID));
             object[] keys = Grid1.DataKeys[e.RowIndex];


            DateTime day=Convert.ToDateTime(keys[1]);
            DateTime bt=day, et=day; 
           

            if (keys[2].Equals("1-2节")) 
            {
                bt = Convert.ToDateTime(keys[1]).AddHours(7);
                et = Convert.ToDateTime(keys[1]).AddHours(10);
            }
            else if (keys[2].Equals("3-4节"))
            {
                bt = Convert.ToDateTime(keys[1]).AddHours(10);
                et = Convert.ToDateTime(keys[1]).AddHours(13);
            }
            else if (keys[2].Equals("5-6节"))
            {
                bt = Convert.ToDateTime(keys[1]).AddHours(13);
                et = Convert.ToDateTime(keys[1]).AddHours(16);
            }
            else if (keys[2].Equals("7-8节"))
            {
                bt = Convert.ToDateTime(keys[1]).AddHours(16);
                et = Convert.ToDateTime(keys[1]).AddHours(18);
            }
            else if (keys[2].Equals("9-10节"))
            {
                bt = Convert.ToDateTime(keys[1]).AddHours(18);
                et = Convert.ToDateTime(keys[1]).AddHours(21);
            }
            pictable.Clear();

            SqlConnection conn = new SqlConnection(dsconString);
            conn.Open();
            string weeksql = "select [id],[room],[time],[sf] ,[lujing],[name],[RoomName] from [duomeiti].[dbo].[jietu],[dscontrol].[dbo].[RoomInfo] where [dscontrol].[dbo].[RoomInfo].[RoomID]=[duomeiti].[dbo].[jietu].[RoomID] and [duomeiti].[dbo].[jietu].roomid='" + keys[0] + "' and lujing='" + keys[1] + "' and time>'" + bt + "' and time<'" + et + "' order by time";
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

        protected void jkshow(int no, DataTable sdnudate)
        {

            

            if (jccount > 0)
            {
                imgPhoto.ImageUrl = @"http://172.27.16.250/pic/" + sdnudate.Rows[no][4] + @"/" + sdnudate.Rows[no][1] + @"/" + sdnudate.Rows[no][5] + ".jpg";
                labResult.Text = sdnudate.Rows[jcno][1] + "教室 日期：" + sdnudate.Rows[jcno][2];
               // HtmlEditor1.Text = "<span style=\"color: rgb(0, 0, 0); background-color: rgb(255, 255, 255);\">教室：" + sdnudate.Rows[jcno][6] + "</span><br><div style=\"background-color: rgb(255, 255, 255);\">讲台检测教师：<font color=\"#ff0000\">无</font></div><div ><span style=\"background-color: rgb(255, 255, 255);\">多媒体设备使用：<font color=\"#ff0000\">关</font></span></div>";
                //TextArea1.Text = HtmlEditor1.Text;
            }
            else
            {
                imgPhoto.ImageUrl = "http://172.27.16.250/pic/11.jpg";
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
            string xn = "", xy = "", xz = "";
            List<string> texts = new List<string>();
            List<string> values = new List<string>();

            if (DropDownList1.SelectedItem.Text == "2018")
            {
                xn = "2018-2019";
            }
            else
            {
                xn = "2019-2020";
            }
            if (DropDownList4.SelectedItem.Text == "所有学院")
            {
                xy = "长清湖校区";
            }
            else
            {
                xy = "长清湖校区" + DropDownList4.SelectedItem.Text;
            }
            if (DropDownList3.SelectedItem != null)
            {
                if (DropDownList3.SelectedItem.Text != "所有周")
                {
                    tabletitle.HeaderText = xn + "学年第" + DropDownList2.SelectedItem.Text + "学期第" + DropDownList3.SelectedItem.Text + "周" + xy + "<br>多媒体教室异常数据统计表";
                }
                else
                {
                    if (DropDownList3.SelectedItem != null)
                    {

                        foreach (FineUI.ListItem item in DropDownList3.SelectedItemArray)
                        {
                            texts.Add(item.Text);
                            values.Add(item.Value);
                            xz = xz + ",";
                        }
                        xz = xz.Remove(xz.Length);
                        labResult.Text = String.Format("选中学周：{0}<br/>",
                            String.Join("&nbsp;&nbsp;", texts.ToArray()));
                    }
                    tabletitle.HeaderText = xn + "学年第" + DropDownList2.SelectedItem.Text + "学期" + xy + "<br>多媒体教室异常数据统计表";

                  //  Grid1.Columns[0].HeaderText = xn + "学年第" + DropDownList2.SelectedItem.Text + "学期" + xy + "<br>多媒体教室异常数据统计表";
                }
            }
            else
            { tabletitle.HeaderText = xn + "学年第" + DropDownList2.SelectedItem.Text + "学期" + xy + "<br>多媒体教室异常数据统计表";
            //Grid1.Columns[0].HeaderText = xn + "学年第" + DropDownList2.SelectedItem.Text + "学期" + xy + "<br>多媒体教室异常数据统计表";
            }

           
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindGrid(); CheckSelection();
        }
      
        #endregion
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=myexcel.xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(GetGridTableHtml(Grid1));
            Response.End();
        }

        private string GetGridTableHtml(Grid grid)
        {
            StringBuilder sb = new StringBuilder();

            MultiHeaderTable mht = new MultiHeaderTable();
            GridColumnCollection columns1 = Grid1.Columns;
            


            mht.ResolveMultiHeaderTable(columns1);


         //  Provider = Microsoft.Jet.OLEDB.4.0 ;
           // Persist Security Info=False;
           // Data Source = " + filePath + ";Extended Properties=Excel 8.0;" //过于老了一点很难去兼容Excel版本问题

            // Provider =  Microsoft.ACE.OLEDB.12.0;
            //Persist Security Info=False;
            //System.Data Source= " + filePath + ";
            //Extended Properties=Excel 8.0;//"   还没来的急看看具体区别。
           
            sb.Append("<meta http-equiv=\"content-type\" content=\"application/excel; charset=UTF-8\"/>");


            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

            foreach (List<object[]> rows in mht.MultiTable)
            {
                sb.Append("<tr>");
                
                foreach (object[] cell in rows)
                {
                    int rowspan = Convert.ToInt32(cell[0]);
                    int colspan = Convert.ToInt32(cell[1]);
                    GridColumn column = cell[2] as GridColumn;

                    sb.AppendFormat("<th{0}{1}{2}>{3}</th>",
                        rowspan != 1 ? " rowspan=\"" + rowspan + "\"" : "",
                        colspan != 1 ? " colspan=\"" + colspan + "\"" : "",
                        colspan != 1 ? " style=\"text-align:center;\"" : "",
                        column.HeaderText);
                }
                sb.Append("</tr>");
            }


            foreach (GridRow row in grid.Rows)
            {
                sb.Append("<tr>");

                foreach (GridColumn column in mht.Columns)
                {
                    string html = row.Values[column.ColumnIndex].ToString();

                    if (column.ColumnID == "tfNumber")
                    {
                        html = (row.FindControl("spanNumber") as System.Web.UI.HtmlControls.HtmlGenericControl).InnerText;
                    }
                    else if (column.ColumnID == "tfGender")
                    {
                        html = (row.FindControl("labGender") as System.Web.UI.WebControls.Label).Text;
                    }


                    sb.AppendFormat("<td>{0}</td>", html);
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");

            return sb.ToString();
        }


        #region 多表头处理

        /// <summary>
        /// 处理多表头的类
        /// </summary>
        public class MultiHeaderTable
        {
            // 包含 rowspan，colspan 的多表头，方便生成 HTML 的 table 标签
            public List<List<object[]>> MultiTable = new List<List<object[]>>();
            // 最终渲染的列数组
            public List<GridColumn> Columns = new List<GridColumn>();


            public void ResolveMultiHeaderTable(GridColumnCollection columns)
            {
                List<object[]> row = new List<object[]>();
                
                foreach (GridColumn column in columns)
                {                 
                   
                        object[] cell = new object[4];
                        cell[0] = 1;    // rowspan
                        cell[1] = 1;    // colspan
                        cell[2] = column;
                        cell[3] = null;                       
                        row.Add(cell);
                    
                }
                foreach (object[] cell in row)
                {
                    GroupField groupField = cell[2] as GroupField;

                    if (groupField != null && groupField.Columns.Count > 0)
                    {
                        groupField.Columns.RemoveAt(0); //删除id列
                        groupField.HeaderText.Remove(0);//删除id列

                    }
                }



                ResolveMultiTable(row, 0);

                ResolveColumns(row);
            }

            private void ResolveColumns(List<object[]> row)
            {
              //  row.RemoveAt(0);
               
                foreach (object[] cell in row)
                {
                    GroupField groupField = cell[2] as GroupField;
                   
                    if (groupField != null && groupField.Columns.Count > 0)
                    {
                        //groupField.Columns.RemoveAt(0);
                        List<object[]> subrow = new List<object[]>();
                        foreach (GridColumn column in groupField.Columns)
                        {
                            subrow.Add(new object[]
                            {
                                1,
                                1,
                                column,
                                groupField
                            });
                        }

                        ResolveColumns(subrow);
                    }
                    else
                    {
                        Columns.Add(cell[2] as GridColumn);
                    }
                }

            }

            private void ResolveMultiTable(List<object[]> row, int level)
            {
                List<object[]> nextrow = new List<object[]>();

                foreach (object[] cell in row)
                {
                    GroupField groupField = cell[2] as GroupField;
                    if (groupField != null && groupField.Columns.Count > 0)
                    {
                        // 如果当前列包含子列，则更改当前列的 colspan，以及增加父列（向上递归）的colspan
                        cell[1] = Convert.ToInt32(groupField.Columns.Count);
                        PlusColspan(level - 1, cell[3] as GridColumn, groupField.Columns.Count - 1);

                        foreach (GridColumn column in groupField.Columns)
                        {
                            nextrow.Add(new object[]
                            {
                                1,
                                1,
                                column,
                                groupField
                            });
                        }
                    }
                }

                MultiTable.Add(row);

                // 如果当前下一行，则增加上一行（向上递归）中没有子列的列的 rowspan
                if (nextrow.Count > 0)
                {
                    PlusRowspan(level);

                    ResolveMultiTable(nextrow, level + 1);
                }
            }

            private void PlusRowspan(int level)
            {
                if (level < 0)
                {
                    return;
                }

                foreach (object[] cells in MultiTable[level])
                {
                    GroupField groupField = cells[2] as GroupField;
                    if (groupField != null && groupField.Columns.Count > 0)
                    {
                        // ...
                    }
                    else
                    {
                        cells[0] = Convert.ToInt32(cells[0]) + 1;
                    }
                }

                PlusRowspan(level - 1);
            }

            private void PlusColspan(int level, GridColumn parent, int plusCount)
            {
                if (level < 0)
                {
                    return;
                }

                foreach (object[] cells in MultiTable[level])
                {
                    GridColumn column = cells[2] as GridColumn;
                    if (column == parent)
                    {
                        cells[1] = Convert.ToInt32(cells[1]) + plusCount;

                        PlusColspan(level - 1, cells[3] as GridColumn, plusCount);
                    }
                }
            }

        }
        #endregion

        protected void cx_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}
