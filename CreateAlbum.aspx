<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAlbum.aspx.cs" Inherits="clubsgoonline.CreateAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
    
    </div>
    <table>
        <tr>
            <td align="right">
                Album Name</td>
            <td>
                <asp:TextBox ID="txtAlbumName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnCreate" runat="server" onclick="btnCreate_Click" 
                    Text="Create" />
            </td>
        </tr>
    </table>
</asp:Content>
