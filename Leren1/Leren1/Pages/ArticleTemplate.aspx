<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ArticleTemplate.aspx.cs" Inherits="Leren1.Pages.ArticleTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Alatsi&family=Outfit:wght@200&display=swap" rel="stylesheet">
    <script src="../JsScript/clientsideScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="DynamicContentPanel" runat="server">
        <div class="flex-row d-flex sticky-topCustom col-sm-2 me-auto">
            <div id="secDiv" class="navbar flex-column flex-grow w-100 bg-info">
                <div id="list-example" class="list-group justify-self-center">
                  <a class="list-group-item list-group-item-action" href="#list-item-1">Item 1</a>
                </div>
            </div>
            <div id="BtnSections" class="btn bg-primary fs-5 alatsi-regular tracking-widest rotate" style="letter-spacing: 0.6rem; color:white;">SECTIONS</div>
        </div>
    </asp:Panel>
</asp:Content>

