Imports System.Data.SqlClient
Public Class AltaPedido
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

    Function cargaDrpDwClientes()
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "SELECT idCliente, nombre, apellido FROM Clientes WHERE baja = 0"

        vComando = New SqlCommand(vStringComando, vConexion)
        vResultados = vComando.ExecuteReader

        DrpDw_Clientes.Items.Clear()

        While vResultados.Read()
            DrpDw_Clientes.Items.Add(New ListItem(vResultados("nombre") & ", " & vResultados("apellido"), vResultados("idCliente")))
        End While
        vConexion.Close()
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
        vResultados = vComando.ExecuteReader

        DrpDw_Provincias.Items.Clear()
        While vResultados.Read()
            DrpDw_Provincias.Items.Add(New ListItem(vResultados("nombreProvincia"), vResultados("idProvincia")))
        End While
        vConexion.Close()
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
        vResultados = vComando.ExecuteReader

        DrpDw_Ciudades.Items.Clear()
        While vResultados.Read()
            DrpDw_Ciudades.Items.Add(New ListItem(vResultados("nombreCiudad"), vResultados("idCiudad")))
        End While
        vConexion.Close()
    End Function

    Private Sub Btn_AgregarCiudad_Click(sender As Object, e As EventArgs) Handles Btn_AgregarCiudad.Click
        Response.Redirect("AltaCiudad.aspx")
    End Sub

    Private Sub Btn_AgregarCliente_Click(sender As Object, e As EventArgs) Handles Btn_AgregarCliente.Click
        Response.Redirect("AltaCliente.aspx")
    End Sub

    Private Sub Btn_AgregarProvincia_Click(sender As Object, e As EventArgs) Handles Btn_AgregarProvincia.Click
        Response.Redirect("AltaProvincia.aspx")
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarPedidos.aspx")
    End Sub

    Private Sub Btn_AgregarPedido_Click(sender As Object, e As EventArgs) Handles Btn_AgregarPedido.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        If Page.IsValid Then

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()


            vStringComando = "Insert into Pedidos (idCliente, detalle, idCiudad, idProvincia, direccion, fechaPedido) 
                              values (@idCliente, @detalle, @idCiudad, @idProvincia, @direccion, @fechaPedido)"

            vComando = New SqlCommand(vStringComando, vConexion)


            vComando.Parameters.AddWithValue("@idCliente", DrpDw_Clientes.SelectedValue)
            vComando.Parameters.AddWithValue("@idCiudad", DrpDw_Ciudades.SelectedValue)
            vComando.Parameters.AddWithValue("@idProvincia", DrpDw_Provincias.SelectedValue)
            vComando.Parameters.AddWithValue("@detalle", Txt_Detalle.Text.Trim())
            vComando.Parameters.AddWithValue("@direccion", Txt_Direccion.Text.Trim())
            vComando.Parameters.AddWithValue("@fechaPedido", Cdr_FechaPedido.SelectedDate)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarPedidos.aspx")
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

        vStringComando = "SELECT idCiudad, nombreCiudad FROM Ciudades WHERE idProvincia = @idProvincia"

        vComando = New SqlCommand(vStringComando, vConexion)
        vComando.Parameters.AddWithValue("@idProvincia", idProvincia)
        vResultados = vComando.ExecuteReader

        DrpDw_Ciudades.Items.Clear()
        While vResultados.Read()
            DrpDw_Ciudades.Items.Add(New ListItem(vResultados("nombreCiudad"), vResultados("idCiudad")))
        End While
        vConexion.Close()

    End Sub
End Class