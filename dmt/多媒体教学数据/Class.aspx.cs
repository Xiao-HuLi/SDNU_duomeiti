using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace EmptyProjectNet40_FineUI.多媒体教学数据
{
    public partial class Class : System.Web.UI.Page
    {
        public static readonly string conString = ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString;
        public static readonly string dsconString = ConfigurationManager.ConnectionStrings["dssqlCon"].ConnectionString;
        public static string DMTSQL = "", jcdd = "", jkday = "";
        public static int jccount = 0, jcno = 0; public static DataTable pictable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid(); CheckSelection();
        }


        #region BindGrid

        private void BindGrid()
        {
            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            Grid1.RecordCount = GetTotalCount();

            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable();

            // 3.绑定到Grid
            Grid1.DataSource = table;
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
            string XN = DropDownList1.SelectedItem.Text, XQ = DropDownList2.SelectedItem.Text;
            if (XN == "2018") { XN = "[2018-2]"; } else { XN = "[2019-1]"; }
            string sql = @"SELECT [duomeiti].[dbo]." + XN + @".* ,[duomeiti].[dbo].[DMT_YKT].XM,[duomeiti].[dbo].[DMT_YKT].MC,[duomeiti].[dbo].[RoomInfo].[RoomName],[duomeiti].[dbo].[buildinginfo].[BuildingName] 
from  [duomeiti].[dbo]." + XN + ",[duomeiti].[dbo].[DMT_YKT],[duomeiti].[dbo].[RoomInfo],[duomeiti].[dbo].[buildinginfo] where [SKBJH]='sixy' AND [duomeiti].[dbo].[RoomInfo].[RoomID]=[duomeiti].[dbo]." + XN + ".[RoomID] and [duomeiti].[dbo].[buildinginfo].[BuildingID]=[duomeiti].[dbo].[RoomInfo].[BuildingID] and [duomeiti].[dbo].[DMT_YKT].RYBH = [duomeiti].[dbo]." + XN + ".RKJSGH ";

            //if (DropDownList1.SelectedItem != null)
            //{
            //    sql = sql + "and [XN]='" + DropDownList1.SelectedItem.Text + "' ";
            //}
            //if (DropDownList2.SelectedItem != null)
            //{
            //    sql = sql + "and [XQ]='" + DropDownList2.SelectedItem.Text + "' ";
            //}
            if (DropDownList3.SelectedItem.Text != "所有")
            {
                sql = sql + "and [BuildingName]='" + DropDownList3.SelectedItem.Text + "' ";
            }
            //else
            //{
            //    sql = @"SELECT sum([z1z]) as [z1z],sum([z1y]) as [z1y],sum([z2z]) as [z2z],sum([z2y]) as [z2y],sum([z3z]) as [z3z],sum([z3y]) as [z3y],sum([z4z]) as [z4z],sum([z4y]) as [z4y],sum([z5z]) as [z5z],sum([z5y]) as [z5y],sum([zz]) as [zz],sum([zr]) as [zr],[xy]  FROM [duomeiti].[dbo].[YC_XY_COUNT] group by [xy] ";
            //}

            if (DropDownList4.SelectedItem.Text != "所有学院")
            {
                sql = sql + "and [MC]='" + DropDownList4.SelectedItem.Text + "' ";
            }
            if (TextBox1.Text != "")
            {
                sql = sql + "and [XM]='" + TextBox1.Text + "' ";
            }
            if (TextBox2.Text != "")
            {
                sql = sql + "and [RKJSGH]='" + TextBox2.Text + "' ";
            }
            if (TextBox3.Text != "")
            {
                sql = sql + "and [duomeiti].[dbo].[RoomInfo].[RoomName] like '%" + TextBox3.Text + "%' ";
            }

            // sql = sql + "and id in (select MAX(ID) from [duomeiti].[dbo].[YC] WHERE bz='异常' GROUP BY [RoomID] ,[RKJSGH] ,[ZC] ,[XQJ]  ,[JC])";
            return sql;
        }
        private System.Data.DataTable GetAll()
        {
            SqlConnection conn = new SqlConnection(conString);
            DMTSQL = backsql();
            SqlDataAdapter da = new SqlDataAdapter(DMTSQL, conn);
            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);
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
            string xn = "", xy = "";

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
                xy = "";
            }
            else
            {
                xy = DropDownList4.SelectedItem.Text;
            }

            if (DropDownList3.SelectedItem.Text != "所有")
            {
                //tabletitle.HeaderText = xn + "学年第" + DropDownList2.SelectedItem.Text + "学期 " + DropDownList3.SelectedItem.Text + " " + xy + "<br>多媒体教室课表数据汇总表";
            }
            else
            {
               // tabletitle.HeaderText = xn + "学年第" + DropDownList2.SelectedItem.Text + "学期" + xy + "<br>多媒体教室课表数据汇总表";
            }


            BindGrid();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelection();

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
            mht.ResolveMultiHeaderTable(Grid1.Columns);


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

                ResolveMultiTable(row, 0);

                ResolveColumns(row);
            }

            private void ResolveColumns(List<object[]> row)
            {
                foreach (object[] cell in row)
                {
                    GroupField groupField = cell[2] as GroupField;
                    if (groupField != null && groupField.Columns.Count > 0)
                    {
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
