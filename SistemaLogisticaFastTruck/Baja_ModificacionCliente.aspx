<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Baja_ModificacionCliente.aspx.vb" Inherits="SistemaLogisticaFastTruck.Baja_ModificacionCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css" />
    <title>Baja modificación cliente</title>
</head>
<body>
    <div  class=" display-3 d-flex">Modificar - Eliminar cliente</div>
    <div class="container">
        <form id="Form_Baja_Modificacion_Cliente" runat="server">
            <div class="row">
                <div class="col-sm- col-md-0 col-lg-3 col-xl-3"></div>
                <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6">
                    <asp:TextBox ID="Txt_id" ReadOnly="true" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Lb_NombreCliente" runat="server" Text="Nombre cliente:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_NombreCliente" ValidationGroup="baja_mod" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="baja_mod" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_NombreCliente"></asp:RequiredFieldValidator>
                    <asp:Label ID="Lb_ApellidoCliente" runat="server" Text="Apellido chofer:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_ApellidoCliente" ValidationGroup="baja_mod" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="baja_mod" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_ApellidoCliente"></asp:RequiredFieldValidator>
                    <asp:Label ID="Lb_DniCliente" runat="server" Text="Dni chofer:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_DniCliente" ValidationGroup="baja_mod" runat="server"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="baja_mod" runat="server" ControlToValidate="Txt_DniCliente" ErrorMessage="Formato incorrecto de dni"  ValidationExpression="^[0-9]{8}$"></asp:RegularExpressionValidator>
                    
                    <asp:Button class="btn btn-dark" ID="Btn_ModificarCliente" ValidationGroup="baja_mod" runat="server" Text="Modificar cliente" />
                    <asp:Button class="btn btn-dark" ID="Btn_Eliminar" ValidationGroup="baja_mod" runat="server" Text="Eliminar cliente" />
                    <asp:Button class="btn btn-dark" ID="Btn_Cancelar" runat="server" Text="Cancelar" />
                </div>
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"></div>
            </div>
        </form>
    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
