<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="clubsgoonline.Account.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
    <MailDefinition From="someone@project.com" Priority="High" 
        Subject="password reset">
    </MailDefinition>
</asp:PasswordRecovery>
</asp:Content>
