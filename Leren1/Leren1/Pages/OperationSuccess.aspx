<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/LoggedIn.Master" AutoEventWireup="true" CodeBehind="OperationSuccess.aspx.cs" Inherits="Leren1.Pages.OperationSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- redirect due to how it works maybe can only be inline? Dunno not working in standalone script!
            Placement effects how it works so it should be placed on <body>, BUT <BODY> is ON MASTER --> 
    <script>
        function redirectDelay() {
            setTimeout(function () {
                window.location.href = 'HomepageStudent.aspx';
            }, 5000);
        }

        window.onload = redirectDelay()
    </script>

    <link href="https://fonts.googleapis.com/css2?family=Alatsi&family=Outfit:wght@200&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex flex-column justify-content-center align-items-center">
        <h1 class="alatsi-regular my-3" onload="redirectDelay()">Operation Success</h1>
        <div class="col-sm-8">
            <img class="p-0 img-fluid fill-con object-fit-contain rounded" src="../Assets/Picture/Success.gif" />
        </div>
        <h4 class="alatsi-regular my-3 text-align-center">You will be redirected shortly</h4>
    </div>
</asp:Content>
