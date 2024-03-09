Imports System.Data
Imports TablaDLL

Public Class Log
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Dim usu, pas As String
        usu = txtUsuario.Text
        pas = txtpassword.Text
        Dim objusu As New Usuario()
        If (objusu.Loguear(usu, pas)) Then
            Session("Usuario") = txtUsuario.Text
            Response.Redirect("WFormGl.aspx")
        End If

    End Sub


End Class