﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmptyProjectNet40_FineUI.异常数据判定依据
{
    public partial class Rule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextArea1.Text = @"1.从中间库读取课表数据，获得规定时间段内任课教师课表数据：课表db
2.从服务器读取插卡数据，获得规定时间段内任课教师插卡数据：插卡db
3.从服务器读取远程开启数据，获得时间段内任课教师远程开启数据：远程开启db
4.从插卡db中匹配课表db中的教师数据，如果匹配成功且教室为课表规定教室，且插卡db中该教师插卡记录教室数=1,且拔卡时间-插卡时间>10分钟，如果工号一致，则标记该数据为“正常”，工号不一致，标记“非本人上课”，否则执行下一步
5.如果规定教室内拔卡时间-插卡时间<10分钟，且插卡db中该教师插卡记录教室数>1,且每个教室的插卡时间之差<10分钟，则标记该数据为“临时更换教室”，否则执行下一步
6.从插卡db中匹配课表db中的教室数据，如果匹配成功，则标记该数据为“非规定教室上课”，否则执行下一步
7.从远程开启db中匹配课表db中的教室数据，如果匹配成功，则标记该数据为“远程开启”，否则执行下一步
8.查询时间段内课表剩余数据暂时设为“异常”，遍历插卡db，排除已标记的教室，将剩余与课表db不匹配的教室插入至异常教室db
9.对于暂时已标记的课表数据，执行图像分析分析规定教室内每一张视频截图，分析该教室讲台区域是否有教师，如果超过一半截图数据分析结果为“true”，则更正改数据标记为“正常”，否则执行下一步
10.（暂未实现）执行图像分析分析异常教室db内每一张视频截图，尝试匹配教师特征获取是否存在该教师上课，如果有，且异常教室db教学楼与课表教学楼一致，且异常教室db教室ID与课表教室ID之差小于一个适当值（即两个教室距离很近），则更正数据标记为“临时更换教室”，如果大于该值，则更正数据标记为“非规定教室上课”，否则执行下一步
11.将数据插入数据库保存";
        }
    }
}