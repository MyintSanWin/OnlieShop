<%@ Page Title="Admistration" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div>
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
            &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Button ID="btnUpdate" runat="server" Text="Update"  CssClass="button" OnClick="btnUpdate_Click"/>
             &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" OnClick="btnDelete_Click"/>
             &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="button" OnClick="btnPrint_Click" />
              &nbsp; &nbsp; &nbsp; &nbsp;
            Admin Name:
            <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" AutoComplete="off" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
        </td>
        
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="5" CellSpacing="1" DataKeyNames="AdminID" Width="700px" Height="700px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="No" HeaderText="No"/>
                    <asp:BoundField DataField="AdminID" HeaderText="AdminID"/>

                    <asp:BoundField DataField="AdminName" HeaderText="AdminName" Visible="false" />
                    <asp:BoundField DataField="Password" HeaderText="Password" Visible="false"/>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Select">
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
              <asp:Label ID="lblError2" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="10pt"></asp:Label>
              <asp:TextBox ID="txtAdminID" runat="server" Visible="false"></asp:TextBox>
              <table style="color:#000000; border:1px solid #000000">
                  <tr>
                      <td colspan="2" class="tablehead">New Admin</td>
                  </tr>
                  <tr>
                      <td class="col">Admin Name:

                      </td>
                      <td>
                          <asp:TextBox ID="txtAdminName" runat="server" Width="200px" AutoComplete="off"  ></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td class="col">Password:</td>
                      <td>
                          <asp:TextBox ID="txtPassword" runat="server" Width="200px" AutoComplete="off" TextMode="Password"  ></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td class="col">ComfirmPassword:</td>
                      <td>
                          <asp:TextBox ID="txtConfirmPassword" runat="server" Width="200px" TextMode="Password" ></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td>

                      </td>
                      <td>
                          <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                      </td>
                  </tr>
              </table>
          </asp:View>

    </asp:MultiView>
    </div>
</asp:Content>

