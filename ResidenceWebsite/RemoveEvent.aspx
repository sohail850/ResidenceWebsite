<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveEvent.aspx.cs" Inherits="ResidenceWebsite.RemoveEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            {Sit in al die headers en CSS goed hierso}<br />
        </div>
        Select an event to remove:<br />
        <br />
        <asp:ListBox ID="eventsListBox" runat="server" Height="135px" Width="416px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnRemoveEvent" runat="server" OnClick="btnRemoveEvent_Click" Text="Remove Event" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    </form>
</body>
</html>
