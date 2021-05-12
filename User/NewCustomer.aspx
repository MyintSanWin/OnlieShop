<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="NewCustomer.aspx.cs" Inherits="User_NewCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="10pt"></asp:Label>
    </div>
    <div>
        <table style="color: #000000; border: 1px solid #000000" width="400" >
            <tr>

               <th colspan="2" class="tablehead">Customer Entry</th>
            </tr>
            <tr>
                <td class="col">Customer Name:</td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server" Width="200px" AutoComplete="off"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="col">Address:</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" Width="200px" AutoComplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="col">Phone:

                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" Width="200px" AutoComplete="off"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="col">Email:

                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="200px" AutoComplete="off"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="col">Password:

                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" Width="200px" AutoComplete="off" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="col">ComfirmPassword:

                </td>
                <td>
                    <asp:TextBox ID="txtComfirmPassword" runat="server" Width="200px" AutoComplete="off" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="col" style="height: 24px">PaidType:

                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlCType" runat="server" Width="200px">
                        <asp:ListItem>Mobile Pay Banking</asp:ListItem>
                        <asp:ListItem>Visa</asp:ListItem>
                        <asp:ListItem>Master</asp:ListItem>
                    </asp:DropDownList>
                   
                </td>
            </tr>
            <tr>
                <td class="col">Account No:</td>
                <td>
                     <asp:TextBox ID="txtAcc" runat="server" Width="200px" AutoCompleteT="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" OnClick="btnSave_Click" />

                </td>
            </tr>
        </table>
    </div>
</asp:Content>

