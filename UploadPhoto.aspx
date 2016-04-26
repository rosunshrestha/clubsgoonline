<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadPhoto.aspx.cs" Inherits="clubsgoonline.UploadPhoto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>"
            DeleteCommand="DELETE FROM [photo] WHERE [id] = @id"
            InsertCommand="INSERT INTO [photo] ([photo_url], [photo_caption], [event_id], [taken_by_user], [uploaded_on], [alubm_id], [user_id], [club_id]) VALUES (@photo_url, @photo_caption, @event_id, @taken_by_user, @uploaded_on, @alubm_id, @user_id, @club_id)"
            SelectCommand="SELECT TOP 1 * FROM [photo] where club_id=@club_id order by uploaded_on desc"
            
            UpdateCommand="UPDATE [photo] SET [photo_url] = @photo_url, [photo_caption] = @photo_caption, [event_id] = @event_id, [taken_by_user] = @taken_by_user, [uploaded_on] = @uploaded_on, [alubm_id] = @alubm_id, [user_id] = @user_id, [club_id] = @club_id WHERE [id] = @id">
            <SelectParameters>
            <asp:ControlParameter Name="club_id" Type="String" ControlID="Label7" PropertyName ="Text" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:ControlParameter Name="photo_url" Type="String" ControlID="FileUpload2" PropertyName="FileName" />
                
                <asp:ControlParameter Name="photo_caption" Type="String" PropertyName="text" ControlID = "TextBox1"/>
                <asp:Parameter Name="event_id" Type="Int32" />
                <asp:ControlParameter Name="taken_by_user" Type="String" PropertyName="text" ControlID="Label2" />
                <asp:ControlParameter Name="uploaded_on" Type="DateTime" ControlID="Label3" PropertyName="text" />
                <asp:Parameter Name="alubm_id" Type="Int32" />
                <asp:ControlParameter Name="user_id" Type="String" PropertyName="Text" ControlID="Label6"/>
                <asp:ControlParameter Name="club_id" ControlID="Label7" PropertyName="text" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="photo_url" Type="String" />
                <asp:Parameter Name="photo_caption" Type="String" />
                <asp:Parameter Name="event_id" Type="Int32" />
                <asp:Parameter Name="taken_by_user" Type="String" />
                <asp:Parameter Name="uploaded_on" Type="String" />
                <asp:Parameter Name="alubm_id" Type="Int32" />
                <asp:Parameter Name="user_id" Type="Object" />
                <asp:Parameter Name="club_id" Type="Int32" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <b>Select a Photo to Upload</b>
    </div>
    <p>
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <asp:Button ID="BtnUpload" runat="server" OnClick="BtnUpload_Click" Text="Upload" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="Button1" runat="server" Text="View All Photos" OnClick="ViewAllPhotos" />
        <br />
        <br />

        <asp:TextBox ID="TextBox1" runat="server" TextWrapping="Wrap" Width="200px" Height="40px" AcceptsReturn="True"  VerticalScrollBarVisibility="Visible"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
        <br />Add Your Caption Here
    </p>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <asp:Label ID="Label6" runat="server" Visible="false"></asp:Label>
    </p>
    <p>
        <asp:DataList ID="DataList2" runat="server" DataKeyField="id" DataSourceID="SqlDataSource1"
            OnDeleteCommand="DataList2_DeleteCommand" RepeatColumns="2" 
            RepeatDirection="Horizontal">
            <ItemTemplate>
                &nbsp;<asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' visible="false"/>
                <br />
                
                <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("photo_url", "~/Images/{0}") %>'
                    Height="300px" AccessKey="p" BorderStyle="Inset" ImageAlign="Left" Width="400px" />
                <br />
                Caption:
                <asp:Label ID="photo_captionLabel" runat="server" 
                Text='<%# Eval("photo_caption") %>' />
                &nbsp;<asp:Label ID="event_idLabel" runat="server" Text='<%# Eval("event_id") %>' Visible="false" />
                <br />
                Uploaded By: <asp:Label ID="taken_by_userLabel" runat="server" Text='<%# Eval("taken_by_user") %>' />
                <br />
                Uploaded On:
                <asp:Label ID="uploaded_onLabel" runat="server" Text='<%# Eval("uploaded_on") %>' />
                <br />
                <asp:Label ID="alubm_idLabel" runat="server" Text='<%# Eval("alubm_id") %>' visible ="false" />
                <asp:Label ID="user_idLabel" runat="server" Text='<%# Eval("user_id") %>' visible="false"/>
                <br />
                <asp:Label ID="club_idLabel" runat="server" Text='<%# Eval("club_id") %>' visible="false" />
                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete"                
                    OnClientClick="javascript:return confirm('Are you sure!!!\nYou want to delete the record permanently?');" 
                    >Delete</asp:LinkButton>

            </ItemTemplate>
        </asp:DataList>
    </p>
    <p>
        &nbsp;</p>
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">&lt;&lt;Prev</asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Next&gt;&gt;</asp:LinkButton>
</asp:Content>
