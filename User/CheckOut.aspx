<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="User_CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="../Css.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 31px;
        }

        .auto-style2 {
            width: 150px;
            height: 40px;
            text-align: right;
        }

        .auto-style3 {
            height: 40px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        &nbsp;<table width="1000" style="color: #000000; border: 1px solid #000000">
            <tr>
                <th colspan="3" class="tablehead">Check Out
                    <asp:TextBox ID="txtLoad" runat="server" Visible="false"></asp:TextBox>

                </th>
            </tr>
            <tr>
                <td colspan="3" align="right" class="auto-style1">
                    <div>
                        <asp:Label ID="lblError" runat="server" Font-Bold="true" Font-Size="10pt" ForeColor="Red"></asp:Label>

                    </div>
                </td>
            </tr>
            <tr>
                <td rowspan="5">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" DataKeyNames="ItemID" Width="600px">
                        <Columns>
                            <asp:BoundField DataField="No" HeaderText="No" />
                            <asp:BoundField DataField="ItemID" HeaderText="ItemID" Visible="false" />
                            <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                            <asp:BoundField DataField="CatName" HeaderText="Category Name" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                            <asp:BoundField DataField="Qty" HeaderText="Qty" />
                            <asp:TemplateField HeaderText="Price*Qty">
                              <ItemTemplate>
                               <asp:Label ID="txtTotal" runat="server" Text='<%# totalAmount(Convert.ToDouble(Eval("Price")),Convert.ToDouble((Eval("Qty")))).ToString() %>' Enabled="false"></asp:Label>
                              </ItemTemplate>
                             </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div>
                        <p></p>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        Total:<asp:TextBox ID="txtTotal" runat="server" Enabled="false"></asp:TextBox>
                    </div>

                </td>
                <td class="auto-style2">Customer Name:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtCustomerName" runat="server" Enabled="false" Width="200px"></asp:TextBox>

                </td>


            </tr>
            <tr>
                <td class="auto-style2">Card Type:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtCardType" runat="server" Enabled="false" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="col">Account No:</td>
                <td>
                    <asp:TextBox ID="txtAccountNo" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="col">Shipped Address:

                </td>
                <td>
                    <asp:TextBox ID="txtShipAdd" runat="server" Rows="5" Width="200px" TextMode="MultiLine"></asp:TextBox></td>

            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="button" Width="102px" OnClick="btnConfirm_Click" />&nbsp;
                    <asp:Button ID="btnCancelShop" runat="server" Text="CancelBuy" CssClass="button" Width="102px" OnClick="btnCancelShop_Click" />

                </td>
            </tr>
        </table>
    </div>
</asp:Content>

