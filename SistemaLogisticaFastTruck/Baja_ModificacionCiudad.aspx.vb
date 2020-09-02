Imports System.Data.SqlClient

Public Class Baja_ModificacionCiudad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idCiudad As String
        Dim idProvincia As String
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
            If Request.QueryString("idparametro") <> "" Then
                idCiudad = Request.QueryString("idparametro")
                Txt_Id.Text = idCiudad
                cargaDrpDwProvincias()

                vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
                vConexion.Open()
                vStringComando = "SELECT idProvincia, nombreCiudad FROM Ciudades WHERE idCiudad = @idCiudad"

                vComando = New SqlCommand(vStringComando, vConexion)
                vComando.Parameters.AddWithValue("@idCiudad", Txt_Id.Text)
                vResultados = vComando.ExecuteReader
                If vResultados.Read() Then
                    idProvincia = vResultados("idProvincia")
                    DrpDw_Provincias.SelectedValue = idProvincia
                    Txt_Ciudad.Text = vResultados("nombreCiudad")
                End If


                vConexion.Close()

            End If
        End If
    End Sub

    Private Sub Btn_ModificarCiudad_Click(sender As Object, e As EventArgs) Handles Btn_ModificarCiudad.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        If Page.IsValid Then

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()


            vStringComando = "UPDATE Ciudades set nombreCiudad = @nombreCiudad, idProvincia = @idProvincia WHERE idCiudad = @idCiudad"

            vComando = New SqlCommand(vStringComando, vConexion)


            vComando.Parameters.AddWithValue("@nombreCiudad", Txt_Ciudad.Text.Trim())
            vComando.Parameters.AddWithValue("@idProvincia", DrpDw_Provincias.SelectedValue)
            vComando.Parameters.AddWithValue("@idCiudad", Txt_Id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarCiudades.aspx")
        End If
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String

        If MsgBox("Está seguro que desea ELIMINAR la ciudad?", vbYesNo, "Eliminar") = vbYes Then
            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "UPDATE Ciudades set baja = 1 WHERE idCiudad = @idCiudad"

            vComando = New SqlCommand(vStringComando, vConexion)

            vComando.Parameters.AddWithValue("@idCiudad", Txt_Id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarCiudades.aspx")
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
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