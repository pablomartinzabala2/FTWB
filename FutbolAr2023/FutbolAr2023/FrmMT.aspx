<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal1.Master" CodeBehind="FrmMT.aspx.vb" Inherits="FutbolAr2023.FrmMT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    frmfix<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="500px">
        <ajaxToolkit:TabPanel ID="TabEquipos" runat="server" HeaderText="Equipos">
            <ContentTemplate>
                 <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/images/buscar.png" />
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:GridView ID="Grilla" runat="server" AutoGenerateColumns="False" GridLines="None"
                                Width="530px">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" /></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IdEquipo" />
                                    <asp:BoundField DataField="Equipo" HeaderText="Equipo">
                                        <HeaderStyle HorizontalAlign="Left" Width="600px" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="HeaderGrilla" />
                                <RowStyle CssClass="RowGrilla" />
                                <AlternatingRowStyle CssClass="AlternativaRow" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel  ID="Tab2" runat ="server" >
            <HeaderTemplate>
                Posiciones 
            </HeaderTemplate>
            <ContentTemplate>
                <asp:GridView ID="Grilla2" runat="server" AutoGenerateColumns="False" 
                    GridLines="None" Width="530px">
                    <AlternatingRowStyle CssClass="AlternativaRow" />
                    <Columns>
                        <asp:BoundField DataField="IdEquipo">
                            <ItemStyle Width="0px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Pos" HeaderText="Pos" >
                              <ItemStyle Width="50px" />
                         </asp:BoundField>
                        <asp:BoundField DataField="Equipo" HeaderText="Equipo">
                            <HeaderStyle HorizontalAlign="Left" Width="300px" />
                            <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PTS" HeaderText="Pts" SortExpression="Pts">
                            <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PJ" HeaderText="Pj">
                        <ItemStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="G" HeaderText="G" >
                        <ItemStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="E" HeaderText="E" >
                        <ItemStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="P" HeaderText="P" >
                        <ItemStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="GF" HeaderText="Gf" >
                        <ItemStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="GC" HeaderText="Gc" >
                        <ItemStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="DIF" HeaderText="Dif" >
                        <ItemStyle Width="50px" />
                        </asp:BoundField>

                    </Columns>
                    <HeaderStyle CssClass="HeaderGrilla" />
                    <RowStyle CssClass="GridRow" />
                </asp:GridView>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tab3" runat ="server">
            <HeaderTemplate>
                Partidos
            </HeaderTemplate>
            <ContentTemplate>
                <asp:GridView ID="Grilla3" runat="server" AutoGenerateColumns="False" GridLines="None" Width="550px">
                    <Columns>
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" ShowHeader="False">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width ="30px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="local" HeaderText="Local">
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="gl">
                            <HeaderStyle Width="50px" HorizontalAlign ="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="gv">
                            <HeaderStyle Width="50px" HorizontalAlign ="Right"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="visitante" HeaderText="Visitante">
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="HeaderGrilla" />
                    <RowStyle CssClass="RowGrilla" />
                    <AlternatingRowStyle CssClass="AlternativaRow" />
                </asp:GridView>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
