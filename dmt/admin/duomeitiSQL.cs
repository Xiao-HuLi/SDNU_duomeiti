using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EmptyProjectNet40_FineUI.admin
{
    public class duomeitiSQL
    {
        public static readonly string conString = ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString;
        public static readonly string dsconString = ConfigurationManager.ConnectionStrings["dssqlCon"].ConnectionString;
        public string DMTSQL = "";
        public System.Data.DataTable extable = new System.Data.DataTable();
        public static DataTable jsroomid, kbdatanow, kbdata1_1, kbdata1_2, kbdata1_3, kbdata2_1, kbdata2_2, kbdata2_3, kbdata3_1, kbdata3_2, kbdata3_3, kbdata4_1, kbdata4_2, kbdata4_3, kbdata5_1, kbdata5_2, kbdata5_3;
        private static int DateDiff(DateTime dateStart, DateTime dateEnd)
        {
            //DateTime start = Convert.ToDateTime(dateStart.ToShortDateString());
            //DateTime end = Convert.ToDateTime(dateStart.ToShortDateString());

            TimeSpan sp = dateEnd.Subtract(dateStart);

            return sp.Days;
        }
        public static System.Data.DataTable skjsgh(int sqj, int jc)//课表里安排的上课教师工号
        {
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            string JC = "";
            System.Data.DataTable sdnudate = new DataTable();
            if (jc == 1) { JC = "JC='1-2' or JC='1' or JC='3-4' or JC='3'"; }

            else if (jc == 2) { JC = "JC='5-6' or JC='5' or JC='7-8' or JC='7' "; }

            else if (jc == 3) { JC = "JC='9-10' or JC='11'"; }
            string sql = "select RKJSGH,SKDD,JC  from [duomeiti].[dbo].[2019-1] WHERE xqj='" + sqj + "' and (" + JC + ") group by RKJSGH,SKDD,JC";
            if (jc == 0) { sql = "select RKJSGH,SKDD,JC  from [duomeiti].[dbo].[2019-1] WHERE xqj='" + sqj + "' group by RKJSGH,SKDD,JC"; }
            SqlDataAdapter daweek = new SqlDataAdapter(sql, conn);
            daweek.Fill(sdnudate);
            conn.Close();
            daweek.Dispose();
            conn.Dispose();
            return sdnudate;


        }
        public System.Data.DataTable skjsid(DateTime btime, DateTime etime)//查询时间内上课的教室ID
        {
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string sql = "SELECT RoomID,CardNo   FROM [SQL_LINK].[dscontrol].[dbo].[HistoryInfo]  where BeginTime>'" + btime + "' and BeginTime<'" + etime + "' and beginOrEnd='1' group by RoomID,CardNo";
            System.Data.DataTable sdnudate = new DataTable();
            SqlDataAdapter daweek = new SqlDataAdapter(sql, conn);
            // SELECT RoomID   FROM [SQL_LINK].[dscontrol].[dbo].[HistoryInfo]  where BeginTime>'2018/8/27 7:00:00' and BeginTime<'2018/8/27 12:00:00' and beginOrEnd='1' group by RoomID,CardNo
            daweek.Fill(sdnudate);
            conn.Close();
            daweek.Dispose();
            conn.Dispose();
            return sdnudate;

        }
        public void yc(DateTime stime, DateTime etime, int weeked)
        {

            kbdata1_1 = duomeitiSQL.skjsgh(1, 1);
            kbdata1_2 = duomeitiSQL.skjsgh(1, 2);
            kbdata1_3 = duomeitiSQL.skjsgh(1, 3);
            kbdata2_1 = duomeitiSQL.skjsgh(2, 1);
            kbdata2_2 = duomeitiSQL.skjsgh(2, 2);
            kbdata2_3 = duomeitiSQL.skjsgh(2, 3);
            kbdata3_1 = duomeitiSQL.skjsgh(3, 1);
            kbdata3_2 = duomeitiSQL.skjsgh(3, 2);
            kbdata3_3 = duomeitiSQL.skjsgh(3, 3);
            kbdata4_1 = duomeitiSQL.skjsgh(4, 1);
            kbdata4_2 = duomeitiSQL.skjsgh(4, 2);
            kbdata4_3 = duomeitiSQL.skjsgh(4, 3);
            kbdata5_1 = duomeitiSQL.skjsgh(5, 1);
            kbdata5_2 = duomeitiSQL.skjsgh(5, 2);
            kbdata5_3 = duomeitiSQL.skjsgh(5, 3);
            //DateTime stime = Convert.ToDateTime("2018-01-15 00:00:00.000"), etime = Convert.ToDateTime("2018-02-03 00:00:00.000");
            //int weeked = 0;
            int year_Begin = Convert.ToInt32(stime.Year);
            int month_Begin = Convert.ToInt32(stime.Month);
            int day_Begin = Convert.ToInt32(stime.Day);
            int year_End = Convert.ToInt32(etime.Year);
            int month_End = Convert.ToInt32(etime.Month);
            int day_End = Convert.ToInt32(etime.Day);



            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            SqlConnection conn2 = new SqlConnection(dsconString);
            conn2.Open();

            SqlCommand msc1 = new SqlCommand();
            msc1.Connection = conn;
            SqlCommand msc2 = new SqlCommand();
            msc2.Connection = conn;
            SqlCommand msc3 = new SqlCommand();
            msc3.Connection = conn;
            SqlCommand msc4 = new SqlCommand();
            msc4.Connection = conn;



            for (DateTime dt = new DateTime(year_Begin, month_Begin, day_Begin); dt < new DateTime(year_End, month_End, day_End); dt = dt.AddDays(1))
            {
                int M = dt.Month, D = dt.Day;
                if (M == 9 && D == 24)
                {
                    continue;
                }
                if (M == 10 && D >= 1 && D <= 7)//节假日
                {
                    continue;
                }
                if (M == 4 && D >= 29 && D <= 30)//节假日
                {
                    continue;
                }
                if (M == 5 && D == 1)//节假日
                {
                    continue;
                }

                int ddd = Convert.ToInt32((DateDiff(stime, dt)));
                int xqj = (int)dt.DayOfWeek; int dijizhou = (ddd - ddd % 7) / 7 + weeked; int dsz = dijizhou % 2;
                if (M == 4 && D == 8)//节假日补课
                {
                    xqj = 5;
                }
                if (M == 4 && D == 28)//节假日补课
                {
                    xqj = 1;
                }
                if (M == 9 && D == 29)
                {
                    xqj = 4;
                }
                if (M == 9 && D == 30)
                {
                    xqj = 5;
                }
                if (M == 12 && D == 29)
                {
                    xqj = 1;
                }

                string jc1 = "", jc2 = "";
                //DateTime today = DateTime.Now;

                DateTime bt = dt;
                DateTime et = dt;
                //string s = DateTime.Now.ToShortTimeString();


                for (int hour = 1; hour <= 5; hour++)
                {
                    System.Data.DataTable sdnudate = new System.Data.DataTable();
                    System.Data.DataTable sdnudate2 = new System.Data.DataTable();
                    System.Data.DataTable sdnudate3 = new System.Data.DataTable();
                    System.Data.DataTable sdnudate4 = new System.Data.DataTable();
                    System.Data.DataTable sdnucount = new System.Data.DataTable();
                    string outROOM = "0", yuancheng = "0";
                    if (hour == 1)
                    {
                        jc1 = "1-2"; jc2 = "1"; bt = dt.AddHours(7); et = dt.AddHours(9);
                    }
                    else if (hour == 2)
                    {
                        jc1 = "3-4"; jc2 = "3"; bt = dt.AddHours(9); et = dt.AddHours(12);
                    }
                    else if (hour == 3)
                    {
                        jc1 = "5-6"; jc2 = "5"; bt = dt.AddHours(13); et = dt.AddHours(15);
                    }
                    else if (hour == 4)
                    {
                        jc1 = "7-8"; jc2 = "7"; bt = dt.AddHours(15); et = dt.AddHours(18);
                    }
                    else if (hour == 5)
                    {
                        jc1 = "9-10"; jc2 = "11"; bt = dt.AddHours(18); et = dt.AddHours(21);
                    }

                    else if (hour == 6)
                    {

                    }

                    string weeksql = @"select a.* ,b.UserName,b.StaffRoom  from [duomeiti].[dbo].[2018-2] as a,[SQL_LINK].[dscontrol].[dbo].[cardinfo] as b
                             where RoomID is not null and a.RKJSGH =b.EmployeeID AND  xqj='" + xqj + "' and (JC='" + jc1 + "' ) and SKBJH='sixy' and CAST(LEFT(ZC,charindex('-',ZC,charindex('-',ZC))-1)AS integer)<='" + dijizhou + "' AND CAST(RIGHT(ZC,len(ZC)-charindex('-',ZC,charindex('-',ZC)-1))AS integer)>='" + dijizhou + "'   ";
                    //每个教职工第几周第几节
                    string dszstr = "";
                    if (dsz == 1) { weeksql = weeksql + " and (DSZ='单' OR DSZ IS NULL )"; dszstr = " and (DSZ='单' OR DSZ IS NULL )"; }
                    else if (dsz == 0) { weeksql = weeksql + " and (DSZ='双' OR DSZ IS NULL)"; dszstr = " and (DSZ='双' OR DSZ IS NULL)"; }
                    // string RoomIDsql = "select RoomID " + weeksql; 

                    string sdnucountsql = weeksql;
                    string cardsql = "SELECT b.EmployeeID,a.RoomID,a.CardNo  FROM [SQL_LINK].[dscontrol].[dbo].[HistoryInfo] as a,[duomeiti].[dbo].[cardinfo] as b  where a.CardNo=b.CardNo and   BeginTime>'" + bt + "' and BeginTime<'" + et + "' and beginOrEnd='1' group by a.RoomID,a.CardNo,b.EmployeeID ";
                    string yuanchengkaiqisql = "SELECT RoomID,CardNo  FROM [SQL_LINK].[dscontrol].[dbo].[HistoryInfo] where CardNo = '000000' and   BeginTime>'" + bt + "' and BeginTime<'" + et + "' and beginOrEnd='1' group by RoomID,CardNo ";
                    string allsql = "SELECT RoomID,CardNo  FROM [SQL_LINK].[dscontrol].[dbo].[HistoryInfo] where    BeginTime>'" + bt + "' and BeginTime<'" + et + "' and beginOrEnd='1' group by RoomID,CardNo ";

                    SqlDataAdapter daweek = new SqlDataAdapter(weeksql, conn);
                    daweek.Fill(sdnudate);//课表数据

                    SqlDataAdapter daweek2 = new SqlDataAdapter(cardsql, conn);
                    daweek2.Fill(sdnudate2);//教师插卡数据

                    SqlDataAdapter daweek3 = new SqlDataAdapter(yuanchengkaiqisql, conn);
                    daweek3.Fill(sdnudate3);//远程开启数据
                    SqlDataAdapter daweek4 = new SqlDataAdapter(allsql, conn);
                    daweek3.Fill(sdnudate4);//所有开启过设备的教室总数据

                    int sdcount1 = sdnudate.Rows.Count, sdcount2 = sdnudate2.Rows.Count, sdcount3 = sdnudate3.Rows.Count, sdcount4 = sdcount2 + sdcount3;
                    int da1 = 0, da2 = 0, da3 = 0, da4 = 0, da5 = 0, sdcount6 = sdcount1 - sdcount4; if (sdcount6 < 0) { sdcount6 = 0; }
                    //da1 正常上课,d2非规定教室上课 d3非本人教室上课 d4"远程开启" d5"异常"统计 sdcount6 真实异常数
                    sdnudate.Columns.Add("bz", typeof(string));
                    for (int i = 0; i < sdnudate.Rows.Count; i++)
                    {
                        DataRow[] Row = sdnudate2.Select("EmployeeID='" + sdnudate.Rows[i]["RKJSGH"].ToString() + "'");
                        DataRow[] Row2 = sdnudate2.Select("RoomID='" + sdnudate.Rows[i]["RoomID"].ToString() + "'");
                        DataRow[] Row3 = sdnudate3.Select("RoomID='" + sdnudate.Rows[i]["RoomID"].ToString() + "'");
                        DataRow[] Row4 = sdnudate4.Select("RoomID='" + sdnudate.Rows[i]["RoomID"].ToString() + "'");
                        outROOM = "0"; sdnudate.Rows[i][13] = 0;
                        if (Row.Length > 0 || Row2.Length > 0 || Row3.Length > 0 || Row4.Length > 0)
                        {

                            sdnudate.Rows[i][22] = "正常上课";//老师带卡了，并插卡上课
                            if (Row.Length > 0 && Row2.Length > 0)//老师带卡了，并规定教室插卡上课
                            {
                                sdnudate.Rows[i][22] = "正常上课";//老师带卡了，并插卡上课
                                sdnudate.Rows[i][13] = 1;
                                da1++;
                            }
                            else if (Row.Length > 0)//老师带卡了，并规定教室插卡上课
                            {
                                sdnudate.Rows[i][22] = "非规定教室上课";//老师带卡了，并插卡上课
                                outROOM = sdnudate.Rows[i][19].ToString();//ROOMID
                                da2++;
                            }
                            else if (Row2.Length > 0)//老师带卡了，并规定教室插卡上课
                            {
                                sdnudate.Rows[i][22] = "非本人教室上课";//老师带卡了，并插卡上课
                                outROOM = sdnudate.Rows[i][5].ToString();//RKJSGH
                                da3++;
                            }
                            else if (Row3.Length > 0)//老师带卡了，并规定教室插卡上课
                            {
                                sdnudate.Rows[i][22] = "远程开启";//老师带卡了，并插卡上课
                                yuancheng = "1";
                                da4++;
                            }


                        }


                        else
                        {
                            DataRow[] Row6 = sdnudate4.Select("RoomID<(" + sdnudate.Rows[i]["RoomID"] + "+15) and RoomID>(" + sdnudate.Rows[i]["RoomID"] + "-15) ");
                            if (Row6.Length > 0)
                            {
                                sdnudate.Rows[i][22] = "正常上课"; 
                                sdnudate.Rows[i][13] = 1;
                                da1++;
                            }
                            else
                            {
                                sdnudate.Rows[i][22] = "异常";
                                da5++; 
                            }
                        }



                    }

                    string ddtt = dt.ToShortDateString().ToString().Replace("/", "-");
                    if (sdnudate.Rows.Count>0)
                    {
                    string insql = "INSERT INTO [duomeiti].[dbo].[YC_COUNT] ([XN] ,[XQ] ,[DJZ] ,[XQJ] ,[JC] ,[CLASS_COUNT] ,[ROOM_COUNT] ,[YUANCHENG_COUNT] ,[ALLUSE_COUNT] ,[CLASS_ZC] ,[CLASS_FGD] ,[CLASS_FBR] ,[CLASS_YUANCHENG] ,[CLASS_YC] ,[YC_COUNT]) VALUES ('2018','2','" + dijizhou + "','" + sdnudate.Rows[0][7] + "','" + sdnudate.Rows[0][9] + "','" + sdcount1 + "','" + sdcount2 + "','" + sdcount3 + "','" + sdcount4 + "','" + da1 + "'," + da2 + ",'" + da3 + "','" + da4 + "','" + da5 + "','" + sdcount6 + "')";
                    msc2.CommandText = insql;
                    msc2.ExecuteNonQuery();
                    }
                    //for (int i = sdnudate.Rows.Count - 1; i >= 0; i--)
                    //{
                    //    try
                    //    {

                    //        //string insql = "INSERT INTO [duomeiti].[dbo].[YC] ([XN],[XQ],[CLASS_ID],[RoomID],[RKJSGH],[ZC],[XQJ],[DSZ],[JC],[SKRQ],[inKB],[outROOM],[yuancheng],[DJZ],[bz]) VALUES ('2019','1','" + sdnudate.Rows[i][15] + "','" + sdnudate.Rows[i][19] + "','" + sdnudate.Rows[i][5] + "','" + sdnudate.Rows[i][6] + "','" + sdnudate.Rows[i][7] + "','" + sdnudate.Rows[i][8] + "','" + sdnudate.Rows[i][9] + "','" + ddtt + "'," + sdnudate.Rows[i][13] + ",'" + outROOM + "','" + yuancheng + "','" + dijizhou + "','" + sdnudate.Rows[i][22] + "')";
                    //        //msc2.CommandText = insql;
                    //        //msc2.ExecuteNonQuery();
                            
                    //    }
                    //    catch
                    //    {
                    //        string insql1 = "";
                    //        continue;
                    //    };
                    //}
                    sdnudate.Dispose();
                    sdnudate2.Dispose();
                    sdnudate3.Dispose();
                    sdnudate4.Dispose();
                }
            }

            conn.Close();
            conn2.Close();
            msc1.Dispose();
            msc2.Dispose();
            msc3.Dispose();
            msc4.Dispose();
            conn.Dispose();
            conn2.Dispose();


        }
        public DataTable ycshishi()
        {
            DateTime stime = Convert.ToDateTime("2019-02-25 00:00:00.000");
            DateTime Now = DateTime.Now;
            DateTime Today = DateTime.Today;
            //kbdata1_1 = duomeitiSQL.skjsgh(1, 1);
            //kbdata1_2 = duomeitiSQL.skjsgh(1, 2);
            //kbdata1_3 = duomeitiSQL.skjsgh(1, 3);
            //kbdata2_1 = duomeitiSQL.skjsgh(2, 1);
            //kbdata2_2 = duomeitiSQL.skjsgh(2, 2);
            //kbdata2_3 = duomeitiSQL.skjsgh(2, 3);
            //kbdata3_1 = duomeitiSQL.skjsgh(3, 1);
            //kbdata3_2 = duomeitiSQL.skjsgh(3, 2);
            //kbdata3_3 = duomeitiSQL.skjsgh(3, 3);
            //kbdata4_1 = duomeitiSQL.skjsgh(4, 1);
            //kbdata4_2 = duomeitiSQL.skjsgh(4, 2);
            //kbdata4_3 = duomeitiSQL.skjsgh(4, 3);
            //kbdata5_1 = duomeitiSQL.skjsgh(5, 1);
            //kbdata5_2 = duomeitiSQL.skjsgh(5, 2);
            //kbdata5_3 = duomeitiSQL.skjsgh(5, 3);
            //DateTime stime = Convert.ToDateTime("2018-01-15 00:00:00.000"), etime = Convert.ToDateTime("2018-02-03 00:00:00.000");
            int weeked = 2;
            int year_Begin = Convert.ToInt32(Now.Year);
            int month_Begin = Convert.ToInt32(Now.Month);
            int day_Begin = Convert.ToInt32(Now.Day);
            //int year_End = Convert.ToInt32(etime.Year);
            //int month_End = Convert.ToInt32(etime.Month);
            //int day_End = Convert.ToInt32(etime.Day);



            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            SqlConnection conn2 = new SqlConnection(dsconString);
            conn2.Open();

            SqlCommand msc1 = new SqlCommand();
            msc1.Connection = conn;
            SqlCommand msc2 = new SqlCommand();
            msc2.Connection = conn;
            SqlCommand msc3 = new SqlCommand();
            msc3.Connection = conn;
            SqlCommand msc4 = new SqlCommand();
            msc4.Connection = conn;




            //int M = dt.Month, D = dt.Day;
            //if (M == 9 && D == 24)
            //{
            //    continue;
            //}
            //if (M == 10 && D >= 1 && D <= 7)//节假日
            //{
            //    continue;
            //}
            //if (M == 4 && D >= 29 && D <= 30)//节假日
            //{
            //    continue;
            //}
            //if (M == 5 && D == 1)//节假日
            //{
            //    continue;
            //}

            int ddd = Convert.ToInt32((DateDiff(stime,Now )));
            int xqj = (int)Now.DayOfWeek;
            int dijizhou = (ddd - ddd % 7) / 7 + weeked;
            int dsz = dijizhou % 2;
            //if (month_Begin == 4 && day_Begin == 8)//节假日补课
            //{
            //    xqj = 5;
            //}
            //if (M == 4 && D == 28)//节假日补课
            //{
            //    xqj = 1;
            //}
            //if (M == 9 && D == 29)
            //{
            //    xqj = 4;
            //}
            //if (M == 9 && D == 30)
            //{
            //    xqj = 5;
            //}
            //if (M == 12 && D == 29)
            //{
            //    xqj = 1;
            //}

            string jc1 = "", jc2 = "";
            //DateTime today = DateTime.Now;

            DateTime bt = Today;
            DateTime et = Today;
            //string s = DateTime.Now.ToShortTimeString();






            System.Data.DataTable sdnudate = new System.Data.DataTable();
            System.Data.DataTable sdnudate2 = new System.Data.DataTable();
            System.Data.DataTable sdnudate3 = new System.Data.DataTable();
            System.Data.DataTable sdnudate4 = new System.Data.DataTable();
            System.Data.DataTable sdnucount = new System.Data.DataTable();
            string outROOM = "0", yuancheng = "0";
            if (Now.Hour >= 6 && Now.Hour < 10)
            {
                jc1 = "1-2"; jc2 = "1"; bt = DateTime.Today.AddHours(7); et = DateTime.Today.AddHours(9);
            }
            else if (Now.Hour >= 10 && Now.Hour < 13)
            {
                jc1 = "3-4"; jc2 = "3"; bt = DateTime.Today.AddHours(9); et = DateTime.Today.AddHours(12);
            }
            else if (Now.Hour >= 13 && Now.Hour < 16)
            {
                jc1 = "5-6"; jc2 = "5"; bt = DateTime.Today.AddHours(13); et = DateTime.Today.AddHours(15);
            }
            else if (Now.Hour >= 16 && Now.Hour < 18)
            {
                jc1 = "7-8"; jc2 = "7"; bt = DateTime.Today.AddHours(15); et = DateTime.Today.AddHours(18);
            }
            else if (Now.Hour >= 18 && Now.Hour < 22)
            {
                jc1 = "9-10"; jc2 = "11"; bt = DateTime.Today.AddHours(18); et = DateTime.Today.AddHours(21);
            }



            string weeksql = @"select a.* ,b.XM,b.MC,c.[BuildingName]  from [duomeiti].[dbo].[2019-1] as a,[duomeiti].[dbo].[DMT_YKT] as b,[duomeiti].[dbo].[buildinginfo] as c
                             where a.BuildingID=c.BuildingID    and a.RKJSGH =b.RYBH AND  xqj='" + xqj + "' and (JC='" + jc1 + "' ) and SKBJH='sixy' and CAST(LEFT(ZC,charindex('-',ZC,charindex('-',ZC))-1)AS integer)<='" + dijizhou + "' AND CAST(RIGHT(ZC,len(ZC)-charindex('-',ZC,charindex('-',ZC)-1))AS integer)>='" + dijizhou + "'   ";
            //每个教职工第几周第几节
            string dszstr = "";
            if (dsz == 1) { weeksql = weeksql + " and (DSZ='单' OR DSZ IS NULL )"; dszstr = " and (DSZ='单' OR DSZ IS NULL )"; }
            else if (dsz == 0) { weeksql = weeksql + " and (DSZ='双' OR DSZ IS NULL)"; dszstr = " and (DSZ='双' OR DSZ IS NULL)"; }
            // string RoomIDsql = "select RoomID " + weeksql; 

            string sdnucountsql = weeksql;
            string cardsql = "SELECT b.EmployeeID,a.RoomID,a.CardNo  FROM [SQL_LINK].[dscontrol].[dbo].[HistoryInfo] as a,[duomeiti].[dbo].[cardinfo] as b  where a.CardNo=b.CardNo and   BeginTime>'" + bt + "' and BeginTime<'" + et + "' and beginOrEnd='1' group by a.RoomID,a.CardNo,b.EmployeeID ";
            string yuanchengkaiqisql = "SELECT RoomID,CardNo  FROM [SQL_LINK].[dscontrol].[dbo].[HistoryInfo] where CardNo = '000000' and   BeginTime>'" + bt + "' and BeginTime<'" + et + "' and beginOrEnd='1' group by RoomID,CardNo ";
            string allsql = "SELECT RoomID,CardNo  FROM [SQL_LINK].[dscontrol].[dbo].[HistoryInfo] where    BeginTime>'" + bt + "' and BeginTime<'" + et + "' and beginOrEnd='1' group by RoomID,CardNo ";

            SqlDataAdapter daweek = new SqlDataAdapter(weeksql, conn);
            daweek.Fill(sdnudate);//课表数据

            SqlDataAdapter daweek2 = new SqlDataAdapter(cardsql, conn);
            daweek2.Fill(sdnudate2);//教师插卡数据

            SqlDataAdapter daweek3 = new SqlDataAdapter(yuanchengkaiqisql, conn);
            daweek3.Fill(sdnudate3);//远程开启数据
            SqlDataAdapter daweek4 = new SqlDataAdapter(allsql, conn);
            daweek3.Fill(sdnudate4);//所有开启过设备的教室总数据

            int sdcount1 = sdnudate.Rows.Count, sdcount2 = sdnudate2.Rows.Count, sdcount3 = sdnudate3.Rows.Count, sdcount4 = sdcount2 + sdcount3;
            int da1 = 0, da2 = 0, da3 = 0, da4 = 0, da5 = 0, sdcount6 = sdcount1 - sdcount4; if (sdcount6 < 0) { sdcount6 = 0; }
            //da1 正常上课,d2非规定教室上课 d3非本人教室上课 d4"远程开启" d5"异常"统计 sdcount6 真实异常数
            sdnudate.Columns.Add("bz", typeof(string));
            for (int i = 0; i < sdnudate.Rows.Count; i++)
            {
                DataRow[] Row = sdnudate2.Select("EmployeeID='" + sdnudate.Rows[i]["RKJSGH"].ToString() + "'");//老师自己打开设备的数据
                DataRow[] Row2 = sdnudate2.Select("RoomID='" + sdnudate.Rows[i]["RoomID"].ToString() + "'");//所有开启的设备中有这个教室的数据
                DataRow[] Row3 = sdnudate3.Select("RoomID='" + sdnudate.Rows[i]["RoomID"].ToString() + "'");//所有远程开启的设备中有这个教室的数据
                DataRow[] Row4 = sdnudate4.Select("RoomID='" + sdnudate.Rows[i]["RoomID"].ToString() + "'");//所有开启的设备中有这个教室的数据
                outROOM = "0"; sdnudate.Rows[i][13] = 0;
                if (Row.Length > 0 || Row2.Length > 0 || Row3.Length > 0 || Row4.Length > 0)
                {

                    sdnudate.Rows[i][23] = "正常上课";//老师带卡了，并插卡上课
                    if (Row.Length > 0 && Row2.Length > 0)//老师带卡了，并规定教室插卡上课
                    {
                        sdnudate.Rows[i][23] = "正常上课";//老师带卡了，并插卡上课
                        sdnudate.Rows[i][13] = 1;
                        da1++;
                    }
                    else if (Row.Length > 0)//老师带卡了，并规定教室插卡上课
                    {
                        sdnudate.Rows[i][23] = "非规定教室上课";//老师带卡了，并插卡上课
                        outROOM = sdnudate.Rows[i][19].ToString();//ROOMID
                        da2++;
                    }
                    else if (Row2.Length > 0)//老师带卡了，并规定教室插卡上课
                    {
                        sdnudate.Rows[i][23] = "非本人教室上课";//老师带卡了，并插卡上课
                        outROOM = sdnudate.Rows[i][5].ToString();//RKJSGH
                        da3++;
                    }
                    else if (Row3.Length > 0)//老师带卡了，并规定教室插卡上课
                    {
                        sdnudate.Rows[i][23] = "远程开启";//老师带卡了，并插卡上课
                        yuancheng = "1";
                        da4++;
                    }


                }


                else
                {
                    DataRow[] Row6 = sdnudate4.Select("RoomID<(" + sdnudate.Rows[i]["RoomID"] + "+15) and RoomID>(" + sdnudate.Rows[i]["RoomID"] + "-15) ");
                    if (Row6.Length > 0)
                    {
                        sdnudate.Rows[i][23] = "正常上课";
                        sdnudate.Rows[i][13] = 1;
                        da1++;
                    }
                    else
                    {
                        sdnudate.Rows[i][23] = "异常";
                        da5++;
                    }
                }

            }
           
            
            conn.Close();
            conn2.Close();
            
            msc1.Dispose();
            msc2.Dispose();
            msc3.Dispose();
            msc4.Dispose();
            conn.Dispose();
            conn2.Dispose();
            return sdnudate;
        }
        public void xygx() 
        {
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            SqlConnection conn2 = new SqlConnection(dsconString);
            conn2.Open();

            SqlCommand msc1 = new SqlCommand();
            msc1.Connection = conn;
            SqlCommand msc2 = new SqlCommand();
            msc2.Connection = conn;
            string DMTSQL = "", jc1="";

            for(int i=18;i==18;i++)
            {
                for(int m=1;m<=5;m++)
                {
                for (int j = 0; j < 5; j++)
                {
                    if (j == 0)
                    {
                        jc1 = "1-2";
                    }
                    else if (j == 1)
                    {
                        jc1 = "3-4"; 
                    }
                    else if (j == 2)
                    {
                        jc1 = "5-6"; 
                    }
                    else if (j == 3)
                    {
                        jc1 = "7-8";
                    }
                    else if (j == 4)
                    {
                        jc1 = "9-10"; 
                    }
                    
                    string[] xy = new String[] { "教育学部", "马克思主义学院", "经济学院", "法学院", "体育学院", "文学院", "国际教育学院", "外国语学院", "音乐学院", "美术学院", "新闻与传媒学院", "历史文化学院", "数学与统计学院", "物理与电子科学学院", "化学化工与材料科学学院", "生命科学学院", "地理与环境学院", "心理学院", "信息科学与工程学院", "商学院", "公共管理学院"};

//                    DMTSQL = @"SELECT b.[StaffRoom],a.*  FROM [duomeiti].[dbo].[YC] as a,[duomeiti].[dbo].[cardinfo] as b where XN='2018' and a.[RKJSGH]=b.[EmployeeID] 
//and DJZ='" +i+"' AND XQJ='"+m+"' AND JC='" + jc1 + "' AND BZ='异常'";
//                    SqlDataAdapter da = new SqlDataAdapter(DMTSQL, conn);
//                    System.Data.DataTable table = new System.Data.DataTable();
//                    da.Fill(table);

                    for (int s = 1; s < 22; s++) 
                    {
                        DMTSQL = @"SELECT b.[StaffRoom],a.*  FROM [duomeiti].[dbo].[YC] as a,[duomeiti].[dbo].[cardinfo] as b where XN='2018' and a.[RKJSGH]=b.[EmployeeID] 
and DJZ='" + i + "' AND XQJ='" + m + "' AND JC='" + jc1 + "' AND BZ='异常' and b.[StaffRoom]='" + xy[s-1] + "'";
                        SqlDataAdapter da = new SqlDataAdapter(DMTSQL, conn);
                        System.Data.DataTable table = new System.Data.DataTable();
                        da.Fill(table);
                       
                        try{
                            string insql = "UPDATE [duomeiti].[dbo].[YC_COUNT]  SET  [x" + s + "] = " + table.Rows.Count + " where DJZ='" + i + "' AND XQJ='" + m + "' AND JC='" + jc1 + "'";
                                     msc2.CommandText = insql;
                                     msc2.ExecuteNonQuery();
                        }
                        catch
                        {
                            string insql1 = "";
                            continue;
                        };
                    }

 
                    }
                }

            }

            conn.Close();
            conn2.Close();
            msc1.Dispose();
            msc2.Dispose();
            
            conn.Dispose();
            conn2.Dispose();
        }

        public void xytj()
        {
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            SqlConnection conn2 = new SqlConnection(dsconString);
            conn2.Open();

            SqlCommand msc1 = new SqlCommand();
            msc1.Connection = conn;
            SqlCommand msc2 = new SqlCommand();
            msc2.Connection = conn;
           

            for (int i = 1; i <= 18; i++)
            {
            
                        string[] xy = new String[] { "教育学部", "马克思主义学院", "经济学院", "法学院", "体育学院", "文学院", "国际教育学院", "外国语学院", "音乐学院", "美术学院", "新闻与传媒学院", "历史文化学院", "数学与统计学院", "物理与电子科学学院", "化学化工与材料科学学院", "生命科学学院", "地理与环境学院", "心理学院", "信息科学与工程学院", "商学院", "公共管理学院" };

                       
                        System.Data.DataTable sdnudate = new DataTable();
                        
                     
                        for (int j = 0; j < 22; j++)
                        {  try
                           {
                               int mm = j + 1;
                            string usql = @"INSERT INTO [duomeiti].[dbo].[YC_XY_COUNT] ([xy],[djz],[z1y]  ,[z2y]   ,[z3y]        ,[z4y]          ,[z5y] ,[z1z]  ,[z2z]   ,[z3z]        ,[z4z]          ,[z5z]  )
  VALUES ('" + xy[j] + "','" + i + "',(select sum(x"+mm+") from [duomeiti].[dbo].[YC_COUNT] where  xqj='1' and djz='" + i + "'),(select sum(x"+mm+") from [duomeiti].[dbo].[YC_COUNT] where  xqj='2' and djz='" + i + "'),(select sum(x"+mm+") from [duomeiti].[dbo].[YC_COUNT] where  xqj='3' and djz='" + i + "'),(select sum(x"+mm+") from [duomeiti].[dbo].[YC_COUNT] where  xqj='4' and djz='" + i + "'),(select sum(x"+mm+") from [duomeiti].[dbo].[YC_COUNT] where  xqj='5' and djz='" + i + "'),";
                            usql = usql + @" (select count(RKJSGH) from [duomeiti].[dbo].[2018-2]as a,[duomeiti].[dbo].[DMT_YKT] as b where  [SKBJH]='sixy' and xqj='1' and  a.rkjsgh=b.RYBH and [MC]='" + xy[j] + "' ),(select count(RKJSGH)   from [duomeiti].[dbo].[2018-2]as a,[duomeiti].[dbo].[DMT_YKT] as b where  [SKBJH]='sixy' and xqj='2' and  a.rkjsgh=b.RYBH and [MC]='" + xy[j] + "' ), (select count(RKJSGH) from [duomeiti].[dbo].[2018-2]as a,[duomeiti].[dbo].[DMT_YKT] as b where  [SKBJH]='sixy' and xqj='3' and  a.rkjsgh=b.RYBH and [MC]='" + xy[j] + "' ), (select count(RKJSGH) from [duomeiti].[dbo].[2018-2]as a,[duomeiti].[dbo].[DMT_YKT] as b where  [SKBJH]='sixy' and xqj='4' and  a.rkjsgh=b.RYBH and [MC]='" + xy[j] + "' ), (select count(RKJSGH) from [duomeiti].[dbo].[2018-2]as a,[duomeiti].[dbo].[DMT_YKT] as b where  [SKBJH]='sixy' and xqj='5' and  a.rkjsgh=b.RYBH and [MC]='" + xy[j] + "' ))";
                            msc2.CommandText = usql;
                            msc2.ExecuteNonQuery();

                             }
                            catch
                            {
                                string insql1 = "";
                                continue;
                            };
                        }
//                        
                //    }
                }



            conn.Close();
            conn2.Close();
            msc1.Dispose();
            msc2.Dispose();
            
            conn.Dispose();
            conn2.Dispose();




            }


        }
    }
