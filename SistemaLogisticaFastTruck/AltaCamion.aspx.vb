Imports System.Data.SqlClient
Public Class AltaCamion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nombreUsuario As String

        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try
    End Sub

    Private Sub Btn_AgregarCamion_Click(sender As Object, e As EventArgs) Handles Btn_AgregarCamion.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()
        vStringComando = "INSERT INTO Camiones (modelo, patente) values (@modelo, @patente)"
        vComando = New SqlCommand(vStringComando, vConexion)

        vComando.Parameters.AddWithValue("@modelo", Txt_Modelo.Text.Trim())
        vComando.Parameters.AddWithValue("@patente", Txt_Patente.Text.Trim())

        vComando.ExecuteNonQuery()
        vConexion.Close()
        Response.Redirect("ListarCamiones.aspx")
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarCamiones.aspx")
    End Sub
End Class