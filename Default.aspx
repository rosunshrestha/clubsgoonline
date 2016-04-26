<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="clubsgoonline._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 327px;
        }
        .style3
        {
            width: 26px;
        }
        .style4
        {
            width: 139px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome Clubs go Online
        This is the HomePage
    </h2>
    <p>
        To goto official site of Kathmandu University Please click here <a href="http://www.ku.edu.np" title="Kathmandu University"></a>.
    </p>
    
      <table>
            <tr>
                <td rowspan="2" class="style4">
                    <asp:ListView ID="ClublistDyn" runat="server" DataSourceID="Clublisting" OnItemCommand="GoToClubwhich">
                        <ItemTemplate>
                            <center><asp:ImageButton runat="server" ID="ClubLogoDyn" ImageUrl='<%# "~\\logo\\" + Eval("clublogo") %>' CommandArgument='<%# Eval("clubid") %>' CommandName="cluburl" Height="100" Width="100"  BorderWidth="5" BorderStyle="Double" BorderColor="Aquamarine" /></center>
                            <br />
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:SqlDataSource ID="Clublisting" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>" 
                        SelectCommand="SELECT [clubname], [clublogo], [clubid] FROM [clubinformation]"></asp:SqlDataSource>
                </td>
                <td class="style3"><strong>Recent News</strong></td>
                <td class="style1">
                    <asp:Button ID="UpdateNews" runat="server" Text="Update News" OnClick="NewsUpdate" Visible="true" Enabled="true" AutoPostBack="true" />
                </td>
            </tr>
            <tr>
                
            <td>
                <asp:Datalist ID="Briefnews" runat="server" CellPadding="4" 
                DataSourceID="RecentNews" Width="411px" ForeColor="#333333" 
                    OnItemCommand="GetFullNews">
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
                    </ItemTemplate>
                </asp:Datalist>
                <asp:SqlDataSource ID="RecentNews" runat="server" ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>">
                </asp:SqlDataSource>
              </td>
            <td valign="top">
                <asp:Panel ID="Panel" ScrollBars="Vertical" runat="server" 
                    Height="263px" Wrap="true">
                     <asp:Label runat="server" ID="NewsPanel"></asp:Label>
                     <asp:TextBox runat="server" ID="Headline" TextMode="SingleLine" Visible="false" Enabled="false">Headline</asp:TextBox><br />
                     <asp:TextBox runat="server" ID="NewNews" TextMode="MultiLine" Visible="false" Enabled="false">Type Your News Here</asp:TextBox><br />
                     <asp:Button runat="server" Text="Save" ID="GetNewsUpdate" Visible="false" Enabled="false" OnClick="NewsUpdated" AutoPostBack="true" />
                 </asp:Panel>
            </td>
        </tr>
    </table>
    
</asp:Content>
