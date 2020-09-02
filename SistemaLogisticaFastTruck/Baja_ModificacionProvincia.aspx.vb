Imports System.Data.SqlClient

Public Class Baja_ModificacionProvincia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idProvincia As String
        Dim nombreUsuario As String

        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try

        If Not IsPostBack Then
            If Request.QueryString("idparametro") <> "" Then
                idProvincia = Request.QueryString("idparametro")
                Txt_id.Text = idProvincia
                cargaDrpDwProvincias()
                DrpDw_Provincia.SelectedValue = Txt_id.Text
            End If
        End If

    End Sub

    Private Sub Btn_ModificarProvincia_Click(sender As Object, e As EventArgs) Handles Btn_ModificarProvincia.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String
        If Page.IsValid Then

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()


            vStringComando = "UPDATE Provincias set idProvincia = @idProvincia, nombreProvincia = @nombreProvincia WHERE idProvincia = @idProvincia"

            vComando = New SqlCommand(vStringComando, vConexion)


            vComando.Parameters.AddWithValue("@idProvincia", DrpDw_Provincia.SelectedValue)
            vComando.Parameters.AddWithValue("@nombreProvincia", DrpDw_Provincia.SelectedItem.ToString())
            vComando.Parameters.AddWithValue("@idProvincia", Txt_id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarProvincias.aspx")
        End If
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vStringComando As String

        If MsgBox("Está seguro que desea ELIMINAR la provincia?", vbYesNo, "Eliminar") = vbYes Then
            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "UPDATE Provincias set baja = 1 WHERE idProvincia = @idProvincia"

            vComando = New SqlCommand(vStringComando, vConexion)

            vComando.Parameters.AddWithValue("@idProvincia", Txt_id.Text)

            vComando.ExecuteNonQuery()

            vConexion.Close()

            Response.Redirect("ListarProvincias.aspx")
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarProvincias.aspx")
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

        DrpDw_Provincia.Items.Clear()
        While vResultados.Read()
            DrpDw_Provincia.Items.Add(New ListItem(vResultados("nombreProvincia"), vResultados("idProvincia")))
        End While


        vConexion.Close()
    End Function

End Class