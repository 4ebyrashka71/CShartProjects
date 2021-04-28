<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="ItemStorage.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 77px;
        }
        .auto-style3 {
            width: 296px;
        }
        .auto-style4 {
            width: 373px;
        }
        .auto-style5 {
            height: 120px;
        }
        .auto-style7 {
            height: 120px;
            width: 240px;
        }
        .auto-style8 {
            width: 240px;
        }
        .auto-style9 {
            height: 48px;
            width: 240px;
        }
        .auto-style11 {
            height: 16px;
            width: 240px;
        }
        .auto-style13 {
            height: 74px;
            width: 240px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" rowspan="5">&nbsp;</td>
                <td class="auto-style3" rowspan="5">
                    <asp:GridView ID="ItemsGridView" runat="server" Caption="Goods" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="255px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </td>
                <td class="auto-style4" rowspan="5" style="vertical-align: top">
                    <asp:GridView ID="DeliveriesGridView" runat="server" BorderStyle="Solid" Caption="Deliveries" CellPadding="4" Width="343px" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
                <td class="auto-style13">ID:<br />
                    <asp:DropDownList ID="idDropDownList" runat="server" Height="16px" Width="128px">
                    </asp:DropDownList>
                </td>
                <td rowspan="3">Product name:<br />
                    <asp:DropDownList ID="NameDropDownList" runat="server" Height="16px" Width="128px">
                    </asp:DropDownList>
                </td>
                <td rowspan="5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">
                    Price:</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="priceBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Task 1" Width="129px" />
                </td>
                <td class="auto-style5">
                    <asp:Button ID="Button2" runat="server" Text="Task 2" Width="129px" OnClick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
