<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="EmptyProjectNet40_FineUI.admin.admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Button ID="btnChangeEnable" Text="重新更新整个异常数据库" runat="server" OnClick="btnChangeEnable_Click"
        CssClass="marginr" Hidden="True" /> 
        <f:Button ID="Button1" Text="重新更新整个异常数据库" runat="server" OnClick="Button1_Click"
        CssClass="marginr"  Hidden="True" />
        <f:Button ID="Button2" Text="2222" runat="server" OnClick="Button2_Click"
        CssClass="marginr"  Hidden="True" />
    </form>
</body>
</html>
