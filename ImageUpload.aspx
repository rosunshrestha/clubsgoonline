<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImageUpload.aspx.cs" Inherits="clubsgoonline.ImageUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
     <table style="width: 100%">
            <tr>
                <td align="right" >
                    Select a image to upload</td>
                <td align="left" >
        <asp:FileUpload ID="fuImage" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" >
                    Image name</td>
                <td align="left" >
        <asp:TextBox ID="txtImageName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" >
                    Make it as Album Cover</td>
                <td align="left" >
                    <asp:CheckBox ID="ckbAlbumCover" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" >
                    &nbsp;</td>
                <td align="left" >
                    <asp:DropDownList ID="ddlAlbum" runat="server" DataSourceID="SqlDataSource1" 
                        DataTextField="AlbumName" DataValueField="AlbumID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>" 
                        SelectCommand="SELECT [AlbumID], [AlbumName] FROM [Album1]">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td >
                </td>
                <td >
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
                    <asp:LinkButton ID="lbGoTo" runat="server" onclick="lbGoTo_Click">Go to Album</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
