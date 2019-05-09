<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ResidenceWebsite.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" type="text/css" href="Nav.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="headingLogo">
            <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl="~/Ratau.jpeg" Width="750px" />
        </div>
        <div class="headingLogin">
            <br />
            <br />
            <asp:Label class="navLoginLabel" ID="Label2" runat="server" Text="Username:"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label class="navLoginLabel" ID="Label3" runat="server" Text="Password:"></asp:Label>
            &nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            &nbsp;
            <asp:Button Class="navLoginButton" ID="Button5" runat="server" Text="Login" />
        </div>
        <div class="nav">
            <div class="navSpace"></div>
            <asp:Button class="navButtonSelected" ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
            <asp:Button class="navButton" ID="Button2" runat="server" Text="Residents" OnClick="Button2_Click" />
            <asp:Button class="navButton" ID="Button3" runat="server" Text="Events" OnClick="Button3_Click" />
            <asp:Button class="navButton" ID="Button4" runat="server" Text="Contact Us" OnClick="Button4_Click" />
            <div class="navUsername">
                <br />
                <asp:Label class="navUsernameLabel" ID="Label1" runat="server" Text="You are not logged in!"></asp:Label>
            </div>
        </div>

        <div class="contents">

        </div>
    </form>
</body>
</html>
