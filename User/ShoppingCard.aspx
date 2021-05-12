<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCard.aspx.cs" Inherits="User_ShoppingCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table>
    <tr>
        <th>Checking Your Items Information....
            <asp:TextBox ID="txtLoad" runat="server" Visible="False"></asp:TextBox>
        </th>
    </tr>
    <tr>
        <td>
        
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px" 
                CellPadding="5" CellSpacing="1" DataKeyNames="ItemID" Width="900px" 
                PageSize="6">
                <Columns>
                    <asp:BoundField DataField="No" HeaderText="No"></asp:BoundField>
                    <asp:BoundField DataField="ItemID" HeaderText="ItemID" Visible="False" />
                    <asp:BoundField DataField="ItemName" HeaderText="Items Name" />
                    <asp:BoundField DataField="CatName" HeaderText="Category Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    
                    <asp:BoundField DataField="Qty" HeaderText="Qty"/>
                    <asp:TemplateField HeaderText="ChangeQty">
                        <ItemTemplate>
                           <asp:TextBox ID="txtNewQty" runat="server" 
                               Text='<%# Bind("Qty") %>' ></asp:TextBox>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             
        </td>
    </tr>
    <tr>
        <td>
        <asp:Button ID="btnContinue" runat="server" Text="Continue" 
                CssClass="button" Width="110px" OnClick="btnContinue_Click1" />
        &nbsp;<asp:Button ID="btnCheckOut" runat="server" Text="Check Out" 
                 CssClass="button" Width="110px" OnClick="btnCheckOut_Click1" />
        &nbsp;<asp:Button ID="btnCancleShopping" runat="server" Text="Cancle Shopping" 
                CssClass="button" Width="110px" OnClick="btnCancleShopping_Click" />
        </td>
        </tr>
    </table>

</asp:Content>

