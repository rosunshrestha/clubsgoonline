<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="clubsgoonline.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <table>
        <tr>
            <td>ClubName:</td>
            <td><asp:TextBox runat="server" ID="ClubName" TextMode="SingleLine" Width="367px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="VClubname" runat="server" ErrorMessage="*" ControlToValidate="ClubName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Abbreviation:</td>
            <td><asp:TextBox runat="server" ID="Abbv" TextMode="SingleLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="vAbbv" runat="server" ErrorMessage="*" ControlToValidate="Abbv"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Club Motto:</td>
            <td><asp:TextBox runat="server" ID="ClubMoto" TextMode="SingleLine" Width="363px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Established Year:</td>
            <td><asp:TextBox runat="server" ID="Estd" TextMode="SingleLine"></asp:TextBox>
                <asp:RangeValidator ID="vEstd" ControlToValidate="Estd" runat="server" ErrorMessage="1985-2012"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>School:</td>
            <td><asp:DropDownList runat="server" ID="School" AutoPostBack="true" 
                    onselectedindexchanged="School_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Department:</td>
            <td><asp:DropDownList runat="server" ID="Dept" AutoPostBack="true"></asp:DropDownList><br /></td>
     
        </tr>
        <tr>
            <td>Club Logo:
            </td>
            <td>
            <asp:FileUpload ID="UploadLogo" runat="server" />
            <asp:Button ID="LogoUpload" runat="server" Text="Upload" OnClick="UploadNewLogo"/>
            <asp:Label ID="UpdatePro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>A Short Club Description:</td>
            <td><asp:TextBox runat="server" ID="Description" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="vDescription" ControlToValidate="Description" runat="server" ErrorMessage="Please write something about the club"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Security Key:</td>
            <td><asp:TextBox runat="server" ID="SKey" TextMode="SingleLine" AutoPostBack="true" OnTextChanged="CheckCode"></asp:TextBox>
                <asp:CustomValidator ID="vSkey" ControlToValidate="Skey" runat="server" ErrorMessage="Please type in the correct Serial Key given"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button runat="server" ID="Submit" Text="Create this Club" 
                    onclick="Submit_Click" /></td>
        </tr>
        </table>
</asp:Content>