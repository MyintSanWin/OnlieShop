<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="User_UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
    <link href="../Css.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
    <tr>
        <td>
            <asp:Image ID="imgDisplay" runat="server" ImageUrl="~/image/cosmestic.jpg" />

        </td>
    </tr>
    <tr>
        <td><a href="Item.aspx">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/image/c12.jpg" Width="100" Height="100"/>
          
            </a>
           <a href="Item.aspx">
               <asp:Image ID="Image4" runat="server" ImageUrl="~/image/cover.jpg" Width="100" Height="100" />
           </a>
            <a href="Item.aspx">
                <asp:Image ID="Image5" runat="server" ImageUrl="~/image/s2.jpg" Width="100" Height="100" />
            </a>
            <a href="Item.aspx">
                <asp:Image ID="Image7" runat="server" ImageUrl="~/image/w4.jpg" Width="100" Height="100" />
            </a>
            <a href="Item.aspx">
                <asp:Image ID="Image6" runat="server" ImageUrl="~/image/s0.jpg" Width="80" Height="100" />

            </a>
            <a href="Item.aspx">
                <asp:Image ID="Image8" runat="server" ImageUrl="~/image/f1.jpg" Width="80" Height="100" />

            </a>
            <a href="Item.aspx">
                <asp:Image ID="Image9" runat="server" ImageUrl="~/image/g1.jpg" Width="80" Height="100" />
            </a>
        </td>
       

    </tr>
</table>

</asp:Content>

