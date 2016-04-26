<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="allnews.aspx.cs" Inherits="clubsgoonline.allnews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 21px;
            width: 208px;
        }
        .style3
        {
            width: 572px;
        }
        .style4
        {
            height: 21px;
            width: 572px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table border="0" style="width: 909px" >
            <tr>
                <td rowspan="2">
                    <asp:Image ID="clublogo" runat="server" Height="100px" Width="100px" />
                 </td>
                 <td class="style4">
                     <center>
                        <asp:Label ID="ClubName" runat="server" Font-Size="XX-Large" ></asp:Label>
                        <asp:Label ID="Abbrev" runat="server" Font-Size="X-Small"></asp:Label>
                     </center>
                 </td>
            </tr>
            <tr>
                <td colspan="2" align="right" class="style3">
                    <asp:Label ID="ClubMoto" runat="server"></asp:Label>
                        &nbsp; since
                        &nbsp;
                     <asp:Label ID="Estd" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

    <table>
        <tr>
            <td class="style1">
                <strong>News</strong></td>
            <td class="style1">
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
                        <asp:LinkButton ID="FullNews" runat="server" Text="more...>" CommandName="more" CommandArgument='<%#Eval("Headline") + ";" +Eval("post")%>'> 
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
            </td>
            <td valign="top" class="style2">
                <asp:Panel ID="Panel" ScrollBars="Vertical" runat="server" Width="492px" 
                    Height="263px" Wrap="true">
                    <asp:Label runat="server" ID="NewsPanel"></asp:Label>
                    <br />
                    <br />
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
