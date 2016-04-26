<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="clubsgoonline.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        Fill The Event Details Below</p>
    <p>
        Event Name:&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        Event Start Time:&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Event End Time:
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
    <p>
        Event Start Date:&nbsp;
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Event End Date:&nbsp;
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </p>
    <p>
        Event Description:<br />
&nbsp;<asp:TextBox ID="TextBox6" runat="server" Height="300px" TextMode="MultiLine" 
            Width="500px"></asp:TextBox>
    </p>
    <p>
        Event Related Photo:<br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Create Event" 
             />
    </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cgo_dataConnectionString %>" 
            DeleteCommand="DELETE FROM [event] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [event] ([event_name], [event_start_date], [event_start_time], [event_end_time], [event_end_date], [club_id], [event_description], [event_creator_user], [event_photo]) VALUES (@event_name, @event_start_date, @event_start_time, @event_end_time, @event_end_date, @club_id, @event_description, @event_creator_user, @event_photo)" 
            SelectCommand="SELECT * FROM [event]" UpdateCommand="UPDATE [event] SET [event_name] = @event_name, [event_start_date] = @event_start_date, [event_start_time] = @event_start_time, [event_end_time] = @event_end_time, [event_end_date] = @event_end_date, [club_id] = @club_id, [event_description] = @event_description, [event_creator_user] = @event_creator_user, [event_photo] = @event_photo WHERE [id] = @id" 
            >
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:ControlParameter Name="event_name" Type="String" ControlID="TextBox1" PropertyName="text" />
                <asp:ControlParameter Name="event_start_date" ControlID="TextBox4" PropertyName="text" Type="String" />
                <asp:ControlParameter Name="event_start_time" ControlID="TextBox2" PropertyName="text" Type="String" />
                <asp:ControlParameter Name="event_end_time" ControlID="TextBox3" PropertyName="text" Type="String" />
                <asp:ControlParameter Name="event_end_date" ControlID="TextBox5" PropertyName="text" Type="String" />
                <asp:Parameter Name="club_id" Type="Int32" />
                <asp:ControlParameter Name="event_description" ControlID="TextBox6" PropertyName="Text" Type="String" />
                <asp:Parameter Name="event_creator_user" Type="Object"/>
                <asp:ControlParameter Name="event_photo" Type="String" ControlID="FileUpload1" PropertyName="FileName"/>
                <asp:Parameter Name="id" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:ControlParameter Name="event_name" Type="String" />
                <asp:ControlParameter Name="event_start_date" Type="String" />
                <asp:ControlParameter Name="event_start_time" Type="String" />
                <asp:ControlParameter Name="event_end_time" Type="String" />
                <asp:ControlParameter Name="event_end_date" Type="String" />
                <asp:Parameter Name="club_id" Type="Int32" />
                <asp:ControlParameter Name="event_description" Type="String" />
                <asp:Parameter Name="event_creator_user" Type="Object" />
                <asp:ControlParameter Name="event_photo" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>

</asp:Content>
