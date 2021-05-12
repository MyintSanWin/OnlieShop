<%@ Page Title="Administration" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Admin_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblError1" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="10pt"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnNew" runat="server" Text="New" CssClass="button" OnClick="btnNew_Click"  />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnUpdate" runat="server" Text="Update"  CssClass="button" OnClick="btnUpdate_Click"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" OnClick="btnDelete_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;Search Name:
                        <asp:DropDownList ID="ddlSearchType" runat="server" AutoPostBack="true" >
                            <asp:ListItem Value="ItemName"></asp:ListItem>
                            <asp:ListItem Value="CategoryName"></asp:ListItem>
                            <asp:ListItem Value="Price"></asp:ListItem>
                            <asp:ListItem Value="Quantity"></asp:ListItem>
                             </asp:DropDownList>
                         &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" AutoComplete="off" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                         &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="button" OnClick="btnPrint_Click"  />
                         &nbsp;&nbsp;&nbsp;&nbsp;

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="5" CellSpacing="1" DataKeyNames="ItemID" Width="987px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                            <Columns>
                               <asp:BoundField DataField="No" HeaderText="No" />
                                <asp:BoundField DataField="ItemID" HeaderText="ItemID" />
                                <asp:BoundField DataField="ItemName" HeaderText="ItemName" />
                                <asp:BoundField DataField="CatID" HeaderText="CatID" />
                                <asp:BoundField DataField="CatName" HeaderText="CatName" />
                                <asp:BoundField DataField="Price" HeaderText="Price" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <asp:Image ID="ImgItem" runat="server" Width="50" Height="50" ImageUrl='<%#Bind ("Image") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Select" Text="Select">
                                            <asp:CheckBox ID="ChkSelect" runat="server" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
    
<asp:View ID="View2" runat="server">
            <div>
                <asp:Label ID="lblError2" Font-Size="10pt" Font-Bold="True" ForeColor="Red" runat="server"></asp:Label>
                <asp:TextBox ID="txtItemID" Visible="false" runat="server"></asp:TextBox>
                <table style="color: #000000; border:1px solid #000000">
                    <tr>
                        <th colspan="2" class="auto-style1">
                           Item
                            </th>
                        
                       </tr>
                    <tr>
                        <td class="col">
                            Item Name :
                            </td>
                        <td>
                            <asp:TextBox ID="txtItemName" Width="200" AutoComplete="off" runat="server"></asp:TextBox>
                            </td>
                        
                        </tr>
                     <tr>
                        <td class="col">
                            Category Name :
                            </td>
                        <td>
                            <asp:DropDownList ID="ddlCategoryName" Width="200" runat="server" >
                            </asp:DropDownList>
                         </td>
                        
                        </tr>
                     <tr>
                        <td class="col">
                           Price :
                            </td>
                        <td>
                            <asp:TextBox ID="txtPrice" Width="200" AutoComplete="off" runat="server"></asp:TextBox>
                        </td>
                        
                        </tr>
                     <tr>
                        <td class="col">
                            Quantity :
                        </td>
                        <td>
                            <asp:TextBox ID="txtQuantity" Width="200" AutoComplete="off" runat="server"></asp:TextBox>
                        </td>
                        
                        </tr>
                     <tr>
                        <td class="col">
                            Image :
                            </td>
                        <td>
                            <asp:TextBox ID="txtImage" Visible="false" Width="100" AutoComplete="off" runat="server"></asp:TextBox>
                           
                       
                            <asp:FileUpload ID="FileUploadImage" runat="server" />
                           </td>
                        </tr>
                    <tr>
                        
                        <td colspan="2">
                            <asp:Button ID="btnSave" runat="server" Text="Save"  CssClass="button" OnClick="btnSave_Click"/>
                         </td>
                        </tr>


                    </table>


                </div>


        </asp:View>

 </asp:MultiView>

</asp:Content>

