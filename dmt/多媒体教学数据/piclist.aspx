<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="piclist.aspx.cs" Inherits="EmptyProjectNet40_FineUI.多媒体教学数据.piclist" %>



<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
      <style>
    .photo img {
                height: 400px;width:585px;
                vertical-align: middle;
            }
              </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="RegionPanel1" />
         <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region1" ShowBorder="false" ShowHeader="false"
                    Width="200px" RegionPosition="Left" Layout="Fit"
                    runat="server">
                    <Items>
                        <f:Tree ID="Tree1" Width="150px" ShowHeader="true" EnableCollapse="true" 
                            Title="日期" runat="server" OnNodeCommand="Tree1_NodeCommand"  EnableSingleClickExpand="false" EnableSingleExpand="true">
                        </f:Tree>
                    </Items>
               </f:Region>
               <f:Region ID="Region3" ShowBorder="false" ShowHeader="false"
                    Width="200px" RegionPosition="Left" Layout="Fit"
                    runat="server">
                    <Items>
                        <f:Tree ID="Tree2" Width="150px" ShowHeader="true" EnableCollapse="true" 
                            Title="教室" runat="server" OnNodeCommand="Tree2_NodeCommand"  EnableSingleClickExpand="false" EnableSingleExpand="true">
                        </f:Tree>
                    </Items>
               </f:Region>
               <f:Region ID="Region2" ShowBorder="false" ShowHeader="false"
                     RegionPosition="Center" Layout="Anchor"
                    runat="server" BoxFlex="1">
                    <Items>
                     <f:Image AnchorValue="100% 60%" ID="imgPhoto" CssClass="photo" ImageUrl="http://172.27.16.250/pic/11.jpg"  runat="server">
                  </f:Image>
                <f:Grid ID="Grid1" AnchorValue="100% 40%" ShowBorder="true" ShowHeader="true" Title="截图" runat="server" AllowPaging="true"
                             EnableMultiSelect="false"  ShowGridHeader="false" MinWidth="600px"  EnableRowClickEvent="true" OnRowClick="Grid1_RowClick" PageSize="80">
                            <Columns>
                             <f:BoundField Width="220px" DataField="name"     HeaderText="截图名称"/>
                             <f:BoundField Width="120px" DataField="room"    HeaderText="教室名称"/>   
                             <f:BoundField  DataField="time"    HeaderText="截图时间" MinWidth="320px" />  
                                
                             <%--<f:BoundField Width="120px" DataField="room"  SortField="room"  DataFormatString="{0}" HeaderText="教室名称"/>     --%>
                            </Columns>
                        </f:Grid>
                        <f:Label ID="labResult"  runat="server" Label="Label" Text="文本">
                        </f:Label>
                        
                    </Items>
               </f:Region>
               </Regions>
        </f:RegionPanel>
    </form>
</body>
</html>