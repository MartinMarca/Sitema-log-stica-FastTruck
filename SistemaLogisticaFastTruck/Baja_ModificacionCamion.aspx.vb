Imports System.Data.SqlClient

Public Class Baja_ModificacionCamion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idCamion As String
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader
        Dim nombreUsuario As String

        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try

        If Not IsPostBack Then
            If Request.QueryString("idparametro") <> "" Then
                idCamion = Request.QueryString("idparametro")
                Txt_id.Text = idCamion

                vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
                vConexion.Open()
                vStringComando = "SELECT modelo, patente FROM Camiones WHERE idCamion = @idCamion"

                vComando = New SqlCommand(vStringComando, vConexion)
                vComando.Parameters.AddWithValue("@idCamion", Txt_id.Text)
                vResultados = vComando.ExecuteReader
                If vResultados.Read() Then
                    Txt_Modelo.Text = vResultados("modelo")
                    Txt_Patente.Text = vResultados("patente")
                End If
                vConexion.Close()
            End If
        End If
    End Sub

    Private Sub Btn_ModificarCamion_Click(sender As Object, e As EventArgs) Handles Btn_ModificarCamion.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        If Page.IsValid Then

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()


            vStringComando = "UPDATE Camiones set modelo = @modelo, patente = @patente WHERE idCamion = @idCamion"

            vComando = New SqlCommand(vStringComando, vConexion)


            vComando.Parameters.AddWithValue("@modelo", Txt_Modelo.Text.Trim())
            vComando.Parameters.AddWithValue("@patente", Txt_Patente.Text.Trim())
            vComando.Parameters.AddWithValue("@idCamion", Txt_id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarCamiones.aspx")
        End If
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String

        If MsgBox("Está seguro que desea ELIMINAR el camión?", vbYesNo, "Eliminar") = vbYes Then
            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "UPDATE Camiones set baja = 1 WHERE idCamion = @idCamion"

            vComando = New SqlCommand(vStringComando, vConexion)

            vComando.Parameters.AddWithValue("@idCamion", Txt_id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarCamiones.aspx")
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarCamiones.aspx")
    End Sub
End Class