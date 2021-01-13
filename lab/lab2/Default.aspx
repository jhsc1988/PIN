<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txt_box_1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="klikni me !" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="lbl_1" runat="server" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
