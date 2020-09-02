Imports System.Data.SqlClient

Public Class ListarEnvios
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

            vStringComando = "SELECT  en.idEnvio, en.detalle, cl.nombre, cl.apellido, cl.dni, en.direccion, ci.nombreCiudad, pr.nombreProvincia, 
		                    ca.patente, ca.modelo, ch.nombreChofer, ch.apellidoChofer, en.confirmacionEntrega, en.fechaEnvio
                            FROM Envios en
                            INNER JOIN Clientes cl
                            ON en.idCliente = cl.idCliente
                            INNER JOIN Camiones ca
                            ON en.idCamion = ca.idCamion
                            INNER JOIN Choferes ch
                            ON en.idChofer = ch.idChofer
                            INNER JOIN Ciudades ci
                            ON en.idCiudad = ci.idCiudad
                            INNER JOIN Provincias pr
                            ON en.idProvincia = pr.idProvincia WHERE en.baja = 0;"

            vComando = New SqlCommand(vStringComando, vConexion)
            vResultados = vComando.ExecuteReader

            Rpt_Envio.DataSource = vResultados
            Rpt_Envio.DataBind()

            vConexion.Close()
        End If
    End Sub


End Class