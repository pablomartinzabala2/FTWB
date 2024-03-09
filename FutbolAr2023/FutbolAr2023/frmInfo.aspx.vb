Imports TablaDLL

Public Class frmInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            traer()
            Graficar()
        End If
    End Sub

    Private Sub traer()
        Dim eq As New Equipo()
        Dim idequipo, IdTorneo As Integer
        idequipo = Convert.ToInt32(Request.QueryString("idEq"))
        IdTorneo = Convert.ToInt32(Request.QueryString("Id"))
        CargaResumenLocalVisitante(idequipo, IdTorneo)
        Dim t As DataTable
        t = eq.EquipoGetbyId(idequipo)
        LblNombre2.Text = t.Rows(0)("equipo").ToString()
        lblNombre.Text = t.Rows(0)("NombreOficial").ToString()
        lblfundacion.Text = t.Rows(0)("Fundacion").ToString()
        lblestadio.Text = t.Rows(0)("Estadio").ToString()
        lblcapacidad.Text = t.Rows(0)("Capacidad").ToString()
        lblubicacion.Text = t.Rows(0)("Ubicacion").ToString()
        IMG.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
        Dim fix As New Fixture()
        t = fix.FixtureGetbyEquipo(IdTorneo, idequipo)
        ArmarFixture(idequipo, t)
        ' Grilla.DataSource = t
        'Grilla.DataBind()
        Dim tb As New Tabla()
        Dim i As Integer
        t = tb.TablaResumida(IdTorneo, idequipo)
        t.Columns.Add("PTS2")
        t.Columns.Add("POR")
        Dim G, E, P As Integer
        Dim PORC1, PORC2, PORC3 As String
        Dim POR As Decimal
        For i = 0 To t.Rows.Count - 1
            G = Convert.ToInt16(t.Rows(i)("G"))
            E = Convert.ToInt16(t.Rows(i)("E"))
            P = 3 * G + E
            t.Rows(i)("PTS2") = P
        Next
        PORC1 = ((t.Rows(0)("PTS2") * 100) / (Convert.ToInt16(t.Rows(0)("PJ")) * 3)).ToString()
        PORC1 = Mid(PORC1, 1, 5)
        t.Rows(0)("POR") = PORC1
        PORC2 = ((t.Rows(1)("PTS2") * 100) / (Convert.ToInt16(t.Rows(1)("PJ")) * 3)).ToString()
        PORC2 = Mid(PORC2, 1, 5)
        PORC3 = ((t.Rows(2)("PTS2") * 100) / (Convert.ToInt16(t.Rows(2)("PJ")) * 3)).ToString()
        t.Rows(1)("POR") = PORC2
        t.Rows(2)("POR") = Mid(PORC3, 1, 5)
        Grilla2.DataSource = t
        Grilla2.DataBind()

    End Sub

    Private Sub Graficar()
        Dim y1 As New ArrayList()
        Dim x1 As New ArrayList()
        Dim rec As New Rendimiento()
        Dim IdEquipo As Integer = Convert.ToInt32(Request.QueryString("idEq"))
        Dim IdTorneo As Integer = Convert.ToInt32(Request.QueryString("Id"))
        Dim t As DataTable = rec.GetRendimientoxEquipo(IdEquipo, IdTorneo)
        Dim i As Integer
        Dim b As Integer = 0
        Dim pos As Integer
        For i = 0 To t.Rows.Count - 1
            x1.Add(t.Rows(i)("fecha").ToString())
            pos = Convert.ToInt32(t.Rows(i)("Posicion").ToString())
            y1.Add(pos)
            b = 1
        Next
        If b = 1 Then
            Chart1.Series("Series1").Points.DataBindXY(x1, y1)
        End If

    End Sub

    Private Sub CargaResumenLocalVisitante(ByVal IdEquipo As Integer, ByVal IdTorneo As Integer)
        Dim i As Integer
        Dim obj As New Resumen()
        Dim tbLocal As New DataTable
        tbLocal = obj.GetResumenxEquipoLocal(IdEquipo, IdTorneo)
        Dim tb As New DataTable
        tb.Columns.Add("RESULTADO")
        tb.Columns.Add("FRECUENCIA")
        tb.Columns.Add("VEP")
        tb.Columns.Add("POR")
        Dim vep As String = ""
        Dim gf, gc, dif As Integer
        Dim totalPartidos As Integer = 0
        Dim por As Double = 0
        Dim can As Integer = 0
        For i = 0 To tbLocal.Rows.Count - 1
            totalPartidos = totalPartidos + Convert.ToInt32(tbLocal.Rows(i)("can").ToString())
        Next
        For i = 0 To tbLocal.Rows.Count - 1
            Dim r As DataRow
            r = tb.NewRow
            gf = Convert.ToInt32(tbLocal.Rows(i)("gl").ToString())
            gc = Convert.ToInt32(tbLocal.Rows(i)("gv").ToString())
            dif = gf - gc
            r(0) = tbLocal.Rows(i)("gl").ToString() + "-" + tbLocal.Rows(i)("gv").ToString()
            r(1) = tbLocal.Rows(i)("can").ToString()
            can = Convert.ToInt32(tbLocal.Rows(i)("can").ToString())
            If dif = 0 Then
                vep = "Empate"
            End If
            If dif > 0 Then
                vep = "Ganó"
            End If
            If dif < 0 Then
                vep = "Perdío"
            End If
            r(2) = vep
            por = (can / totalPartidos * 100)
            por = System.Math.Round(por, 2)
            r(3) = Convert.ToInt32(por)
            tb.Rows.Add(r)
        Next
        GrillaResumenLocal.DataSource = tb
        GrillaResumenLocal.DataBind()

        Dim tbVisitantes As New DataTable
        tbVisitantes = obj.GetResumenxEquipoVisitante(IdEquipo, IdTorneo)

        Dim tb2 As New DataTable
        tb2.Columns.Add("RESULTADO")
        tb2.Columns.Add("FRECUENCIA")
        tb2.Columns.Add("VEP")
        tb2.Columns.Add("POR")
        totalPartidos = 0
        For i = 0 To tbVisitantes.Rows.Count - 1
            totalPartidos = totalPartidos + Convert.ToInt32(tbVisitantes.Rows(i)("can").ToString())
        Next
        For i = 0 To tbVisitantes.Rows.Count - 1
            Dim r As DataRow
            r = tb2.NewRow
            gf = Convert.ToInt32(tbVisitantes.Rows(i)("gl").ToString())
            gc = Convert.ToInt32(tbVisitantes.Rows(i)("gv").ToString())
            dif = gf - gc
            r(0) = tbVisitantes.Rows(i)("gl").ToString() + "-" + tbVisitantes.Rows(i)("gv").ToString()
            r(1) = tbVisitantes.Rows(i)("can").ToString()
            If dif = 0 Then
                vep = "Empate"
            End If
            If dif > 0 Then
                vep = "Perdió"
            End If
            If dif < 0 Then
                vep = "Ganó"
            End If
            can = Convert.ToInt32(tbVisitantes.Rows(i)("can").ToString())
            r(2) = vep
            por = (can / totalPartidos * 100)
            por = System.Math.Round(por, 2)
            r(3) = por
            tb2.Rows.Add(r)
        Next

        GrillaResumenVisitante.DataSource = tb2
        GrillaResumenVisitante.DataBind()
        CargarResumenGeneral(tbLocal, tbVisitantes)
        CargarResumenCompleto(tbLocal, tbVisitantes)
    End Sub

    Private Sub CargarResumenGeneral(ByVal tbLocal As DataTable, ByVal tbVisitante As DataTable)
        Dim gl, gv, gl2, gv2, can, can2 As Integer
        Dim i, j, dif As Integer
        Dim ban As Integer = 0
        Dim vep As String
        dif = 0
        Dim tbresumen As New DataTable
        tbresumen.Columns.Add("RESULTADO")
        tbresumen.Columns.Add("FRECUENCIA")
        tbresumen.Columns.Add("VEP")
        tbresumen.Columns.Add("POR")
        For i = 0 To tbLocal.Rows.Count - 1
            gl = Convert.ToInt32(tbLocal.Rows(i)("gl"))
            gv = Convert.ToInt32(tbLocal.Rows(i)("gv"))
            can = Convert.ToInt32(tbLocal.Rows(i)("can"))
            For j = 0 To tbVisitante.Rows.Count - 1
                gl2 = Convert.ToInt32(tbVisitante.Rows(j)("gl"))
                gv2 = Convert.ToInt32(tbVisitante.Rows(j)("gv"))
                can2 = Convert.ToInt32(tbVisitante.Rows(j)("can"))

                If gl = gv2 And gv = gl2 Then
                    Dim r As DataRow
                    r = tbresumen.NewRow
                    r(0) = (gl.ToString() + " - " + gv.ToString()).ToString()
                    r(1) = (can + can2).ToString()
                    dif = gl - gv
                    If dif = 0 Then
                        vep = "Empate"
                    End If
                    If dif > 0 Then
                        vep = "Ganó"
                    End If
                    If dif < 0 Then
                        vep = "Perdió"
                    End If
                    r(2) = vep
                    tbresumen.Rows.Add(r)
                    ban = 1
                End If
            Next
            If ban = 0 Then
                Dim r As DataRow
                r = tbresumen.NewRow
                r(0) = (gl.ToString() + " - " + gv.ToString()).ToString()
                r(1) = (can).ToString()
                dif = gl - gv
                If dif = 0 Then
                    vep = "Empate"
                End If
                If dif > 0 Then
                    vep = "Ganó"
                End If
                If dif < 0 Then
                    vep = "Perdió"
                End If
                r(2) = vep
                r(3) = 10
                tbresumen.Rows.Add(r)
            End If
            ban = 0
        Next
        For j = 0 To tbVisitante.Rows.Count - 1
            ban = 0
            gl2 = Convert.ToInt32(tbVisitante.Rows(j)("gl"))
            gv2 = Convert.ToInt32(tbVisitante.Rows(j)("gv"))
            can2 = Convert.ToInt32(tbVisitante.Rows(j)("can"))
            For i = 0 To tbLocal.Rows.Count - 1
                gl = Convert.ToInt32(tbLocal.Rows(i)("gl").ToString())
                gv = Convert.ToInt32(tbLocal.Rows(i)("gv").ToString())
                If gl = gv2 And gv = gl2 Then
                    ban = 1
                End If
            Next
            If ban = 0 Then
                Dim r As DataRow
                r = tbresumen.NewRow
                r(0) = (gl2.ToString() + " - " + gv2.ToString()).ToString()
                r(1) = (can2).ToString()
                dif = gl2 - gv2
                If dif = 0 Then
                    vep = "Empate"
                End If
                If dif > 0 Then
                    vep = "Perdió"
                End If
                If dif < 0 Then
                    vep = "Ganó"
                End If
                r(2) = vep
                r(3) = 25
                tbresumen.Rows.Add(r)
            End If
        Next
        Dim totalPartidos As Integer = 0
        Dim por As Double = 0
        For i = 0 To tbresumen.Rows.Count - 1
            totalPartidos = totalPartidos + Convert.ToInt32(tbresumen.Rows(i)("FRECUENCIA").ToString())
        Next

        For i = 0 To tbresumen.Rows.Count - 1
            can = Convert.ToInt32(tbresumen.Rows(i)("FRECUENCIA"))
            por = can / totalPartidos * 100
            tbresumen.Rows(i)("POR") = Convert.ToInt32(por)
        Next
        Dim dv As New DataView
        dv = tbresumen.DefaultView
        dv.Sort = "FRECUENCIA desc"
        GrillaResumenGeneral.DataSource = dv
        GrillaResumenGeneral.DataBind()
    End Sub

    Private Sub CargarResumenCompleto(ByVal tbLocal As DataTable, ByVal tbVisitante As DataTable)
        Dim tbResumen As New DataTable
        tbResumen.Columns.Add("LEYENDA")
        tbResumen.Columns.Add("DIF")
        tbResumen.Columns.Add("CAN")
        Dim i, k As Integer
        Dim gl, gv As Integer
        Dim dif, can As Integer
        Dim ban As Integer = 0
        Dim leyenda As String = ""
        For i = 0 To tbLocal.Rows.Count - 1
            gl = Convert.ToInt32(tbLocal.Rows(i)("gl"))
            gv = Convert.ToInt32(tbLocal.Rows(i)("gv"))
            dif = gl - gv
            can = Convert.ToInt32(tbLocal.Rows(i)("CAN"))

            For k = 0 To tbResumen.Rows.Count - 1
                If (tbResumen.Rows(k)("DIF").ToString() = dif.ToString()) Then
                    tbResumen.Rows(k)("CAN") = (Convert.ToInt32(tbResumen.Rows(k)("CAN")) + can).ToString()
                    ban = 1
                End If

            Next
            If ban = 0 Then
                Dim r As DataRow
                r = tbResumen.NewRow
                r("DIF") = dif
                r("CAN") = can
                If dif = 0 Then
                    leyenda = "Empate"
                End If
                If dif > 0 Then
                    leyenda = "Victorias por " + dif.ToString() + " gol"
                End If
                If dif < 0 Then
                    leyenda = "Derrotas por " + dif.ToString() + " gol"
                End If
                r("LEYENDA") = leyenda
                tbResumen.Rows.Add(r)
                ban = 0
            End If
            ban = 0
        Next
    End Sub

    Private Sub ArmarFixture(ByVal IdLocal As Integer, ByVal tb As DataTable)
        Dim tbFixture As New DataTable
        tbFixture.Columns.Add("FECHA")
        tbFixture.Columns.Add("RIVAL")
        tbFixture.Columns.Add("G")
        tbFixture.Columns.Add("E")
        tbFixture.Columns.Add("P")
        tbFixture.Columns.Add("CONDICION")
        Dim i As Integer
        Dim gl, gv, dif As Integer
        Dim rival As String = ""
        Dim fecha As String
        Dim gano, empato, perdio, Condicion As String
        gano = ""
        empato = ""
        perdio = ""
        Condicion = ""
        For i = 0 To tb.Rows.Count - 1
            fecha = tb.Rows(i)("fecha").ToString()
            If tb.Rows(i)("jugo").ToString() = "1" Then
                gl = Convert.ToInt32(tb.Rows(i)("gl").ToString())
                gv = Convert.ToInt32(tb.Rows(i)("gv").ToString())
                dif = gl - gv
                If (tb.Rows(i)("IdLocal").ToString() = IdLocal.ToString()) Then
                    rival = tb.Rows(i)("visitante").ToString()
                    Condicion = "Local"
                    If dif = 0 Then
                        empato = gl.ToString() + "-" + gv.ToString()
                        gano = ""
                        perdio = ""
                    End If
                    If dif > 0 Then
                        empato = ""
                        gano = gl.ToString() + "-" + gv.ToString()
                        perdio = ""
                    End If
                    If dif < 0 Then
                        empato = ""
                        gano = ""
                        perdio = gl.ToString() + "-" + gv.ToString()
                    End If
                Else
                    rival = tb.Rows(i)("local").ToString()
                    Condicion = "Visitante"
                    If dif = 0 Then
                        empato = gl.ToString() + "-" + gv.ToString()
                        gano = ""
                        perdio = ""
                    End If
                    If dif > 0 Then
                        empato = ""
                        gano = ""
                        perdio = gl.ToString() + "-" + gv.ToString()
                    End If
                    If dif < 0 Then
                        empato = ""
                        gano = gl.ToString() + "-" + gv.ToString()
                        perdio = ""
                    End If
                End If
                Dim r As DataRow
                r = tbFixture.NewRow()
                r("FECHA") = fecha
                r("RIVAL") = rival
                r("G") = gano
                r("P") = perdio
                r("E") = empato
                r("CONDICION") = Condicion
                tbFixture.Rows.Add(r)
            Else
                gano = ""
                perdio = ""
                empato = ""
                If (tb.Rows(i)("IdLocal").ToString() = IdLocal.ToString()) Then
                    rival = tb.Rows(i)("visitante").ToString()
                    Condicion = "Local"
                Else
                    rival = tb.Rows(i)("local").ToString()
                    Condicion = "Visitante"
                End If
                Dim r As DataRow
                r = tbFixture.NewRow()
                r("FECHA") = fecha
                r("RIVAL") = rival
                r("G") = gano
                r("P") = perdio
                r("E") = empato
                r("CONDICION") = Condicion
                tbFixture.Rows.Add(r)
            End If
        Next
        Grilla.DataSource = tbFixture
        Grilla.DataBind()

    End Sub

End Class