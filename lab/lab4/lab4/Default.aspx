<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <h4 style="background-color:powderblue;">prijava</h4>

            <asp:Label ID="lb_obavijest" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lb_user" runat="server" Text="Korisničko ime:"></asp:Label>
            <br />
            <asp:TextBox ID="tb_korisnik" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lb_password" runat="server" Text="Lozinka"></asp:Label>
            <br />
            <asp:TextBox ID="tb_password" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br /> 
            <asp:Button ID="prijava" runat="server" Text="prijava" OnClick="prijava_Click" />
            <asp:Button ID="registracija" runat="server" Text="registracija" OnClick="registracija_Click"></asp:Button>
            <br />
            
</asp:Content>

