<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="YC_Now.aspx.cs" Inherits="EmptyProjectNet20.YC_Now" %>

<!DOCTYPE html>
<html>
<head runat="server">
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
                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Left" RegionSplit="true" EnableCollapse="true"
                    Width="400px" Title="监控视频截图" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Items>
                    <f:Image ID="imgPhoto" CssClass="photo" ImageUrl="2019-10-30-16-38-22.jpg"  runat="server">
                </f:Image>
                     <f:HtmlEditor runat="server"  ID="HtmlEditor1" Height="250px" ShowLabel="False" >
                </f:HtmlEditor>
                 <f:TextArea ID="TextArea1"   runat="server" width="385px" Height="100px" Text="" ShowLabel="False" Readonly="True">
                </f:TextArea>  
                    </Items>
                    <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" Position="Bottom" ToolbarAlign="Center">
                    <Items>
                        <f:Button ID="firstpic" runat="server" Text="最早" OnClick="firstpic_Click"></f:Button>
                        <f:Button ID="propic" runat="server" Text="前一张" OnClick="propic_Click"></f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server"></f:ToolbarFill>
                        <f:Button ID="nextpic" runat="server" Text="后一张" OnClick="nextpic_Click"></f:Button>
                        <f:Button ID="endpic" runat="server" Text="最后" OnClick="endpic_Click"></f:Button>
                    </Items>
                </f:Toolbar>
                </Toolbars>
                </f:Panel>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center"
                    Title="查询结果（点击标题可以按标题升降序排列查询）" ShowBorder="true" ShowHeader="true" BodyPadding="5px" Layout="Fit">
                    <Items>
                        <f:Grid ID="Grid1" Title="表格"  EnableCollapse="False" Width="800px" PageSize="14" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" EnableCheckBoxSelect="False"
                        DataKeyNames="RoomID,SKRQ,JC,RKJSGH,BZ" IsDatabasePaging="False" OnPageIndexChange="Grid1_PageIndexChange"
                        AllowSorting="true" SortField="MC" SortDirection="ASC"
                        OnSort="Grid1_Sort" EnableRowSelectEvent="true" OnRowSelect="Grid1_RowSelect"  ForceFit="True">
                         <Columns>
                                    
                                    <f:BoundField Width="80px" SortField="id" DataField="id" HeaderText="id" Hidden="True" />
                                    
                                    <f:BoundField Width="80px" SortField="XM" DataField="XM" HeaderText="姓名" />
                                    <f:BoundField Width="80px" SortField="RKJSGH" DataField="RKJSGH" HeaderText="职工号" />
                                    <f:BoundField MinWidth="160px" SortField="MC" DataField="MC" HeaderText="学院/单位" BoxFlex="1" />
                                    <f:BoundField Width="100px" SortField="RoomName" DataField="RoomName" HeaderText="上课教室" />
                                     <f:BoundField  SortField="BuildingName" DataField="BuildingName" HeaderText="上课教学楼" />
                                    <f:BoundField Width="50px" SortField="JC" DataField="JC" HeaderText="节次" />
                                    <f:BoundField Width="50px" SortField="BZ" DataField="BZ" HeaderText="备注" />
                                    <f:BoundField Width="80px" SortField="RoomID" DataField="RoomID" HeaderText="RoomID" Hidden="True"  />
                            </Columns>
                            <Toolbars>
                                <f:Toolbar ID="Toolbar2" runat="server" Position="Bottom">
                                     <Items>
                                    <f:Button ID="Button5" runat="server" Text="查询"  OnClick="cx_Click">
                                    </f:Button>
                                   <%-- <f:DropDownList runat="server" ID="DropDownList1" Width="130"  LabelWidth="40px"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学年" >
                                    <f:ListItem Text="2018" Value="Value1" />
                                    <f:ListItem Text="2019" Value="Value2" />                   
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" ID="DropDownList2" Width="100"  LabelWidth="40px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学期">
                                        <f:ListItem Text="1" Value="Value1" />
                                        <f:ListItem Text="2" Value="Value2" />                   
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
                                    </f:DropDownList>--%>
                                    <f:DropDownList runat="server" ID="DropDownList4" Width="250"  LabelWidth="40px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学院" AutoSelectFirstItem="true">
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
                    Title="底部面板" ShowBorder="true" ShowHeader="false" BodyPadding="5px">
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
