<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal1.Master" CodeBehind="FrmRdoxfec2.aspx.vb" Inherits="FutbolAr2023.FrmRdoxfec2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="Grilla" runat="server" AutoGenerateColumns="False" Width="540px">
    <RowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="IdPartido" />
        <asp:TemplateField>
            <ItemTemplate>
                <table>
                    <tr>
                        <td align="center" colspan="6" height="25px" style="background-color: #FFFFCC;">
                            <asp:Label ID="lblDia" runat="server" ForeColor="Black" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width : 25px; background-color: #FFFFFF;"></td>
                        <td align="center" bgcolor="White" style="width : 250px">
                            <asp:Image ID="ImgLocal" runat="server" Height="25px" Width="25px" />
                        </td>
                        <td align="center" bgcolor="White" rowspan="2" style="width : 25px">
                            <asp:Label ID="lblGl" runat="server" BackColor="White" Font-Size="Large" ForeColor="Black" Text="Label"></asp:Label>
                        </td>
                        <td align="center" bgcolor="White" rowspan="2" style="width : 25px">
                            <asp:Label ID="lblGv" runat="server" Font-Size="Large" ForeColor="Black" Text="Label"></asp:Label>
                        </td>
                        <td align="center" bgcolor="White" style="width : 250px">
                            <asp:Image ID="ImgVisitante" runat="server" Height="25px" Width="25px" />
                        </td>
                        <td style="width : 25px; background-color: #FFFFFF;"></td>
                    </tr>
                    <tr>
                        <td style="width : 25px; background-color: #FFFFFF;"></td>
                        <td align="center" bgcolor="White" style="width : 200px">
                            <asp:Label ID="lblLocal" runat="server" ForeColor="Black" Text="Label"></asp:Label>
                        </td>
                        <td align="center" bgcolor="White" style="width : 250px">
                            <asp:Label ID="lblVisitante" runat="server" ForeColor="Black" Text="Label"></asp:Label>
                        </td>
                        <td style="width : 25px; background-color: #FFFFFF;"></td>
                    </tr>
                </table>
                <HR/>
            </ItemTemplate>
            <HeaderStyle Font-Size="Medium" ForeColor="#FFFFFF" HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:BoundField DataField="idlocal" />
        <asp:BoundField DataField="idvisitante" />
        <asp:BoundField DataField="jugo" />
        <asp:BoundField DataField="fechapartido" />
    </Columns>
    <HeaderStyle CssClass="HeaderGrilla" />
    <RowStyle CssClass="GridRow" />
    <AlternatingRowStyle CssClass="AlternativaRow" />
</asp:GridView>
</asp:Content>
