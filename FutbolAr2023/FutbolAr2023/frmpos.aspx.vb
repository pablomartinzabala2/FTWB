Imports TablaDLL
Imports System.Data



Public Class frmpos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dv As New DataView()
        Dim tb As New Tabla()
        Dim id As Integer = Convert.ToInt32(Request.QueryString("Id"))
        Dim tabla As String = Request.QueryString("T")
        Dim tresul As DataTable
        Select Case tabla
            Case "G"
                dv = tb.TablaGral(id)
                GridView1.DataSource = dv
                GridView1.DataBind()
                trFechas.Visible = False
                lblTabla.Text = "Posiciones Generales"
            Case "Z"
                Dim zona As Integer
                zona = Convert.ToInt32(Request.QueryString("N"))
                dv = tb.TablaGralxZona(id, zona)
                GridView1.DataSource = dv
                GridView1.DataBind()
                trFechas.Visible = False
                lblTabla.Text = "Posiciones Generales"



            Case "L"
                lblTabla.Text = "Tabla de locales"
                tresul = tb.CargarTablaL(id)
                GridView1.DataSource = tresul
                GridView1.DataBind()
                trFechas.Visible = False
            Case "V"
                lblTabla.Text = "Tabla de Visitantes"
                tresul = tb.CargarTablaV(id)
                GridView1.DataSource = tresul
                GridView1.DataBind()
                trFechas.Visible = False
            Case "EF"
                lblTabla.Text = "Posiciones entre fechas"
                dv = tb.TablaGral(id)
                GridView1.DataSource = dv
                GridView1.DataBind()
                trFechas.Visible = True
        End Select
    End Sub

    Protected Sub btnconsultar_Click(sender As Object, e As EventArgs) Handles btnconsultar.Click
        Dim idtorneo As Integer
        idtorneo = Convert.ToInt32(Request.QueryString("Id"))
        Dim dv As New DataView()
        Dim tb As New Tabla()
        Dim desde, hasta As Integer
        desde = Convert.ToInt16(txtdesde.Text)
        hasta = Convert.ToInt16(txthasta.Text)
        Dim texto1 As String
        texto1 = "Posiciones entre la fecha " + txtdesde.Text + " y " + txthasta.Text
        lblTabla.Text = texto1
        dv = tb.cargarporfechas(idtorneo, desde, hasta)
        GridView1.DataSource = dv
        GridView1.DataBind()
        'lblTabla.Text = "Posiciones generales entre la fecha " & desde.ToString & " y " & hasta.ToString()
        'Dim oVisitas As New Visitas()
        'oVisitas.RegistrarVisitasPorItem(idtorneo, "PosicionesEntreFechas")
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As ImageClickEventArgs) Handles btnBuscar.Click
        Dim idtorneo As Integer
        idtorneo = Convert.ToInt32(Request.QueryString("Id"))
        Dim dv As New DataView()
        Dim tb As New Tabla()
        Dim desde, hasta As Integer
        desde = Convert.ToInt16(txtdesde.Text)
        hasta = Convert.ToInt16(txthasta.Text)
        Dim texto1 As String
        texto1 = "Posiciones entre la fecha " + txtdesde.Text + " y " + txthasta.Text
        lblTabla.Text = texto1
        dv = tb.cargarporfechas(idtorneo, desde, hasta)
        GridView1.DataSource = dv
        GridView1.DataBind()
        'lblTabla.Text = "Posiciones generales entre la fecha " & desde.ToString & " y " & hasta.ToString()
        'Dim oVisitas As New Visitas()
        'oVisitas.RegistrarVisitasPorItem(idtorneo, "PosicionesEntreFechas")
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header) Then
            e.Row.Cells(1).Visible = False
        End If
    End Sub
End Class