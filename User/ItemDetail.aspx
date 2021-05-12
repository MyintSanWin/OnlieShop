<%@ Page Title="SMART LIVEING FASHION SHOP" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="ItemDetail.aspx.cs" Inherits="User_ItemDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
    <link href="../Css.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="color: #000000; border: 1px solid #000000">
        <tr>
            <td colspan="3" class="tablehead">
                Item Detail
            </td>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Image ID="imgItem" runat="server"  Width="200px" Height="200px"/>
            </td>
            <td class="col">ItemName:</td>
            <td>
                <asp:Label ID="lblItemName" runat="server" Width="200px"></asp:Label>

            </td>
        </tr>
        <tr>
            <td class="col">CategoryName:</td>
            <td>
                <asp:Label ID="lblCategoryName" runat="server" Width="200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col">Price:</td>
            <td>
                <asp:Label ID="lblPrice" runat="server" Width="200px"></asp:Label>

            </td>
        </tr>
         <tr>
             <td></td>
             <td colspan="2">
                 <asp:Button ID="btnContinue" runat="server" Text="Continue Shopping" CssClass="button" Width="130px" OnClick="btnContinue_Click"/>&nbsp;
                 <asp:Button ID="btnAdd" runat="server" Text="Add To Card" CssClass="button" Width="130px" OnClick="btnAdd_Click" />


             </td>
         </tr>
    </table>
</asp:Content>

