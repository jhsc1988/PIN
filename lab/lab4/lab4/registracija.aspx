<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registracija.aspx.cs" Inherits="registracija" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="rlb_obavijest" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="rlb_k_ime" runat="server" Text="Ime:"></asp:Label>
            <br />
            <asp:TextBox ID="rtb_k_ime" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="rlb_email" runat="server" Text="E-mail:"></asp:Label>
            <br />
            <asp:TextBox ID="rtb_email" runat="server" TextMode="Email"></asp:TextBox>
            <br />

            <asp:Label ID="rlb_password" runat="server" Text="Lozinka"></asp:Label>
            <br />
            <asp:TextBox ID="rtb_password" runat="server" TextMode="Password"></asp:TextBox>
            <br />

            <asp:Label ID="rlb_password_p" runat="server" Text="Ponovi lozinku"></asp:Label>
            <br />
            <asp:TextBox ID="rtb_password_p" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br /> 

            <asp:Button ID="registriraj" runat="server" Text="Registriraj me!" OnClick="registriraj_Click"></asp:Button>
            <br />

        </div>
    </form>
</body>
</html>
