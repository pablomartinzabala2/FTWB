Imports TablaDLL

Public Class FrmRdoxfec2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Getinf()
        End If
    End Sub

    Private Sub Getinf()
        Dim t As DataTable
        Dim fecha As Integer
        Dim FecQueryStrin As Integer
        Dim IdTorneo As Integer
        IdTorneo = Convert.ToInt32(Request.QueryString("Id"))
        If IdTorneo = 0 Then
            IdTorneo = 35
        End If

        Dim idlocal, idvisitante As Integer
        Dim fix As New Fixture()
        FecQueryStrin = Convert.ToInt32(Request.QueryString("Fec"))

        Dim idpartido As Int32
        fecha = fix.MaxFecha(IdTorneo)
        fecha = fecha + 1

        If (FecQueryStrin = 0) Then
            t = fix.FixtureGetbyFecha(IdTorneo, fecha)
            Grilla.Columns(1).HeaderText = "Resultados de la fecha " + fecha.ToString()
        Else
            t = fix.FixtureGetbyFecha(IdTorneo, FecQueryStrin)
            Grilla.Columns(1).HeaderText = "Resultados de la fecha " + FecQueryStrin.ToString()
        End If

        Grilla.DataSource = t
        Grilla.DataBind()
        Dim i As Integer
        Dim imglocal, imgvisitante As Image
        Dim gl, gv, lblDetalleL, lblDetalleV As Label
        Dim lblDia As Label
        Dim local, visitante As Label
        For i = 0 To Grilla.Rows.Count - 1
            imglocal = Grilla.Rows(i).FindControl("ImgLocal")
            imgvisitante = Grilla.Rows(i).FindControl("ImgVisitante")
            'Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
            imglocal.ImageUrl = "~/Imagen/" + t.Rows(i)("FotoL").ToString()
            imgvisitante.ImageUrl = "~/Imagen/" + t.Rows(i)("FotoV").ToString()
            local = Grilla.Rows(i).FindControl("LblLocal")
            visitante = Grilla.Rows(i).FindControl("LblVisitante")
            local.Text = t.Rows(i)("Local").ToString()
            visitante.Text = t.Rows(i)("Visitante").ToString()
            gl =
                Grilla.Rows(i).FindControl("LblGl")
            gv = Grilla.Rows(i).FindControl("LblGv")
            If Convert.ToInt16(Grilla.Rows(i).Cells(4).Text) = 0 Then
                gl.Text = "-"
                gv.Text = "-"
            Else
                gl.Text = t.Rows(i)("Gl").ToString()
                gv.Text = t.Rows(i)("Gv").ToString()
            End If
            'Grilla.Rows(i).Cells(5).Text = Grilla.Rows(i).Cells(5).Text.Replace("", "")
            lblDia = Grilla.Rows(i).FindControl("lblDia")

            If Grilla.Rows(i).Cells(5).Text.Length > 3 Then
                lblDia.Text = GetDia(Grilla.Rows(i).Cells(5).Text)
            Else
                lblDia.Text = ""
            End If
        Next
        Dim j As Integer
        Dim tan As New Tantos()
        Dim t1 As DataTable
        Dim loc, vis As Label
        For i = 0 To Grilla.Rows.Count - 1
            'Grilla.Rows(i).FindControl("lblDetalleV")
            loc = Grilla.Rows(i).FindControl("lblLocal")
            vis = Grilla.Rows(i).FindControl("lblVisitante")
            If Trim(loc.Text) = Trim(vis.Text) Then
                loc.Text = "Libre"
                Dim ImgLoc As Image
                ImgLoc = Grilla.Rows(i).FindControl("ImgLocal")
                ImgLoc.Visible = False
            End If
            idpartido = Convert.ToInt32(Grilla.Rows(i).Cells(0).Text)
            idlocal = Convert.ToInt16(Grilla.Rows(i).Cells(2).Text)
            idvisitante = Convert.ToInt16(Grilla.Rows(i).Cells(3).Text)
            'lblDetalleL = Grilla.Rows(i).FindControl("lblDetalleL")
            'lblDetalleL.Text = ""
            'lblDetalleV = Grilla.Rows(i).FindControl("lblDetalleV")
            'lblDetalleV.Text = ""

            t1 = tan.GolesDetallados(idpartido)
            For j = 0 To t1.Rows.Count - 1
                If (idlocal.ToString() = t1.Rows(j)("IdEquipo").ToString()) Then
                    'lblDetalleL.Text = lblDetalleL.Text + " " + t1.Rows(j)("minuto").ToString()
                    'lblDetalleL.Text = lblDetalleL.Text + "-" + t1.Rows(j)("nombre").ToString()
                    If t1.Rows(j)("jugada").ToString() <> "Jugada" Then
                        'lblDetalleL.Text = lblDetalleL.Text + " (" + t1.Rows(j)("jugada").ToString() + ")"
                    End If
                    'lblDetalleL.Text = lblDetalleL.Text + vbCrLf   'vbNewLine
                    'lblDetalleL.Text = texto1
                End If
                If (idvisitante.ToString() = t1.Rows(j)("IdEquipo").ToString()) Then
                    'lblDetalleV = Grilla.Rows(i).FindControl("lblDetalleV")
                    'lblDetalleV.Text = lblDetalleV.Text + " " + t1.Rows(j)("minuto").ToString()
                    'lblDetalleV.Text = lblDetalleV.Text + "-" + t1.Rows(j)("nombre").ToString()
                    If t1.Rows(j)("jugada").ToString() <> "Jugada" Then
                        'lblDetalleV.Text = lblDetalleV.Text + " (" + t1.Rows(j)("jugada").ToString() + ")"
                    End If
                    'lblDetalleV.Text = lblDetalleV.Text + vbNewLine
                End If
            Next
        Next
    End Sub

    Protected Sub Grilla_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grilla.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header) Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
        End If
    End Sub
    Private Function GetDia(ByVal fecha As String) As String
        'fecha = fecha.Replace("-", "/")
        'Dim vec() As String = Split(fecha, "/")
        'Dim dia, mes, anio As String
        'Dim nombreDia As String = ""
        'Dim nombreMes As String = ""
        'dia = vec(0)
        'mes = vec(1)
        'anio = vec(2)
        'dia = Weekday(fecha)
        'Select Case dia
        '    Case 1
        '        nombreDia = "Domingo"
        '    Case 2
        '        nombreDia = "Lunes"
        '    Case 3
        '        nombreDia = "Martes"
        '    Case 4
        '        nombreDia = "Miércoles"
        '    Case 5
        '        nombreDia = "Jueves"
        '    Case 6
        '        nombreDia = "Viernes"
        '    Case 7
        '        nombreDia = "Sábado"
        'End Select
        'Select Case mes
        '    Case "1", "01"
        '        nombreMes = "Enero"
        '    Case "1", "01"
        '        nombreMes = "Enero"
        '    Case "2", "02"
        '        nombreMes = "Febrero"
        '    Case "3", "03"
        '        nombreMes = "Marzo"
        '    Case "4", "04"
        '        nombreMes = "Abril"
        '    Case "5", "05"
        '        nombreMes = "Mayo"
        '    Case "6", "06"
        '        nombreMes = "Junio"
        '    Case "7", "07"
        '        nombreMes = "Julio"
        '    Case "8", "08"
        '        nombreMes = "Agosto"
        '    Case "9", "09"
        '        nombreMes = "Septiembre"
        '    Case "10"
        '        nombreMes = "Octubre"
        '    Case "11"
        '        nombreMes = "Noviembre"
        '    Case "12"
        '        nombreMes = "Diciembre"
        'End Select
        'Dim fec As String
        'fec = nombreDia + " " + vec(0) + " de " + nombreMes + " " + anio
        Return ""
    End Function

End Class