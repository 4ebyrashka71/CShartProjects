<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ItemStorage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style10 {
            text-align: center;
        }
        .auto-style13 {
            width: 734px;
        }
        .auto-style14 {
            width: 734px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table cellspacing="7" class="auto-style1">
            <tr>
                <td class="auto-style10" colspan="2">Authorization Page</td>
            </tr>
            <tr>
                <td class="auto-style14">Login</td>
                <td>
                        <asp:TextBox ID="UserTextBox" runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">Password</td>
                <td>
                        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style10" colspan="2">
                        <asp:Button ID="OkButton" runat="server" OnClick="OkButton_Click" Text="Confirm" Width="122px" style="height: 25px" />
                    </td>
            </tr>
        </table>
    </form>
</body>
</html>
