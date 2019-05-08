<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ResidenceWebsite.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" type="text/css" href="Nav.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
            <div class="navLogo">
                
                <asp:Image ID="Image1" runat="server" Height="150px" Width="494px" ImageUrl="~/RatauLebone.jpeg" />
                
            </div>
                <asp:Button class="navButtonSelected" ID="Button1" runat="server" Text="Home" />
                <asp:Button class="navButton" ID="Button2" runat="server" Text="Residents" />
                <asp:Button class="navButton" ID="Button3" runat="server" Text="Events" />
                <asp:Button class="navButton" ID="Button4" runat="server" Text="Contact Us" />
            <div class="navLogin">
                <asp:Label class="navLoginLabel" ID="Label1" runat="server" Text="Username: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
                <asp:Label class="navLoginLabel" ID="Label2" runat="server" Text="Password: "></asp:Label>
                &nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
                <asp:Button class="navLoginButton" ID="Button5" runat="server" Text="Login" Width="100px" />
            </div>
        </div>
    </form>
</body>
</html>
