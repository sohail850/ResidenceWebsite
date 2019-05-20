<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ResidenceWebsite.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" type="text/css" href="Nav.css" />
    <link rel="stylesheet" type="text/css" href="Home.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="headingLogo">
        </div>
        <div class="headingLogin">
            <br />
            <br />
            <asp:Label class="navLoginLabel" ID="Label2" runat="server" Text="Username:"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label class="navLoginLabel" ID="Label3" runat="server" Text="Password:"></asp:Label>
            &nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;
            <asp:Button Class="navLoginButton" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Font-Names="Century Gothic" Text="Remember Me" Visible="False" />
        </div>
        <div class="nav">
            <div class="navSpace"></div>
            <asp:Button class="navButtonSelected" ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
            <asp:Button class="navButton" ID="Button2" runat="server" Text="Residents" OnClick="Button2_Click" />
            <asp:Button class="navButton" ID="Button3" runat="server" Text="Events" OnClick="Button3_Click" />
            <asp:Button class="navButton" ID="Button4" runat="server" Text="Contact Us" OnClick="Button4_Click" />
            <div class="navUsername">
                <br />
                <asp:Label class="navUsernameLabel" ID="lblUsername" runat="server" Text="You are not logged in!"></asp:Label>
            <asp:Button Class="navLoginButton" ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
            </div>
        </div>

        <div class="contents">

            <asp:Image class="homeLogo" ID="Image1" runat="server" Height="270px" ImageUrl="~/Ratau.jpeg" ImageAlign="Middle" />
            <p class="homeContents">
                We are the oldest residence on campus and it reflects in the richness of our tradition and values. Ratau’s vision is to pursue and achieve excellence in everything we do, all together, “hand in hand together”. Led by Prof PJ van der Merwe, Ratau opened its doors on 13 September 1940 as part of the then Potchefstroom College of Education (PCE). The residence&#39;s name was borrowed from Prof Van der Merwe’s nickname in Tswana and means “Father Lion”. In his inaugural speech he used the phrase “In the Light of the Father” and to this day this is our motto.
            </p>
        </div>
    </form>
</body>
</html>
