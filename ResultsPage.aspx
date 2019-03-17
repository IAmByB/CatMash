<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultsPage.aspx.cs" Inherits="CatMash.ResultsPage" %>

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
        <asp:Label ID="Label1" runat="server" Text="Résultats du vote."></asp:Label>
            <br />
         <table>
          <tr><td><center><asp:Button ID="BtnBackToVote" runat="server" Text="Retour à la page de vote" OnClick="BtnBackToVote_Click" /></center></td></tr>
        </table>
    </form>
</body>
</html>
