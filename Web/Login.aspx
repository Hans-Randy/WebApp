<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <title>Login</title>
    <style>

        .wrapper1
        {
            height:100vh !important;
            display:flex;
            align-items:center;
            flex-direction:column;
            justify-content:center;
            width:100% !important;
            padding:20px;
            background-color:#f5f5f5 !important;
        }

        .logincontainer
        {
            border-radius:0px;
            background-color:#fff;
            width:90%; 
            max-width:450px;
            position:relative;
            padding:20px;
            border:1px white solid ;
            box-shadow:0 15px 10px -10px #acacac;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper1">

            <div class="logincontainer">

                <h3>
                    <img src="~/Content/login.png" style="width: 50px; height: 50px" /> User Login
                </h3>

                <hr />

                <asp:TextBox runat="server" ID="usernameTextBox" placeholder="Username" CssClass="form-control"/>
                <br />

                <asp:TextBox runat="server" ID="passwordTextBox" placeholder="Password"  TextMode="Password" CssClass="form-control"/>
                <br />

                <asp:Button runat="server" ID="loginButton" CssClass="btn btn-info form-control" Text="Login" OnClick="LoginButton_Click"/>
                <br />
            </div>
        </div>
    </form>
</body>
</html>

