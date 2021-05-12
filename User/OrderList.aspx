<%@Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="User_OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
    <tr>
        <td align="left">
            <asp:Button ID="btnAll" runat="server" Text=" << All" CssClass="button" OnClick="btnAll_Click" />

        </td>
    </tr>
    <tr>
        <td>
            <asp:DataList ID="DataList1" runat="server" Width="800px" OnPreRender="DataList1_PreRender">
                <ItemTemplate>
                    <table width="900px">
                        <tr>
                            <td bgcolor="#3333FF">

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="5" cellspacing="1">
                                    <tr>
                                        <td>
                                            Order Date
                                        </td>
                                        <td>:<asp:Label ID="lblOrderDate" runat="server" Text=' <%# Eval("OrderDate") %>'></asp:Label>

                                        </td>
                                        <td width="100px"></td>
                                        <td>Shipp Address</td>
                                        <td>:<asp:Label ID="lblShippingAdd" runat="server" Text='<%# Eval("ShippingAdd") %>'></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Total</td>
                                        <td>:<asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total") %> '></asp:Label>

                                        </td>
                                        <td width="100px"></td>
                                        <td>Status</td>
                                        <td>:
                                        <asp:Label ID="lblDeleverStatus" runat="server" Text='<%# Eval("DeliverStatus") %>'></asp:Label> </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="5" CellSpacing="1" Width="800px">
                                    <Columns>
                                        <asp:BoundField DataField="No" HeaderText="No" />
                                        <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                                        <asp:BoundField DataField="CatName" HeaderText="Category Name" />
                                        <asp:BoundField DataField="UnitPrice" HeaderText="Price" />
                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                    </Columns>
                                </asp:GridView>

                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>

        </td>
    </tr>
</table>
</asp:Content>

