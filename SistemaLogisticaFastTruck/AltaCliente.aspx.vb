Imports System.Data.SqlClient

Public Class AltaCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nombreUsuario As String

        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try
    End Sub

    Private Sub Btn_AgregarCliente_Click(sender As Object, e As EventArgs) Handles Btn_AgregarCliente.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vResultados As SqlDataReader
        Dim vStringComando As String
        Dim dni As String
        If Page.IsValid Then
            dni = Txt_DniCliente.Text.Trim()

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "Select nombre From Clientes Where dni = @dni"
            vComando = New SqlCommand(vStringComando, vConexion)
            vComando.Parameters.AddWithValue("@dni", dni)
            vResultados = vComando.ExecuteReader
            If (Not vResultados.Read()) Then
                vResultados.Close()
                vStringComando = "Insert into Clientes (nombre, apellido, dni) values (@nombre, @apellido, @dni)"

                vComando = New SqlCommand(vStringComando, vConexion)


                vComando.Parameters.AddWithValue("@nombre", Txt_NombreCliente.Text.Trim())
                vComando.Parameters.AddWithValue("@apellido", Txt_ApellidoCliente.Text.Trim())
                vComando.Parameters.AddWithValue("@dni", dni)

                vComando.ExecuteNonQuery()


                Response.Redirect("ListarClientes.aspx")
            End If
            MsgBox("El cliente ya existe, por favor revise los datos.")
            vConexion.Close()
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarClientes.aspx")
    End Sub
End Class