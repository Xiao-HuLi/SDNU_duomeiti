<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rule.aspx.cs" Inherits="EmptyProjectNet40_FineUI.异常数据判定依据.Rule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel2" />
        <f:Panel ID="Panel2" runat="server"   ShowBorder="True" EnableCollapse="true"
            Layout="VBox" BoxConfigChildMargin="0 0 5 0" BodyPadding="5px"
            ShowHeader="false" Title="面板">
            <Items>
                <%--<f:Panel ID="Panel3" Title="面板1" Height="120px" runat="server"
                    BodyPadding="5px" ShowBorder="true" ShowHeader="true" EnableCollapse="true">
                    <Items>
                        <f:Label ID="Label2" runat="server" Text="Height=120px">
                        </f:Label>
                    </Items>
                </f:Panel>--%>
                <f:Panel ID="Panel1" Title="异常数据判定标准" BoxFlex="2" Margin="0"
                runat="server" Height="410px" BodyPadding="5px"  ShowBorder="true" ShowHeader="true" EnableCollapse="true">
                    <Items>
                        <f:TextArea ID="TextArea1"   runat="server" Margin="0" Text="" ShowLabel="False" Readonly="True" Height="400px" width="1300px">
                </f:TextArea> 
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel4" Title="未来待完善" BoxFlex="1" 
                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" EnableCollapse="true">
                    <Items>
                        <f:Label ID="Label3" runat="server" Text="">
                        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
