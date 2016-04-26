<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorizeMembers.aspx.cs" Inherits="clubsgoonline.AuthorizeMembers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <p>
        Specify Members&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Label" 
            Visible="false"></asp:Label>
       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
    <p>
        <asp:Repeater ID="ProspectMembers" runat="server" 
        DataSourceID="MemberSource">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="ClubCheckBox" AutoPostBack="true" Text='<%# Eval("UserName") %>'
                 
                 />
                <br />
            </ItemTemplate>
        </asp:Repeater>
         <asp:Button ID="AddMemberButton" runat="server" Text="Add To Member" 
        OnClientClick="javascript:return confirm('Are you sure you want to Add This Member?');"
            onclick="AddMemberButton_Click" />
        <asp:SqlDataSource ID="MemberSource" runat="server" ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>"
        SelectCommand="SELECT UserName FROM [club_user] INNER JOIN [aspnet_Users] on club_user.user_id = aspnet_Users.UserId WHERE in_club is null and [club_id] = @club_id">
        <SelectParameters>
        <asp:ControlParameter Name="club_id" Type="String" PropertyName="text" ControlID="Label1" />
        </SelectParameters>
       
        </asp:SqlDataSource>
       
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
       
    </p>
    <p>
        <br />
    </p>
    
</asp:Content>
