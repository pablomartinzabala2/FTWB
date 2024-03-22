<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal1.Master" CodeBehind="frmpos.aspx.vb" Inherits="FutbolAr2023.frmpos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr id="trFechas" runat="server" visible="false">
            <td style="width: 500px" valign="top">
                <table border="0">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri"
                                Font-Size="Small" ForeColor="#336699" Text="Fecha desde"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtdesde" runat="server" Height="15px" Width="50px"
                                BackColor="#FFCC66"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Calibri"
                                Font-Size="Small" ForeColor="#336699" Text="Fecha hasta"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txthasta" runat="server" Height="15px" Width="50px"
                                BackColor="#FFCC66"></asp:TextBox>
                        </td>
                        <td valign="middle" style="width: 81px">
                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/images/buscar.png" />
                        </td>
                        <td>

                            <asp:Label ID="lblMensaje" runat="server" CssClass="GridHeader"></asp:Label>

                        </td>
                    </tr>
                </table>

                <asp:Button ID="btnconsultar" runat="server" Text="Consultar" BackColor="#C00000" Font-Bold="True" ForeColor="White" Visible="False" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTabla" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="False" GridLines="None" Style="margin-top: 0px">
                    <Columns>
                        <asp:BoundField DataField="pos" HeaderText="Pos">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="idequipo">
                            <ItemStyle Font-Bold="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="equipo"  HeaderText="Equipo">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="360px" Font-Bold="true" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PTS" HeaderText="Pts">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="25px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PJ" HeaderText="Pj">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="25px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="G" HeaderText="G">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="25px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="E" HeaderText="E">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="25px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="P" HeaderText="P">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="25px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GF" HeaderText="Gf">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="25px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GC" HeaderText="Gc">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="25px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DIF" HeaderText="Dif">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="25px" HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="HeaderGrilla" />
                    <RowStyle CssClass="GridRow" />

                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
