<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Attendence_System.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <input id="userID" type="text" runat="server" />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Attend" />
    </form>
    <label runat="server" id="testLabel"></label>
</body>
</html>
