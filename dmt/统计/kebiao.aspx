<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kebiao.aspx.cs" Inherits="EmptyProjectNet40_FineUI.统计.kebiao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel2" />
        <f:Panel ID="Panel2" runat="server" ShowBorder="True"
            Layout="VBox" ShowHeader="True" Title="面板（改变页面大小来观察面板的变化）" BodyPadding="5">
            <Items>
            <%--    <f:Panel ID="Panel32" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                    Title="Panel" Height="50px" TableConfigColumns="1">
                    <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Center" TableConfigColumns="5">
                    <Items>
                    <f:Label runat="server" Label="" Text="周一">
                    </f:Label>
                    <f:Label runat="server" Label="" Text="周二">
                    </f:Label>
                    <f:Label runat="server" Label="" Text="周三">
                    </f:Label>
                    <f:Label runat="server" Label="" Text="周四">
                    </f:Label>
                    <f:Label runat="server" Label="" Text="周五">
                    </f:Label>
                                       
                    </Items>
                    </f:Toolbar>
            </Toolbars>
                </f:Panel>--%>
                <f:Panel ID="Panel1" BoxFlex="1" runat="server"
                    ShowBorder="false" ShowHeader="false" Layout="HBox" BoxConfigChildMargin="0 5 0 0" Margin="0 0 5 0">
                    <Items>
                        <f:Panel ID="Panel3" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label1" runat="server" Text="Label1">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel4" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label2" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel10" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label3" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel11" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label4" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel6" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false" Margin="0">
                            <Items>
                                <f:Label ID="Label5" runat="server" Text="Label3">
                                </f:Label>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
                   <f:Panel ID="Panel12" BoxFlex="1" runat="server"
                    ShowBorder="false" ShowHeader="false" Layout="HBox" BoxConfigChildMargin="0 5 0 0" Margin="0 0 5 0">
                    <Items>
                        <f:Panel ID="Panel13" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label6" runat="server" Text="Label1">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel14" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label7" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel15" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label8" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel16" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label9" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel17" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false" Margin="0">
                            <Items>
                                <f:Label ID="Label10" runat="server" Text="Label3">
                                </f:Label>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
                   <f:Panel ID="Panel18" BoxFlex="1" runat="server"
                    ShowBorder="false" ShowHeader="false" Layout="HBox" BoxConfigChildMargin="0 5 0 0" Margin="0 0 5 0">
                    <Items>
                        <f:Panel ID="Panel19" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label11" runat="server" Text="Label1">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel20" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label12" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel21" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label13" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel22" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label14" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel23" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false" Margin="0">
                            <Items>
                                <f:Label ID="Label15" runat="server" Text="Label3">
                                </f:Label>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
                   <f:Panel ID="Panel24" BoxFlex="1" runat="server"
                    ShowBorder="false" ShowHeader="false" Layout="HBox" BoxConfigChildMargin="0 5 0 0" Margin="0 0 5 0">
                    <Items>
                        <f:Panel ID="Panel25" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label16" runat="server" Text="Label1">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel26" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label17" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel27" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label18" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel28" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label19" runat="server" Text="Label2">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel29" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false" Margin="0">
                            <Items>
                                <f:Label ID="Label20" runat="server" Text="Label3">
                                </f:Label>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel5" BoxFlex="1" runat="server"
                    ShowBorder="false" ShowHeader="false" Layout="HBox" BoxConfigChildMargin="0 5 0 0">
                    <Items>
                        <f:Panel ID="Panel7" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label21" runat="server" Text="Label4">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel8" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label22" runat="server" Text="Label5">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel30" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label23" runat="server" Text="Label5">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel31" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <Items>
                                <f:Label ID="Label24" runat="server" Text="Label5">
                                </f:Label>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel9" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false" Margin="0">
                            <Items>
                                <f:Label ID="Label25" runat="server" Text="Label6">
                                </f:Label>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>

            </Items>
        </f:Panel>

    </form>
</body>
</html>
