<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Admin_Category" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style {
            font-size: 20px;
            text-align: center;
            font-weight: bold;
            height: 31px;
        }
        .auto-style2 {
            height:31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />            
     <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table>
            <tr>
                <td>
                    <asp:Label ID="lblError1" runat="server" ForeColor="Red" Font-Bold="True" 
                        Font-Size="10pt"></asp:Label>
                </td>
            </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnNew" runat="server" Text="New" CssClass="button" OnClick="btnNew_Click"   />
             
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click" 
                            />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" OnClick="btnDelete_Click" 
                            />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="button" OnClick="btnPrint_Click" 
                         />
                        &nbsp;&nbsp;&nbsp;
                        Category Name : 
                        <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" 
                            AutoComplete="off" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        
                    </td>
                </tr>
                <tr>
                    <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="5" CellSpacing="1" DataKeyNames="CatID" Width="700px" 
                            onselectedindexchanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="No" HeaderText="No" />
                    <asp:BoundField DataField="CatID" HeaderText="CatID" Visible="False" />
                    <asp:BoundField DataField="CatName" HeaderText="Category Name" />
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select">
                                <asp:CheckBox ID="chkSelect" runat="server" />
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
<div>
    <asp:Label ID="lblError2" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"></asp:Label>
    <asp:TextBox ID="txtCatID" runat="server" Visible="False"></asp:TextBox>
</div>
    <table style="color: #000000; border: 1px solid #000000">
        <tr>
            <th colspan="2" class="tablehead">Category Entry</th>
            <td></td>
        </tr>
        <tr>
            <td class="col">CategoryName:</td>
            <td>
                <asp:TextBox ID="txtCategoryName" runat="server" Width="200px" AutoComplete="off"></asp:TextBox>
                
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2"><asp:Button ID="btnSave" runat="server" Text="Save" 
                   CssClass="button" OnClick="btnSave_Click" /></td>
            
        </tr>
    </table>
</div>
        </asp:View>
    </asp:MultiView>


</asp:Content>

