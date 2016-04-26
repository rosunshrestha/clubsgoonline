<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="club.aspx.cs" Inherits="clubsgoonline.club" %>

<%@ Register Assembly="ASPNetFlashVideo.NET3" Namespace="ASPNetFlashVideo" TagPrefix="ASPNetFlashVideo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 815px;
            height: 72px;
        }
        .style4
        {
            width: 815px;
        }
        .style7
        {
            width: 424px;
        }
        </style>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="query" Visible="false" Enabled="False" runat="server"></asp:Label>
        <table border="0" >
            <tr>
                <td rowspan="2">
                    <asp:Image ID="clublogo" runat="server" Height="100px" Width="100px" />
                 </td>
                 <td class="style1">
                     <center>
                        <asp:Label ID="ClubName" runat="server" Font-Size="XX-Large" ></asp:Label>
                        <asp:Label ID="Abbrev" runat="server" Font-Size="X-Small"></asp:Label>
                     </center>
                 </td>
            </tr>
            <tr>
                <td colspan="2" align="right" class="style4">
                    <asp:Label ID="ClubMoto" runat="server"></asp:Label>
                        &nbsp; since
                        &nbsp;
                     <asp:Label ID="Estd" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <table border="0">
            <tr>
                <td class="style7" valign="top" align="justify">
                    <center>Welcome</center><asp:Label runat="server" ID="Description"></asp:Label>
                    
                </td>
                <td>
                <loginview>
                <a href="JoinAClub.aspx">Join A Club</a>
                </loginview>
                </td>
               
            </tr>
        </table>
    <table>
            <tr>
                <td class="style3"><strong>Recent News</strong></td>
                <td>
                    <asp:Button ID="UpdateNews" runat="server" Text="Update News" OnClick="NewsUpdate" Visible="false" Enabled="false" AutoPostBack="true" />
                     <asp:HyperLink ID="HyperLink2" Visible = "false" runat="server" Enabled="false" Text=""></asp:HyperLink>
                </td>
            </tr>
            <tr>
            <td class="style2">
                <asp:Datalist ID="Briefnews" runat="server" CellPadding="4" 
                DataSourceID="RecentNews" Width="411px" ForeColor="#333333" 
                    OnItemCommand="GetFullNews" RepeatColumns="0"  OnDeleteCommand="Briefnews_DeleteCommand">
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#E3EAEB" />
                    <ItemTemplate>
                        <asp:Label ID="Headline" runat="server" Text='<%# Eval("Headline") %>' Font-Bold="true" Font-Underline="true"/>
                        <br />
                        <asp:Label ID="Briefing" runat="server" Text='<%# Eval("BriefNews") %>'/>
                        <asp:LinkButton ID="FullNews" runat="server" Text="more...>" CommandName="more" CommandArgument='<%# Eval("newsid") %>'> 
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("newsid") %>'                
                    OnClientClick="javascript:return confirm('Are you sure!!!\nYou want to delete the Post permanently?');" 
                    >Delete</asp:LinkButton>
                    
                    
                    </ItemTemplate>
                </asp:Datalist>
                <asp:SqlDataSource ID="RecentNews" runat="server" ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>"
                DeleteCommand="DELETE FROM [news_update] WHERE [newsid] = @newsid">
                
                <DeleteParameters>
                <asp:Parameter Name="newsid" Type="Int32" />
            </DeleteParameters>
                </asp:SqlDataSource>
                <br />
              </td>
            <td valign="top" class="style2">
                <asp:Panel ID="Panel" ScrollBars="Auto" runat="server" Width="492px" 
                    Height="263px" Wrap="true">
                     <asp:Label runat="server" ID="NewsPanel"></asp:Label>
                     <asp:TextBox runat="server" ID="Headline" TextMode="SingleLine" Visible="false" Enabled="false">Headline</asp:TextBox><br />
                     <asp:TextBox runat="server" ID="NewNews" TextMode="MultiLine" Visible="false" Enabled="false">Type Your News Here</asp:TextBox><br />
                     <asp:Button runat="server" Text="Save" ID="GetNewsUpdate" Visible="false" Enabled="false" OnClick="NewsUpdated" AutoPostBack="true" />
                 </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="OlderNews" Text="Older News" onclick="AllNews" />
            </td>
        </tr>
    </table>
        
        <asp:HyperLink ID="HyperLink1" visible = "true" runat="server" >UploadPhoto</asp:HyperLink>
    
      
    
</asp:Content>
