<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="pocetna.aspx.cs" Inherits="pocetna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="pocetna_korisnik" runat="server" Text=""></asp:Label> <br />
    <asp:LinkButton ID="lb_odjava" runat="server" OnClick="lb_odjava_Click">odjava</asp:LinkButton>
    <hr />
    <p>Početna</p>
</asp:Content>

