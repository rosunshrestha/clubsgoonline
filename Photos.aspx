<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Photos.aspx.cs" Inherits="clubsgoonline.Photos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>    
        <table style="background-color:#8a979e">
            <tr>
                <td valign="top"> Album Name:
                    <asp:Label ID="lblAlbumName" runat="server"></asp:Label><br />                
                    <asp:Image CssClass="Timg" runat="server" ID="imAlbumPhoto" /><br />
                    No of Pictures: <asp:Label ID="lblNoofPicz" runat="server"></asp:Label> 
                    <br />
                    <a href="Albums.aspx">Back to Albums</a>
                    <br />
                    <asp:LinkButton ID="lbUploadPhotos" runat="server" 
                        onclick="lbUploadPhotos_Click">Upload Photos</asp:LinkButton>                   
                </td>
                <td>
    
            <asp:ListView ID="lvPhotos" runat="server" DataKeyNames="AlbumID" 
            DataSourceID="SqlDataSource1" GroupItemCount="3">            
            <LayoutTemplate>               
                   <table ID="groupPlaceholderContainer" runat="server" border="0" cellpadding="0" cellspacing="0">
                         <tr ID="groupPlaceholder" runat="server">
                         </tr>
                   </table>                        
            </LayoutTemplate>                        
            <GroupTemplate>
                    <tr ID="itemPlaceholderContainer" runat="server">
                        <td ID="itemPlaceholder" runat="server">
                        </td>
                    </tr>
                </GroupTemplate>           
                <ItemTemplate>
                    <td id="Td1" runat="server" align="center" style="background-color: #e8e8e8;color: #333333;">                    
                    <a href='<%# "PhotoViewer.aspx?PhotoID="+Eval("PhotoID")+"&AlbumID="+ Eval("AlbumID") %>'> 
                    <asp:Image CssClass="Timg" runat="server" ID="imPhoto" ImageUrl='<%# "ThumbNail.ashx?ImURL="+Eval("Photo") %>' />
                    </a>
                    </td>                
                </ItemTemplate>             
            </asp:ListView>
                   <asp:HiddenField ID="hfAlbumID" runat="server" />
             </td>
             </tr>               
            </table>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>" 
            SelectCommand="SELECT [PhotoID], [Photo], [PhotoName], [AlbumID] FROM [PhotAlbum] WHERE ([AlbumID] = @AlbumID) ORDER By [PhotoID] ASC" 
            onselected="SqlDataSource1_Selected">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="1" Name="AlbumID" 
                        QueryStringField="AlbumID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
    
    </div>
</asp:Content>
