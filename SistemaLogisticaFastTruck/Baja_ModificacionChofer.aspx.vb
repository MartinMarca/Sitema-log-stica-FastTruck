Imports System.Data.SqlClient

Public Class Baja_ModificacionChofer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idChofer As String
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
                idChofer = Request.QueryString("idparametro")
                Txt_id.Text = idChofer

                vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
                vConexion.Open()
                vStringComando = "SELECT nombreChofer, apellidoChofer, dni FROM Choferes WHERE idChofer = @idChofer"

                vComando = New SqlCommand(vStringComando, vConexion)
                vComando.Parameters.AddWithValue("@idChofer", Txt_id.Text)
                vResultados = vComando.ExecuteReader
                If vResultados.Read() Then
                    Txt_NombreChofer.Text = vResultados("nombreChofer")
                    Txt_ApellidoChofer.Text = vResultados("apellidoChofer")
                    Txt_DniChofer.Text = vResultados("dni")
                End If

                vConexion.Close()
            End If
        End If
    End Sub

    Private Sub Btn_ModificarChofer_Click(sender As Object, e As EventArgs) Handles Btn_ModificarChofer.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        If Page.IsValid Then

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()


            vStringComando = "UPDATE Choferes set nombreChofer = @nombreChofer, apellidoChofer = @apellidoChofer, dni = @dni WHERE idChofer = @idChofer"

            vComando = New SqlCommand(vStringComando, vConexion)


            vComando.Parameters.AddWithValue("@nombreChofer", Txt_NombreChofer.Text.Trim())
            vComando.Parameters.AddWithValue("@apellidoChofer", Txt_ApellidoChofer.Text.Trim())
            vComando.Parameters.AddWithValue("@dni", Txt_DniChofer.Text.Trim())
            vComando.Parameters.AddWithValue("@idChofer", Txt_id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarChoferes.aspx")
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String

        If MsgBox("Está seguro que desea ELIMINAR el chofer?", vbYesNo, "Eliminar") = vbYes Then
            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "UPDATE Choferes set baja = 1 WHERE idChofer = @idChofer"

            vComando = New SqlCommand(vStringComando, vConexion)

            vComando.Parameters.AddWithValue("@idChofer", Txt_id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarChoferes.aspx")
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarChoferes.aspx")
    End Sub
End Class