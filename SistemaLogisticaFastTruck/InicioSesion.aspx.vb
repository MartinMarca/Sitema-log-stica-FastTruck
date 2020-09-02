Imports System.Data.SqlClient
Public Class InicioSesion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim men As String

        If Request.QueryString("men") <> "" Then
            men = Request.QueryString("men")
            If men = "1" Then
                Lb_InfoAlUsuario.Text = "Debe iniciar sesión"
            End If
        End If
    End Sub

    Private Sub Btn_Ingresar_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar.Click
        Dim nombreUsuario As String
        Dim contrasenia As String

        nombreUsuario = Txt_NombreUsuario.Text
        contrasenia = Imp_Password.Value

        If existeUsuario(nombreUsuario, contrasenia) Then
            Session.Add("nombreUsuario", nombreUsuario)
            Response.Redirect("Inicio.aspx")
        Else
            Lb_InfoAlUsuario.Text = "El usuario o la contraseña son incorrectos!"
        End If

    End Sub

    Function existeUsuario(nombreUsuario As String, contrasenia As String)
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader
        Dim existe As Boolean

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "SELECT nombreDeUsuario, contrasenia FROM Usuarios WHERE nombreDeUsuario = @nombreDeUsuario and contrasenia = @contrasenia"

        vComando = New SqlCommand(vStringComando, vConexion)
        vComando.Parameters.AddWithValue("@nombreDeUsuario", nombreUsuario)
        vComando.Parameters.AddWithValue("@contrasenia", contrasenia)
        vResultados = vComando.ExecuteReader
        existe = vResultados.Read()

        vConexion.Close()

        Return existe
    End Function
End Class