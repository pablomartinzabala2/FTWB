Imports TablaDLL

Public Class Principal1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As String = Request.QueryString("Id")
        If id <> "" Then
            CargarMenu(Convert.ToInt32(id))
            inicio(Convert.ToInt32(id))
        End If
    End Sub

    Private Sub CargarMenu(ByVal IdTorneo As Integer)
        Dim objMenu As New Menu()

        Dim tresul As New DataTable
        Dim id As String = Request.QueryString("Id")
        tresul = objMenu.MenuGetbyTorneo(Convert.ToInt32(id))
        Dim redirec As String = ""

        Dim sMenu As String = "<ul>"
        For i = 0 To tresul.Rows.Count - 1
            redirec = tresul.Rows(i)("Redirect") + "?id=" + id
            If tresul.Rows(i)("Texto") = "Posiciones Generales" Then
                redirec = redirec + "&T=G"
            End If
            If tresul.Rows(i)("Texto") = "Posiciones Locales" Then
                redirec = redirec + "&T=L"
            End If
            If tresul.Rows(i)("Texto") = "Posiciones Visitantes" Then
                redirec = redirec + "&T=V"
            End If
            If tresul.Rows(i)("Texto") = "Subtorneo" Then
                redirec = redirec
            End If
            If tresul.Rows(i)("Texto") = "Posiciones entre fechas" Then
                redirec = redirec + "&T=EF"
            End If
            If tresul.Rows(i)("Texto") = "Diferencias" Then
                redirec = redirec
            End If
            If tresul.Rows(i)("Texto") = "Zona 1" Then
                redirec = redirec + "&T=Z&N=1"
            End If
            If tresul.Rows(i)("Texto") = "Zona 2" Then
                redirec = redirec + "&T=Z&N=2"
            End If
            sMenu = sMenu + "<li><a href ='" + redirec + "'>"
            sMenu = sMenu + tresul.Rows(i)("Texto") + "</a></li>"
        Next
        LiteralMenu.Text = sMenu
    End Sub

    Private Sub CargarMapaFecha(ByVal IdTorneo As Integer)
        Dim fix As New Fixture()
        Dim cantidad As Integer
        cantidad = fix.GetCantidaddeFechasxTorneo(IdTorneo)
        Select Case cantidad
            Case 10
                trFecha1a5.Visible = True
                trFecha6a10.Visible = True
                trFecha11a15.Visible = False
                trFecha16a20.Visible = False
                trFecha21a25.Visible = False
                trFecha26a30.Visible = False
                trFecha31a35.Visible = False
                trFecha36a40.Visible = False
                trfecha41a42.Visible = False
                LinkButton17.Visible = False
                LinkButton18.Visible = False
                LinkButton19.Visible = False
                LinkButton20.Visible = False
            Case 16
                trFecha1a5.Visible = True
                trFecha6a10.Visible = True
                trFecha11a15.Visible = True
                trFecha16a20.Visible = True
                trFecha21a25.Visible = False
                trFecha26a30.Visible = False
                trFecha31a35.Visible = False
                trFecha36a40.Visible = False
                trfecha41a42.Visible = False
                LinkButton17.Visible = False
                LinkButton18.Visible = False
                LinkButton19.Visible = False
                LinkButton20.Visible = False
            Case 18
                trFecha1a5.Visible = True
                trFecha6a10.Visible = True
                trFecha11a15.Visible = True
                trFecha16a20.Visible = True
                trFecha21a25.Visible = False
                trFecha26a30.Visible = False
                trFecha31a35.Visible = False
                trFecha36a40.Visible = False
                trfecha41a42.Visible = False
                LinkButton19.Visible = False
                LinkButton20.Visible = False
            Case 19
                trFecha1a5.Visible = True
                trFecha6a10.Visible = True
                trFecha11a15.Visible = True
                trFecha16a20.Visible = True
                Img20.Visible = False
                trFecha21a25.Visible = False
                trFecha26a30.Visible = False
                trFecha31a35.Visible = False
                trFecha36a40.Visible = False
                trfecha41a42.Visible = False
                LinkButton19.Visible = False
                LinkButton20.Visible = False
            Case 21
                trFecha1a5.Visible = True
                trFecha6a10.Visible = True
                trFecha11a15.Visible = True
                trFecha16a20.Visible = True
                trFecha21a25.Visible = True
                trFecha26a30.Visible = False
                trFecha31a35.Visible = False
                trFecha36a40.Visible = False
                trfecha41a42.Visible = False
                LinkButton22.Visible = False
                LinkButton23.Visible = False
                LinkButton24.Visible = False
                LinkButton25.Visible = False
            Case 22
                trFecha1a5.Visible = True
                trFecha6a10.Visible = True
                trFecha11a15.Visible = True
                trFecha16a20.Visible = True
                trFecha21a25.Visible = False
                trFecha26a30.Visible = False
                trFecha31a35.Visible = False
                trFecha36a40.Visible = False
                trfecha41a42.Visible = False
            Case 30
                trFecha1a5.Visible = True
                trFecha6a10.Visible = True
                trFecha11a15.Visible = True
                trFecha16a20.Visible = True
                trFecha21a25.Visible = True
                trFecha26a30.Visible = True
                trFecha31a35.Visible = False
                trFecha36a40.Visible = False
                trfecha41a42.Visible = False

            Case 38
                trFecha1a5.Visible = True
                trFecha6a10.Visible = True
                trFecha11a15.Visible = True
                trFecha16a20.Visible = True
                trFecha21a25.Visible = True
                trFecha26a30.Visible = True
                trFecha31a35.Visible = True
                trFecha36a40.Visible = True
                trfecha41a42.Visible = False
                LinkButton39.Visible = False
        End Select
    End Sub
    Private Sub inicio(ByVal IdTorneo As Integer)
        Dim eq As New TablaDLL.Equipo()
        Dim t As New DataTable
        Try

        Catch ex As Exception
            Return
        End Try

        Dim torneo As New TablaDLL.Torneo()
        Dim tb As New DataTable()
        tb = torneo.TorneoGetbyId(IdTorneo)
        If tb.Rows.Count > 0 Then
            Dim x As String
            x = tb.Rows(0)("Torneo")
            x = x + " " + tb.Rows(0)("Temporada")
            lblCategoria.Text = x
        End If
        CargarMapaFecha(IdTorneo)

        t = eq.EquiposGetbyEquiposxTorneo(IdTorneo)
        ' ArmarMenu(IdTorneo)
        Dim cantidad As Integer
        cantidad = t.Rows.Count
        Session("cantidad") = cantidad
        Select Case cantidad
            Case 4
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()


                Img5.Visible = False
                Img6.Visible = False
                Img7.Visible = False
                Img8.Visible = False
                Img9.Visible = False
                Img10.Visible = False
                Img11.Visible = False
                Img12.Visible = False
                Img13.Visible = False
                Img14.Visible = False
                Img15.Visible = False
                Img16.Visible = False
                Img17.Visible = False
                Img18.Visible = False
                Img19.Visible = False
                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False
            Case 7
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.Visible = False
                Img9.Visible = False
                Img10.Visible = False
                Img11.Visible = False
                Img12.Visible = False
                Img13.Visible = False
                Img14.Visible = False
                Img15.Visible = False
                Img16.Visible = False
                Img17.Visible = False
                Img18.Visible = False
                Img19.Visible = False
                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False
            Case 8
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.Visible = False
                Img10.Visible = False
                Img11.Visible = False
                Img12.Visible = False
                Img13.Visible = False
                Img14.Visible = False
                Img15.Visible = False
                Img16.Visible = False
                Img17.Visible = False
                Img18.Visible = False
                Img19.Visible = False
                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False
            Case 10
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.Visible = False
                Img12.Visible = False
                Img13.Visible = False
                Img14.Visible = False
                Img15.Visible = False
                Img16.Visible = False
                Img17.Visible = False
                Img18.Visible = False
                Img19.Visible = False
                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False
            Case 9
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()
                Img10.Visible = False
                Img11.Visible = False
                Img12.Visible = False
                Img13.Visible = False
                Img14.Visible = False
                Img15.Visible = False
                Img16.Visible = False
                Img17.Visible = False
                Img18.Visible = False
                Img19.Visible = False
                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False

            Case 11
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()


                Img12.Visible = False
                Img13.Visible = False
                Img14.Visible = False
                Img15.Visible = False
                Img16.Visible = False
                Img17.Visible = False
                Img18.Visible = False
                Img19.Visible = False
                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False
            Case 12
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.Visible = False
                Img14.Visible = False
                Img15.Visible = False
                Img16.Visible = False
                Img17.Visible = False
                Img18.Visible = False
                Img19.Visible = False
                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False
            Case 14
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.ImageUrl = "~/Imagen/" + t.Rows(12)("Foto").ToString()
                Img13.CommandArgument = t.Rows(12)("IdEquipo").ToString()
                Img13.ToolTip = t.Rows(12)("Equipo").ToString()

                Img14.ImageUrl = "~/Imagen/" + t.Rows(13)("Foto").ToString()
                Img14.CommandArgument = t.Rows(13)("IdEquipo").ToString()
                Img14.ToolTip = t.Rows(13)("Equipo").ToString()

                Img15.Visible = False
                Img16.Visible = False
                Img17.Visible = False
                Img18.Visible = False
                Img19.Visible = False
                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False

            Case 15
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.ImageUrl = "~/Imagen/" + t.Rows(12)("Foto").ToString()
                Img13.CommandArgument = t.Rows(12)("IdEquipo").ToString()
                Img13.ToolTip = t.Rows(12)("Equipo").ToString()

                Img14.ImageUrl = "~/Imagen/" + t.Rows(13)("Foto").ToString()
                Img14.CommandArgument = t.Rows(13)("IdEquipo").ToString()
                Img14.ToolTip = t.Rows(13)("Equipo").ToString()

                Img15.ImageUrl = "~/Imagen/" + t.Rows(14)("Foto").ToString()
                Img15.CommandArgument = t.Rows(14)("IdEquipo").ToString()
                Img15.ToolTip = t.Rows(14)("Equipo").ToString()

                Img16.Visible = False
                Img17.Visible = False
                Img18.Visible = False
                Img19.Visible = False
                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False

            Case 19
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.ImageUrl = "~/Imagen/" + t.Rows(12)("Foto").ToString()
                Img13.CommandArgument = t.Rows(12)("IdEquipo").ToString()
                Img13.ToolTip = t.Rows(12)("Equipo").ToString()



                Img14.ImageUrl = "~/Imagen/" + t.Rows(13)("Foto").ToString()
                Img14.CommandArgument = t.Rows(13)("IdEquipo").ToString()
                Img14.ToolTip = t.Rows(13)("Equipo").ToString()

                Img15.ImageUrl = "~/Imagen/" + t.Rows(14)("Foto").ToString()
                Img15.CommandArgument = t.Rows(14)("IdEquipo").ToString()
                Img15.ToolTip = t.Rows(14)("Equipo").ToString()

                Img16.ImageUrl = "~/Imagen/" + t.Rows(15)("Foto").ToString()
                Img16.CommandArgument = t.Rows(15)("IdEquipo").ToString()
                Img16.ToolTip = t.Rows(15)("Equipo").ToString()

                Img17.ImageUrl = "~/Imagen/" + t.Rows(16)("Foto").ToString()
                Img17.CommandArgument = t.Rows(16)("IdEquipo").ToString()
                Img17.ToolTip = t.Rows(16)("Equipo").ToString()

                Img18.ImageUrl = "~/Imagen/" + t.Rows(17)("Foto").ToString()
                Img18.CommandArgument = t.Rows(17)("IdEquipo").ToString()
                Img18.ToolTip = t.Rows(17)("Equipo").ToString()

                Img19.ImageUrl = "~/Imagen/" + t.Rows(18)("Foto").ToString()
                Img19.CommandArgument = t.Rows(18)("IdEquipo").ToString()
                Img19.ToolTip = t.Rows(18)("Equipo").ToString()


                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False


            Case 20
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.ImageUrl = "~/Imagen/" + t.Rows(12)("Foto").ToString()
                Img13.CommandArgument = t.Rows(12)("IdEquipo").ToString()
                Img13.ToolTip = t.Rows(12)("Equipo").ToString()



                Img14.ImageUrl = "~/Imagen/" + t.Rows(13)("Foto").ToString()
                Img14.CommandArgument = t.Rows(13)("IdEquipo").ToString()
                Img14.ToolTip = t.Rows(13)("Equipo").ToString()

                Img15.ImageUrl = "~/Imagen/" + t.Rows(14)("Foto").ToString()
                Img15.CommandArgument = t.Rows(14)("IdEquipo").ToString()
                Img15.ToolTip = t.Rows(14)("Equipo").ToString()

                Img16.ImageUrl = "~/Imagen/" + t.Rows(15)("Foto").ToString()
                Img16.CommandArgument = t.Rows(15)("IdEquipo").ToString()
                Img16.ToolTip = t.Rows(15)("Equipo").ToString()

                Img17.ImageUrl = "~/Imagen/" + t.Rows(16)("Foto").ToString()
                Img17.CommandArgument = t.Rows(16)("IdEquipo").ToString()
                Img17.ToolTip = t.Rows(16)("Equipo").ToString()

                Img18.ImageUrl = "~/Imagen/" + t.Rows(17)("Foto").ToString()
                Img18.CommandArgument = t.Rows(17)("IdEquipo").ToString()
                Img18.ToolTip = t.Rows(17)("Equipo").ToString()

                Img19.ImageUrl = "~/Imagen/" + t.Rows(18)("Foto").ToString()
                Img19.CommandArgument = t.Rows(18)("IdEquipo").ToString()
                Img19.ToolTip = t.Rows(18)("Equipo").ToString()

                Img20.ImageUrl = "~/Imagen/" + t.Rows(19)("Foto").ToString()
                Img20.CommandArgument = t.Rows(19)("IdEquipo").ToString()
                Img20.ToolTip = t.Rows(19)("Equipo").ToString()

                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False
            Case 21
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.ImageUrl = "~/Imagen/" + t.Rows(12)("Foto").ToString()
                Img13.CommandArgument = t.Rows(12)("IdEquipo").ToString()
                Img13.ToolTip = t.Rows(12)("Equipo").ToString()



                Img14.ImageUrl = "~/Imagen/" + t.Rows(13)("Foto").ToString()
                Img14.CommandArgument = t.Rows(13)("IdEquipo").ToString()
                Img14.ToolTip = t.Rows(13)("Equipo").ToString()

                Img15.ImageUrl = "~/Imagen/" + t.Rows(14)("Foto").ToString()
                Img15.CommandArgument = t.Rows(14)("IdEquipo").ToString()
                Img15.ToolTip = t.Rows(14)("Equipo").ToString()

                Img16.ImageUrl = "~/Imagen/" + t.Rows(15)("Foto").ToString()
                Img16.CommandArgument = t.Rows(15)("IdEquipo").ToString()
                Img16.ToolTip = t.Rows(15)("Equipo").ToString()

                Img17.ImageUrl = "~/Imagen/" + t.Rows(16)("Foto").ToString()
                Img17.CommandArgument = t.Rows(16)("IdEquipo").ToString()
                Img17.ToolTip = t.Rows(16)("Equipo").ToString()

                Img18.ImageUrl = "~/Imagen/" + t.Rows(17)("Foto").ToString()
                Img18.CommandArgument = t.Rows(17)("IdEquipo").ToString()
                Img18.ToolTip = t.Rows(17)("Equipo").ToString()

                Img19.ImageUrl = "~/Imagen/" + t.Rows(18)("Foto").ToString()
                Img19.CommandArgument = t.Rows(18)("IdEquipo").ToString()
                Img19.ToolTip = t.Rows(18)("Equipo").ToString()

                Img20.ImageUrl = "~/Imagen/" + t.Rows(19)("Foto").ToString()
                Img20.CommandArgument = t.Rows(19)("IdEquipo").ToString()
                Img20.ToolTip = t.Rows(19)("Equipo").ToString()

                Img21.ImageUrl = "~/Imagen/" + t.Rows(20)("Foto").ToString()
                Img21.CommandArgument = t.Rows(20)("IdEquipo").ToString()
                Img21.ToolTip = t.Rows(20)("Equipo").ToString()
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False
            Case 22
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.ImageUrl = "~/Imagen/" + t.Rows(12)("Foto").ToString()
                Img13.CommandArgument = t.Rows(12)("IdEquipo").ToString()
                Img13.ToolTip = t.Rows(12)("Equipo").ToString()



                Img14.ImageUrl = "~/Imagen/" + t.Rows(13)("Foto").ToString()
                Img14.CommandArgument = t.Rows(13)("IdEquipo").ToString()
                Img14.ToolTip = t.Rows(13)("Equipo").ToString()

                Img15.ImageUrl = "~/Imagen/" + t.Rows(14)("Foto").ToString()
                Img15.CommandArgument = t.Rows(14)("IdEquipo").ToString()
                Img15.ToolTip = t.Rows(14)("Equipo").ToString()

                Img16.ImageUrl = "~/Imagen/" + t.Rows(15)("Foto").ToString()
                Img16.CommandArgument = t.Rows(15)("IdEquipo").ToString()
                Img16.ToolTip = t.Rows(15)("Equipo").ToString()

                Img17.ImageUrl = "~/Imagen/" + t.Rows(16)("Foto").ToString()
                Img17.CommandArgument = t.Rows(16)("IdEquipo").ToString()
                Img17.ToolTip = t.Rows(16)("Equipo").ToString()

                Img18.ImageUrl = "~/Imagen/" + t.Rows(17)("Foto").ToString()
                Img18.CommandArgument = t.Rows(17)("IdEquipo").ToString()
                Img18.ToolTip = t.Rows(17)("Equipo").ToString()

                Img19.ImageUrl = "~/Imagen/" + t.Rows(18)("Foto").ToString()
                Img19.CommandArgument = t.Rows(18)("IdEquipo").ToString()
                Img19.ToolTip = t.Rows(18)("Equipo").ToString()

                Img20.ImageUrl = "~/Imagen/" + t.Rows(19)("Foto").ToString()
                Img20.CommandArgument = t.Rows(19)("IdEquipo").ToString()
                Img20.ToolTip = t.Rows(19)("Equipo").ToString()

                Img21.ImageUrl = "~/Imagen/" + t.Rows(20)("Foto").ToString()
                Img21.CommandArgument = t.Rows(20)("IdEquipo").ToString()
                Img21.ToolTip = t.Rows(20)("Equipo").ToString()

                Img22.ImageUrl = "~/Imagen/" + t.Rows(21)("Foto").ToString()
                Img22.CommandArgument = t.Rows(21)("IdEquipo").ToString()
                Img22.ToolTip = t.Rows(21)("Equipo").ToString()
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False

            Case 23
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.ImageUrl = "~/Imagen/" + t.Rows(12)("Foto").ToString()
                Img13.CommandArgument = t.Rows(12)("IdEquipo").ToString()
                Img13.ToolTip = t.Rows(12)("Equipo").ToString()



                Img14.ImageUrl = "~/Imagen/" + t.Rows(13)("Foto").ToString()
                Img14.CommandArgument = t.Rows(13)("IdEquipo").ToString()
                Img14.ToolTip = t.Rows(13)("Equipo").ToString()

                Img15.ImageUrl = "~/Imagen/" + t.Rows(14)("Foto").ToString()
                Img15.CommandArgument = t.Rows(14)("IdEquipo").ToString()
                Img15.ToolTip = t.Rows(14)("Equipo").ToString()

                Img16.ImageUrl = "~/Imagen/" + t.Rows(15)("Foto").ToString()
                Img16.CommandArgument = t.Rows(15)("IdEquipo").ToString()
                Img16.ToolTip = t.Rows(15)("Equipo").ToString()

                Img17.ImageUrl = "~/Imagen/" + t.Rows(16)("Foto").ToString()
                Img17.CommandArgument = t.Rows(16)("IdEquipo").ToString()
                Img17.ToolTip = t.Rows(16)("Equipo").ToString()

                Img18.ImageUrl = "~/Imagen/" + t.Rows(17)("Foto").ToString()
                Img18.CommandArgument = t.Rows(17)("IdEquipo").ToString()
                Img18.ToolTip = t.Rows(17)("Equipo").ToString()

                Img19.ImageUrl = "~/Imagen/" + t.Rows(18)("Foto").ToString()
                Img19.CommandArgument = t.Rows(18)("IdEquipo").ToString()
                Img19.ToolTip = t.Rows(18)("Equipo").ToString()

                Img20.ImageUrl = "~/Imagen/" + t.Rows(19)("Foto").ToString()
                Img20.CommandArgument = t.Rows(19)("IdEquipo").ToString()
                Img20.ToolTip = t.Rows(19)("Equipo").ToString()

                Img21.ImageUrl = "~/Imagen/" + t.Rows(20)("Foto").ToString()
                Img21.CommandArgument = t.Rows(20)("IdEquipo").ToString()
                Img21.ToolTip = t.Rows(20)("Equipo").ToString()

                Img22.ImageUrl = "~/Imagen/" + t.Rows(21)("Foto").ToString()
                Img22.CommandArgument = t.Rows(21)("IdEquipo").ToString()
                Img22.ToolTip = t.Rows(21)("Equipo").ToString()

                Img23.ImageUrl = "~/Imagen/" + t.Rows(22)("Foto").ToString()
                Img23.CommandArgument = t.Rows(22)("IdEquipo").ToString()
                Img23.ToolTip = t.Rows(22)("Equipo").ToString()


                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False
            Case 13
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.ImageUrl = "~/Imagen/" + t.Rows(12)("Foto").ToString()
                Img13.CommandArgument = t.Rows(12)("IdEquipo").ToString()
                Img13.ToolTip = t.Rows(12)("Equipo").ToString()
                Img14.Visible = False
                Img15.Visible = False
                Img16.Visible = False
                Img17.Visible = False
                Img18.Visible = False
                Img19.Visible = False
                Img20.Visible = False
                Img21.Visible = False
                Img22.Visible = False
                Img23.Visible = False
                Img24.Visible = False
                Img25.Visible = False
                Img26.Visible = False
                Img27.Visible = False
                Img28.Visible = False
                Img29.Visible = False
                Img30.Visible = False
            Case 28
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.ImageUrl = "~/Imagen/" + t.Rows(12)("Foto").ToString()
                Img13.CommandArgument = t.Rows(12)("IdEquipo").ToString()
                Img13.ToolTip = t.Rows(12)("Equipo").ToString()



                Img14.ImageUrl = "~/Imagen/" + t.Rows(13)("Foto").ToString()
                Img14.CommandArgument = t.Rows(13)("IdEquipo").ToString()
                Img14.ToolTip = t.Rows(13)("Equipo").ToString()

                Img15.ImageUrl = "~/Imagen/" + t.Rows(14)("Foto").ToString()
                Img15.CommandArgument = t.Rows(14)("IdEquipo").ToString()
                Img15.ToolTip = t.Rows(14)("Equipo").ToString()

                Img16.ImageUrl = "~/Imagen/" + t.Rows(15)("Foto").ToString()
                Img16.CommandArgument = t.Rows(15)("IdEquipo").ToString()
                Img16.ToolTip = t.Rows(15)("Equipo").ToString()

                Img17.ImageUrl = "~/Imagen/" + t.Rows(16)("Foto").ToString()
                Img17.CommandArgument = t.Rows(16)("IdEquipo").ToString()
                Img17.ToolTip = t.Rows(16)("Equipo").ToString()

                Img18.ImageUrl = "~/Imagen/" + t.Rows(17)("Foto").ToString()
                Img18.CommandArgument = t.Rows(17)("IdEquipo").ToString()
                Img18.ToolTip = t.Rows(17)("Equipo").ToString()

                Img19.ImageUrl = "~/Imagen/" + t.Rows(18)("Foto").ToString()
                Img19.CommandArgument = t.Rows(18)("IdEquipo").ToString()
                Img19.ToolTip = t.Rows(18)("Equipo").ToString()

                Img20.ImageUrl = "~/Imagen/" + t.Rows(19)("Foto").ToString()
                Img20.CommandArgument = t.Rows(19)("IdEquipo").ToString()
                Img20.ToolTip = t.Rows(19)("Equipo").ToString()

                Img21.ImageUrl = "~/Imagen/" + t.Rows(20)("Foto").ToString()
                Img21.CommandArgument = t.Rows(20)("IdEquipo").ToString()
                Img21.ToolTip = t.Rows(20)("Equipo").ToString()

                Img22.ImageUrl = "~/Imagen/" + t.Rows(21)("Foto").ToString()
                Img22.CommandArgument = t.Rows(21)("IdEquipo").ToString()
                Img22.ToolTip = t.Rows(21)("Equipo").ToString()

                Img23.ImageUrl = "~/Imagen/" + t.Rows(22)("Foto").ToString()
                Img23.CommandArgument = t.Rows(22)("IdEquipo").ToString()
                Img23.ToolTip = t.Rows(22)("Equipo").ToString()

                Img24.ImageUrl = "~/Imagen/" + t.Rows(23)("Foto").ToString()
                Img24.CommandArgument = t.Rows(23)("IdEquipo").ToString()
                Img24.ToolTip = t.Rows(23)("Equipo").ToString()

                Img25.ImageUrl = "~/Imagen/" + t.Rows(24)("Foto").ToString()
                Img25.CommandArgument = t.Rows(24)("IdEquipo").ToString()
                Img25.ToolTip = t.Rows(24)("Equipo").ToString()

                Img26.ImageUrl = "~/Imagen/" + t.Rows(25)("Foto").ToString()
                Img26.CommandArgument = t.Rows(25)("IdEquipo").ToString()
                Img26.ToolTip = t.Rows(25)("Equipo").ToString()

                Img27.ImageUrl = "~/Imagen/" + t.Rows(26)("Foto").ToString()
                Img27.CommandArgument = t.Rows(26)("IdEquipo").ToString()
                Img27.ToolTip = t.Rows(26)("Equipo").ToString()

                Img28.ImageUrl = "~/Imagen/" + t.Rows(27)("Foto").ToString()
                Img28.CommandArgument = t.Rows(27)("IdEquipo").ToString()
                Img28.ToolTip = t.Rows(27)("Equipo").ToString()
                Img20.Visible = False
                Img30.Visible = False



            Case 30
                Img1.ImageUrl = "~/Imagen/" + t.Rows(0)("Foto").ToString()
                Img1.CommandArgument = t.Rows(0)("IdEquipo").ToString()
                Img1.ToolTip = t.Rows(0)("Equipo").ToString()

                Img2.ImageUrl = "~/Imagen/" + t.Rows(1)("Foto").ToString()
                Img2.CommandArgument = t.Rows(1)("IdEquipo").ToString()
                Img2.ToolTip = t.Rows(1)("Equipo").ToString()

                Img3.ImageUrl = "~/Imagen/" + t.Rows(2)("Foto").ToString()
                Img3.CommandArgument = t.Rows(2)("IdEquipo").ToString()
                Img3.ToolTip = t.Rows(2)("Equipo").ToString()

                Img4.ImageUrl = "~/Imagen/" + t.Rows(3)("Foto").ToString()
                Img4.CommandArgument = t.Rows(3)("IdEquipo").ToString()
                Img4.ToolTip = t.Rows(3)("Equipo").ToString()

                Img5.ImageUrl = "~/Imagen/" + t.Rows(4)("Foto").ToString()
                Img5.CommandArgument = t.Rows(4)("IdEquipo").ToString()
                Img5.ToolTip = t.Rows(4)("Equipo").ToString()

                Img6.ImageUrl = "~/Imagen/" + t.Rows(5)("Foto").ToString()
                Img6.CommandArgument = t.Rows(5)("IdEquipo").ToString()
                Img6.ToolTip = t.Rows(5)("Equipo").ToString()

                Img7.ImageUrl = "~/Imagen/" + t.Rows(6)("Foto").ToString()
                Img7.CommandArgument = t.Rows(6)("IdEquipo").ToString()
                Img7.ToolTip = t.Rows(6)("Equipo").ToString()

                Img8.ImageUrl = "~/Imagen/" + t.Rows(7)("Foto").ToString()
                Img8.CommandArgument = t.Rows(7)("IdEquipo").ToString()
                Img8.ToolTip = t.Rows(7)("Equipo").ToString()

                Img9.ImageUrl = "~/Imagen/" + t.Rows(8)("Foto").ToString()
                Img9.CommandArgument = t.Rows(8)("IdEquipo").ToString()
                Img9.ToolTip = t.Rows(8)("Equipo").ToString()

                Img10.ImageUrl = "~/Imagen/" + t.Rows(9)("Foto").ToString()
                Img10.CommandArgument = t.Rows(9)("IdEquipo").ToString()
                Img10.ToolTip = t.Rows(9)("Equipo").ToString()

                Img11.ImageUrl = "~/Imagen/" + t.Rows(10)("Foto").ToString()
                Img11.CommandArgument = t.Rows(10)("IdEquipo").ToString()
                Img11.ToolTip = t.Rows(10)("Equipo").ToString()

                Img12.ImageUrl = "~/Imagen/" + t.Rows(11)("Foto").ToString()
                Img12.CommandArgument = t.Rows(11)("IdEquipo").ToString()
                Img12.ToolTip = t.Rows(11)("Equipo").ToString()

                Img13.ImageUrl = "~/Imagen/" + t.Rows(12)("Foto").ToString()
                Img13.CommandArgument = t.Rows(12)("IdEquipo").ToString()
                Img13.ToolTip = t.Rows(12)("Equipo").ToString()



                Img14.ImageUrl = "~/Imagen/" + t.Rows(13)("Foto").ToString()
                Img14.CommandArgument = t.Rows(13)("IdEquipo").ToString()
                Img14.ToolTip = t.Rows(13)("Equipo").ToString()

                Img15.ImageUrl = "~/Imagen/" + t.Rows(14)("Foto").ToString()
                Img15.CommandArgument = t.Rows(14)("IdEquipo").ToString()
                Img15.ToolTip = t.Rows(14)("Equipo").ToString()

                Img16.ImageUrl = "~/Imagen/" + t.Rows(15)("Foto").ToString()
                Img16.CommandArgument = t.Rows(15)("IdEquipo").ToString()
                Img16.ToolTip = t.Rows(15)("Equipo").ToString()

                Img17.ImageUrl = "~/Imagen/" + t.Rows(16)("Foto").ToString()
                Img17.CommandArgument = t.Rows(16)("IdEquipo").ToString()
                Img17.ToolTip = t.Rows(16)("Equipo").ToString()

                Img18.ImageUrl = "~/Imagen/" + t.Rows(17)("Foto").ToString()
                Img18.CommandArgument = t.Rows(17)("IdEquipo").ToString()
                Img18.ToolTip = t.Rows(17)("Equipo").ToString()

                Img19.ImageUrl = "~/Imagen/" + t.Rows(18)("Foto").ToString()
                Img19.CommandArgument = t.Rows(18)("IdEquipo").ToString()
                Img19.ToolTip = t.Rows(18)("Equipo").ToString()

                Img20.ImageUrl = "~/Imagen/" + t.Rows(19)("Foto").ToString()
                Img20.CommandArgument = t.Rows(19)("IdEquipo").ToString()
                Img20.ToolTip = t.Rows(19)("Equipo").ToString()

                Img21.ImageUrl = "~/Imagen/" + t.Rows(20)("Foto").ToString()
                Img21.CommandArgument = t.Rows(20)("IdEquipo").ToString()
                Img21.ToolTip = t.Rows(20)("Equipo").ToString()

                Img22.ImageUrl = "~/Imagen/" + t.Rows(21)("Foto").ToString()
                Img22.CommandArgument = t.Rows(21)("IdEquipo").ToString()
                Img22.ToolTip = t.Rows(21)("Equipo").ToString()

                Img23.ImageUrl = "~/Imagen/" + t.Rows(22)("Foto").ToString()
                Img23.CommandArgument = t.Rows(22)("IdEquipo").ToString()
                Img23.ToolTip = t.Rows(22)("Equipo").ToString()

                Img24.ImageUrl = "~/Imagen/" + t.Rows(23)("Foto").ToString()
                Img24.CommandArgument = t.Rows(23)("IdEquipo").ToString()
                Img24.ToolTip = t.Rows(23)("Equipo").ToString()

                Img25.ImageUrl = "~/Imagen/" + t.Rows(24)("Foto").ToString()
                Img25.CommandArgument = t.Rows(24)("IdEquipo").ToString()
                Img25.ToolTip = t.Rows(24)("Equipo").ToString()

                Img26.ImageUrl = "~/Imagen/" + t.Rows(25)("Foto").ToString()
                Img26.CommandArgument = t.Rows(25)("IdEquipo").ToString()
                Img26.ToolTip = t.Rows(25)("Equipo").ToString()

                Img27.ImageUrl = "~/Imagen/" + t.Rows(26)("Foto").ToString()
                Img27.CommandArgument = t.Rows(26)("IdEquipo").ToString()
                Img27.ToolTip = t.Rows(26)("Equipo").ToString()

                Img28.ImageUrl = "~/Imagen/" + t.Rows(27)("Foto").ToString()
                Img28.CommandArgument = t.Rows(27)("IdEquipo").ToString()
                Img28.ToolTip = t.Rows(27)("Equipo").ToString()

                Img29.ImageUrl = "~/Imagen/" + t.Rows(28)("Foto").ToString()
                Img29.CommandArgument = t.Rows(28)("IdEquipo").ToString()
                Img29.ToolTip = t.Rows(28)("Equipo").ToString()

                Img30.ImageUrl = "~/Imagen/" + t.Rows(29)("Foto").ToString()
                Img30.CommandArgument = t.Rows(29)("IdEquipo").ToString()
                Img30.ToolTip = t.Rows(29)("Equipo").ToString()


        End Select
    End Sub

    Protected Sub Img1_Click(sender As Object, e As ImageClickEventArgs) Handles Img1.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img1.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img16_Click(sender As Object, e As ImageClickEventArgs) Handles Img16.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img16.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img2_Click(sender As Object, e As ImageClickEventArgs) Handles Img2.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img2.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img9_Click(sender As Object, e As ImageClickEventArgs) Handles Img9.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img9.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img3_Click(sender As Object, e As ImageClickEventArgs) Handles Img3.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img3.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img4_Click(sender As Object, e As ImageClickEventArgs) Handles Img4.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img4.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img5_Click(sender As Object, e As ImageClickEventArgs) Handles Img5.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img5.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img6_Click(sender As Object, e As ImageClickEventArgs) Handles Img6.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img6.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img7_Click(sender As Object, e As ImageClickEventArgs) Handles Img7.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img7.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img8_Click(sender As Object, e As ImageClickEventArgs) Handles Img8.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img8.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img10_Click(sender As Object, e As ImageClickEventArgs) Handles Img10.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img10.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img11_Click(sender As Object, e As ImageClickEventArgs) Handles Img11.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img11.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img12_Click(sender As Object, e As ImageClickEventArgs) Handles Img12.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img12.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img13_Click(sender As Object, e As ImageClickEventArgs) Handles Img13.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img13.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img14_Click(sender As Object, e As ImageClickEventArgs) Handles Img14.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img14.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img15_Click(sender As Object, e As ImageClickEventArgs) Handles Img15.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img15.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img17_Click(sender As Object, e As ImageClickEventArgs) Handles Img17.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img17.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img18_Click(sender As Object, e As ImageClickEventArgs) Handles Img18.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img18.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img19_Click(sender As Object, e As ImageClickEventArgs) Handles Img19.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img19.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub Img20_Click(sender As Object, e As ImageClickEventArgs) Handles Img20.Click
        Dim id As String = Request.QueryString("Id").ToString()
        Dim idEq As String = Img20.CommandArgument.ToString()
        Dim pagina As String = "frmInfo.aspx?id=" + id.ToString() + "&idEq=" + idEq
        Session("Equipo") = Convert.ToInt16(Img1.CommandArgument.ToString())
        Response.Redirect(pagina)
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Dim IdTorneo As Integer
        Dim Pagina As String
        IdTorneo = Convert.ToInt32(Request.QueryString("Id"))
        'String Pagina ="FrmRdoxfec2.aspx?id=42&Fec=0"
        Pagina = "FrmRdoxfec2.aspx?id=" & IdTorneo.ToString()
        Pagina = Pagina & "&Fec=1"
        Response.Redirect(Pagina)
    End Sub

    Protected Sub LinkButton7_Click(sender As Object, e As EventArgs) Handles LinkButton7.Click
        Dim IdTorneo As Integer
        Dim Pagina As String
        IdTorneo = Convert.ToInt32(Request.QueryString("Id"))
        'String Pagina ="FrmRdoxfec2.aspx?id=42&Fec=0"
        Pagina = "FrmRdoxfec2.aspx?id=" & IdTorneo.ToString()
        Pagina = Pagina & "&Fec=7"
        Response.Redirect(Pagina)
    End Sub
End Class