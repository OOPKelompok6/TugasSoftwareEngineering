<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ArticleTemplate.aspx.cs" Inherits="Leren1.Pages.ArticleTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Alatsi&family=Outfit:wght@200&display=swap" rel="stylesheet">
    <script src="../JsScript/clientsideScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" data-bs-spy="scroll" data-bs-target="#navbar-example3" data-bs-smooth-scroll="true" class="scrollspy-example-2" tabindex="0">
    <asp:Panel ID="DynamicContentPanel" runat="server">
        <!-- Dynamic Content Here -->
    </asp:Panel>
    <div ID="sideNavBar" class="flex-row d-flex sticky-topCustom col-sm-2 ">
        <nav ID="secDiv" runat="server" class="nav flex-column nav-pills flex-grow w-100 bg-info">
             <!-- Dynamic Content Here -->
        </nav>
        <div id="BtnSections" class="btn bg-primary fs-5 alatsi-regular tracking-widest rotate bSectionsT" onclick="collapsibleSections()" >SECTIONS</div>
    </div>
</asp:Content>

