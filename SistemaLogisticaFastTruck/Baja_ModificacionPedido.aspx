<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Baja_ModificacionPedido.aspx.vb" Inherits="SistemaLogisticaFastTruck.Baja_ModificacionPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Baja Modificacion Pedido</title>
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css" />
</head>
<body>
    <div  class=" display-3">Modificar - Eliminar pedido</div><br /><br />

    <div class="container">
        <div class="row">
            <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"></div>
            <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6">
                <form id="Form_Baja_Modificacion_Pedido" runat="server">
                    <asp:TextBox ID="Txt_Id" runat="server" ReadOnly="true" style="display:none"></asp:TextBox><br />
                    <asp:Label ID="Lb_Detalle" runat="server" Text="Detalle pedido:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_Detalle" ValidationGroup="baja_mod" runat="server"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="baja_mod" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_Detalle"></asp:RequiredFieldValidator><br />
                    
                    <asp:Label ID="Lb_Cliente" runat="server" Text="Cliente:"></asp:Label>
                    <asp:DropDownList class="form-control" ID="DrpDw_Clientes" runat="server"></asp:DropDownList><br />

                    <asp:Label ID="Lb_DatosDireccion" runat="server" Text="Datos donde debe ser enviado el pedido:"></asp:Label><br />
                    <asp:Label ID="Lb_Direccion" runat="server" Text="Dirección"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_Direccion" ValidationGroup="baja_mod" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="baja_mod" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_Direccion"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Lb_Provincia" runat="server" Text="Provincia::"></asp:Label>
                    <asp:DropDownList class="form-control" ID="DrpDw_Provincias" AutoPostBack="true" runat="server"></asp:DropDownList><br />

                    <asp:Label ID="Lb_Ciudad" runat="server" Text="Ciudad:"></asp:Label><br />
                    <asp:DropDownList class="form-control" ID="DrpDw_Ciudades" runat="server"></asp:DropDownList>

                    <asp:Calendar ID="Cdr_FechaPedido" runat="server"></asp:Calendar>
                    <br />
                    <br />
                    <asp:Button class="btn btn-dark" ID="Btn_ModificarPedido" ValidationGroup="baja_mod" runat="server" Text="Modificar pedido" />
                    <asp:Button class="btn btn-dark" ID="Btn_EliminarPedido" ValidationGroup="baja_mod" runat="server" Text="Eliminar pedido" />
                    <asp:Button class="btn btn-dark" ID="Btn_Cancelar" runat="server" Text="Cancelar" />
                </form>
            </div>
            <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"></div>
        </div>
    </div>
   
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="Estilos/Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
