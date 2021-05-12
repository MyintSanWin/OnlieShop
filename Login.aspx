<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Css.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblError" runat="server" Text="Label" Font-Bold="false" Font-Size="10pt" ForeColor="Red"></asp:Label>

<table style="color:#000000; border:10px solid #000000">
<tr>
    <td colspan="2" class="tablehead">Admin LogIn</td>
</tr>
    <tr>
    <td class="col">Name:</td> 
    
      <td>
            <asp:TextBox ID="txtAdminName" runat="server"  Width="200px" AutoComplete="OFF" ></asp:TextBox>
       </td>
 </tr>

    <tr>
        <td class="col">Password : </td>
      <td>  <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px" ></asp:TextBox>

        </td>
    </tr>
    <tr><td></td>
        <td>
            <asp:Button ID="btnLogIn" runat="server" Text="Log In" CssClass="button" OnClick="btnLogIn_Click" />
        </td>
    </tr>
</table>
</asp:Content>