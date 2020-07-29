<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="publier_adminUI.aspx.cs" Inherits="recrutement.publication.publier_adminUI" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="asp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Votre publicite ici"></asp:Label><br /><br />

        <asp:Label runat="server" Font-Bold="true" ForeColor="Yellow" BackColor="Black" >Titre de votre publicite</asp:Label><br />
        <asp:TextBox runat="server" Font-Bold="true" Width="700px" Height="37px"></asp:TextBox>
           <br /><br /><br />
        &nbsp;&nbsp
        <br />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Width="141px" />
        <br />
        <br />
        <br />
        <asp:Label ID="showPub" runat="server" Width="200px"></asp:Label>
    </form>
</body>
</html>
