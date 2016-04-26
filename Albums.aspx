<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="clubsgoonline.Albums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ListView ID="lvAlbums" runat="server"
            DataSourceID="SqlDataSource1" GroupItemCount="3" 
            InsertItemPosition="LastItem">            
            <LayoutTemplate>                
                    <table border="1">
                       <tr ID="groupPlaceholder" runat="server">
                       </tr>
                    </table>                       
            </LayoutTemplate>                                              
            <GroupTemplate>
                    <tr>
                        <td ID="itemPlaceholder" runat="server">
                        </td>
                    </tr>
             </GroupTemplate>             
             <ItemTemplate>
                    <td id="Td3" width="150px" height="150px" align="center" style="background-color: #e8e8e8;color: #333333;">
                    <asp:HiddenField ID="hfPhotoID" runat="server" Value='<%# Eval("DefaultPhotID") %>' />
                    <a href='<%# "Photos.aspx?AlbumID="+Eval("AlbumID") %>'> 
                    <asp:Image CssClass="Timg" runat="server" ID="imPhoto" ImageUrl='<%# "ThumbNail.ashx?ImURL="+Eval("Photo") %>' />
                    </a>
                    <br />                    
                    <b><asp:Label ID="lblAlbumName" runat="server" Text='<%# Eval("AlbumName") %>'></asp:Label>   </b>
                    </td>                
                </ItemTemplate>
                
                <InsertItemTemplate>
                <td id="Td3" width="150px" height="150px" runat="server" align="center" style="background-color: #e8e8e8;color: #333333;">
                <a href="CreateAlbum.aspx">                    
                    Create New Album
                </a>
                </td>              
                </InsertItemTemplate>             
            </asp:ListView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>" 
            SelectCommand="SELECT Album1.AlbumID, Album1.DefaultPhotID, Album1.AlbumName, PhotAlbum.Photo FROM Album1 INNER JOIN PhotAlbum ON Album1.DefaultPhotID = PhotAlbum.PhotoID">
        </asp:SqlDataSource>
</asp:Content>
