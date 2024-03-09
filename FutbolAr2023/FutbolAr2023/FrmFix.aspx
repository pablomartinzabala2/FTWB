<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal1.Master" CodeBehind="FrmFix.aspx.vb" Inherits="FutbolAr2023.FrmFix" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <asp:Literal ID="Label1" runat="server"></asp:Literal>
</div>
 <div>
     <asp:GridView ID="Grilla" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" BackColor="White" BorderStyle="Solid" 
    BorderWidth="1px" CellPadding="5" CellSpacing="3" GridLines="None" 
    Height="25px" AllowSorting="True">
    <RowStyle  Height="25px" />
    <Columns>
        <asp:BoundField DataField="idpartido">
        <ItemStyle Font-Bold="False" />
        </asp:BoundField>
        <asp:BoundField DataField="idlocal">
        <ItemStyle />
        </asp:BoundField>
        <asp:BoundField DataField="Local" HeaderText="Local">
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle Width="220px" />
        </asp:BoundField>
        <asp:BoundField DataField="Gl">
        <ItemStyle HorizontalAlign="Center" Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="idVisitante">
        <ItemStyle />
        </asp:BoundField>
        <asp:BoundField DataField="Visitante" HeaderText="Visitante">
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle Width="220px" />
        </asp:BoundField>
        <asp:BoundField DataField="Gv">
        <ItemStyle HorizontalAlign="Center" Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="FechaPartido" HeaderText="Fecha">
        <ItemStyle Width="50px" />
        <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="jugo">
        <ItemStyle Font-Bold="False" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Info">
            <ItemTemplate>
                <asp:ImageButton ID="btnInfo" runat="server" Height="20px" 
                    ImageUrl="~/Imagen/pelota.jpg" OnClick="btnInfo_Click" Width="20px" />
            </ItemTemplate>
            <ItemStyle Font-Bold="False" />
        </asp:TemplateField>
    </Columns>
    <FooterStyle />
   
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <HeaderStyle   CssClass="GridHeader" />
</asp:GridView>
 </div>
</asp:Content>
