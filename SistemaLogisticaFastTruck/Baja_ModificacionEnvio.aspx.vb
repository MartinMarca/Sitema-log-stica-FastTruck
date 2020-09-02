Imports System.Data.SqlClient

Public Class Baja_ModificacionEnvio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idEnvio As Integer
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader
        Dim idCliente As String
        Dim idCiudad As String
        Dim idProvincia As String
        Dim idChofer As String
        Dim idCamion As String
        Dim nombreUsuario As String

        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try

        If Not IsPostBack Then

            If Request.QueryString("idparametro") <> "" Then
                idEnvio = Request.QueryString("idparametro")
                Txt_Id.Text = idEnvio

                vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
                vConexion.Open()

                vStringComando = "SELECT detalle, direccion, fechaEnvio, idCliente, idCiudad, idProvincia, idChofer, idCamion FROM Envios WHERE idEnvio = @idEnvio"
                vComando = New SqlCommand(vStringComando, vConexion)
                vComando.Parameters.AddWithValue("@idEnvio", Txt_Id.Text)

                vResultados = vComando.ExecuteReader
                If vResultados.Read() Then
                    Txt_Detalle.Text = vResultados("detalle")
                    Txt_Direccion.Text = vResultados("direccion")
                    Cdr_FechaEnvio.SelectedDate = vResultados("fechaEnvio")
                    idCliente = vResultados("idCliente")
                    idCiudad = vResultados("idCiudad")
                    idProvincia = vResultados("idProvincia")
                    idChofer = vResultados("idChofer")
                    idCamion = vResultados("idCamion")
                End If

                cargaDrpDwClientes()
                cargaDrpDwProvincias()
                cargaDrpDwCiudades()
                cargaDrpDwCamiones()
                cargaDrpDwChoferes()
                DrpDw_Ciudades.SelectedValue = idCiudad
                DrpDw_Clientes.SelectedValue = idCliente
                DrpDw_Provincias.SelectedValue = idProvincia
                DrpDw_Choferes.SelectedValue = idChofer
                DrpDw_Camiones.SelectedValue = idCamion
            End If
        End If
    End Sub

    Private Sub Btn_ModificarEnvio_Click(sender As Object, e As EventArgs) Handles Btn_ModificarEnvio.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        If Page.IsValid Then

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()


            vStringComando = "UPDATE Envios set idCliente=@idCliente, idCamion=@idCamion, idChofer=@idChofer, idCiudad=@idCiudad, 
                              idProvincia=@idProvincia, detalle=@detalle, direccion=@direccion, fechaEnvio=@fechaEnvio WHERE idEnvio = @idEnvio"


            vComando = New SqlCommand(vStringComando, vConexion)


            vComando.Parameters.AddWithValue("@idCliente", DrpDw_Clientes.SelectedValue)
            vComando.Parameters.AddWithValue("@idCamion", DrpDw_Camiones.SelectedValue)
            vComando.Parameters.AddWithValue("@idChofer", DrpDw_Choferes.SelectedValue)
            vComando.Parameters.AddWithValue("@idCiudad", DrpDw_Ciudades.SelectedValue)
            vComando.Parameters.AddWithValue("@idProvincia", DrpDw_Provincias.SelectedValue)
            vComando.Parameters.AddWithValue("@detalle", Txt_Detalle.Text.Trim())
            vComando.Parameters.AddWithValue("@direccion", Txt_Direccion.Text.Trim())
            vComando.Parameters.AddWithValue("@fechaEnvio", Cdr_FechaEnvio.SelectedDate)
            vComando.Parameters.AddWithValue("@idEnvio", Txt_Id.Text)

            vComando.ExecuteNonQuery()

            'dejan de estar disponibles el chofer y el camion que participan en el envio

            vStringComando = "UPDATE Choferes set disponible = 0 WHERE idChofer = @idChofer"
            vComando = New SqlCommand(vStringComando, vConexion)
            vComando.Parameters.AddWithValue("@idChofer", DrpDw_Choferes.SelectedValue)
            vComando.ExecuteNonQuery()


            vStringComando = "UPDATE Camiones set disponible = 0 WHERE idCamion = @idCamion"
            vComando = New SqlCommand(vStringComando, vConexion)
            vComando.Parameters.AddWithValue("@idCamion", DrpDw_Camiones.SelectedValue)
            vComando.ExecuteNonQuery()


            vConexion.Close()

            Response.Redirect("ListarEnvios.aspx")
        End If
    End Sub

    Private Sub Btn_EliminarEnvio_Click(sender As Object, e As EventArgs) Handles Btn_EliminarEnvio.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String

        If MsgBox("Está seguro que desea ELIMINAR el envío?", vbYesNo, "Eliminar") = vbYes Then
            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "UPDATE Envios set baja = 1 WHERE idEnvio = @idEnvio"

            vComando = New SqlCommand(vStringComando, vConexion)

            vComando.Parameters.AddWithValue("@idEnvio", Txt_Id.Text)

            vComando.ExecuteNonQuery()

            'vuelven a estar disponibles el chofer y el camion que participan en el envio

            vStringComando = "UPDATE Choferes set disponible = 1 WHERE idChofer = @idChofer"
            vComando = New SqlCommand(vStringComando, vConexion)
            vComando.Parameters.AddWithValue("@idChofer", DrpDw_Choferes.SelectedValue)
            vComando.ExecuteNonQuery()


            vStringComando = "UPDATE Camiones set disponible = 1 WHERE idCamion = @idCamion"
            vComando = New SqlCommand(vStringComando, vConexion)
            vComando.Parameters.AddWithValue("@idCamion", DrpDw_Camiones.SelectedValue)
            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarEnvios.aspx")
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarEnvios.aspx")
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

    Private Sub Btn_ConfirmarEntrega_Click(sender As Object, e As EventArgs) Handles Btn_ConfirmarEntrega.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String

        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "UPDATE Envios set confirmacionEntrega = 1 Where idEnvio = @idEnvio"

        vComando = New SqlCommand(vStringComando, vConexion)

        vComando.Parameters.AddWithValue("@idEnvio", Txt_Id.Text)

        vComando.ExecuteNonQuery()


        'vuelven a estar disponibles el chofer y el camion que participan en el envio

        vStringComando = "UPDATE Choferes set disponible = 1 WHERE idChofer = @idChofer"
        vComando = New SqlCommand(vStringComando, vConexion)
        vComando.Parameters.AddWithValue("@idChofer", DrpDw_Choferes.SelectedValue)
        vComando.ExecuteNonQuery()


        vStringComando = "UPDATE Camiones set disponible = 1 WHERE idCamion = @idCamion"
        vComando = New SqlCommand(vStringComando, vConexion)
        vComando.Parameters.AddWithValue("@idCamion", DrpDw_Camiones.SelectedValue)
        vComando.ExecuteNonQuery()

        vConexion.Close()

        Response.Redirect("ListarEnvios.aspx")
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
        If vResultados.Read() Then
            idCliente = vResultados("idCliente")
        End If
        DrpDw_Clientes.Items.Clear()
        vResultados.Close()
        vResultados = vComando.ExecuteReader
        While vResultados.Read()
            DrpDw_Clientes.Items.Add(New ListItem(vResultados("nombre") & ", " & vResultados("apellido"), vResultados("idCliente")))
        End While

        vConexion.Close()
        DrpDw_Clientes.SelectedValue = idCliente
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
        If vResultados.Read() Then
            idProvincia = vResultados("idProvincia")
        End If
        DrpDw_Provincias.Items.Clear()
        vResultados.Close()
        vResultados = vComando.ExecuteReader
        While vResultados.Read()
            DrpDw_Provincias.Items.Add(New ListItem(vResultados("nombreProvincia"), vResultados("idProvincia")))
        End While
        vConexion.Close()
        DrpDw_Provincias.SelectedValue = idProvincia
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
        If vResultados.Read() Then
            idCiudad = vResultados("idCiudad")
        End If
        DrpDw_Ciudades.Items.Clear()
        vResultados.Close()
        vResultados = vComando.ExecuteReader
        While vResultados.Read()
            DrpDw_Ciudades.Items.Add(New ListItem(vResultados("nombreCiudad"), vResultados("idCiudad")))
        End While
        vConexion.Close()
        DrpDw_Ciudades.SelectedValue = idCiudad
    End Function


    Function cargaDrpDwChoferes()
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader
        Dim idChofer As String
        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "SELECT idChofer, nombreChofer, apellidoChofer FROM Choferes WHERE baja = 0"

        vComando = New SqlCommand(vStringComando, vConexion)

        vResultados = vComando.ExecuteReader
        If vResultados.Read() Then
            idChofer = vResultados("idChofer")
        End If
        DrpDw_Choferes.Items.Clear()
        vResultados.Close()
        vResultados = vComando.ExecuteReader
        While vResultados.Read()
            DrpDw_Choferes.Items.Add(New ListItem(vResultados("nombreChofer") & ", " & vResultados("apellidoChofer"), vResultados("idChofer")))
        End While
        vConexion.Close()
        DrpDw_Choferes.SelectedValue = idChofer
    End Function

    Function cargaDrpDwCamiones()
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        Dim vResultados As SqlDataReader
        Dim idCamion As String
        vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
        vConexion.Open()

        vStringComando = "SELECT idCamion, modelo, patente FROM Camiones WHERE baja = 0"

        vComando = New SqlCommand(vStringComando, vConexion)

        vResultados = vComando.ExecuteReader
        If vResultados.Read() Then
            idCamion = vResultados("idCamion")
        End If
        DrpDw_Camiones.Items.Clear()
        vResultados.Close()
        vResultados = vComando.ExecuteReader
        While vResultados.Read()
            DrpDw_Camiones.Items.Add(New ListItem(vResultados("modelo") & ", patente: " & vResultados("patente"), vResultados("idCamion")))
        End While
        vConexion.Close()
        DrpDw_Camiones.SelectedValue = idCamion
    End Function

End Class