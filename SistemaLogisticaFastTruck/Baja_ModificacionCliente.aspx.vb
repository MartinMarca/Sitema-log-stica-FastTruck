Imports System.Data.SqlClient

Public Class Baja_ModificacionCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idCliente As String
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
                idCliente = Request.QueryString("idparametro")
                Txt_id.Text = idCliente

                vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
                vConexion.Open()
                vStringComando = "SELECT nombre, apellido, dni FROM Clientes WHERE idCliente = @idCliente"

                vComando = New SqlCommand(vStringComando, vConexion)
                vComando.Parameters.AddWithValue("@idCliente", Txt_id.Text)
                vResultados = vComando.ExecuteReader
                If vResultados.Read() Then
                    Txt_NombreCliente.Text = vResultados("nombre")
                    Txt_ApellidoCliente.Text = vResultados("apellido")
                    Txt_DniCliente.Text = vResultados("dni")
                End If

                vConexion.Close()
            End If
        End If
    End Sub

    Private Sub Btn_ModificarCliente_Click(sender As Object, e As EventArgs) Handles Btn_ModificarCliente.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        If Page.IsValid Then

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()


            vStringComando = "UPDATE Clientes set nombre = @nombre, apellido = @apellido, dni = @dni WHERE idCliente = @idCliente"

            vComando = New SqlCommand(vStringComando, vConexion)


            vComando.Parameters.AddWithValue("@nombre", Txt_NombreCliente.Text.Trim())
            vComando.Parameters.AddWithValue("@apellido", Txt_ApellidoCliente.Text.Trim())
            vComando.Parameters.AddWithValue("@dni", Txt_DniCliente.Text.Trim())
            vComando.Parameters.AddWithValue("@idCliente", Txt_id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarClientes.aspx")
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String

        If MsgBox("Está seguro que desea ELIMINAR el cliente?", vbYesNo, "Eliminar") = vbYes Then
            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "UPDATE Clientes set baja = 1 WHERE idCliente = @idCliente"

            vComando = New SqlCommand(vStringComando, vConexion)

            vComando.Parameters.AddWithValue("@idCliente", Txt_id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarClientes.aspx")
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarClientes.aspx")
    End Sub
End Class