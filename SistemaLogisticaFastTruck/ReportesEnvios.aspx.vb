Imports System.Data.SqlClient
Public Class ReportesEnvios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nombreUsuario As String

        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try

        If Not IsPostBack Then
            cargaDrpDwClientes()
            cargaDrpDwProvincias()
            cargaDrpDwCiudades()
            cargaDrpDwCamiones()
            cargaDrpDwChoferes()

            DrpDw_EstadoEntrega.Items.Add(New ListItem("Seleccionar", 2))
            DrpDw_EstadoEntrega.Items.Add(New ListItem("No entregados", 0))
            DrpDw_EstadoEntrega.Items.Add(New ListItem("Entregados", 1))
        End If

    End Sub

    Private Sub DrpDw_Provincias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DrpDw_Provincias.SelectedIndexChanged
        Dim idProvincia As Integer

        idProvincia = DrpDw_Provincias.SelectedValue

        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader
        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "SELECT idCiudad, nombreCiudad FROM Ciudades WHERE idProvincia = @idProvincia AND baja = 0"

        vComando = New SqlCommand(vStringComando, vConexion)
        vComando.Parameters.AddWithValue("@idProvincia", idProvincia)
        vResultados = vComando.ExecuteReader

        DrpDw_Ciudades.Items.Clear()
        DrpDw_Ciudades.Items.Add(New ListItem("Seleccionar", 0))

        While vResultados.Read()
            DrpDw_Ciudades.Items.Add(New ListItem(vResultados("nombreCiudad"), vResultados("idCiudad")))
        End While
        vConexion.Close()
    End Sub

    Private Sub Btn_Volver_Click(sender As Object, e As EventArgs) Handles Btn_Volver.Click
        Response.Redirect("Inicio.aspx")
    End Sub

    Private Sub Btn_SolicitarReporte_Click(sender As Object, e As EventArgs) Handles Btn_SolicitarReporte.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = armarConsultaSQL()

        vComando = New SqlCommand(vStringComando, vConexion)
        vResultados = vComando.ExecuteReader

        Rpt_ReporteEnvio.DataSource = vResultados
        Rpt_ReporteEnvio.DataBind()

        vConexion.Close()
    End Sub

    Private Sub Btn_LimpiarFiltros_Click(sender As Object, e As EventArgs) Handles Btn_LimpiarFiltros.Click
        DrpDw_Ciudades.SelectedValue = 0
        DrpDw_Clientes.SelectedValue = 0
        DrpDw_Provincias.SelectedValue = 0
        DrpDw_Choferes.SelectedValue = 0
        DrpDw_Camiones.SelectedValue = 0
        Fecha1.Value = ""
        Fecha2.Value = ""
    End Sub

    Function armarConsultaSQL()
        Dim consulta As String
        consulta = ""

        consulta = "SELECT  en.idEnvio, en.detalle, cl.nombre, cl.apellido, cl.dni, en.direccion, ci.nombreCiudad, pr.nombreProvincia, 
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
                            ON en.idProvincia = pr.idProvincia WHERE en.baja = 0"

        If DrpDw_Clientes.SelectedValue <> "0" Then
            consulta += " AND en.idCliente = '" + DrpDw_Clientes.SelectedValue + "'"
        End If

        If DrpDw_Provincias.SelectedValue <> "0" Then
            consulta += " AND en.idProvincia = '" + DrpDw_Provincias.SelectedValue + "'"
        End If

        If DrpDw_Ciudades.SelectedValue <> "0" Then
            consulta += " AND en.idCiudad = '" + DrpDw_Ciudades.SelectedValue + "'"
        End If

        If DrpDw_Choferes.SelectedValue <> "0" Then
            consulta += " AND en.idChofer = '" + DrpDw_Choferes.SelectedValue + "'"
        End If

        If DrpDw_Camiones.SelectedValue <> "0" Then
            consulta += " AND en.idCamion = '" + DrpDw_Camiones.SelectedValue + "'"
        End If

        If DrpDw_EstadoEntrega.SelectedValue <> "2" Then
            consulta += " AND en.confirmacionEntrega = '" + DrpDw_EstadoEntrega.SelectedValue + "'"
        End If

        If Fecha1.Value <> "" And Fecha2.Value <> "" Then
            consulta += " AND fechaEnvio Between '" + CDate(Fecha1.Value) + "' AND '" + CDate(Fecha2.Value) + "'"
        End If

        Return consulta
    End Function

    Function cargaDrpDwClientes()
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "SELECT idCliente, nombre, apellido FROM Clientes WHERE baja = 0"
        vComando = New SqlCommand(vStringComando, vConexion)

        DrpDw_Clientes.Items.Clear()
        DrpDw_Clientes.Items.Add(New ListItem("Seleccionar", 0))

        vResultados = vComando.ExecuteReader
        While vResultados.Read()
            DrpDw_Clientes.Items.Add(New ListItem(vResultados("nombre") & ", " & vResultados("apellido"), vResultados("idCliente")))
        End While

        vConexion.Close()
        DrpDw_Clientes.SelectedValue = 0
    End Function

    Function cargaDrpDwProvincias()
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "SELECT idProvincia, nombreProvincia FROM Provincias WHERE baja = 0"

        vComando = New SqlCommand(vStringComando, vConexion)

        DrpDw_Provincias.Items.Clear()
        DrpDw_Provincias.Items.Add(New ListItem("Seleccionar", 0))

        vResultados = vComando.ExecuteReader
        While vResultados.Read()
            DrpDw_Provincias.Items.Add(New ListItem(vResultados("nombreProvincia"), vResultados("idProvincia")))
        End While
        vConexion.Close()
        DrpDw_Provincias.SelectedValue = 0
    End Function


    Function cargaDrpDwCiudades()
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "SELECT idCiudad, nombreCiudad FROM Ciudades WHERE baja = 0"

        vComando = New SqlCommand(vStringComando, vConexion)

        DrpDw_Ciudades.Items.Clear()
        DrpDw_Ciudades.Items.Add(New ListItem("Seleccionar", 0))

        vResultados = vComando.ExecuteReader
        While vResultados.Read()
            DrpDw_Ciudades.Items.Add(New ListItem(vResultados("nombreCiudad"), vResultados("idCiudad")))
        End While
        vConexion.Close()
        DrpDw_Ciudades.SelectedValue = 0
    End Function


    Function cargaDrpDwChoferes()
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "SELECT idChofer, nombreChofer, apellidoChofer FROM Choferes WHERE baja = 0"

        vComando = New SqlCommand(vStringComando, vConexion)

        DrpDw_Choferes.Items.Clear()
        DrpDw_Choferes.Items.Add(New ListItem("Seleccionar", 0))

        vResultados = vComando.ExecuteReader
        While vResultados.Read()
            DrpDw_Choferes.Items.Add(New ListItem(vResultados("nombreChofer") & ", " & vResultados("apellidoChofer"), vResultados("idChofer")))
        End While
        vConexion.Close()
        DrpDw_Choferes.SelectedValue = 0
    End Function

    Function cargaDrpDwCamiones()
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "SELECT idCamion, modelo, patente FROM Camiones WHERE baja = 0"

        vComando = New SqlCommand(vStringComando, vConexion)

        DrpDw_Camiones.Items.Clear()
        DrpDw_Camiones.Items.Add(New ListItem("Seleccionar", 0))

        vResultados = vComando.ExecuteReader
        While vResultados.Read()
            DrpDw_Camiones.Items.Add(New ListItem(vResultados("modelo") & ", patente: " & vResultados("patente"), vResultados("idCamion")))
        End While
        vConexion.Close()
        DrpDw_Camiones.SelectedValue = 0
    End Function

End Class