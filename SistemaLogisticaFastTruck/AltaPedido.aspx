<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AltaPedido.aspx.vb" Inherits="SistemaLogisticaFastTruck.AltaPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div class="container">
        <form id="Form_AltaPedido" runat="server">
            <div class="row">
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"> </div>
                

                <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6">
                    <asp:Label ID="Lb_Detalle" runat="server" Text="Detalle pedido:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_Detalle" ValidationGroup="alta" runat="server"></asp:TextBox><br /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="alta" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_Detalle"></asp:RequiredFieldValidator>

                    <asp:Label ID="Lb_Cliente" runat="server" Text="Cliente:"></asp:Label><br />
                    <asp:DropDownList class="form-control" ID="DrpDw_Clientes" runat="server"></asp:DropDownList><asp:Label ID="Lb_InfoCliente" runat="server" Text="El cliente no se encuentra en la lista?"></asp:Label><br /><br />
                    <asp:Button class="btn btn-dark" ID="Btn_AgregarCliente" runat="server" Text="Agregar nuevo cliente" /><br />

                    <asp:Label ID="Lb_DatosDireccion" runat="server" Text="Datos donde debe ser enviado el pedido:"></asp:Label><br />
                    <asp:Label ID="Lb_Direccion" runat="server" Text="Dirección"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_Direccion" ValidationGroup="alta" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="alta" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_Direccion"></asp:RequiredFieldValidator>

                    <asp:Label ID="Lb_Provincia" runat="server" Text="Provincia:"></asp:Label><br />
                    <asp:DropDownList class="form-control" ID="DrpDw_Provincias" AutoPostBack="true" runat="server"></asp:DropDownList><asp:Label ID="Lb_InfoProvincia" runat="server" Text="La provincia no se encuentra en la lista?"></asp:Label><br /><br />
                    <asp:Button class="btn btn-dark" ID="Btn_AgregarProvincia" runat="server" Text="Agregar nueva provincia" /><br />

                    <asp:Label ID="Lb_Ciudad" runat="server" Text="Ciudad:"></asp:Label><br />
                    <asp:DropDownList class="form-control" ID="DrpDw_Ciudades" runat="server"></asp:DropDownList><asp:Label ID="Lb_InfoCiudad" runat="server" Text="La ciudad no se encuentra en la lista?"></asp:Label><br /><br />
                    <asp:Button class="btn btn-dark" ID="Btn_AgregarCiudad" runat="server" Text="Agregar nueva ciudad" />  <br /><br />

                    <asp:Calendar ID="Cdr_FechaPedido"  runat="server"></asp:Calendar> <br /><br />
                    <asp:Button class="btn btn-dark" ID="Btn_AgregarPedido" ValidationGroup="alta" runat="server" Text="Agregar pedido" />
                    <asp:Button class="btn btn-dark" ID="Btn_Cancelar" runat="server" Text="Cancelar" />
                </div>
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"> </div>

                
            </div>
        </form>
    </div>
    
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
