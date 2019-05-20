<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="ResidenceWebsite.Events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Events</title>
    <link rel="stylesheet" type="text/css" href="Nav.css" />
    <link rel="stylesheet" type="text/css" href="Events.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
            <div class="navSpace"></div>
            <asp:Button class="navButton" ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
            <asp:Button class="navButton" ID="Button2" runat="server" Text="Residents" OnClick="Button2_Click" />
            <asp:Button class="navButtonSelected" ID="Button3" runat="server" Text="Events" OnClick="Button3_Click" />
            <asp:Button class="navButton" ID="Button4" runat="server" Text="Contact Us" OnClick="Button4_Click" />
            <div class="navUsername">
                <br />
                <asp:Label class="navUsernameLabel" ID="Label1" runat="server" Text="You are not logged in!"></asp:Label>
            &nbsp;<asp:Button Class="navLoginButton" ID="btnLogout" runat="server" Text="Logout" />
            </div>
        </div>

        <div class="contents">

            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="Calendar1" runat="server" Height="429px" OnSelectionChanged="Calendar1_SelectionChanged" Width="533px"></asp:Calendar>
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblOutput" runat="server"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="eventsListBox" runat="server" Width="536px"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddEvent" runat="server" OnClick="btnAddEvent_Click" Text="Add Event" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRemoveEvent" runat="server" OnClick="btnRemoveEvent_Click" Text="Remove Event" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEditEvent" runat="server" OnClick="btnEditEvent_Click" Text="Edit Event" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;

        </div>
    </form>
</body>
</html>
