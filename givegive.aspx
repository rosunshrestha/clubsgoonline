<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="givegive.aspx.cs" Inherits="clubsgoonline.givegive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>" 
            DeleteCommand="DELETE FROM [picture] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [picture] ([url]) VALUES (@url)" 
            SelectCommand="SELECT [url], [id] FROM [picture]" 
            UpdateCommand="UPDATE [picture] SET [url] = @url WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="url" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="url" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
        <br />
        <br />
        <asp:DataList ID="DataList1" runat="server" DataKeyField="id" 
            DataSourceID="SqlDataSource2" style="margin-right: 4px">
            <ItemTemplate>
                url:<asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("url","~/Images/{0}") %>' />
                <br />
                id:
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>" 
            SelectCommand="SELECT [url], [id] FROM [picture] WHERE ([id] = @id) ORDER BY [id]">
            <SelectParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
