<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PicData.aspx.cs" Inherits="EmptyProjectNet40_FineUI.多媒体教学数据.PicData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="RegionPanel1" />
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region1" ShowBorder="false" ShowHeader="false"
                    Width="120px" RegionPosition="Left" Layout="Fit"
                    runat="server">
                    <Items>
                        <f:Grid ID="Grid2" ShowBorder="true" ShowHeader="true" Title="日期" runat="server"
                            DataKeyNames="lujing" EnableMultiSelect="false" ShowGridHeader="false">
                            <Columns>
                                
                                <f:BoundField ExpandUnusedSpace="true" DataField="lujing" DataFormatString="{0}"
                                    HeaderText="lujing" />
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Region>
                <f:Region ID="Region3" ShowBorder="false" ShowHeader="false"
                    Width="120px" RegionPosition="Left" Layout="Fit"
                    runat="server">
                    <Items>
                        <f:Grid ID="Grid1"  ShowBorder="true" ShowHeader="true" Title="教室" ShowGridHeader="false"
                            runat="server" DataKeyNames="room" EnableMultiSelect="false" EnableRowSelectEvent="false" >
                            <Columns>
                                
                                <f:BoundField Width="120px" ExpandUnusedSpace="true" DataField="room" DataFormatString="{0}" HeaderText="room" />
                                
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Region>
                <f:Region ID="Region2" ShowBorder="false" ShowHeader="false" Position="Center"
                    Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Left" runat="server">
                    <Items>
                       
                        <f:Grid ID="Grid3" ShowBorder="true" ShowHeader="true" Title="截图" runat="server" AllowPaging="true"
                             EnableMultiSelect="false"  ShowGridHeader="false">
                            <Columns>
                             <f:BoundField Width="120px" DataField="name"     HeaderText="截图名称"/>
                             <f:BoundField Width="120px" DataField="room"    HeaderText="教室名称"/>   
                             <f:BoundField Width="120px" DataField="time"    HeaderText="截图时间"/>  
                                
                             <%--<f:BoundField Width="120px" DataField="room"  SortField="room"  DataFormatString="{0}" HeaderText="教室名称"/>     --%>
                            </Columns>
                        </f:Grid>
                         <f:Panel ID="Panel1" Height="80px" ShowHeader="false" BodyPadding="10px"
                            ShowBorder="true" runat="server">
                            <Items>
                                <f:Label ID="labelClassDesc" EncodeText="false" runat="server">
                                </f:Label>
                                <f:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click">
                                </f:Button>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <br />
        <br />
    </form>
</body>
</html>