<%@ Page Title="SMART LIVEING FASHION SHOP " Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="User_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtLoad" runat="server" Visible="false" Width="200px">
       
    </asp:TextBox>
    <div>

        <div class="box">
            <div class="listbox">
                <div class="CatTitle">Category Name</div>
                <asp:DataList ID="CatNameList" runat="server" DataKeyField="CatID" OnSelectedIndexChanged="CatNameList_SelectedIndexChanged">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/favs.png"/>
                        <asp:LinkButton ID="btnCategoryName1" runat="server" CommandName="Select" Text='<%#Eval("CatName") %>' class="list"/>

                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="listbox">
                <div class="CatTitle">View Your Cart</div>
                <div class="img">
                    <a href="ShoppingCard.aspx">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/shop_cart.png" Width="50px" Height="50px" />

                    </a>
                </div>
            </div>
        </div>
        <div>
            
                    <asp:DataList ID="ItemList" runat="server" DataKeyField="ItemID" RepeatColumns="4" RepeatDirection="Horizontal" BorderColor="#003300" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="3" Width="800px" OnSelectedIndexChanged="ItemList_SelectedIndexChanged" >
                        <ItemTemplate>
                            <div class="Itemlist">
                                <table cellpadding="5" cellspacing="3" align="center">
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image3" runat="server" ImageUrl='<%# Eval("Image") %>' Width="100px" Height="100px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="price">
                                           Price: <asp:Label ID="Price" runat="server" Text='<%#Eval("Price") %>'></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="detail">
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select">Detail</asp:LinkButton>

                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
        
        </div>
    </div>
</asp:Content>

