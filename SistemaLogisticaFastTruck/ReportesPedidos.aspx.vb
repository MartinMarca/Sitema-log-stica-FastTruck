Imports System.Data.SqlClient
Public Class ReportesPedidos
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
        End If

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

        Rpt_ReportePedido.DataSource = vResultados
        Rpt_ReportePedido.DataBind()

        vConexion.Close()
    End Sub

    Function armarConsultaSQL()
        Dim consulta As String
        consulta = ""

        consulta = "SELECT pe.idPedido, pe.detalle, cl.nombre, cl.apellido, pe.direccion, ci.nombreCiudad, pr.nombreProvincia, pe.fechaPedido
                                FROM Pedidos pe
                                INNER JOIN Clientes cl
                                ON pe.idCliente = cl.idCliente
                                INNER JOIN Ciudades ci
                                ON pe.idCiudad = ci.idCiudad
                                INNER JOIN Provincias pr
                                ON pe.idProvincia = pr.idProvincia WHERE pe.baja = 0"

        If DrpDw_Clientes.SelectedValue <> "0" Then
            consulta += " AND pe.idCliente = '" + DrpDw_Clientes.SelectedValue + "'"
        End If

        If DrpDw_Provincias.SelectedValue <> "0" Then
            consulta += " AND pe.idProvincia = '" + DrpDw_Provincias.SelectedValue + "'"
        End If

        If DrpDw_Ciudades.SelectedValue <> "0" Then
            consulta += " AND pe.idCiudad = '" + DrpDw_Ciudades.SelectedValue + "'"
        End If

        If Fecha1.Value <> "" And Fecha2.Value <> "" Then
            consulta += " AND fechaPedido Between '" + CDate(Fecha1.Value) + "' AND '" + CDate(Fecha2.Value) + "'"
        End If

        Return consulta
    End Function

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

    Private Sub Btn_LimpiarFiltros_Click(sender As Object, e As EventArgs) Handles Btn_LimpiarFiltros.Click
        DrpDw_Ciudades.SelectedValue = 0
        DrpDw_Clientes.SelectedValue = 0
        DrpDw_Provincias.SelectedValue = 0
        Fecha1.Value = ""
        Fecha2.Value = ""
    End Sub
End Class