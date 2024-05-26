<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/LoggedIn.Master" AutoEventWireup="true" CodeBehind="SearchTemplate.aspx.cs" Inherits="Leren1.Pages.SearchTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Alatsi&family=Outfit:wght@200&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel id="Results" runat="server" class="d-flex justify-content-center"></asp:Panel>
</asp:Content>
