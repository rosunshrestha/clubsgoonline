<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="video.aspx.cs" Inherits="clubsgoonline.video" %>

<%@ Register Assembly="ASPNetMediaGUI.NET3" Namespace="ASPNetMediaGUI" TagPrefix="ASPNetMediaGUI" %>

<%@ Register Assembly="ASPNetFlashVideo.NET3" Namespace="ASPNetFlashVideo" TagPrefix="ASPNetFlashVideo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ASPNetFlashVideo:FlashVideo ID="FlashVideo" runat="server" AutoPlay="false" BorderColor="Aqua" ScaleMode="StretchToFit" ShowControlPanel="true" >
    </ASPNetFlashVideo:FlashVideo>
    <ASPNetMediaGUI:PlayList ID="PlayList1" runat="server" AutoGenerateColumns="False"
        ShowHeader="False" MediaPlayer="Player" 
         AutoPlay="False" SelectedTrack="1" OnSelectedIndexChanged="a" 
        ontrackchangeevent="PlayList1_TrackChangeEvent">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="TrackSelectButton" runat="server" CausesValidation="False" CommandName="Select" Text='<%# Eval("Name") %>'></asp:LinkButton>
                
                </ItemTemplate>
            </asp:TemplateField>           
        </Columns>
    </ASPNetMediaGUI:PlayList>
    <%--<asp:SqlDataSource ID="VideoPlaylist" runat="server"></asp:SqlDataSource>--%>
</asp:Content>
