Imports System.Data.SqlClient
Public Class ListarPedidos
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

            vStringComando = "SELECT pe.idPedido, pe.detalle, cl.nombre, cl.apellido, pe.direccion, ci.nombreCiudad, pr.nombreProvincia, pe.fechaPedido
                                FROM Pedidos pe
                                INNER JOIN Clientes cl
                                ON pe.idCliente = cl.idCliente
                                INNER JOIN Ciudades ci
                                ON pe.idCiudad = ci.idCiudad
                                INNER JOIN Provincias pr
                                ON pe.idProvincia = pr.idProvincia WHERE pe.baja = 0;"

            vComando = New SqlCommand(vStringComando, vConexion)
            vResultados = vComando.ExecuteReader

            Rpt_Pedido.DataSource = vResultados
            Rpt_Pedido.DataBind()

            vConexion.Close()
        End If
    End Sub

End Class