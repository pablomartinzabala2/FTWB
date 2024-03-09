Imports TablaDLL
Imports System.Data


Public Class FrmFix
    Inherits System.Web.UI.Page
    Private IdTorneo As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' IdTorneo = Convert.ToInt16(Session("IdTorneo"))
        IdTorneo = Convert.ToInt32(Request.QueryString("Id"))

        Dim tope As Integer
        Dim cantidad As Integer
        Dim tamañoPage As Integer
        Dim t As DataTable
        'Dim eq As New Equipo()
        't = eq.EquiposGetbyEquiposxTorneo(IdTorneo)
        cantidad = Convert.ToInt16(Session("cantidad"))
        If Not IsPostBack Then
            If cantidad Mod 2 = 0 Then
                tope = (cantidad / 2) - 1
                tamañoPage = cantidad / 2
            Else
                tamañoPage = (cantidad + 1) / 2
                tope = tamañoPage - 1

            End If
            Grilla.PageSize = tamañoPage

            ' IdTorneo = Convert.ToInt16(Session("IdTorneo"))
            'Dim cat As Integer
            'cat = Convert.ToInt16(Session("Categoria"))
            'If cat = 4 Then
            'Grilla.PageSize = 11
            'tope = 10
            'End If
            'If cat < 3 Then
            'Grilla.PageSize = 10
            'tope = 9
            'End If
            'If cat = 3 Then
            'Dim zona As Integer
            'zona = Convert.ToInt16(Session("zona"))
            'If zona = 1 Then
            'Grilla.PageSize = 7
            'tope = 6
            'End If
            'If zona = 2 Then
            'Grilla.PageSize = 6
            'tope = 5
            'End If
            'End If
            'If cat = 10 Then
            'Grilla.PageSize = 5
            'tope = 4
            'End If
            Dim fecha As Integer
            Dim Fix As New Fixture()
            fecha = Fix.MaxFecha(IdTorneo)
            Grilla.PageIndex = fecha
            CargarGrilla()
            Dim i, jugo As Integer
            For i = 0 To tope

                jugo = Convert.ToInt16(Grilla.Rows(i).Cells(8).Text)
                If jugo = 0 Then
                    Dim btnInfo As ImageButton = Grilla.Rows(i).FindControl("btnInfo")
                    btnInfo.Visible = False
                End If
                If Grilla.Rows(i).Cells(1).Text = Grilla.Rows(i).Cells(4).Text Then
                    Grilla.Rows(i).Cells(2).Text = "Libre"
                    Grilla.Rows(i).Cells(3).Text = ""
                    Grilla.Rows(i).Cells(6).Text = ""
                End If
            Next
            Label1.Text = "Fecha " + (Grilla.PageIndex + 1).ToString()

        End If
        Dim oVisitas As New Visitas()
        oVisitas.RegistrarVisitasPorItem(IdTorneo, "Fixture")
    End Sub

    Private Sub CargarGrilla()
        Dim fix As New Fixture()
        Dim tope As Integer
        Dim cat As Integer
        Dim t As New DataTable
        ' IdTorneo = Convert.ToInt16(Session("IdTorneo"))
        IdTorneo = Convert.ToInt32(Request.QueryString("Id"))
        't = fix.FixtureGetbyFecha(2, 1)
        t = fix.FixtureGetbyTorneo(IdTorneo)
        Grilla.DataSource = t
        Grilla.DataBind()
        Dim i, jugo As Integer
        cat = Convert.ToInt16(Session("Categoria"))
        'If cat = 4 Then
        'Grilla.PageSize = 11
        'tope = 10
        'End If
        'If cat = 3 Then
        'Dim zona As Integer
        'zona = Convert.ToInt16(Session("zona"))
        'If zona = 1 Then
        'Grilla.PageSize = 7
        'tope = 6
        'End If
        'If zona = 2 Then
        'Grilla.PageSize = 6
        'tope = 5
        'End If
        'End If
        'If cat < 3 Then
        'Grilla.PageSize = 10
        'tope = 9
        'End If
        'If cat = 10 Then
        'Grilla.PageSize = 5
        'tope = 4
        'End If
        Dim cantidad As Integer
        cantidad = Convert.ToInt16(Session("cantidad"))
        Dim tamañoPage As Integer
        If cantidad Mod 2 = 0 Then
            tope = (cantidad / 2) - 1
            tamañoPage = tope + 1
        Else
            tamañoPage = (cantidad + 1) / 2
            tope = tamañoPage - 1
        End If
        Grilla.PageSize = tamañoPage

        For i = 0 To tope
            jugo = Convert.ToInt16(Grilla.Rows(i).Cells(8).Text)
            If jugo = 0 Then
                Dim btnInfo As ImageButton = Grilla.Rows(i).FindControl("btnInfo")
                btnInfo.Visible = False
                'revisar aca
                'Grilla.Rows(i).Cells(3).Text = "-"
                'Grilla.Rows(i).Cells(6).Text = "-"
            End If
        Next
    End Sub
    Protected Sub Grilla_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles Grilla.PageIndexChanging
        Grilla.PageIndex = e.NewPageIndex
        CargarGrilla()
        Dim f As Integer
        f = Convert.ToInt16(Grilla.PageIndex.ToString())
        f = f + 1
        Label1.Text = "Fecha " + f.ToString()
        Dim i, jugo As Integer
        Dim cat, tope As Integer
        cat = Convert.ToInt16(Session("Categoria"))
        ' If cat = 4 Then
        'Grilla.PageSize = 11
        'tope = 10
        'End If
        'If cat < 3 Then
        'Grilla.PageSize = 10
        'tope = 9
        'End If
        'If cat = 3 Then
        'Dim zona As Integer
        'zona = Convert.ToInt16(Session("zona"))
        'If zona = 1 Then
        'Grilla.PageSize = 7
        'tope = 6
        'End If
        'If zona = 2 Then
        'Grilla.PageSize = 6
        'tope = 5
        'End If
        'End If
        'If cat = 10 Then
        'Grilla.PageSize = 5
        'tope = 4
        'End If
        Dim cantidad As Integer
        cantidad = Convert.ToInt16(Session("cantidad"))
        Dim tamañoPage As Integer
        If cantidad Mod 2 = 0 Then
            tope = (cantidad / 2) - 1
            tamañoPage = tope + 1
        Else
            tamañoPage = (cantidad + 1) / 2
            tope = tamañoPage - 1
        End If
        Grilla.PageSize = tamañoPage
        For i = 0 To tope

            jugo = Convert.ToInt16(Grilla.Rows(i).Cells(8).Text)
            If jugo = 0 Then
                Dim btnInfo As ImageButton = Grilla.Rows(i).FindControl("btnInfo")
                btnInfo.Visible = False
                Grilla.Rows(i).Cells(3).Text = "-"
                Grilla.Rows(i).Cells(6).Text = "-"
                If Grilla.Rows(i).Cells(1).Text = Grilla.Rows(i).Cells(4).Text Then
                    Grilla.Rows(i).Cells(2).Text = "Libre"
                    Grilla.Rows(i).Cells(3).Text = ""
                    Grilla.Rows(i).Cells(6).Text = ""
                End If
            End If
        Next
        '
    End Sub

    Protected Sub Grilla_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles Grilla.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header) Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(1).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(8).Visible = False
        End If
    End Sub

    Protected Sub btnInfo_Click(sender As Object, e As ImageClickEventArgs)
        Dim idPartido As Int32
        Dim btn As ImageButton = CType(sender, ImageButton)
        Dim row As GridViewRow = CType(btn.NamingContainer, GridViewRow)
        'Dim idDoc As Integer
        'idDoc = Convert.ToInt32(row.Cells(0).Text)
        idPartido = Convert.ToInt32(row.Cells(0).Text)
        Session("Partido") = idPartido
        Dim popupScript As String
        popupScript = String.Empty
        Dim ruta As String
        ruta = "FrmRdo.aspx"
        popupScript = "<script language='JavaScript'>"
        popupScript += "window.open('" + ruta + "', 'CustomPopUp', "
        popupScript += "'top=15,left=0 ,width=350 height=350, menubar=no, scrollbars=yes ,resizable=yes')"
        popupScript += "</script>"
        Page.RegisterStartupScript("popup", popupScript)
    End Sub
End Class