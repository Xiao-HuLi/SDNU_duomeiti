<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YC_Histroy_Count.aspx.cs" Inherits="EmptyProjectNet40_FineUI.统计.YC_Histroy_Count" %>

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
                    Title="查询结果（点击标题可以按标题升降序排列查询，标题后面带 ↑ 为升序， ↓ 为降序）" ShowBorder="true" ShowHeader="true" BodyPadding="5px" Layout="Fit">
                    <Items>
                        <f:Grid ID="Grid1" Title="表格"  EnableCollapse="true" Width="800px" PageSize="21" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                        DataKeyNames="XY,DJZ" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                        AllowSorting="true" SortField="zr" SortDirection="DESC"
                        OnSort="Grid1_Sort"  ForceFit="True">
                         <Columns>
                         
                         <f:GroupField EnableLock="true" HeaderText="2018年第1学期第1周多媒体教室异常数据统计表" TextAlign="Center"  ID="tabletitle">
                          <Columns>
                          <f:BoundField width="120px" DataField="XY" SortField="XY" HeaderText="学院" />
                              <f:GroupField EnableLock="true" HeaderText="周一" TextAlign="Center">
                              <Columns>
                              <f:BoundField  DataField="z1z" SortField="z1z" HeaderText="正常" />
                              <f:BoundField  DataField="z1y" SortField="z1y" HeaderText="异常" />
                             </Columns>
                             </f:GroupField>
                              <f:GroupField EnableLock="true" HeaderText="周二" TextAlign="Center">
                              <Columns>
                              <f:BoundField  DataField="z2z" SortField="z2z" HeaderText="正常" />
                              <f:BoundField  DataField="z2y" SortField="z2y" HeaderText="异常" />
                             </Columns>
                             </f:GroupField>
                             <f:GroupField EnableLock="true" HeaderText="周三" TextAlign="Center">
                              <Columns>
                              <f:BoundField DataField="z3z" SortField="z3z" HeaderText="正常" />
                              <f:BoundField  DataField="z3y" SortField="z3y" HeaderText="异常" />
                             </Columns>
                             </f:GroupField>
                             <f:GroupField EnableLock="true" HeaderText="周四" TextAlign="Center">
                              <Columns>
                              <f:BoundField  DataField="z4z" SortField="z4z" HeaderText="正常" />
                              <f:BoundField  DataField="z4y" SortField="z4y" HeaderText="异常" />
                             </Columns>
                             </f:GroupField>
                             <f:GroupField EnableLock="true" HeaderText="周五" TextAlign="Center">
                              <Columns>
                              <f:BoundField  DataField="z5z" SortField="z5z" HeaderText="正常" />
                              <f:BoundField  DataField="z5y" SortField="z5y" HeaderText="异常" />
                             </Columns>
                             </f:GroupField>
                             <f:GroupField EnableLock="true" HeaderText="统计" TextAlign="Center">
                              <Columns>
                              <f:BoundField  DataField="zz" SortField="zz" HeaderText="正常" />
                              <f:BoundField DataField="zr" SortField="zr" HeaderText="异常" />
                             </Columns>
                             </f:GroupField>

                           
                        </Columns>
                         </f:GroupField>  
                            </Columns>
                            <Toolbars>
                                <f:Toolbar ID="Toolbar2" runat="server" Position="Bottom">
                                     <Items>
                                    <f:Button ID="cx" runat="server" Text="查询" OnClick="cx_Click">
                                    </f:Button>
                                    <f:Button ID="Button1" EnableAjax="false" DisableControlBeforePostBack="false"
                                        runat="server" Text="导出为Excel文件" OnClick="Button1_Click">
                                     </f:Button>
                                    <f:DropDownList runat="server" ID="DropDownList1" Width="130"  LabelWidth="40px"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学年" >
                                    <f:ListItem Text="2018" Value="Value1" />
                                    <f:ListItem Text="2019" Value="Value2" />                   
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" ID="DropDownList2" Width="100"  LabelWidth="40px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学期">
                                        <f:ListItem Text="2" Value="Value1" />
                                        <f:ListItem Text="1" Value="Value2" />                   
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" ID="DropDownList3" Width="100"  LabelWidth="40px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学周" >
                                        
                                        <f:ListItem Text="1" Value="Value1" />
                                        <f:ListItem Text="2" Value="Value2" /> 
                                        <f:ListItem Text="3" Value="Value3" />
                                        <f:ListItem Text="4" Value="Value4" /> 
                                        <f:ListItem Text="5" Value="Value5" />
                                        <f:ListItem Text="6" Value="Value6" /> 
                                        <f:ListItem Text="7" Value="Value7" />
                                        <f:ListItem Text="8" Value="Value8" /> 
                                        <f:ListItem Text="9" Value="Value9" />
                                        <f:ListItem Text="10" Value="Value10" /> 
                                        <f:ListItem Text="11" Value="Value11" />
                                        <f:ListItem Text="12" Value="Value12" /> 
                                        <f:ListItem Text="13" Value="Value13" />
                                        <f:ListItem Text="14" Value="Value14" /> 
                                        <f:ListItem Text="15" Value="Value15" />
                                        <f:ListItem Text="16" Value="Value16" /> 
                                        <f:ListItem Text="17" Value="Value17" />
                                        <f:ListItem Text="18" Value="Value18" />  
                                        <f:ListItem Text="所有周" Value="Value19" />                                                         
                                    </f:DropDownList>
                                 <%--   <f:DropDownList runat="server" ID="DropDownList4" Width="250"  LabelWidth="40px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学院" >
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
                                    </f:DropDownList>--%>
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
                <%--<f:Panel runat="server" ID="panelBottomRegion" RegionPosition="Bottom" RegionSplit="true" EnableCollapse="true" Height="30px"
                    Title="底部面板" ShowBorder="true" ShowHeader="false" BodyPadding="5px">
                    <Items>
                         <f:Label runat="server" ID="labResult">
        </f:Label>
                    </Items>
                </f:Panel>--%>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
