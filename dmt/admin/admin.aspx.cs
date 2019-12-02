using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmptyProjectNet40_FineUI.admin
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnChangeEnable_Click(object sender, EventArgs e)
        {

            duomeitiSQL duomeitisql = new duomeitiSQL();

            DateTime stime = Convert.ToDateTime("2018-08-27 00:00:00.000"), etime = Convert.ToDateTime("2018-12-30 00:00:00.000");
            duomeitisql.yc(stime, etime, 1);


            //DateTime stime = Convert.ToDateTime("2019-01-13 00:00:00.000"); DateTime etime = Convert.ToDateTime("2019-01-20 00:00:00.000");
            //duomeitisql.yc(stime, etime, 1);
            //stime = Convert.ToDateTime("2019-02-25 00:00:00.000"); etime = Convert.ToDateTime("2019-03-08 00:00:00.000");
            //duomeitisql.yc(stime, etime, 2);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

          //  duomeitiSQL duomeitisql = new duomeitiSQL();

          //  duomeitisql.xygx();



        }
        protected void Button2_Click(object sender, EventArgs e)
        {
           // duomeitiSQL duomeitisql = new duomeitiSQL();
          //  duomeitisql.xytj();
        }

    }
}