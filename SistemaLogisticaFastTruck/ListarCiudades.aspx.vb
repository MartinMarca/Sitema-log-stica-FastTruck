Imports System.Data.SqlClient

Public Class ListarCiudades
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "SELECT ci.idCiudad, ci.nombreCiudad, pr.nombreProvincia FROM Ciudades ci                           
                              INNER JOIN Provincias pr ON ci.idProvincia = pr.idProvincia WHERE ci.baja = 0;"

            vComando = New SqlCommand(vStringComando, vConexion)
            vResultados = vComando.ExecuteReader

            Rpt_Ciudad.DataSource = vResultados
            Rpt_Ciudad.DataBind()

            vConexion.Close()
        End If
    End Sub

End Class