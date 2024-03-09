<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal1.Master" CodeBehind="frmInfo.aspx.vb" Inherits="FutbolAr2023.frmInfo" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div>
     <table style="width: 480px">
        <tr>
            <td colspan="2" style="background-color: #336699 height :20px">
                <asp:Label ID="LblNombre2" runat="server" ForeColor="White" Text="Independiente"
                    Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 85px">
                <asp:Image ID="IMG" runat="server" Height="80px" ImageUrl="" Width="80px" />
            </td>
            <td style="width: 415px" align="left" valign="top">
                <table style="width: 400px" border="0">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" CssClass="entry" runat="server" Text="Nombre Oficial:   "
                                Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblNombre" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="Fundación: " Font-Bold="True" Font-Size="Small"></asp:Label><asp:Label
                                ID="lblfundacion" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label3" runat="server" Text="Estadio: " Font-Bold="True" Font-Size="Small"></asp:Label><asp:Label
                                ID="lblestadio" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px" colspan="2">
                            <asp:Label ID="Label4" runat="server" Text="Capacidad: " Font-Bold="True" Font-Size="Small"></asp:Label><asp:Label
                                ID="lblcapacidad" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px" colspan="2">
                            <asp:Label ID="Label5" runat="server" Text="Ubicación: " Font-Bold="True" Font-Size="Small"></asp:Label><asp:Label
                                ID="lblubicacion" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
     </table>>
</div>
<div>
    <ajaxToolkit:TabContainer  ID ="tab" runat="server" Width="500px" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel ID ="Panel1" runat="server">
            <HeaderTemplate>Fixture</HeaderTemplate>
            <ContentTemplate>
                <asp:GridView ID="Grilla" Width="500px" runat="server" AutoGenerateColumns="False"
                                GridLines="None"><AlternatingRowStyle CssClass="AlternativaRow" /><Columns>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="Rival" HeaderText="Rival"></asp:BoundField>
                                <asp:BoundField DataField="G" HeaderText="G"></asp:BoundField>
                                <asp:BoundField DataField="E" HeaderText="E"></asp:BoundField>
                                <asp:BoundField DataField="P" HeaderText="P"></asp:BoundField>
                                <asp:BoundField DataField="CONDICION" HeaderText="Cond"></asp:BoundField></Columns><HeaderStyle CssClass="HeaderGrilla" /><RowStyle CssClass="GridRow" /></asp:GridView>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID ="Panel2" runat ="server">
            <HeaderTemplate>
                Resumen
            </HeaderTemplate>
            <ContentTemplate>
                <table><tr><td>
                        <asp:GridView ID="Grilla2" runat="server" AutoGenerateColumns="False" GridLines="None"><AlternatingRowStyle CssClass="AlternativaRow" />
                        <Columns><asp:BoundField DataField="Condicion" 
                        HeaderText="Condicion">
                        <HeaderStyle Width="250px" HorizontalAlign="Left" />
                        <ItemStyle Width="30px" Height="8px" /></asp:BoundField><asp:BoundField DataField="PTS2" HeaderText="Pts"></asp:BoundField><asp:BoundField DataField="pj" HeaderText="Pj"><HeaderStyle HorizontalAlign="Center" /><ItemStyle Width="30px" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="g" HeaderText="G"><HeaderStyle HorizontalAlign="Center" /><ItemStyle Width="30px" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="e" HeaderText="E"><HeaderStyle HorizontalAlign="Center" /><ItemStyle Width="30px" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="p" HeaderText="P"><HeaderStyle HorizontalAlign="Center" /><ItemStyle Width="30px" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="gf" HeaderText="Gf"><HeaderStyle HorizontalAlign="Center" /><ItemStyle Width="30px" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="gc" HeaderText="Gc"><HeaderStyle HorizontalAlign="Center" /><ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle></asp:BoundField><asp:BoundField DataField="DIF" HeaderText="Dif"><HeaderStyle HorizontalAlign="Center" /><ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle></asp:BoundField><asp:BoundField DataField="POR" HeaderText="%"></asp:BoundField></Columns><HeaderStyle CssClass="HeaderGrilla" /><RowStyle CssClass="GridRow" /></asp:GridView></td></tr><tr><td>
                        <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblNombre3" runat="server" Font-Bold="True">Local</asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblNombre4" runat="server" Font-Bold="True">Visitante</asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblNombre5" runat="server" Font-Bold="True">General</asp:Label>
                            </td>
                        </tr>
                        <tr>
                        <td style="vertical-align:top">
                        <asp:GridView ID="GrillaResumenLocal" runat="server" AutoGenerateColumns="False" GridLines="None"><AlternatingRowStyle CssClass="AlternativaRow" /><Columns>
                            <asp:BoundField DataField="RESULTADO" HeaderText="Res"></asp:BoundField><asp:BoundField 
                                DataField="FRECUENCIA" HeaderText="Total"></asp:BoundField><asp:BoundField DataField="VEP"></asp:BoundField>
                            <asp:BoundField DataField="POR" HeaderText="%" />
                            </Columns><HeaderStyle CssClass="HeaderGrilla" /><RowStyle CssClass="GridRow" /></asp:GridView></td><td valign="top" ><asp:GridView ID="GrillaResumenVisitante" runat="server" 
                                                AutoGenerateColumns="False" GridLines="None"><AlternatingRowStyle CssClass="AlternativaRow" /><Columns>
                                    <asp:BoundField DataField="RESULTADO" HeaderText="Res" /><asp:BoundField 
                                        DataField="FRECUENCIA" HeaderText="Total" /><asp:BoundField DataField="VEP" />
                                    <asp:BoundField DataField="POR" HeaderText="%" />
                                </Columns><HeaderStyle CssClass="HeaderGrilla" /><RowStyle CssClass="GridRow" /></asp:GridView></td>
                                        <td>
                                        <asp:GridView ID="GrillaResumenGeneral" runat="server" 
                                                AutoGenerateColumns="False" GridLines="None"><AlternatingRowStyle CssClass="AlternativaRow" /><Columns>
                                                <asp:BoundField DataField="RESULTADO" HeaderText="Res" /><asp:BoundField 
                                        DataField="FRECUENCIA" HeaderText="Total" /><asp:BoundField DataField="VEP" />
                                                <asp:BoundField DataField="POR" HeaderText="%" />
                                            </Columns><HeaderStyle CssClass="HeaderGrilla" /><RowStyle CssClass="GridRow" /></asp:GridView>
                                        </td></tr></table></td></tr></table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID ="Panel3" runat ="server">
            <HeaderTemplate>Grafico

            </HeaderTemplate>
            <ContentTemplate>
                <asp:Chart ID="Chart1" runat="server">
    <series>
        <asp:Series Name="Series1">
        </asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </chartareas>
</asp:Chart>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</div>
</asp:Content>
