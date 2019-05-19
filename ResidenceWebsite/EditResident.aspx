<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditResident.aspx.cs" Inherits="ResidenceWebsite.EditResident" %>

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
        <asp:Label ID="Label1" runat="server" Text="Student number:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtStudents" runat="server" Enabled="False"></asp:TextBox>
&nbsp;
        <br />
        <asp:Label ID="Label2" runat="server" Text="Username:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtUser" runat="server" Enabled="False"></asp:TextBox>
&nbsp;
        <br />
        <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPass" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Confirm password:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtConfirm" runat="server"></asp:TextBox>
&nbsp;
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPass" ControlToValidate="txtConfirm" ErrorMessage="Passwords do not match"></asp:CompareValidator>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtConfirm" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Name:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtName" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Surname:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSurname" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Room number:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtRoom" runat="server"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRoom" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Cell:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtCell" runat="server"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCell" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Email:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Degree:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtDegree" runat="server"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDegree" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Historic year:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtYear" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Academic average:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtAverage" runat="server"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAverage" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Admin:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtAdmin" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Resident" />
    </form>
</body>
</html>
