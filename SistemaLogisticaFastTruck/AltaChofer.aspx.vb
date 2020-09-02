Imports System.Data.SqlClient

Public Class AltaChofer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nombreUsuario As String

        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try
    End Sub

    Private Sub Btn_AgregarChofer_Click(sender As Object, e As EventArgs) Handles Btn_AgregarChofer.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vResultados As SqlDataReader
        Dim vStringComando As String
        Dim dni As String
        If Page.IsValid Then
            dni = Txt_DniChofer.Text.Trim()

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "Select nombreChofer From Choferes Where dni = @dni"
            vComando = New SqlCommand(vStringComando, vConexion)
            vComando.Parameters.AddWithValue("@dni", dni)
            vResultados = vComando.ExecuteReader
            If (Not vResultados.Read()) Then
                vResultados.Close()
                vStringComando = "Insert into Choferes (nombreChofer, apellidoChofer, dni) values (@nombreChofer, @apellidoChofer, @dni)"

                vComando = New SqlCommand(vStringComando, vConexion)


                vComando.Parameters.AddWithValue("@nombreChofer", Txt_NombreChofer.Text.Trim())
                vComando.Parameters.AddWithValue("@apellidoChofer", Txt_ApellidoChofer.Text.Trim())
                vComando.Parameters.AddWithValue("@dni", dni)

                vComando.ExecuteNonQuery()


                Response.Redirect("ListarChoferes.aspx")
            End If
            MsgBox("El chofer ya existe, por favor revise los datos.")
            vConexion.Close()
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarChoferes.aspx")
    End Sub
End Class