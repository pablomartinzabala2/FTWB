Imports System.Data
Imports TablaDLL


Public Class WFormGl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("Usuario") Is Nothing Then
            Response.Redirect("Log.aspx")
        End If
        If Not IsPostBack Then
            CargarTorneo()
        End If
    End Sub

    Private Sub CargarTorneo()
        Dim obj As New Torneo()
        cmbTorneo.DataSource = obj.TorneoAll()
        cmbTorneo.DataValueField = "IdTorneo"
        cmbTorneo.DataTextField = "Torneo"
        cmbTorneo.DataBind()
    End Sub

    Protected Sub btnDiferencias_Click(sender As Object, e As EventArgs) Handles btnDiferencias.Click
        GrabarDiferencias(Convert.ToInt32(txtDiferencias.Text))
    End Sub

    Private Sub GrabarDiferencias(ByVal IdTorneo As Integer)
        Dim obj As New Tabla()
        obj.BorrarDiferencias(IdTorneo)
        obj.BorrarDiferencias(Convert.ToInt32(IdTorneo.ToString()))
        obj.GrabarRegistrosDiferencias(IdTorneo, "GanoL", "Menor", "Menor cantidad de triunfos de local ", "GanoV", "Menor cantidad de triunfos visitanes")
        obj.GrabarRegistrosDiferencias(IdTorneo, "GanoL", "Mayor", "Mayor cantidad de triunfos de local ", "GanoV", "Mayor cantidad de triunfos visitanes")
        obj.GrabarRegistrosDiferencias(IdTorneo, "EmpateL", "Mayor", "Mayor cantidad de empates de Local", "EmpateV", "Mayor cantidad de empates de Visitantes")
        obj.GrabarRegistrosDiferencias(IdTorneo, "EmpateL", "Menor", "Menor cantidad de empates de Local", "EmpateV", "Menor cantidad de empates de Visitantes")
        obj.GrabarRegistrosDiferencias(IdTorneo, "Gl", "Mayor", "Mayor Cantidad de goles de local a favor", "Gv", "Mayor Cantidad de goles visitantes")
        obj.GrabarRegistrosDiferencias(IdTorneo, "Gv", "Menor", "Menor Cantidad de goles de local en contra", "Gl", "Menor Cantidad de goles en contra de visitantes")
        obj.GrabarRegistrosDiferencias(IdTorneo, "Pl", "Mayor", "Mas puntos de local", "Pv", "Mas puntos de visitante")
        obj.GrabarRegistrosDiferencias(IdTorneo, "PerdioL", "Mayor", "Mas partidos perdidos de local", "PerdioV", "Mas partidos Perdidos de Visitante")
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim opartido As New Partido()
        Dim s As String
        Dim IdPartido As Integer
        Dim dif, gl, gv, pl, pv As Integer
        Dim GanoL, GanoV, EmpateL, EmpateV, PerdioL, PerdioV As Integer
        For Each fila As GridViewRow In Grilla.Rows
            Dim txtgl As TextBox = fila.FindControl("txtgl")
            Dim txtgv As TextBox = fila.FindControl("txtgv")
            Dim txtNumeroFecha As TextBox = fila.FindControl("txtNumeroFecha")
            s = fila.Cells(8).Text
            If fila.Cells(8).Text = "0" Then
                If txtgl.Text <> "" Then
                    IdPartido = Convert.ToInt32(fila.Cells(0).Text)
                    gl = Convert.ToInt16(txtgl.Text)
                    gv = Convert.ToInt32(txtgv.Text)
                    dif = gl - gv
                    If dif > 0 Then
                        pl = 3
                        pv = 0
                        GanoL = 1
                        GanoV = 0
                        EmpateL = 0
                        EmpateV = 0
                        PerdioL = 0
                        PerdioV = 1
                    End If
                    If dif < 0 Then
                        pl = 0
                        pv = 3
                        GanoL = 0
                        GanoV = 1
                        EmpateL = 0
                        EmpateV = 0
                        PerdioL = 1
                        PerdioV = 0
                    End If
                    If dif = 0 Then
                        pl = 1
                        pv = 1
                        GanoL = 0
                        GanoV = 0
                        EmpateL = 1
                        EmpateV = 1
                        PerdioL = 0
                        PerdioV = 0
                    End If
                    If (txtNumeroFecha.Text <> "") Then
                        opartido.CargarResultado(IdPartido, gl, gv, pl, pv, GanoL, GanoV, EmpateL, EmpateV, PerdioL, PerdioV, txtNumeroFecha.Text)
                    End If

                End If
            End If
        Next
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim idtorneo As Integer
        idtorneo = Convert.ToInt32(txttorneo.Text)
        Dim obj As New Fixture()
        Dim t As DataTable
        Dim i, j As Integer
        t = obj.GetFixtureParaSimular(idtorneo)
        For i = 0 To t.Rows.Count - 1
            If t.Rows(i)("IdLocal").ToString() = t.Rows(i)("idvisitante").ToString() Then
                t.Rows(i).Delete()
            End If
        Next
        Grilla.DataSource = t
        Grilla.DataBind()
        Dim b As Integer
        b = 0
        Dim IdLocal As Integer
        Dim txtgl, txtgv As TextBox
        Dim lblgl, lblgv As Label
        Dim fechapartido As String

        For i = 0 To Grilla.Rows.Count - 1
            IdLocal = Convert.ToInt16(Grilla.Rows(i).Cells(1).Text)
            txtgl = Grilla.Rows(i).FindControl("txtgl")
            txtgv = Grilla.Rows(i).FindControl("txtgv")
            lblgl = Grilla.Rows(i).FindControl("lblgl")
            lblgv = Grilla.Rows(i).FindControl("lblgv")
            fechapartido = Grilla.Rows(i).Cells(7).Text
            For j = 0 To t.Rows.Count - 1
                If (IdLocal = Convert.ToInt16(t.Rows(i)("idlocal"))) And fechapartido.Length > 7 Then
                    lblgl.Text = t.Rows(i)("gl").ToString()
                    lblgv.Text = t.Rows(i)("gv").ToString()
                    txtgl.Visible = False
                    txtgv.Visible = False
                End If
            Next
        Next
        For i = 0 To Grilla.Rows.Count - 1
            txtgl = Grilla.Rows(i).FindControl("txtgl")
            txtgv = Grilla.Rows(i).FindControl("txtgv")
            lblgl = Grilla.Rows(i).FindControl("lblgl")
            lblgv = Grilla.Rows(i).FindControl("lblgv")
            fechapartido = Grilla.Rows(i).Cells(7).Text
            If fechapartido.Length > 7 Then
                txtgl.Visible = False
                txtgv.Visible = False
            Else
                lblgl.Visible = False
                lblgv.Visible = False
                txtgl.Text = ""
                txtgv.Text = ""
            End If
        Next
    End Sub
End Class