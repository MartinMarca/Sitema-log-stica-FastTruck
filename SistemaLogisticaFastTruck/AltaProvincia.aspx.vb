Imports System.Data.SqlClient

Public Class AltaProvincia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nombreUsuario As String

        Try
            nombreUsuario = Session("nombreUsuario").ToString()
        Catch ex As Exception
            Response.Redirect("InicioSesion.aspx?men=1")
        End Try

        If Not IsPostBack Then
            DrpDw_Provincia.Items.Add(New ListItem("Cordoba", 1))
            DrpDw_Provincia.Items.Add(New ListItem("Santa FE", 2))
            DrpDw_Provincia.Items.Add(New ListItem("Corrientes", 3))
            DrpDw_Provincia.Items.Add(New ListItem("Chaco", 4))
            DrpDw_Provincia.Items.Add(New ListItem("Entre Rios", 5))
            DrpDw_Provincia.Items.Add(New ListItem("Formosa", 6))
            DrpDw_Provincia.Items.Add(New ListItem("Misiones", 7))
            DrpDw_Provincia.Items.Add(New ListItem("Sgo. del Estero", 8))
            DrpDw_Provincia.Items.Add(New ListItem("Jujuy", 9))
            DrpDw_Provincia.Items.Add(New ListItem("Salta", 10))
            DrpDw_Provincia.Items.Add(New ListItem("Catamarca", 11))
            DrpDw_Provincia.Items.Add(New ListItem("La Rioja", 12))
            DrpDw_Provincia.Items.Add(New ListItem("Tucumán", 13))
            DrpDw_Provincia.Items.Add(New ListItem("San Juan", 14))
            DrpDw_Provincia.Items.Add(New ListItem("Mendoza", 15))
            DrpDw_Provincia.Items.Add(New ListItem("San Luis", 16))
            DrpDw_Provincia.Items.Add(New ListItem("La Pampa", 17))
            DrpDw_Provincia.Items.Add(New ListItem("Buenos Aires", 18))
            DrpDw_Provincia.Items.Add(New ListItem("C.A.B.A.", 19))
            DrpDw_Provincia.Items.Add(New ListItem("Rio Negro", 20))
            DrpDw_Provincia.Items.Add(New ListItem("Neuquen", 21))
            DrpDw_Provincia.Items.Add(New ListItem("Chubut", 22))
            DrpDw_Provincia.Items.Add(New ListItem("Santa Cruz", 23))
            DrpDw_Provincia.Items.Add(New ListItem("Tierra del Fuego", 24))
        End If



    End Sub

    Private Sub Btn_AgregarProvincia_Click(sender As Object, e As EventArgs) Handles Btn_AgregarProvincia.Click
        Dim vConexion As SqlConnection
        Dim vComando As SqlCommand
        Dim vResultados As SqlDataReader
        Dim vStringComando As String
        Dim provincia As String
        If Page.IsValid Then
            provincia = DrpDw_Provincia.SelectedItem.ToString()

            vConexion = New SqlConnection(ConfigurationManager.AppSettings("StringDeConexion"))
            vConexion.Open()

            vStringComando = "Select nombreProvincia From Provincias Where nombreProvincia = @nombreProvincia"
            vComando = New SqlCommand(vStringComando, vConexion)
            vComando.Parameters.AddWithValue("@nombreProvincia", provincia)
            vResultados = vComando.ExecuteReader
            If (Not vResultados.Read()) Then
                vResultados.Close()
                vStringComando = "Insert into Provincias (nombreProvincia) values (@nombreProvincia)"

                vComando = New SqlCommand(vStringComando, vConexion)


                vComando.Parameters.AddWithValue("@nombreProvincia", DrpDw_Provincia.SelectedItem.ToString())

                vComando.ExecuteNonQuery()


                Response.Redirect("ListarProvincias.aspx")
            End If
            MsgBox("La provincia ya existe, por favor revise los datos.")
            vConexion.Close()
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Response.Redirect("ListarProvincias.aspx")
    End Sub
End Class