Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Dim url As String = "FrmRdoxfec2.aspx?Id=51"
        Dim url As String = "FrmRdoxfec2.aspx?Id=9"
        Response.Redirect(url)
    End Sub

End Class