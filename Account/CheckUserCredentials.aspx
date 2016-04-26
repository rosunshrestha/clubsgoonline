<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckUserCredentials.aspx.cs" Inherits="clubsgoonline.Account.CheckUserCredentials" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <p>
       <b>KU Registered Name:</b> &nbsp;&nbsp; &nbsp; Your Class Name   <br /> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       </p>
       <p>
       <b>KU Registratoin Code:</b> &nbsp;&nbsp; &nbsp; Code in ID Card     <br /> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          <br /> <asp:Button ID="Button1" runat="server" Text="Validate Registration" 
               onclick="Button1_Click" />
       </p>

        
    
    </div>
    </form>
</body>
</html>
