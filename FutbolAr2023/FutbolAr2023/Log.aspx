<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Log.aspx.vb" Inherits="FutbolAr2023.Log" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
        <tr>
            <td style ="width :100px">
                <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label></td>
            <td style ="width :100px">
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style ="width :100px">
                <asp:Label ID="Label2" runat="server" Text="password"></asp:Label></td>
            <td style ="width :100px">
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td style ="width :100px">
                <asp:ImageButton ID="ImageButton1" runat="server" />
            </td>
            <td style ="width :100px">
                <asp:Button ID="btnEntrar" runat="server" Text="Entrar" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
