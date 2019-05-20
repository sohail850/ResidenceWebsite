<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="ResidenceWebsite.ContactUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us</title>
    <link rel="stylesheet" type="text/css" href="Nav.css" />
    <link rel="stylesheet" type="text/css" href="ContactUs.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
            <div class="navSpace"></div>
            <asp:Button class="navButton" ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
            <asp:Button class="navButton" ID="Button2" runat="server" Text="Residents" OnClick="Button2_Click" />
            <asp:Button class="navButton" ID="Button3" runat="server" Text="Events" OnClick="Button3_Click" />
            <asp:Button class="navButtonSelected" ID="Button4" runat="server" Text="Contact Us" OnClick="Button4_Click" />
            <div class="navUsername">
                <br />
                <asp:Label class="navUsernameLabel" ID="Label1" runat="server" Text="You are not logged in!"></asp:Label>
            &nbsp;<asp:Button Class="navLoginButton" ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
            </div>
        </div>

        <div class="contents">
            <div class="contactUsDiv">
                <br />
                <span class="contactUsHeading">
                    Telephone Number:
                </span>
                <br />
                <span class="contactUsParagraph">
                    <i class="fas fa-phone" style="font-size:18px;color:black"></i>
                    063 111 2607
                </span>
                <br /><br />
                <span class="contactUsHeading">
                    Email Adress:
                </span>
                <br />
                <span class="contactUsParagraph">
                    <i class="material-icons" style="font-size:18px;color:black;">email</i>
                    rataulebone@gmail.com
                </span>
                <br /><br />
                <span class="contactUsHeading">
                    Social Media:
                </span>
                <br />
                <span class="contactUsParagraph">
                    <iframe src="https://www.facebook.com/plugins/like.php?href=https%3A%2F%2Fwww.facebook.com%2FNwuPukkeRatauLeboneManskoshuis%2F&width=152&layout=button_count&action=like&size=large&show_faces=false&share=true&height=46&appId" width="152" height="46" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowTransparency="true" allow="encrypted-media"></iframe>
                </span>
                <br /><br />
            </div>
        </div>
    </form>
</body>
</html>
