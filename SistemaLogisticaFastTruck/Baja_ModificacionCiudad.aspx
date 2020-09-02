<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Baja_ModificacionCiudad.aspx.vb" Inherits="SistemaLogisticaFastTruck.Baja_ModificacionCiudad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css" />
    <title></title>
</head>
<body>
    <div class=" display-3 d-flex">Modificar - Eliminar ciudad</div>
    <div class="container">
        <form id="Form_Baja_Modificacion_Ciudad" runat="server">
            <div class="row">
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"> </div>             

                <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6">
                    <asp:TextBox ID="Txt_Id" ReadOnly="true" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Lb_Ciudad" runat="server" Text="Ciudad:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_Ciudad" ValidationGroup="baja_mod" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="baja_mod" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_Ciudad"></asp:RequiredFieldValidator>
                    <asp:DropDownList class="form-control" ID="DrpDw_Provincias" runat="server"></asp:DropDownList><br />
                    
                    
                    <asp:Button class="btn btn-dark" ID="Btn_ModificarCiudad" ValidationGroup="baja_mod" runat="server" Text="Modificar ciudad" />
                    <asp:Button class="btn btn-dark" ID="Btn_Eliminar" ValidationGroup="baja_mod" runat="server" Text="Eliminar ciudad" />
                    <asp:Button class="btn btn-dark" ID="Btn_Cancelar" runat="server" Text="Cancelar" />
                </div>
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"> </div>
            </div>
        </form>
    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="Estilos/Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
