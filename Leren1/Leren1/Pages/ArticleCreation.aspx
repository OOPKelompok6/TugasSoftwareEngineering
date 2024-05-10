<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ArticleCreation.aspx.cs" Inherits="Leren1.Pages.ArticleCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Alatsi&family=Outfit:wght@200&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex-column d-flex flex-grow">
        <div id="titleContainer" class="py-4 mx-auto">
            <h1 class="alatsi-regular">Create Article</h1>
        </div>
        <div class="flex-column mx-auto py-2">
            <img class="p-0 img-fluid" src="../Assets/Picture/Revised.gif" />
        </div>
        <div class="d-flex flex-column mx-auto align-items-center py-3 col-sm-6">
            <h2 class="alatsi-regular my-2 mx-auto justify-self-center">Title</h2>
            <asp:TextBox ID="TextTitle" runat="server" CssClass="my-2 form-control border-none alatsi-regular"></asp:TextBox>
        </div>
        <div class="d-flex flex-column mx-auto align-items-center py-3">
            <h2 class="alatsi-regular">Subject</h2>
            <asp:DropDownList ID="DropDownSubjects" CssClass="border-none" runat="server"></asp:DropDownList>
        </div>
        <div class="d-flex flex-column mx-auto align-items-center py-3">
            <h2 class="alatsi-regular">Category</h2>
            <asp:DropDownList ID="DropDownCategory" CssClass="border-none" runat="server"></asp:DropDownList>
        </div>
        <div class="d-flex flex-column mx-auto py-3 col-sm-3 align-items-center">
            <h2 class="alatsi-regular">Number of sections</h2>
            <div class="d-flex">
                <asp:DropDownList ID="DropDownListSections" runat="server" CssClass="alatsi-regular border-none"></asp:DropDownList>
            </div>
        </div>
        <div class="mx-auto my-3 py-3">
            <asp:Button ID="ButtonCreate" runat="server" Text="Create" CssClass="bg-info btn"/>
        </div>
    </div>
</asp:Content>
