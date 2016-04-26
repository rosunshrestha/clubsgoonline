<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhotoViewer.aspx.cs" Inherits="clubsgoonline.PhotoViewer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <table>
    <tr>
    <td>
        <asp:ListView ID="lvPhotoViewer" runat="server" GroupItemCount="1">
         <LayoutTemplate>                
             <table ID="groupPlaceholderContainer" runat="server" border="1">                               
                  <tr ID="groupPlaceholder" runat="server">
                  </tr>
             </table>                       
         </LayoutTemplate>
               
         <ItemTemplate>
             <td id="Td4" align="center" style="background-color: #eeeeee;">
                    
                    <center><asp:Image runat="server" ID="imPhoto" Height="450"  Width="600" ImageUrl='<%# "~"+Eval("Photo") %>' /></center>
                    <br />
                    <asp:Label ID="DefaultPhotIDLabel" runat="server" 
                            Text='<%# Eval("PhotoName") %>' />
             </td>
        </ItemTemplate>
   
         <GroupTemplate>
              <tr ID="itemPlaceholderContainer" runat="server">
                   <td ID="itemPlaceholder" runat="server">
                   </td>
              </tr>
        </GroupTemplate>
        </asp:ListView>
    </td>
    </tr>
    <tr>
    <td align="center">
        <asp:DataPager ID="DataPager1" runat="server" 
        PagedControlID="lvPhotoViewer" PageSize="1" 
        onprerender="DataPager1_PreRender">
        <Fields>
            <asp:NextPreviousPagerField ButtonType="Link"
            PreviousPageText="<< " NextPageText=" >>" />
         </Fields>
        </asp:DataPager>
    </td>
    </tr>
    </table>  
</asp:Content>
