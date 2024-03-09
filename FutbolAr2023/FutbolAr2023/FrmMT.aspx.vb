Imports TablaDLL


Public Class FrmMT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargargrilla()
        End If
    End Sub

    Private Sub cargargrilla()
        Dim equipo As New Equipo()
        Dim t As DataTable
        'Dim cat As Integer
        'cat = Convert.ToInt16(Session("Categoria"))
        't = equipo.EquiposGetAll(cat)
        Dim IdTorneo As Integer
        IdTorneo = Convert.ToInt16(Request.QueryString("Id"))
        t = equipo.EquiposGetbyEquiposxTorneo(IdTorneo)
        Grilla.DataSource = t
        Grilla.DataBind()
    End Sub

    Private Sub Obtener()
        Dim can As Integer
        can = 0

        'Dim x1 As CheckBox = GVitems.Rows(cnt - 1).Cells(2).FindControl("CKITEM")
        Dim i As Integer
        Dim vec As New Collection()

        'For i = 0 To Grilla.Rows.Count - 1
        ' Dim chk As CheckBox = Grilla.Rows(i).Cells(0).FindControl("chk")
        ' chk.Checked = True
        ' 'CheckBox chkbox1 = (CheckBox)row.FindControl("chkseleccion");
        ' Next

        For Each fila As GridViewRow In Grilla.Rows
            Dim chk As CheckBox = fila.FindControl("chk")
            If chk.Checked Then
                can = can + 1
                vec.Add(fila.Cells(1).Text)
            End If
        Next
        Dim vector(can) As Integer
        For i = 1 To vec.Count

            vector(i - 1) = Convert.ToInt16(vec.Item(i).ToString())
            'TextBox1.Text = TextBox1.Text + vector(i - 1).ToString() + "|"
        Next
        Dim idtorneo As Integer
        idtorneo = Convert.ToInt16(Request.QueryString("Id"))
        Dim TBL As New Tabla()
        Dim dt As New DataTable
        dt = TBL.MiniTorneos(vector, can, idtorneo)



        For i = 0 To dt.Rows.Count - 1
            dt.Rows(i)("Pos") = (i + 1).ToString()
        Next i

        't.DefaultView.Sort = "pts desc,DIF DESC"
        'dv = t.DefaultView
        'Dim dv1 As New DataView(t, "", "pts desc", DataViewRowState.CurrentRows)
        Grilla2.DataSource = dt
        Grilla2.DataBind()
        Dim fix As New Fixture()
        Dim dv2 As DataView
        dv2 = fix.GetFixtureByMinitorneo(vector, can, idtorneo)
        dv2.Sort = "fecha desc"
        Grilla3.DataSource = dv2
        Grilla3.DataBind()
        Dim oVisitas As New Visitas()
        oVisitas.RegistrarVisitasPorItem(idtorneo, "MiniTorneo")
    End Sub

    Protected Sub Grilla2_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles Grilla2.DataBound

    End Sub

    Protected Sub Grilla_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grilla.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header) Then
            e.Row.Cells(1).Visible = False
        End If
    End Sub

    Protected Sub Grilla3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grilla3.RowDataBound

    End Sub

    Protected Sub Grilla2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grilla2.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header) Then
            e.Row.Cells(0).Visible = False
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As ImageClickEventArgs) Handles btnBuscar.Click
        Obtener()
        TabContainer1.ActiveTabIndex = 1
    End Sub
End Class