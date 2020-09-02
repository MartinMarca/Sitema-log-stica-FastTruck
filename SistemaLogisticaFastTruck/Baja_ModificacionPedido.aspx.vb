Imports System.Data.SqlClient

Public Class Baja_ModificacionPedido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idPedido As Integer
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader
        Dim idCliente As String
        Dim idCiudad As String
        Dim idProvincia As String
        Dim nombreUsuario As String

        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try

        If Not IsPostBack Then

            If Request.QueryString("idparametro") <> "" Then
                idPedido = Request.QueryString("idparametro")
                Txt_Id.Text = idPedido

                vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
                vConexion.Open()

                vStringComando = "SELECT detalle, direccion, fechaPedido, idCliente, idCiudad, idProvincia FROM Pedidos WHERE idPedido = @idPedido"
                vComando = New SqlCommand(vStringComando, vConexion)
                vComando.Parameters.AddWithValue("@idPedido", Txt_Id.Text)

                vResultados = vComando.ExecuteReader
                If vResultados.Read() Then
                    Txt_Detalle.Text = vResultados("detalle")
                    Txt_Direccion.Text = vResultados("direccion")
                    Cdr_FechaPedido.SelectedDate = vResultados("fechaPedido")
                    idCliente = vResultados("idCliente")
                    idCiudad = vResultados("idCiudad")
                    idProvincia = vResultados("idProvincia")
                End If

                cargaDrpDwClientes()
                cargaDrpDwProvincias()
                cargaDrpDwCiudades()
                DrpDw_Ciudades.SelectedValue = idCiudad
                DrpDw_Clientes.SelectedValue = idCliente
                DrpDw_Provincias.SelectedValue = idProvincia

            End If
        End If
    End Sub

    Private Sub Btn_ModificarPedido_Click(sender As Object, e As EventArgs) Handles Btn_ModificarPedido.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        If Page.IsValid Then

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            'Pais.Text = "'); Drop table Paises; Select ('"
            vStringComando = "UPDATE Pedidos set idCliente=@idCliente, detalle=@detalle, idCiudad=@idCiudad, idProvincia=@idProvincia, 
                              direccion=@direccion, fechaPedido=@fechaPedido WHERE idPedido = @idPedido"

            vComando = New SqlCommand(vStringComando, vConexion)


            vComando.Parameters.AddWithValue("@idCliente", DrpDw_Clientes.SelectedValue)
            vComando.Parameters.AddWithValue("@idCiudad", DrpDw_Ciudades.SelectedValue)
            vComando.Parameters.AddWithValue("@idProvincia", DrpDw_Provincias.SelectedValue)
            vComando.Parameters.AddWithValue("@detalle", Txt_Detalle.Text.Trim())
            vComando.Parameters.AddWithValue("@direccion", Txt_Direccion.Text.Trim())
            vComando.Parameters.AddWithValue("@fechaPedido", Cdr_FechaPedido.SelectedDate)
            vComando.Parameters.AddWithValue("@idPedido", Txt_Id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarPedidos.aspx")
        End If
    End Sub

    Private Sub Btn_EliminarPedido_Click(sender As Object, e As EventArgs) Handles Btn_EliminarPedido.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String

        If MsgBox("Está seguro que desea ELIMINAR el pedido?", vbYesNo, "Eliminar") = vbYes Then
            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "UPDATE Pedidos set baja = 1 WHERE idPedido = @idPedido"

            vComando = New SqlCommand(vStringComando, vConexion)

            vComando.Parameters.AddWithValue("@idPedido", Txt_Id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarPedidos.aspx")
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarPedidos.aspx")
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
        While vResultados.Read()
            DrpDw_Ciudades.Items.Add(New ListItem(vResultados("nombreCiudad"), vResultados("idCiudad")))
        End While
        vConexion.Close()
    End Sub

    Function cargaDrpDwClientes()
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader
        Dim idCliente As String

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
        Dim idProvincia As String

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
        Dim idCiudad As String
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
End Class