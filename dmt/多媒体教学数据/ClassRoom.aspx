<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassRoom.aspx.cs" Inherits="EmptyProjectNet40_FineUI.多媒体教学数据.ClassRoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title></title>
    <style>
        .photo {
            height: 300px;
            width:400px;
            line-height: 300px;
            overflow: hidden;
        }

            .photo img {
                height: 300px;width:385px;
                vertical-align: middle;
            }
             .x-grid-item.highlight td {
            background-color: lightgreen;
            background-image: none;
        }

        .x-grid-item-selected.highlight td {
            background-color: yellow;
            background-image: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Items>
                <%--<f:Panel runat="server" ID="panelTopRegion" RegionPosition="Top" RegionSplit="true" EnableCollapse="true" Height="100px"
                    Title="顶部面板" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Items>
                        <f:Label ID="Label1" runat="server" Text="顶部面板的内容">
                        </f:Label>
                    </Items>
                </f:Panel>--%>
               
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center"
                    Title="查询结果（点击标题可以按标题升降序排列查询）" ShowBorder="true" ShowHeader="true" BodyPadding="5px" Layout="Fit">
                    <Items>
                        <f:Grid ID="Grid1" Title="表格"  EnableCollapse="true" Width="800px" PageSize="10" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                        DataKeyNames="XM,MC,RYBH" IsDatabasePaging="TRUE" OnPageIndexChange="Grid1_PageIndexChange"
                        AllowSorting="true" SortField="RYBH" SortDirection="ASC"
                        OnSort="Grid1_Sort" ForceFit="true" >
                         <Columns>
                         
                         <f:GroupField BoxFlex="1" MinWidth="1000px" EnableLock="true" HeaderText="2018-2019年第2学期第1周<br>多媒体教室使用数据统计表" TextAlign="Center" ID="tabletitle">
                          <Columns>
                          <f:BoundField width="80px" DataField="SquareName" SortField="SquareName" HeaderText="校区" />
                           <f:BoundField width="80px" DataField="RYBH" SortField="RYBH" HeaderText="工号" />
                           <f:BoundField width="80px" DataField="XM" SortField="XM" HeaderText="姓名" />
                           <f:BoundField Minwidth="180px" BoxFlex="1" DataField="MC" SortField="MC" HeaderText="学院" />
                           <f:BoundField Minwidth="180px" BoxFlex="1" DataField="BeginTime" SortField="BeginTime" HeaderText="开始时间" />
                           <f:BoundField Minwidth="180px" BoxFlex="1" DataField="EndTime" SortField="EndTime" HeaderText="结束时间" /> 
                           <f:BoundField width="80px" DataField="RoomName" SortField="RoomName" HeaderText="教室" /> 
                           <f:BoundField width="120px" DataField="BuildingName" SortField="BuildingName" HeaderText="教学楼" /> 
                          
                           
                        </Columns>
                         </f:GroupField>  
                            </Columns>
                            <Toolbars>
                                <f:Toolbar ID="Toolbar2" runat="server" Position="Bottom">
                                     <Items>
                                    
                                    <f:Button ID="Button1" EnableAjax="false" DisableControlBeforePostBack="false"
                                        runat="server" Text="导出为Excel文件" OnClick="Button1_Click">
                                     </f:Button>
                                    <f:DropDownList runat="server" ID="DropDownList1" Width="130"  LabelWidth="60px"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学年" >
                                    <f:ListItem Text="2018" Value="Value1" />
                                    <f:ListItem Text="2019" Value="Value2" />                   
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" ID="DropDownList2" Width="120"  LabelWidth="60px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学期">
                                        <f:ListItem Text="2" Value="Value1" />
                                        <f:ListItem Text="1" Value="Value2" />                   
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" ID="DropDownList3" Width="250"  LabelWidth="80px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="教学楼" >
                                        
                                        <f:ListItem Text="所有" Value="Value1" />
                                        <f:ListItem Text="综合楼C区" Value="Value2" /> 
                                        <f:ListItem Text="综合楼B区" Value="Value3" />
                                        <f:ListItem Text="实验楼1区（信工）" Value="Value4" /> 
                                        <f:ListItem Text="实验楼2区（心院）" Value="Value5" />
                                        <f:ListItem Text="艺体综合楼1区（经济）" Value="Value6" /> 
                                        <f:ListItem Text="艺体综合楼2区（马克）" Value="Value7" />
                                        <f:ListItem Text="艺体综合楼3区（历史）" Value="Value8" /> 
                                        <f:ListItem Text="艺体综合楼4区（法学）" Value="Value9" />
                                                                                                 
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" ID="DropDownList4" Width="200"  LabelWidth="55px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学院" >
                                         <f:ListItem Text="所有学院" Value="Value0" />
                                         <f:ListItem Text="教育学部" Value="Value1" />
                                        <f:ListItem Text="马克思主义学院" Value="Value2" /> 
                                        <f:ListItem Text="经济学院" Value="Value3" />
                                        <f:ListItem Text="法学院" Value="Value4" /> 
                                        <f:ListItem Text="体育学院" Value="Value5" />
                                        <f:ListItem Text="文学院" Value="Value6" /> 
                                        <f:ListItem Text="国际教育学院" Value="Value7" />
                                        <f:ListItem Text="外国语学院" Value="Value8" /> 
                                        <f:ListItem Text="音乐学院" Value="Value9" />
                                        <f:ListItem Text="美术学院" Value="Value10" /> 
                                        <f:ListItem Text="新闻与传媒学院" Value="Value11" />
                                        <f:ListItem Text="历史文化学院" Value="Value12" /> 
                                        <f:ListItem Text="数学与统计学院" Value="Value13" />
                                        <f:ListItem Text="物理与电子科学学院" Value="Value14" /> 
                                        <f:ListItem Text="化学化工与材料科学学院" Value="Value15" />
                                        <f:ListItem Text="生命科学学院" Value="Value16" /> 
                                        <f:ListItem Text="地理与环境学院" Value="Value17" />
                                        <f:ListItem Text="心理学院" Value="Value18" />  
                                        <f:ListItem Text="信息科学与工程学院" Value="Value19" /> 
                                        <f:ListItem Text="商学院" Value="Value20" />
                                        <f:ListItem Text="公共管理学院" Value="Value21" />                                                         
                                    </f:DropDownList>
                                         <f:TextBox ID="TextBox1" runat="server" Label="姓名" Text="" Width="110px" LabelWidth="50px">
                                         </f:TextBox>
                                         <f:TextBox ID="TextBox2" runat="server" Label="工号" Text="" Width="110px" LabelWidth="50px">
                                         </f:TextBox>
                                         <f:TextBox ID="TextBox3" runat="server" Label="教室" Text="" Width="130px" LabelWidth="50px">
                                         </f:TextBox>
                                         <f:Button ID="cx" runat="server" Text="查询" OnClick="cx_Click">
                                    </f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                        </f:Grid>
                    </Items>
                </f:Panel>
                <%--<f:Panel runat="server" ID="panelRightRegion" RegionPosition="Right" RegionSplit="true" EnableCollapse="true"
                    Width="200px" Title="右侧面板" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Items>
                        <f:Label ID="Label4" runat="server" Text="右侧面板的内容">
                        </f:Label>
                    </Items>
                </f:Panel>--%>
                <f:Panel runat="server" ID="panelBottomRegion" RegionPosition="Bottom" RegionSplit="true" EnableCollapse="true" Height="100px"
                    Title="底部面板" ShowBorder="true" ShowHeader="false" BodyPadding="5px" Hidden="True">
                    <Items>
                         <f:Label runat="server" ID="labResult">
        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
