<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/LoggedIn.Master" AutoEventWireup="true" CodeBehind="SectionsCreation.aspx.cs" Inherits="Leren1.Pages.SectionsCreation"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Alatsi&family=Outfit:wght@200&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex-column d-flex flex-grow">
        <div class="BimageT">
            <div class="d-flex flex-column">
                <asp:Panel ID="DynamicContentHandler" runat="server">
                    <!-- Placeholder for dynamically added content -->
                </asp:Panel>
                <div class="col-sm-6 d-flex flex-column align-items-center mx-auto my-5">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" CssClass="btn w-100 bg-info alatsi-regular" OnClick="ButtonSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
