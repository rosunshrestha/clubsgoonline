<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JoinAClub.aspx.cs" Inherits="clubsgoonline.JoinAClub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>Please Select Clubs You Want To join </p>
  <asp:Repeater ID="ClubList" runat="server" 
        DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="ClubCheckBox" AutoPostBack="true" Text='<%# Eval("clubname") %>'
                 
                 />
                <br />
            </ItemTemplate>
        </asp:Repeater>
    <asp:Button ID="Confirm" runat="server" Text="Request To Join"
    OnClientClick="javascript:return confirm('Are you sure you want to Join The Clubs?');"
     onclick="Confirm_Click" />

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>" 
        SelectCommand="SELECT [clubname] FROM [clubinformation]">
    </asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server" Text="Label"  Visible="false"></asp:Label>
</asp:Content>
