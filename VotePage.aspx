<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VotePage.aspx.cs" Inherits="CatMash.VotePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body bgcolor="edf0f0">
    <form id="form1" runat="server">
        <div>
            <center>
            <img src="catmash.jpg" />
        </center>
        </div>
        <br />
        <br />
        <br />
        <div>
        <center>
        <asp:Label ID="Label1" runat="server" Text="Votez pour votre chat préféré."></asp:Label>
        <table>
        <tr>
            <td><asp:Image ID="Image1" runat="server" width="200"  Height="200"/><br /><asp:RadioButton ID="RBVote1" GroupName="cats" runat="server" OnCheckedChanged="RBVote1_CheckedChanged" Text="Voter pour le premier chat " AutoPostBack="true"></asp:RadioButton></td>
            <td><asp:Image ID="Image2" runat="server" width="200"  Height="200" /><br /><asp:RadioButton ID="RBVote2" GroupName="cats" runat="server" OnCheckedChanged="RBVote2_CheckedChanged" Text="Voter pour le deuxième chat" AutoPostBack="true"></asp:RadioButton></td>
        </tr>
        </table>
        <table>
          <tr><td><center><asp:Button ID="BtnToResults" runat="server" Text="Accéder à la page des résultats" OnClick="BtnToResults_Click" /></center></td></tr>
        </table>
        </center>
            <br />

        </div>
        
    </form>
</body>
</html>
