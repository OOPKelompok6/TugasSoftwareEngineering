<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInPage.aspx.cs" Inherits="Leren1.Pages.SignInPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>
    <link href="../Styles/SignInStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Sign In</h2>
            <img src="../Assets/Picture/Leren_Logo2.png" />

            <div class="form-group">
                <label for="EmailLbl">Email</label>
                <asp:TextBox ID="EmailTxt" runat="server" CssClass="form-control" placeholder="Input Your Email"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="PasswordLbl">Password</label>
                <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password" CssClass="form-control" placeholder="Input Your Password"></asp:TextBox>
            </div>

            <div class="forgotpassword">
                <asp:LinkButton ID="forgotpasswordLb" runat="server">Forgot password?</asp:LinkButton>
            </div>

            <div class="btn-container">
                <asp:Button ID="btnSubmit" runat="server" Text="Sign In" CssClass="btn" OnClick="btnSubmit_Click"  />
            </div>

            <div class="DonthaveAccount">
                <asp:Label ID="DonthaveAccountLbl" runat="server" Text="Don't have an account?"></asp:Label>
                <asp:LinkButton ID="DonthaveAccountLb" CssClass="donthaveAccount" runat="server">Sign Up</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
