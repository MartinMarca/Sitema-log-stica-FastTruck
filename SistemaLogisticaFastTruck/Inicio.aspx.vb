Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nombreUsuario As String
        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try
    End Sub

    Private Sub Btn_CerrarSesion_Click(sender As Object, e As EventArgs) Handles Btn_CerrarSesion.Click
        Session.Remove("nombreUsuario")
        Response.Redirect("InicioSesion.aspx")
    End Sub
End Class