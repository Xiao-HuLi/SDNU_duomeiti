<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="True" CodeBehind="YC_Histroy.aspx.cs" Inherits="EmptyProjectNet20.YC_Histroy" %>

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
                    <f:Image ID="imgPhoto" CssClass="photo" ImageUrl="http://172.27.16.250/pic/11.jpg"  runat="server">
                </f:Image>
                     <%--<f:ContentPanel ID="ContentPanel1" Title="内容面板" ShowBorder="true" width="385px"
                    BodyPadding="10px" EnableCollapse="true" ShowHeader="false"
                    runat="server" MinHeight="100px">
                    可以在此放置Asp.Net控件或者HTML标签。
                </f:ContentPanel>--%>  
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
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center"  Layout="Fit"
                    Title="查询结果（点击标题可以按标题升降序排列查询，标题后面带 ↑ 为升序， ↓ 为降序）" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Items>
                        <f:Grid ID="Grid1" Title="表格"  EnableCollapse="false" PageSize="14" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" EnableCheckBoxSelect="false"
                        DataKeyNames="RoomID,SKRQ,JC,RKJSGH,BZ" IsDatabasePaging="false" OnPageIndexChange="Grid1_PageIndexChange"
                        AllowSorting="true" SortField="MC" SortDirection="ASC"
                        OnSort="Grid1_Sort" EnableRowSelectEvent="true" OnRowSelect="Grid1_RowSelect" ForceFit="True">
                         <Columns>
                         <f:GroupField  HeaderText="" TextAlign="Center" ID="tabletitle" runat="server" MinWidth="1000px" BoxFlex="1">
                          <Columns>
                         
                                   
                                    <f:BoundField Width="80px" SortField="id" DataField="id" HeaderText="id"  Hidden="True" />
                                    <f:BoundField Width="60px" DataField="DJZ" SortField="DJZ" DataFormatString="{0}"
                                        HeaderText="学周" />
                                    <f:BoundField Width="90px" DataField="SKRQ" SortField="SKRQ" DataFormatString="{0}"
                                        HeaderText="日期" />
                                    <f:BoundField Width="80px" SortField="XM" DataField="XM" HeaderText="姓名" />
                                    <f:BoundField Width="80px" SortField="RKJSGH" DataField="RKJSGH" HeaderText="职工号" />
                                    <f:BoundField MinWidth="200px" SortField="MC" DataField="MC" HeaderText="学院/单位"  />
                                    <f:BoundField Width="80px" SortField="RoomName" DataField="RoomName" HeaderText="上课教室" />
                                    <f:BoundField MinWidth="200px" SortField="BuildingName" DataField="BuildingName" HeaderText="上课教学楼" />
                                    <f:BoundField Width="70px" SortField="JC" DataField="JC" HeaderText="节次" />
                                    <f:BoundField Width="70px" SortField="BZ" DataField="BZ" HeaderText="备注" />
                                    <%--<f:BoundField Width="520px" SortField="RoomID" DataField="RoomID" HeaderText="RoomID" Hidden="True"  />--%>
                           
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
                                    <f:DropDownList runat="server" ID="DropDownList3" EnableMultiSelect="true" Width="250"  LabelWidth="100px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学周(多选)" >
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
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" ID="DropDownList4" Width="250"  LabelWidth="40px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Label="学院" >
                                         <f:ListItem Text="所有学院" Value="Value0" />
                                         <f:ListItem Text="教育学部" Value="教育学" />
                                        <f:ListItem Text="马克思主义学院" Value="马" /> 
                                        <f:ListItem Text="经济学院" Value="经" />
                                        <f:ListItem Text="法学院" Value="法" /> 
                                        <f:ListItem Text="体育学院" Value="体" />
                                        <f:ListItem Text="文学院" Value="文" /> 
                                        <f:ListItem Text="国际教育学院" Value="国际" />
                                        <f:ListItem Text="外国语学院" Value="外" /> 
                                        <f:ListItem Text="音乐学院" Value="音乐" />
                                        <f:ListItem Text="美术学院" Value="美术" /> 
                                        <f:ListItem Text="新闻与传媒学院" Value="传媒" />
                                        <f:ListItem Text="历史文化学院" Value="历" /> 
                                        <f:ListItem Text="数学与统计学院" Value="数" />
                                        <f:ListItem Text="物理与电子科学学院" Value="物" /> 
                                        <f:ListItem Text="化学化工与材料科学学院" Value="化" />
                                        <f:ListItem Text="生命科学学院" Value="生" /> 
                                        <f:ListItem Text="地理与环境学院" Value="地" />
                                        <f:ListItem Text="心理学院" Value="心" />  
                                        <f:ListItem Text="信息科学与工程学院" Value="信" /> 
                                        <f:ListItem Text="商学院" Value="商" />
                                        <f:ListItem Text="公共管理学院" Value="公共" />                                                         
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
                <f:Panel runat="server" ID="panelBottomRegion" RegionPosition="Bottom" RegionSplit="true" EnableCollapse="true" Height="30px"
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
