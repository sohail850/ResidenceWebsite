<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Residents.aspx.cs" Inherits="ResidenceWebsite.Residents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Residents</title>
    <link rel="stylesheet" type="text/css" href="Nav.css" />
    <link rel="stylesheet" type="text/css" href="Residents.css" />

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
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
            <br />
            <br />
            <asp:Label class="navLoginLabel" ID="Label3" runat="server" Text="Password:"></asp:Label>
            &nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True"></asp:TextBox>
            <br />
            &nbsp;
            <asp:Button Class="navLoginButton" ID="Button5" runat="server" Text="Login" />
        </div>
        <div class="nav">
            <div class="navSpace"></div>
            <asp:Button class="navButton" ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
            <asp:Button class="navButtonSelected" ID="Button2" runat="server" Text="Residents" OnClick="Button2_Click" />
            <asp:Button class="navButton" ID="Button3" runat="server" Text="Events" OnClick="Button3_Click" />
            <asp:Button class="navButton" ID="Button4" runat="server" Text="Contact Us" OnClick="Button4_Click" />
            <div class="navUsername">
                <br />
                <asp:Label class="navUsernameLabel" ID="Label1" runat="server" Text="You are not logged in!"></asp:Label>
            </div>
        </div>

        <div class="contents">
                <div class="contents_gridview">
                    <br />
                    <asp:TextBox ID="txtBoxSearch" runat="server" AutoCompleteType="Disabled" AutoPostBack="True"></asp:TextBox>
                    <asp:Button class="dataButton dataButtonSearch" ID="Button7" runat="server" OnClick="Button7_Click" Text="Search" />
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" Font-Names="Century Gothic">
                        <HeaderStyle BackColor="SteelBlue" Font-Size="18px" ForeColor="White" />
                    </asp:GridView> 
                </div>
                <div class="contents_a">
                    <asp:Button class="dataButton dataButton_AddEdit" ID="Button8" runat="server" OnClick="Button8_Click" Text="Add Resident" />
                    <br />
                    <br />
                    <asp:Button class="dataButton dataButton_AddEdit" ID="btnEditResident" runat="server" OnClick="Button9_Click" Text="Edit Resident" />
                    <br />
                    <br />
                    <asp:Button class="dataButton dataButton_Delete" ID="Button10" runat="server" OnClick="Button10_Click" Text="Delete Resident" />
                    <asp:DropDownList ID="ddListDelete" runat="server">
                    </asp:DropDownList>
                </div>
             <div class="contents_b">
                <br />
                <asp:Button class="dataButton dataButton_Academic" ID="Button11" runat="server" Text="Distinction" OnClick="Button11_Click" />
                <br />
                <asp:Button class="dataButton dataButton_Academic" ID="Button12" runat="server" Text="Pass" OnClick="Button12_Click" />
                <br />
                <asp:Button class="dataButton dataButton_Academic" ID="Button13" runat="server" Text="Fail" OnClick="Button13_Click" />
            </div>
        </div>
    </form>
    </body>
</html>
