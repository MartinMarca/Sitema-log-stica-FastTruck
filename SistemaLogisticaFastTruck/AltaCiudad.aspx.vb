Imports System.Data.SqlClient

Public Class AltaCiudad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nombreUsuario As String

        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try

        If Not IsPostBack Then
            cargaDrpDwProvincias()
        End If

    End Sub

    Private Sub Btn_AgregarProvincia_Click(sender As Object, e As EventArgs) Handles Btn_AgregarProvincia.Click
        Response.Redirect("AltaProvincia.aspx")
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarProvincias.aspx")
    End Sub

    Private Sub Btn_AgregarCiudad_Click(sender As Object, e As EventArgs) Handles Btn_AgregarCiudad.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()
        vStringComando = "INSERT INTO Ciudades (nombreCiudad, idProvincia) values(@nombreCiudad, @idProvincia)"
        vComando = New SqlCommand(vStringComando, vConexion)

        vComando.Parameters.AddWithValue("@nombreCiudad", Txt_Ciudad.Text.Trim())
        vComando.Parameters.AddWithValue("@idProvincia", DrpDw_Provincias.SelectedValue)

        vComando.ExecuteNonQuery()
        vConexion.Close()
        Response.Redirect("ListarCiudades.aspx")
    End Sub

    Function cargaDrpDwProvincias()
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()
        vStringComando = "SELECT idProvincia, nombreProvincia FROM Provincias WHERE baja = 0"

        vComando = New SqlCommand(vStringComando, vConexion)
        vResultados = vComando.ExecuteReader

        DrpDw_Provincias.Items.Clear()
        While vResultados.Read()
            DrpDw_Provincias.Items.Add(New ListItem(vResultados("nombreProvincia"), vResultados("idProvincia")))
        End While
        vConexion.Close()
    End Function
End Class