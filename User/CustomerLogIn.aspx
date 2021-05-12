<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="CustomerLogIn.aspx.cs" Inherits="User_CustomerLogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="lblError" runat="server" Font-Bold="true" Font-Size="10pt" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <table style="color:#000000; border:1px solid #000000" width="400">
            <tr>
                <th colspan="2" class="tablehead">LogIn</th>
            </tr>
            <tr>
                <td class="col">Email:

                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="200px" AutoComplete="off" TextMode="Email"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="col" >Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" Width="200px" AutoComplete="off"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:Button ID="btnLogIn" runat="server" Text="LogIn" CssClass="button" OnClick="btnLogIn_Click" />

                </td>
            </tr> 

        </table>
    </div>
</asp:Content>

