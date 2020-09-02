<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Baja_ModificacionCamion.aspx.vb" Inherits="SistemaLogisticaFastTruck.Baja_ModificacionCamion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css" />
    <title></title>
</head>
<body>
    <div  class="display-3 d-flex">Modificar - Eliminar camión</div>
    <div class="container">
         <form id="Form_Baja_Modificacion_Camion" runat="server">
                <div class="row">
                    <div class="col-sm- col-md-0 col-lg-3 col-xl-3"></div>
                        <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6">
                            <asp:TextBox ID="Txt_id" ReadOnly="true" runat="server"></asp:TextBox><br />
                            <asp:Label ID="Lb_Modelo" runat="server" Text="Modelo:"></asp:Label><br />
                            <asp:TextBox class="form-control" ID="Txt_Modelo" ValidationGroup="baja_mod" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="baja_mod" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_Modelo"></asp:RequiredFieldValidator>
                            <asp:Label ID="Lb_Patente" runat="server" Text="Patente:"></asp:Label><br />
                            <asp:TextBox class="form-control" ID="Txt_Patente" ValidationGroup="baja_mod" runat="server"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="baja_mod" runat="server" ControlToValidate="Txt_Patente" ErrorMessage="Formato incorrecto de patente"  ValidationExpression="^[a-z A-Z]{2}[0-9]{3}[a-z A-Z]{2}$"></asp:RegularExpressionValidator>
                    
                    
                            <asp:Button class="btn btn-dark" ID="Btn_ModificarCamion" ValidationGroup="baja_mod" runat="server" Text="Modificar camión" />
                            <asp:Button class="btn btn-dark" ID="Btn_Eliminar" ValidationGroup="baja_mod" runat="server" Text="Eliminar camión" />
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
