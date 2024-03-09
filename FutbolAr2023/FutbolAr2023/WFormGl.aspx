<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal1.Master" CodeBehind="WFormGl.aspx.vb" Inherits="FutbolAr2023.WFormGl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style ="width :500px">
<tr>
<td>
    <asp:TextBox ID="txttorneo" runat="server"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Button" />
    </td>
</tr>
<tr>
<td>
    <asp:GridView ID="Grilla" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Calibri"
        GridLines="None">
        <RowStyle BackColor="#E0E0E0" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
            ForeColor="#330099" Height="1px" />
        <Columns>
            <asp:BoundField DataField="idpartido" />
            <asp:BoundField DataField="idlocal" />
            <asp:BoundField DataField="local" HeaderText="Local">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="204px" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="txtgl" runat="server" Font-Bold="True" Width="20px"></asp:TextBox>
                    <asp:Label ID="lblgl" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="idvisitante" />
            <asp:BoundField DataField="visitante" HeaderText="Visitante">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="202px" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="txtgv" runat="server" Font-Bold="True" Width="20px"></asp:TextBox>
                    <asp:Label ID="lblgv" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="fechapartido" />
            <asp:BoundField DataField="Jugo" />
            <asp:TemplateField HeaderText="Fecha">
                <ItemTemplate>
                    <asp:TextBox ID="txtNumeroFecha" runat="server" BorderColor="#FFCC66" 
                        Width="80px"></asp:TextBox>
                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField></asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" Font-Size="XX-Small" ForeColor="#330099" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <HeaderStyle BackColor="#336699" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Small"
            ForeColor="#FFFFCC" />
        <AlternatingRowStyle BackColor="White" ForeColor="Black" />
    </asp:GridView>

</td>
</tr>
<tr>
<td>
<asp:Button ID="BtnGuardar" runat="server" Text="Guardar" />
</td>
</tr>
<tr>
<td>
    <asp:DropDownList ID="cmbTorneo" runat="server" Width="150px">
    </asp:DropDownList>
    <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
    <asp:Button ID="btnRendimiento" runat="server" Text="Rendimiento" />
</td>
</tr>
<tr>
    <td>
        <asp:TextBox ID="txtDiferencias" runat="server"></asp:TextBox>
        <asp:Button ID="btnDiferencias" runat="server" Text="Diferencias" />
    </td>
</tr>
</table>
</asp:Content>
